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
using StudentsPro.Models;

namespace StudentsPro
{
    /// <summary>
    /// Логика взаимодействия для UpdateStudent.xaml
    /// </summary>
    public partial class UpdateStudent : Window
    {
        public UpdateStudent()
        {
            InitializeComponent();
            OkCommand = new RelayCommand(o =>
            {
                if (string.IsNullOrEmpty(Student.Error))
                {
                    DialogResult = true;
                    Close();
                    return;
                }
                MessageBox.Show(Student.Error, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            });
            CancelCommand = new RelayCommand(o => Close());
        }


        public Student Student
        {
            get { return (Student)GetValue(StudentProperty); }
            set { SetValue(StudentProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Student.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty StudentProperty =
            DependencyProperty.Register("Student", typeof(Student), typeof(UpdateStudent), new PropertyMetadata(new Student()));


        public RelayCommand OkCommand { get; set; }
        public RelayCommand CancelCommand { get; set; }
    }
}
