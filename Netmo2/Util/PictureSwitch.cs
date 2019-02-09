using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace Netmo2.Util
{
    public class PictureSwitch
    {
        private static List<PictureSwitch> switches = new List<PictureSwitch>();

        private int interval = 0;
        private int movement = -1;
        private DispatcherTimer timer;
        private int current = 0;
        private int pixelCurrent = 0;
        private List<FrameworkElement> scrolls = new List<FrameworkElement>();
        private bool loop = true;
        private bool isStopped = true;
        private bool start = false;

        private PictureSwitch(int interval_, int movement_)
        {
            interval = interval_;
            movement = movement_;

            timer = new DispatcherTimer
            {
                Interval = new TimeSpan(0, 0, 0, 0, interval)
            };
            timer.Tick += DispatchTick;
            timer.Start();

            switches.Add(this);
            start = true;
        }

        private PictureSwitch(int interval_, int movement_, List<FrameworkElement> scrolls_)
        {
            interval = interval_;
            movement = movement_;
            scrolls = scrolls_;

            timer = new DispatcherTimer
            {
                Interval = new TimeSpan(0, 0, 0, 0, interval)
            };
            timer.Tick += DispatchTick;
            timer.Start();

            switches.Add(this);
            start = true;
        }

        public void Start()
        {
            start = true;
        }

        public void Loop(bool loop_)
        {
            loop = loop_;
        }

        public static PictureSwitch CreateSwitch(int inteval_, int movement_, bool loop_, List<FrameworkElement> scrolls_, bool start_)
        {
            PictureSwitch ret = new PictureSwitch(inteval_, movement_, scrolls_);
            ret.Loop(loop_);
            ret.start = start_;
            return ret;
        }

        private void DispatchTick(object sender, object e)
        {
            if (isStopped)
            {
                if (loop)
                {
                    isStopped = false;
                    NextPicture();
                    pixelCurrent = 0;
                }
                else if (start)
                {
                    start = false;
                    isStopped = false;
                    NextPicture();
                    pixelCurrent = 0;
                }

                return;
            }

            if (pixelCurrent >= scrolls[current].ActualHeight)
            {
                isStopped = true;
                if (current == 0)
                {
                    scrolls[scrolls.Count - 1].Visibility = Visibility.Collapsed;
                }
                else
                {
                    scrolls[current - 1].Visibility = Visibility.Collapsed;
                }
            }
            else
            {
                pixelCurrent++;
                if (current > 0)
                {
                    TransformPoint(new Point(0, movement), scrolls[current]);
                    TransformPoint(new Point(0, movement), scrolls[current - 1]);
                }
                else
                {
                    TransformPoint(new Point(0, movement), scrolls[current]);
                    TransformPoint(new Point(0, movement), scrolls[scrolls.Count - 1]);
                }
            }
        }

        private void NextPicture()
        {
            if (current > 0)
            {
                scrolls[current - 1].Visibility = Visibility.Collapsed;
                if (current < scrolls.Count - 1)
                {
                    scrolls[current + 1].Visibility = Visibility.Visible;
                    TransformPoint(new Point(0, scrolls[current + 1].Height * (scrolls.Count - 1) * -PlusMinus(movement)), scrolls[current + 1]);
                }
                else
                {
                    scrolls[0].Visibility = Visibility.Visible;
                    TransformPoint(new Point(0, scrolls[0].Height * (scrolls.Count - 1) * -PlusMinus(movement)), scrolls[0]);
                    current = -1;
                }
            }
            else
            {
                scrolls[scrolls.Count - 1].Visibility = Visibility.Collapsed;
                scrolls[current + 1].Visibility = Visibility.Visible;
                TransformPoint(new Point(0, scrolls[current + 1].Height * (scrolls.Count - 1) * -PlusMinus(movement)), scrolls[current + 1]);
                scrolls[0].Visibility = Visibility.Visible;
                //TransformPoint(new Point(0, scrolls[0].Height * (scrolls.Count - 1) * -PlusMinus(movement)), scrolls[0]);
            }

            current++;
        }

        private int PlusMinus(int input)
        {
            if (input < 0)
            {
                return -1;
            }
            else
            {
                return 1;
            }
        }

        private void TransformPoint(Point point, FrameworkElement element)
        {
            Thickness th = element.Margin;
            th.Top += point.Y;
            element.Margin = th;
        }
    }
}
