using System.Collections.Generic;

namespace StudentsProject.DataProviding
{
    public interface IDataProvider<T>
    {
        IEnumerable<T> GetStudents(string path);
    }
}
