using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentsProject.Models
{
    class Student : IDataErrorInfo
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string Last { get; set; }
        public int Age { get; set; }

        public int Gender { get; set; }
        public string this[string columnName]
        {
            get
            {
                string error = String.Empty;
                switch (columnName)
                {
                    case nameof(Age):
                        if ((Age < 0) || (Age > 100))
                        {
                            error = "Возраст должен быть больше 0 и меньше 100";
                        }

                        break;
                    case nameof(FirstName):
                        if (FirstName.Length < 2)
                        {
                            error = "Длина имени не может быть меньше 2";
                        }

                        break;
                    case nameof(Last):
                        if (Last.Length < 2)
                        {
                            error = "Длина имени не может быть меньше 2";
                        }

                        break;
                }
                return error;
            }
        }
        public string Error => throw new NotImplementedException();
    }

}

