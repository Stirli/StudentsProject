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
using Microsoft.Win32;
using StudentsPro.DataProviding;
using StudentsPro.ViewModels;

namespace StudentsPro
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new MainViewModel(new XmlStudentsProvider(() => "Students.xml"))
            {
                Ask = str => MessageBox.Show(str, "", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes,
                Update = student =>
                {
                    var dialog = new UpdateStudent() { Student = student };
                    return dialog.ShowDialog() == true;
                }
            };
        }
    }
}
