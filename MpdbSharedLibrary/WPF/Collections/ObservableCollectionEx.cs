using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;
using System.Windows.Threading;
using System.Collections.Specialized;
using System.Collections;

namespace MpdBaileyTechnology.Shared.WPF.Collections
{
    /// <summary>
    /// A fast, efficient and thread safe ObservableCollection for use in WPF projects
    /// 
    /// Based on code from
    /// http://stackoverflow.com/questions/7687000/fast-performing-and-thread-safe-observable-collection
    /// 
    /// Also see:
    /// http://geekswithblogs.net/NewThingsILearned/archive/2008/01/16/have-worker-thread-update-observablecollection-that-is-bound-to-a.aspx
    /// 
    /// While playing around with WPF, I tried to do some multithreading where I have a worker thread updating my ObservableCollection, while having a ListCollectionView of that ObservableCollection being shown on a ListBox.
    /// It was surprising to see that I get a NotSupportedException thrown, with the message saying 'This type of CollectionView does not support changes to its SourceCollection from a thread different from the Dispatcher thread.'.  That doesn't seem to make sense - In my mind, I understand how the thread that created the UI should be the one that handles all UI updates.  However, the data itself should be able to reside anywhere, and I should be able to update it however and whenever I want.
    /// Looking for a solution, I created a class deriving from ObservableCollection (the class name I chose is ObservableCollectionEx) thinking that I would just manually walk through the event's invocation list.  Well, that didn't quite work, since events are not accessible (other than for adding/removing delegates) to child classes.  Looking at the documentation, the CollectionChanged event in ObservableCollection is virtual - that means I can override it! Yeah!  I am glad someone at Microsoft decided to make that virtual.
    /// So here's the code that I created - the pain is I now have to rename all occurrences of ObservableCollection to this new class.  Oh well, at least making it work with threads isn't too painful. 
    /// 
    /// </summary>
    /// <typeparam name="T">Type of the objects to be stored</typeparam>
    public class ObservableCollectionEx<T> : ObservableCollection<T>
    {
        /// <summary>
        /// This private variable holds the flag to
        /// turn on and off the collection changed notification.
        /// </summary>
        private bool suspendCollectionChangeNotification = false;

        /// <summary>
        /// This event is overriden CollectionChanged event of the observable collection.
        /// </summary>
        public override event NotifyCollectionChangedEventHandler CollectionChanged;

        /// <summary>
        /// This method adds the given generic list of items
        /// as a range into current collection by casting them as type T.
        /// It then notifies once after all items are added.
        /// </summary>
        /// <param name="items">The source collection.</param>
        public void AddItems(IList items)
        {
            this.SuspendCollectionChangeNotification();
            try
            {
                foreach (var i in items)
                {
                    InsertItem(Count, (T)i);
                }
            }
            catch (Exception ex)
            {
                throw new InvalidCastException("Please check the type of item.", ex);
            }
            finally
            {
                this.NotifyChanges();
            }
        }

        /// <summary>
        /// Raises collection change event.
        /// </summary>
        public void NotifyChanges()
        {
            this.ResumeCollectionChangeNotification();
            var arg
                 = new NotifyCollectionChangedEventArgs
                      (NotifyCollectionChangedAction.Reset);
            this.OnCollectionChanged(arg);
        }

        /// <summary>
        /// This method removes the given generic list of items as a range
        /// into current collection by casting them as type T.
        /// It then notifies once after all items are removed.
        /// </summary>
        /// <param name="items">The source collection.</param>
        public void RemoveItems(IList items)
        {
            this.SuspendCollectionChangeNotification();
            try
            {
                foreach (var i in items)
                {
                    Remove((T)i);
                }
            }
            catch (Exception ex)
            {
                throw new InvalidCastException(
                   "Please check the type of items getting removed.", ex);
            }
            finally
            {
                this.NotifyChanges();
            }
        }

        /// <summary>
        /// Resumes collection changed notification.
        /// </summary>
        public void ResumeCollectionChangeNotification()
        {
            this.suspendCollectionChangeNotification = false;
        }

        /// <summary>
        /// Suspends collection changed notification.
        /// </summary>
        public void SuspendCollectionChangeNotification()
        {
            this.suspendCollectionChangeNotification = true;
        }

        /// <summary>
        /// This collection changed event performs thread safe event raising.
        /// </summary>
        /// <param name="e">The event argument.</param>
        protected override void OnCollectionChanged(NotifyCollectionChangedEventArgs e)
        {
            // Recommended is to avoid reentry 
            // in collection changed event while collection
            // is getting changed on other thread.
            using (BlockReentrancy())
            {
                if (!this.suspendCollectionChangeNotification)
                {
                    NotifyCollectionChangedEventHandler eventHandler = this.CollectionChanged;
                    if (eventHandler == null)
                    {
                        return;
                    }

                    // Walk thru invocation list.
                    Delegate[] delegates = eventHandler.GetInvocationList();

                    foreach (NotifyCollectionChangedEventHandler handler in delegates)
                    {
                        // If the subscriber is a DispatcherObject and different thread.
                        DispatcherObject dispatcherObject = handler.Target as DispatcherObject;

                        if (dispatcherObject != null && !dispatcherObject.CheckAccess())
                        {
                            // Invoke handler in the target dispatcher's thread... 
                            // asynchronously for better responsiveness.
                            dispatcherObject.Dispatcher.BeginInvoke(DispatcherPriority.DataBind, handler, this, e);
                        }
                        else
                        {
                            // Execute handler as is.
                            handler(this, e);
                        }
                    }
                }
            }
        }
    }
}
