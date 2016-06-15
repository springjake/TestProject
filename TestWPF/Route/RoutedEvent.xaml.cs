using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using TestWPF.Annotations;

namespace TestWPF.Route
{
    /// <summary>
    /// RoutedEvent.xaml 的交互逻辑
    /// </summary>
    public partial class RoutedEvent : Window
    {
        public RoutedEvent()
        {
            InitializeComponent();
        }

        private void RoutedEvent_OnReportTime(object sender, ReportTimeEventArgs e)
        {
            FrameworkElement element = sender as FrameworkElement;
            string timeStr = e.ClickTime.ToLongTimeString();
            if (element != null)
            {
                string content = string.Format("{0}:到达{1}", timeStr, element.Name);
                ListBox1.Items.Add(content);

                if (element.Name == "Grid2")
                {
                    e.Handled = true;
                }
            }


        }
    }


    class TimeButton : Button
    {
        public static readonly System.Windows.RoutedEvent ReportTimeEvent = EventManager.RegisterRoutedEvent("ReportTime",
            RoutingStrategy.Bubble, typeof(EventHandler<ReportTimeEventArgs>), typeof(TimeButton));
        public event RoutedEventHandler ReportTime
        {
            add { this.AddHandler(ReportTimeEvent, value); }
            remove { this.RemoveHandler(ReportTimeEvent, value); }
        }

        protected override void OnClick()
        {
            base.OnClick();
            ReportTimeEventArgs args = new ReportTimeEventArgs(ReportTimeEvent, this);
            args.ClickTime = DateTime.Now;
            RaiseEvent(args);
        }
    }

    class ReportTimeEventArgs : RoutedEventArgs
    {
        public ReportTimeEventArgs(System.Windows.RoutedEvent routedEvent, object source)
            : base(routedEvent, source)
        {
        }
        public DateTime ClickTime { get; set; }

    }
}
