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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace TestWPF
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            List<Employee> employees=new List<Employee>()
            {
                new Employee(){Age = 18,Id=1,Name="Mouse"},
                new Employee(){Age = 18,Id=2,Name="Cat"},
                new Employee(){Age = 18,Id=3,Name="Tom"},
                new Employee(){Age = 18,Id=4,Name="Jerry"}
            };
            this.NameListBox.DisplayMemberPath = "Name";
            this.NameListBox.SelectedValuePath = "Id";
            this.NameListBox.ItemsSource = employees;

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(this,"这是个按钮","消息提醒");
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Button btn=sender as Button; //按钮
            DependencyObject level1 = VisualTreeHelper.GetParent(btn);//内容区
            DependencyObject level2 = VisualTreeHelper.GetParent(level1);//border
            DependencyObject level3 = VisualTreeHelper.GetParent(level2);
            
            MessageBox.Show(level3.GetType().ToString());
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            
        }
    }

    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
    }
}
