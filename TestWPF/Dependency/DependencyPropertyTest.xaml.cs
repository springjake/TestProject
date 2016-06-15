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

namespace TestWPF.Dependency
{
    /// <summary>
    /// DependencyPropertyTest.xaml 的交互逻辑
    /// </summary>
    public partial class DependencyPropertyTest : Window
    {
        private Student stu;
        public DependencyPropertyTest()
        {
            InitializeComponent();
            stu = new Student();
            System.Windows.Data.Binding binding1 = new System.Windows.Data.Binding("Text") { Source = this.TextBox1 };
            //this.TextBox2.SetBinding(TextBox.TextProperty, binding1);
            stu.SetBinding(TextBox.TextProperty, binding1);

            BindingOperations.SetBinding(stu, NameProperty, binding1);
        }

        private void ButtonName_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(stu.GetValue(NameProperty).ToString());
        }
    }

    public class Student : DependencyObject
    {
        public static readonly DependencyProperty NameProperty = DependencyProperty.Register(
            "Name", typeof(string), typeof(Student), new PropertyMetadata(default(string)));

        public string Name
        {
            get { return (string)GetValue(NameProperty); }
            set { SetValue(NameProperty, value); }
        }

        public BindingExpressionBase SetBinding(DependencyProperty dp, BindingBase binding)
        {
            return BindingOperations.SetBinding(this, dp, binding);
        }


        
    }
}
