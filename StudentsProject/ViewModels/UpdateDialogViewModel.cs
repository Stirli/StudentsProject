using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using StudentsProject.Models;
using StudentsProject.MVVM;
using StudentsProject.Properties;

namespace StudentsProject.ViewModels
{
    class UpdateDialogViewModel:INotifyPropertyChanged
    {
        public UpdateDialogViewModel()
        {
            OkCommand = new RelayCommand(o =>
            {
                if (string.IsNullOrEmpty(Student.Error))
                {
                    DialogResult = true;
                    return;
                }
                MessageBox.Show(Student.Error, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            });
            CancelCommand = new RelayCommand(o => DialogResult = false);
        }
        public Student Student { get; set; }

        public RelayCommand OkCommand { get; set; }
        public RelayCommand CancelCommand { get; set; }
        public bool? DialogResult { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
