using System;
using System.Collections.Generic;
using System.Data.OleDb;
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
    /// AttachedProperty.xaml 的交互逻辑
    /// </summary>
    public partial class AttachedProperty : Window
    {
        public AttachedProperty()
        {
            InitializeComponent();
            SetLayout();
        }

        void SetLayout()
        {
            Grid grid=new Grid(){ShowGridLines = true};
            grid.RowDefinitions.Add(new RowDefinition());
            grid.RowDefinitions.Add(new RowDefinition());
            grid.RowDefinitions.Add(new RowDefinition());
            grid.ColumnDefinitions.Add(new ColumnDefinition());
            grid.ColumnDefinitions.Add(new ColumnDefinition());
            grid.ColumnDefinitions.Add(new ColumnDefinition());

            Button btn=new Button(){Content = "click me"};

            Grid.SetRow(btn,1);
            Grid.SetColumn(btn,1);

            grid.Children.Add(btn);
            this.Content = grid;
        }

        private void ClickMeButton_Click(object sender, RoutedEventArgs e)
        {
            Human h=new Human();
            School.SetGrade(h,6);
            int grade = School.GetGrade(h);
            MessageBox.Show(grade.ToString());
        }
    }


    class Human:DependencyObject
    {
         
    }

    class School : DependencyObject
    {
        public static readonly DependencyProperty GradeProperty = DependencyProperty.RegisterAttached(
            "Grade", typeof (int), typeof (School), new PropertyMetadata(default(int)));

        public static void SetGrade(DependencyObject element, int value)
        {
            element.SetValue(GradeProperty, value);
        }

        public static int GetGrade(DependencyObject element)
        {
            return (int) element.GetValue(GradeProperty);
        }


    }


}
