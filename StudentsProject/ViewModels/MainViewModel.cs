using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using StudentsProject.Annotations;
using StudentsProject.Models;
using StudentsProject.Properties;
using StudentsProject.Rep;

namespace StudentsProject.ViewModels
{
    class MainViewModel : INotifyPropertyChanged
    {
        private Students _students;
        private ObservableCollection<Student> _selectedItems;
        private Student _selectedItem;

        public MainViewModel()
        {
            Commands = new List<RelayCommand>
            {
                new RelayCommand(BeginAddStudent){Header = "Добавление"},
                new RelayCommand(BeginUpdateStudent){Header = "Изменение"},
                new RelayCommand(RemoveStudent, CanRemoveStudent){Header = "Удалить"},
                new RelayCommand(ClearSelection){Header = "Очистить выделение"}
            };
            SelectedItems = new ObservableCollection<Student>();
        }

        private void ClearSelection(object o)
        {
            SelectedItem = null;
        }

        private bool CanRemoveStudent(object o)
        {
            return !Students.IsEmpty;
        }

        private void RemoveStudent(object o)
        {
            var list = SelectedItems.ToList();
            foreach (var student in list)
            {
                Students.Remove(student);
            }
        }

        private void BeginUpdateStudent(object obj)
        {

        }

        private void BeginAddStudent(object o)
        {

        }

        public Students Students => _students ?? (_students = new Students());

        public ObservableCollection<Student> SelectedItems
        {
            get { return _selectedItems; }
            set
            {
                if (Equals(value, _selectedItems)) return;
                _selectedItems = value;
                OnPropertyChanged();
            }
        }

        public Student SelectedItem
        {
            get { return _selectedItem; }
            set
            {
                if (Equals(value, _selectedItem)) return;
                _selectedItem = value;
                OnPropertyChanged();
            }
        }

        public IReadOnlyCollection<RelayCommand> Commands { get; private set; }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
