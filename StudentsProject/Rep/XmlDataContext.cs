using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Xml.XPath;
using StudentsProject.Annotations;
using StudentsProject.Models;

namespace StudentsProject.Rep
{
    /// <summary>
    /// Предоставляет доступ к данным xml
    /// </summary>
    class XmlDataContext : IDataContext
    {
        public XmlDataContext(string path)
        {
            Path = path;
            XElement xe = XElement.Load(path);
            var elements = xe.XPathSelectElements("./Student");
            Students = new ObservableCollection<Student>(elements.Select(
                element => new Student
                {
                    FirstName = element.Element("FirstName").Value,
                    Last = element.Element("Last").Value,
                    Age = Convert.ToInt32(element.Element("Age").Value),
                    Gender = Convert.ToInt32(element.Element("Gender").Value),
                    Id = Convert.ToInt32(element.Attribute("Id").Value)
                }));
            Path = path;
        }

        public string Path { get; set; }

        public ICollection<Student> Students { get; private set; }
    }
}