using System.Collections.Generic;

namespace StudentsProject.DataProviding
{
    interface IDataProvider<T>
    {
        IEnumerable<T> GetStudents();
    }
}
