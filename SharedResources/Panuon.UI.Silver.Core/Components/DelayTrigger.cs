using System;
using System.Threading;

namespace Panuon.UI.Silver.Core
{
    public class DelayTrigger
    {
        #region Timer
        private Timer _timer;

        private bool _onlyOneMode;

        private int _lock;

        private int _newTick;
        #endregion

        #region Event
        public event EventHandler Ticked;
        #endregion

        #region Ctor
        public DelayTrigger(int intervalMs, bool onlyOneTicked = false)
        {
            IntervalMs = intervalMs;
            _onlyOneMode = onlyOneTicked;
            _timer = new Timer(OnTimerTicked, null, Timeout.Infinite, Timeout.Infinite);
        }
        #endregion

        #region Property
        public int IntervalMs { get; set; }
        #endregion

        #region Methods
        public void Start()
        {
            _timer.Change(IntervalMs, Timeout.Infinite);
        }

        public void Start(int intervalMs)
        {
            _timer.Change(intervalMs, Timeout.Infinite);
        }
        #endregion

        #region Function
        private void OnTimerTicked(object state)
        {
            if (Interlocked.Exchange(ref _lock, 1) == 1 && _onlyOneMode)
            {

                Interlocked.Exchange(ref _newTick, 1);
                return;
            }
            Ticked?.Invoke(this, new EventArgs());
            if (Interlocked.Exchange(ref _newTick, 0) == 1 && _onlyOneMode)
            {
                Ticked?.Invoke(this, new EventArgs());
            }
            Interlocked.Exchange(ref _lock, 0);
        }
        #endregion
    }

}
