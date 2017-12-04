using System;
using System.Collections.Generic;
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
        private readonly IDataContext _context;
        private Students _students;
        private RelayCommand _addCommand;
        private Student _formStudent;
        private Student _currentStudent;

        public MainViewModel(IDataContext context)
        {
            _context = context;
        }

        public Students Students => _students ?? (_students = new Students(_context));

        public Student CurrentStudent
        {
            get { return _currentStudent; }
            set
            {
                if (Equals(value, _currentStudent)) return;
                _currentStudent = value;
                OnPropertyChanged();
            }
        }

        public RelayCommand AddCommand

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
