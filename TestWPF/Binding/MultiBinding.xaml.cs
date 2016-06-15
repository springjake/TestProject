using System;
using System.Collections.Generic;
using System.Globalization;
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

namespace TestWPF.Binding
{
    /// <summary>
    /// MultiBinding.xaml 的交互逻辑
    /// </summary>
    public partial class MultiBinding : Window
    {
        public MultiBinding()
        {
            InitializeComponent();
            SetMultiBinding();
        }

        public void SetMultiBinding()
        {
            System.Windows.Data.Binding binding1 = new System.Windows.Data.Binding("Text") { Source = this.TextBox1 };
            System.Windows.Data.Binding binding2 = new System.Windows.Data.Binding("Text") { Source = this.TextBox2 };
            System.Windows.Data.Binding binding3 = new System.Windows.Data.Binding("Text") { Source = this.TextBox3 };
            System.Windows.Data.Binding binding4 = new System.Windows.Data.Binding("Text") { Source = this.TextBox4 };

            System.Windows.Data.MultiBinding multiBinding = new System.Windows.Data.MultiBinding() { Mode = BindingMode.OneWay };
            multiBinding.Bindings.Add(binding1);
            multiBinding.Bindings.Add(binding2);
            multiBinding.Bindings.Add(binding3);
            multiBinding.Bindings.Add(binding4);

            multiBinding.Converter = new LogonMultiBindingConverter();
            this.ButtonName.SetBinding(IsEnabledProperty, multiBinding);
        }
    }

    public class LogonMultiBindingConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            return !values.Cast<string>().Any(string.IsNullOrEmpty) &&
                   values[0].ToString() == values[1].ToString() && values[2].ToString() == values[3].ToString();
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
