using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows.Data;
using System.Collections.ObjectModel;
using System.Reflection;

namespace MpdBaileyTechnology.Shared.WPF.Collections
{
    public class WorkspaceManager
    {
        private ObservableCollectionEx<IDisposable> _Workspaces;
        public ObservableCollectionEx<IDisposable> Workspaces
        {
            get
            {
                if (_Workspaces == null)
                {
                    _Workspaces = new ObservableCollectionEx<IDisposable>();
                }
                return _Workspaces;
            }
        }
        public void Show(IDisposable workspace)
        {
            Workspaces.Add(workspace);
            SetActiveWorkspace(workspace);
        }
        /// <summary>
        /// Creates a workspace and adds it to the manager if that type of workspace is not already being displayed.
        /// If the workspace is already being displayed, then that workspace is activated
        /// The workspace's type is used as key to check if it is already being displayed.
        /// </summary>
        /// <param name="createWorkspaceFunc">Function to create the workspace and view</param>
        /// <param name="workspaceType">Acts as a key for the workspace lookup</param>
        public void Show(Func<IDisposable> createWorkspaceFunc, Type workspaceType)
        {
            IDisposable workspace = Workspaces.FirstOrDefault(x => workspaceType.IsInstanceOfType(x)) as IDisposable;
            if (workspace == null)
            {
                workspace = createWorkspaceFunc();
                Workspaces.Add(workspace);
            }
            SetActiveWorkspace(workspace);
        }

        public object GetCurrentWorkspace()
        {
            ICollectionView collectionView = CollectionViewSource.GetDefaultView(this.Workspaces);
            if (collectionView != null)
            {
                return collectionView.CurrentItem;
            }
            return null;
        }

        public void SetActiveWorkspace(IDisposable workspace)
        {
            Debug.Assert(this.Workspaces.Contains(workspace));
            ICollectionView collectionView = CollectionViewSource.GetDefaultView(this.Workspaces);
            if (collectionView != null)
            {
                collectionView.MoveCurrentTo(workspace);
            }
        }

        public void CloseWorkspace()
        {
            ICollectionView collectionView = CollectionViewSource.GetDefaultView(this.Workspaces);
            if (collectionView != null)
            {
                IDisposable workspace = collectionView.CurrentItem as IDisposable;
                if (workspace != null)
                {
                    workspace.Dispose();
                    Workspaces.Remove(workspace);
                }
            }
        }

        public void CloseOtherWorkspaces()
        {
            ICollectionView collectionView = CollectionViewSource.GetDefaultView(this.Workspaces);
            if (collectionView != null)
            {
                IDisposable currentWorkspace = collectionView.CurrentItem as IDisposable;
                if (currentWorkspace != null)
                {
                    var deletionList =
                        (from ws in _Workspaces
                         where ws != currentWorkspace
                         select ws).ToArray();
                    foreach (IDisposable ws in deletionList)
                    {
                        ws.Dispose();
                        Workspaces.Remove(ws);
                    }
                }
            }
        }
        public void CloseAllWorkspaces()
        {
            foreach (IDisposable workspace in Workspaces)
            {
                workspace.Dispose();
            }
            Workspaces.Clear();
        }
    }
}
