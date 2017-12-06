using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StudentsPro.Models;

namespace StudentsPro.DataProviding
{
    interface IDataProvider<T>
    {
        IEnumerable<T> GetStudents();
    }
}
