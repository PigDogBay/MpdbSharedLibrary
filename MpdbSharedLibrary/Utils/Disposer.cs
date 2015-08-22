using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MpdBaileyTechnology.Shared.Utils
{
    /// <summary>
    /// To implement the .Net Dispose pattern, sub-class this class and override the following 2 methods
    ///     void CleanUpManagedResources()
    ///     void CleanUpUnmanagedResources()
    /// </summary>
    public abstract class Disposer : IDisposable
    {
        // Track whether Dispose has been called
        private bool disposed = false;

        ~Disposer()
        {
            Dispose(false);
        }
        /// <summary>
        /// Override this method to call Dispose on managed objects
        /// </summary>
        protected virtual void CleanUpManagedResources()
        {
        }
        /// <summary>
        /// Override this method to clean up unmanaged resources
        /// such as releasing COM objects
        /// </summary>
        protected virtual void CleanUpUnmanagedResources()
        {
        }

        /// <summary>
        /// Dispose(bool disposing) executes in two distinct scenarios.
        /// If disposing equals true, the method has been called directly
        /// or indirectly by a user's code. Managed and unmanaged resources
        /// can be disposed.
        /// If disposing equals false, the method has been called by the
        /// runtime from inside the finalizer and you should not reference
        /// other objects. Only unmanaged resources can be disposed.
        /// </summary>
        /// <param name="disposing">True - called from dispose, false - called from destructor</param>
        protected void Dispose(bool disposing)
        {
            if (!disposed)
            {
                this.disposed = true;
                if (disposing)
                {
                    //dispose all managed resources
                    CleanUpManagedResources();
                }
                //Clean up unmanaged resources
                CleanUpUnmanagedResources();

                //Disposal has been done
                disposed = true;
            }
        }
        //Implements IDisposable
        public void Dispose()
        {
            Dispose(true);
            // This object will be cleaned up by the Dispose method.
            // Therefore, you should call GC.SupressFinalize to
            // take this object off the finalization queue
            // and prevent finalization code for this object
            // from executing a second time.
            GC.SuppressFinalize(this);
        }
    }
}
