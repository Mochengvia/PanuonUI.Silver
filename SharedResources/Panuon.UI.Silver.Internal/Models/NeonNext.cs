using System;
using System.Collections.Generic;
using System.Text;

namespace Panuon.UI.Silver.Internal.Models
{
    internal class NeonNext
    {
        public bool TextChanged { get; private set; }


        public string Text
        {
            get { return _text; }
            set { _text = value; TextChanged = true; }
        }
        private string _text;


        public NeonAnimation? Animation { get; set; }

        public TimeSpan? Duration { get; set; }


        public TimeSpan? Interval
        {
            get { return _interval; }
            set { _interval = value; IntervalChanged = true; }
        }
        private TimeSpan? _interval;

        public bool IntervalChanged { get; private set; }
    }
}
