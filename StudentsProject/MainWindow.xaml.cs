using System.Windows;
using StudentsProject.ViewModels;

namespace StudentsProject
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new MainViewModel
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
