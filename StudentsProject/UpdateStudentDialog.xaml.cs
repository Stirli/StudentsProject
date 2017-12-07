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
using StudentsProject.Models;
using StudentsProject.MVVM;
using StudentsProject.Services;
using StudentsProject.ViewModels;

namespace StudentsProject
{
    /// <summary>
    /// Логика взаимодействия для UpdateStudentDialog.xaml
    /// </summary>
    public partial class UpdateStudentDialog : Window
    {
        public UpdateStudentDialog(Student initialValue)
        {
            InitializeComponent();
            DataContext = new UpdateDialogViewModel(new WindowDialogService()){Student = initialValue};
        }
    }
}
