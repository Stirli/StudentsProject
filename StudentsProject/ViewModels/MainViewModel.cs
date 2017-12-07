using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows;
using StudentsProject;
using StudentsProject.DataProviding;
using StudentsProject.Models;
using StudentsProject.MVVM;
using StudentsProject.Properties;
using StudentsProject.Services;

namespace StudentsProject.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        private readonly IDialogService _dialogService;
        private readonly IDataProvider<Student> _dataProvider;
        private ObservableCollection<Student> _selectedItems;
        private Student _selectedItem;
        private ObservableCollection<Student> _students;
        private DataTemplate _dataTemplate;

        public MainViewModel(IDialogService dialogService, IDataProvider<Student> dataProvider)
        {
            DataTemplate = App.Current.Resources["StudentsEmptyList"] as DataTemplate;
            _dialogService = dialogService;
            _dataProvider = dataProvider;
            MainMenu = new List<RelayCommand>
            {
                new RelayCommand(o =>
                {
                    if (_dialogService.OpenFileDialog() == true)
                    {
                        Students = new ObservableCollection<Student>(_dataProvider.GetStudents(_dialogService.FileName));
                    }
                }){Header = "Открыть"},
            };
            Commands = new List<RelayCommand>
            {
                new RelayCommand(BeginAddStudent, o => Students!=null){Header = "Добавление"},
                new RelayCommand(BeginUpdateStudent, o => SelectedItem != null){ Header = "Изменение"},
                new RelayCommand(RemoveStudent, o => SelectedItems.Any()){Header = "Удалить"},
                new RelayCommand(ClearSelection,o => SelectedItems.Any()){Header = "Очистить выделение"}
            };
            SelectedItems = new ObservableCollection<Student>();
        }

        private void ClearSelection(object o)
        {
            SelectedItem = null;
        }

        private void RemoveStudent(object o)
        {
            if (_dialogService.ShowMessage("Удалить элементы?") == true)
            {
                var list = SelectedItems.ToList();
                foreach (var student in list)
                {
                    Students.Remove(student);
                }
            }
        }

        private void BeginUpdateStudent(object obj)
        {
            var student = new Student();
            SelectedItem.CopyTo(student);
            if (_dialogService.ShowUpdateDialog(student) == true)
            {
                student.CopyTo(SelectedItem);
            }
        }

        private void BeginAddStudent(object o)
        {
            var student = new Student();
            if (_dialogService.ShowUpdateDialog(student) == true)
            {
                Students.Add(student);
            }
        }

        public ObservableCollection<Student> Students
        {
            get { return _students; }
            set
            {
                if (Equals(value, _students)) return;
                _students = value;
                SelectDataTemplate();
                _students.CollectionChanged += (sender, args) => SelectDataTemplate();
                OnPropertyChanged();
            }
        }

        private void SelectDataTemplate()
        {
            DataTemplate = _students.Any()
                ? Application.Current.Resources[("StudentsList")] as DataTemplate
                : Application.Current.Resources[("StudentsEmptyList")] as DataTemplate;
        }

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
        public IReadOnlyCollection<RelayCommand> MainMenu { get; private set; }

        public DataTemplate DataTemplate
        {
            get { return _dataTemplate; }
            set
            {
                _dataTemplate = value;
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
