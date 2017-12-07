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
using StudentsProject.Services;

namespace StudentsProject.ViewModels
{
    public class UpdateDialogViewModel:INotifyPropertyChanged
    {
        private Student _student;
        private bool? _dialogResult;

        public UpdateDialogViewModel(IDialogService dialogService)
        {
            OkCommand = new RelayCommand(o =>
            {
                if (string.IsNullOrEmpty(Student.Error))
                {
                    DialogResult = true;
                    return;
                }
                dialogService.ShowError(Student.Error);
            });
            CancelCommand = new RelayCommand(o => DialogResult = false);
        }

        public Student Student
        {
            get { return _student; }
            set
            {
                if (Equals(value, _student)) return;
                _student = value;
                OnPropertyChanged();
            }
        }

        public RelayCommand OkCommand { get; set; }
        public RelayCommand CancelCommand { get; set; }

        public bool? DialogResult
        {
            get { return _dialogResult; }
            set
            {
                if (value == _dialogResult) return;
                _dialogResult = value;
                OnPropertyChanged();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [Annotations.NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
