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

namespace TestWPF.Route
{
    /// <summary>
    /// RouteTest.xaml 的交互逻辑
    /// </summary>
    public partial class RouteTest : Window
    {
        public RouteTest()
        {
            InitializeComponent();
            //this.GridRoot.AddHandler(Button.ClickEvent, new RoutedEventHandler(Button_Click));
        }

        public void Button_Click(object sender, RoutedEventArgs e)
        {
            var frameworkElement = e.OriginalSource as FrameworkElement;
            if (frameworkElement != null)
                MessageBox.Show(frameworkElement.Name);
            var element = sender as FrameworkElement;
            if (element != null) MessageBox.Show(element.Name);
        }

        public void Button_Click1(object sender, RoutedEventArgs e)
        {
            var frameworkElement = e.OriginalSource as FrameworkElement;
            if (frameworkElement != null)
                MessageBox.Show(frameworkElement.Name);
            var element = sender as FrameworkElement;
            if (element != null) MessageBox.Show(element.Name);
        }
    }
}
