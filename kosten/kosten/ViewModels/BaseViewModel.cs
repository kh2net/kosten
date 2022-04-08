using System;
using kosten.Support;

namespace kosten.ViewModels
{
    public abstract class BaseViewModel : BaseBindableObject
    {
        #region Events

        public event EventHandler LoadingStartedEvent;
        public event EventHandler LoadingEndedEvent;

        #endregion

        protected virtual void OnLoadingStarted(EventArgs e)
        {
            LoadingStartedEvent?.Invoke(this, e);
        }

        protected virtual void OnLoadingEnded(EventArgs e)
        {
            LoadingEndedEvent?.Invoke(this, e);
        }
    }
}
