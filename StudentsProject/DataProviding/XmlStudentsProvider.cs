using System;
using System.Collections.Generic;
using System.Xml.Linq;
using System.Xml.XPath;
using StudentsProject.Models;

namespace StudentsProject.DataProviding
{
    class XmlStudentsProvider : IDataProvider<Student>
    {
        private readonly Func<string> _getPath;

        public XmlStudentsProvider(Func<string> getPath)
        {
            _getPath = getPath;
        }
        public IEnumerable<Student> GetStudents()
        {
            XElement cur = null;
            try
            {
                XElement xe = XElement.Load("");
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
        }
    }
}
