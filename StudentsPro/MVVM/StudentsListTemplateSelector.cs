using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using StudentsPro.ViewModels;

namespace StudentsPro.MVVM
{
    class StudentsListTemplateSelector : DataTemplateSelector
    {
        public override DataTemplate
            SelectTemplate(object item, DependencyObject container)
        {
            FrameworkElement element = container as FrameworkElement;
            if (item is MainViewModel vm)
            {
                return (vm.Students.Any()
                    ? element.FindResource("StudentsList")
                    : element.FindResource("StudentsEmptyList")) as DataTemplate;
            }

            return null;
        }
    }
}
