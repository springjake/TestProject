using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
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
    /// BindingConverter.xaml 的交互逻辑
    /// </summary>
    public partial class BindingConverter : Window
    {
        public BindingConverter()
        {
            InitializeComponent();
            
        }

        private void ButtonLoad_Click(object sender, RoutedEventArgs e)
        {
            List<Plane> list=new List<Plane>()
            {
                new Plane(){Category = Category.Bomber,State = State.Unknown,Name = "A1"},
                new Plane(){Category = Category.Fighter,State = State.Unknown,Name = "B2"},
                new Plane(){Category = Category.Bomber,State = State.Unknown,Name = "A45"},
                new Plane(){Category = Category.Bomber,State = State.Unknown,Name = "DF3"},
                new Plane(){Category = Category.Fighter,State = State.Unknown,Name = "DFG3"},
                new Plane(){Category = Category.Fighter,State = State.Unknown,Name = "RT6"},
                new Plane(){Category = Category.Bomber,State = State.Unknown,Name = "FG4"},
                new Plane(){Category = Category.Bomber,State = State.Unknown,Name = "F6"}
            };
            this.ListBoxPlan.ItemsSource = list;
        }

        private void ButtonSave_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder sb=new StringBuilder();
            foreach (Plane item in this.ListBoxPlan.Items)
            {
                sb.AppendLine(string.Format("Category={0},State={1},Plane={2}", item.Category, item.State, item.Name));
            }
            File.WriteAllText(@"D:\Plane.txt",sb.ToString());
        }
    }

    public class CategoryToResourceConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            Category c = (Category)value;
            switch (c)
            {
                case Category.Bomber:
                    return @"\Icon\bomber.png";
                case Category.Fighter:
                    return @"\Icon\fighter.png";
                default:
                    return "";
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

    public class StateToNullableBoolConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            State s = (State)value;
            switch (s)
            {
                case State.Available:
                    return true;
                case State.Locked:
                    return false;
                case State.Unknown:
                default:
                    return null;

            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            bool? b = (bool?)value;
            switch (b)
            {
                case true:
                    return State.Available;
                case false:
                    return State.Locked;
                default:
                    return State.Unknown;
            }
        }
    }

    /// <summary>
    /// 种类
    /// </summary>
    public enum Category
    {
        Bomber,
        Fighter
    }
    /// <summary>
    /// 状态
    /// </summary>
    public enum State
    {
        Available,
        Locked,
        Unknown
    }

    public class Plane
    {
        public Category Category { get; set; }
        public string Name { get; set; }
        public State State { get; set; }
    }
}
