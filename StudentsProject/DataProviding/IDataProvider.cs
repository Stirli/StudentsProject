using System.Collections.Generic;
using System.Threading.Tasks;
using StudentsProject.Models;

namespace StudentsProject.DataProviding
{
    /// <summary>
    /// Предоставляет метод для получения списка студентов
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IDataProvider<T>
    {
        /// <summary>
        /// Возвращает список студентов
        /// </summary>
        /// <param name="path">Параметр</param>
        /// <returns>Список студентов</returns>
        Task<IEnumerable<Student>> GetStudentsAsync(string path);
    }
}
