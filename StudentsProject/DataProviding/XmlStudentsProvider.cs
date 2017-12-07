using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Xml.XPath;
using StudentsProject.Models;

namespace StudentsProject.DataProviding
{
    class XmlStudentsProvider : IDataProvider<Student>
    {
        public async Task<IEnumerable<Student>> GetStudentsAsync(string path)
        {
            // Запоминаем "рабочий" элмент, чтобы вывести его на жкран, если произойдет ошибка
            XElement cur = null;
            return await Task.Run(() =>
            {
                try
                {
                    XElement xe = XElement.Load(path);
                    var elements = xe.XPathSelectElements("./Student");
                    List<Student> list = new List<Student>();
                    foreach (var element in elements)
                    {
                        cur = element;
                        list.Add(new Student
                        {
                            FirstName = element.Element("FirstName").Value,
                            Last = element.Element("Last").Value,
                            Age = Convert.ToInt32(element.Element("Age").Value),
                            Gender = Convert.ToInt32(element.Element("Gender").Value),
                            Id = Convert.ToInt32(element.Attribute("Id").Value)
                        });
                    }
                    return list;
                }
                catch (Exception e)
                {
                    var message = $"Невозможно прочитать файл.\n{e.Message}";
                    if (cur != null)
                    {
                        message += $"\nНекорректный элемент: {cur}";
                    }
                    throw new Exception(message);
                }
            });

        }
    }
}
