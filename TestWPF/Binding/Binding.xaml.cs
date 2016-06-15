using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
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

namespace TestWPF.Binding
{
    /// <summary>
    /// Binding.xaml 的交互逻辑
    /// </summary>
    public partial class Binding : Window
    {
        private Student _student;
        public Binding()
        {
            InitializeComponent();

            _student = new Student();

            #region 绑定方式1
            //System.Windows.Data.Binding binding=new System.Windows.Data.Binding();
            //binding.Source = _student;
            //binding.Path=new PropertyPath("Name");
            //BindingOperations.SetBinding(this.TextBoxName, TextBox.TextProperty, binding);
            #endregion

            #region 绑定方式2

            this.TextBoxName.SetBinding(TextBox.TextProperty,
                new System.Windows.Data.Binding("Name") {Source = _student});

            #endregion

            List<string> list=new List<string>(){"Tom","Jerry","Cat"};
            this.TextBoxListBinding1.SetBinding(TextBox.TextProperty, new System.Windows.Data.Binding("/") {Source = list});
            this.TextBoxListBinding2.SetBinding(TextBox.TextProperty, new System.Windows.Data.Binding("/[2]") { Source = list,Mode = BindingMode.OneWay});
            this.TextBoxListBinding3.SetBinding(TextBox.TextProperty, new System.Windows.Data.Binding("/Length") { Source = list,Mode = BindingMode.OneWay});

            List<Student> studentList=new List<Student>()
            {
                new Student(){Id=11,Age=17,Name = "111"},
                new Student(){Id=12,Age=16,Name = "222"},
                new Student(){Id=13,Age=15,Name = "333"},
                new Student(){Id=14,Age=14,Name = "444"},
                new Student(){Id=15,Age=13,Name = "555"},
                new Student(){Id=16,Age=12,Name = "666"}
            };
            this.StudentListBoxName.ItemsSource = studentList;
            //this.StudentListBoxName.DisplayMemberPath = "Name";
            this.StudentListBoxName.SelectedValuePath = "Id";
            this.IdTextBoxName.SetBinding(TextBox.TextProperty,
                new System.Windows.Data.Binding("SelectedItem.Id") {Source = this.StudentListBoxName});

            RelativeSource rs=new RelativeSource(RelativeSourceMode.FindAncestor,typeof(Grid),1);
            System.Windows.Data.Binding bind=new System.Windows.Data.Binding("Name"){RelativeSource = rs};
            this.InnerTextBoxName.SetBinding(TextBox.TextProperty, bind);

            SliderBindingTextBoxName.SetBinding(TextBox.TextProperty,
                new System.Windows.Data.Binding("Value")
                {
                    Source = this.SliderName,
                    ValidationRules = {new RangeValidateRule(){ValidatesOnTargetUpdated = true}},
                    UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged
                });

            this.SliderBindingTextBoxName.AddHandler(Validation.ErrorEvent,new RoutedEventHandler(this.ValidationError));
        }

        private void ValidationError(object sender, RoutedEventArgs e)
        {
            if (Validation.GetErrors(this.SliderBindingTextBoxName).Count > 0)
            {
                this.SliderBindingTextBoxName.ToolTip =
                    Validation.GetErrors(this.SliderBindingTextBoxName)[0].ErrorContent.ToString();
            }
        }


        private void Button_Click(object sender, RoutedEventArgs e)
        {
            for (int i = 0; i < 10; i++)
            {
                Thread.Sleep(100); // 
                _student.Name += "Name";
            }
        }

    }

    public class Student: INotifyPropertyChanged
    {
        private string _name;
        private int _id;
        private int _age;


        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            var handler = PropertyChanged;
            if (handler != null) handler.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public string Name
        {
            get { return _name; }
            set
            {
                if (value == _name) return;
                _name = value;
                OnPropertyChanged();
            }
        }


        public int Id
        {
            get { return _id; }
            set
            {
                if (value == _id) return;
                _id = value;
                OnPropertyChanged();
            }
        }

        public int Age
        {
            get { return _age; }
            set
            {
                if (value == _age) return;
                _age = value;
                OnPropertyChanged();
            }
        }
    }

    public class RangeValidateRule : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            double d = 0;
            if (double.TryParse(value.ToString(), out d))
            {
                if (d >= 0 && d <= 100)
                {
                    return new ValidationResult(true,"");
                }
            }

            return new ValidationResult(false,"输入有误");

        }
    }
}
