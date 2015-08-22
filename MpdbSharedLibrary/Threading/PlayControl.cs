using MpdBaileyTechnology.Shared.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace MpdBaileyTechnology.Shared.Threading
{
    /// <summary>
    /// The PlayControl manages a worker thread that repeatedly performs the same specified action.
    /// </summary>
    public class PlayControl : Disposer
    {
        private const int WaitTimeOut = 500;
        /// <summary>
        /// Enumeration of the possible states for the worker thread
        /// </summary>
        public enum States
        {
            Stopped,
            Paused,
            Playing,
            Error
        }
        private AutoResetEvent _PauseEvent = new AutoResetEvent(false);
        private Action _Action;
        private volatile States _State;

        /// <summary>
        /// Raised when the PlayControl worker thread completes
        /// </summary>
        public event EventHandler Finished;
        /// <summary>
        /// Raised if a exception is caught during execution of the worker thread
        /// </summary>
        public event EventHandler<PlayControlFailedEventArgs> Failed;
        /// <summary>
        /// Gets the current state of the worker thread
        /// </summary>
        public States State { get { return _State; } }
        /// <summary>
        /// Sends a stop signal to the worker thread
        /// </summary>
        public void Stop()
        {
            _State = States.Stopped;
            _PauseEvent.Set();
        }
        /// <summary>
        /// Sends a pause signal to the worker thread
        /// </summary>
        public void Pause()
        {
            if (_State == States.Playing)
            {
                _State = States.Paused;
            }
        }
        /// <summary>
        /// Allows the paused worker thread to resume
        /// </summary>
        public void Play()
        {
            _PauseEvent.Set();
            _State = States.Playing;
        }
        /// <summary>
        /// Creates a new worker thread which will begin execution asynchronously
        /// The worker thread will loop performing the specified action until it is stopped or paused.
        /// </summary>
        /// <param name="action">The function to be performed</param>
        public void Start(Action action)
        {
            if (action == null)
            {
                throw new NullReferenceException("Action is null");
            }
            this._Action = action;
            Thread thread = new Thread(StartPlaying);
            thread.Name = "PlayControl";
            thread.Start();
        }
        private void StartPlaying()
        {
            try
            {
                _State = States.Playing;
                while (this.State != States.Stopped)
                {
                    if (this.State == States.Paused)
                    {
                        _PauseEvent.WaitOne(WaitTimeOut);
                        continue;
                    }
                    this._Action.Invoke();
                }
            }
            catch (Exception e)
            {
                _State = States.Error;
                OnFailed(e);
            }
            OnFinished();
        }

        private void OnFailed(Exception e)
        {
            if (Failed != null)
            {
                Failed(this, new PlayControlFailedEventArgs(e));
            }
        }

        private void OnFinished()
        {
            if (Finished != null)
            {
                Finished(this, EventArgs.Empty);
            }
        }

        protected override void CleanUpManagedResources()
        {
            Stop();
            _PauseEvent.Dispose();
        }
    }
}
