using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Media;
using System.Windows.Media.Animation;

namespace Panuon.UI.Silver
{
    internal static class AnimationUtils
    {
        public static DoubleAnimation GetDoubleAnimation(double? from, double? to, double durationSeconds, double? beginTimeSeconds = null, Action completeAction = null)
        {
            var animation = new DoubleAnimation()
            {
                From = from,
                To = to,
                Duration = TimeSpan.FromSeconds(durationSeconds),
                BeginTime = beginTimeSeconds == null ? (TimeSpan?)null : TimeSpan.FromSeconds((double)beginTimeSeconds),
            };

            if (completeAction != null)
                animation.Completed += delegate { completeAction(); };

            return animation;
        }

        public static ColorAnimation GetColorAnimation(Color? from, Color? to, double durationSeconds, double? beginTimeSeconds = null, Action completeAction = null)
        {
            var animation = new ColorAnimation()
            {
                From = from,
                To = to,
                Duration = TimeSpan.FromSeconds(durationSeconds),
                BeginTime = beginTimeSeconds == null ? (TimeSpan?)null : TimeSpan.FromSeconds((double)beginTimeSeconds),
            };

            if (completeAction != null)
                animation.Completed += delegate { completeAction(); };

            return animation;
        }
        
    }
}
