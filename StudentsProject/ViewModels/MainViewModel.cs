﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
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
                new RelayCommand(BeginUpdateStudent,CanUpdateStudent){Header = "Изменение"},
                new RelayCommand(RemoveStudent, HasItems){Header = "Удалить"},
                new RelayCommand(ClearSelection,HasItems){Header = "Очистить выделение"}
            };
            SelectedItems = new ObservableCollection<Student>();
        }

        private bool HasItems(object o)
        {
            return SelectedItems.Any();
        }

        private bool CanUpdateStudent(object o)
        {
            return SelectedItem != null;
        }

        private void ClearSelection(object o)
        {
            SelectedItem = null;
        }

        private void RemoveStudent(object o)
        {
            if (Ask == null || Ask("Удалить элементы?"))
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
            var stud = new Student();
            SelectedItem.CopyTo(stud);
            if (Update?.Invoke(stud) == true)
            {
                stud.CopyTo(SelectedItem);
            }
        }

        private void BeginAddStudent(object o)
        {
            var student = new Student();
            if (Update?.Invoke(student) == true)
                Students.Create(student);
        }
        public Func<string, bool> Ask { get; set; }
        public Func<Student, bool> Update { get; set; }
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
