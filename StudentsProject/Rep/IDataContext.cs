using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StudentsProject.Models;

namespace StudentsProject.Rep
{
    interface IDataContext
    {
        /// <summary>
        /// Студенты
        /// </summary>
        ICollection<Student> Students { get; }
    }
}
