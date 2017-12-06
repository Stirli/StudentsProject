using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Xml.XPath;
using StudentsPro.Models;

namespace StudentsPro.DataProviding
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
            XElement xe = XElement.Load("");
            XElement cur = null;
            var elements = xe.XPathSelectElements("./Student");
            try
            {
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
            catch (Exception)
            {
                var message = "Невозможно прочитать файл.";
                if (cur != null)
                {
                    message += $"\nНекорректный элемент: {cur}";
                }
                throw new Exception(message);
            }
        }
    }
}
