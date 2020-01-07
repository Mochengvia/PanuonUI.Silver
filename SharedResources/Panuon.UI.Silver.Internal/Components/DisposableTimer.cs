using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Panuon.UI.Silver.Internal.Components
{
    internal class DisposableTimer : IDisposable
    {
        #region Fields
        private Timer _timer;

        private Action _tickedAction;

        private bool _isStoped;
        #endregion

        #region Ctor
        public DisposableTimer(Action tickedAction, TimeSpan? interval)
        {
            _tickedAction = tickedAction;
            var intervalMs = interval == null ? 0 : ((TimeSpan)interval).TotalMilliseconds;
            _timer = new Timer(OnTimerTicked, null, (int)intervalMs, Timeout.Infinite);
        }

        #endregion

        #region Event Handler
        private void OnTimerTicked(object state)
        {
            if (_isStoped)
                return;

            _tickedAction?.Invoke();
        }
        #endregion

        #region Methods
        public void Change(TimeSpan? interval)
        {
            if (_isStoped)
                return;

            var intervalMs = interval == null ? 0 : ((TimeSpan)interval).TotalMilliseconds;
            _timer.Change((int)intervalMs, Timeout.Infinite);
        }

        public void Stop()
        {
            _isStoped = true;
        }

        public void Dispose()
        {
            _isStoped = true;
            _timer.Dispose();
        }
        #endregion
    }
}
