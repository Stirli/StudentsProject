using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using StudentsPro.Annotations;

namespace StudentsPro.Models
{
    public class Student : IDataErrorInfo, INotifyPropertyChanged
    {
        private int _gender;
        private int _age;
        private string _firstName = String.Empty;
        private string _last = String.Empty;
        private string _error = String.Empty;

        public int Id { get; set; }

        public string FirstName
        {
            get { return _firstName; }
            set
            {
                if (value == _firstName) return;
                _firstName = value;
                OnPropertyChanged();
            }
        }

        public string Last
        {
            get { return _last; }
            set
            {
                if (value == _last) return;
                _last = value;
                OnPropertyChanged();
            }
        }

        public int Age
        {
            get { return _age; }
            set
            {
                if (value == _age) return;
                _age = value;
                OnPropertyChanged();
            }
        }

        public int Gender
        {
            get { return _gender; }
            set
            {
                if (value == _gender) return;
                _gender = value;
                OnPropertyChanged();
            }
        }

        public string this[string columnName]
        {
            get
            {
                Error = String.Empty;
                switch (columnName)
                {
                    case nameof(Age):
                        if ((Age < 16) || (Age > 100))
                        {
                            Error = "Возраст должен быть больше 0 и меньше 100";
                        }

                        break;
                    case nameof(FirstName):
                        if (FirstName.Length < 2)
                        {
                            Error = "Длина имени не может быть меньше 2";
                        }

                        break;
                    case nameof(Last):
                        if (Last.Length < 2)
                        {
                            Error = "Длина имени не может быть меньше 2";
                        }

                        break;
                }
                return Error;
            }
        }

        public string Error
        {
            get { return _error; }
            private set
            {
                if (value == _error) return;
                _error = value;
                OnPropertyChanged();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

}

