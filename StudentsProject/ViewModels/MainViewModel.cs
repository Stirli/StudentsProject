using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows;
using StudentsProject.DataProviding;
using StudentsProject.Models;
using StudentsProject.MVVM;
using StudentsProject.Services;

namespace StudentsProject.ViewModels
{
    // ModelView главного окна
    public class MainViewModel : INotifyPropertyChanged
    {
        private readonly IDialogService _dialogService;
        private ObservableCollection<Student> _selectedItems;
        private Student _selectedItem;
        private ObservableCollection<Student> _students;

        public MainViewModel(IDialogService dialogService, IDataProvider<Student> dataProvider)
        {
            _dialogService = dialogService;
            // список пунктов главного меню
            MainMenu = new List<RelayCommand>
            {
                new RelayCommand(async o =>
                {
                    if (_dialogService.OpenFileDialog(out string fileName))
                    {
                        try
                        {
                            var enumerable = await dataProvider.GetStudentsAsync(fileName);
                            Students = new ObservableCollection<Student>(enumerable);
                        }
                        catch (Exception e)
                        {
                            _dialogService.ShowError(e.Message);
                        }
                    }
                }){Header = "Открыть"},
            };
            // список пунктов меню
            Commands = new List<RelayCommand>
            {
                new RelayCommand(BeginAddStudent, o => Students!=null){Header = "Добавление"},
                new RelayCommand(BeginUpdateStudent, o => SelectedItem != null){ Header = "Изменение"},
                new RelayCommand(RemoveStudent, o => SelectedItems.Any()){Header = "Удалить"},
                // снятие выделения со всех элментов
                new RelayCommand(ClearSelection,o => SelectedItems.Any()){Header = "Очистить выделение"}
            };
            // выбранные студенты
            SelectedItems = new ObservableCollection<Student>();
        }


        public ObservableCollection<Student> Students
        {
            get { return _students; }
            set
            {
                if (Equals(value, _students)) return;
                _students = value;
                OnPropertyChanged();
                // При каждом изменении коллецкции будет проверяться остаток студентов.
                _students.CollectionChanged += (sender, args) => OnPropertyChanged(nameof(HasItems));
                OnPropertyChanged(nameof(HasItems));
            }
        }

        // Остаток студентов
        public bool HasItems => Students != null && Students.Any();

        // Выбранные студенты
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

        // Выбранный студент (или первый из списка)
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


        public IReadOnlyCollection<RelayCommand> Commands { get; }
        public IReadOnlyCollection<RelayCommand> MainMenu { get; }

        private void ClearSelection(object o)
        {
            SelectedItem = null;
        }

        private void RemoveStudent(object o)
        {
            if (_dialogService.ShowMessage("Удалить элементы?"))
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
            // Копируем данные в другой объект, чтобы не внести изменения сразу в список
            SelectedItem.CopyTo(student);
            if (_dialogService.ShowUpdateDialog(student) == true)
            {
                // Если пользователь подтвердил, копируем данные в выбранный объект
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

        public event PropertyChangedEventHandler PropertyChanged;

        [Annotations.NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
