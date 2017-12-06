using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentsProject
{
    static class Helpers
    {
        /// <summary>
        /// Копирует значения свойств obj1 в obj2
        /// </summary>
        /// <typeparam name="T">Тип объекта</typeparam>
        /// <param name="obj1">Источник</param>
        /// <param name="obj2">Цель</param>
        public static void CopyTo<T>(this T obj1, T obj2) where T : class
        {
            var props = typeof(T).GetProperties().Where(prop => prop.CanWrite);
            foreach (var prop in props)
            {
                prop.SetValue(obj2, prop.GetValue(obj1));
            }
        }
    }
}
