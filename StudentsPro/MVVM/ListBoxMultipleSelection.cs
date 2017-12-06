using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace StudentsPro.MVVM
{
    public class ListBoxMultipleSelection
    {
        private static ListBox list;
        private static bool _isRegisteredSelectionChanged = false;
        
        public static readonly DependencyProperty SelectedItemsProperty =
        DependencyProperty.RegisterAttached("SelectedItems", typeof(IList),
        typeof(ListBoxMultipleSelection),
        new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault,
        new PropertyChangedCallback(OnSelectedItemsChanged)));

        public static IList GetSelectedItems(DependencyObject d)
        {
            return (IList)d.GetValue(SelectedItemsProperty);
        }
        
        public static void SetSelectedItems(DependencyObject d, IList value)
        {
            d.SetValue(SelectedItemsProperty, value);
        }

        // Изменилось значение привязки
        private static void OnSelectedItemsChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (!_isRegisteredSelectionChanged)
            {
                list = (ListBox)d;
                list.SelectionChanged += listBox_SelectionChanged;
                _isRegisteredSelectionChanged = true;
            }
        }

        // Изменился список выделенных элементов
        private static void listBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            IEnumerable listBoxSelectedItems = list.SelectedItems;
            
            // Список из модели
            IList modelSelectedItems = GetSelectedItems(list);

            // Обновляем список в модели
            modelSelectedItems.Clear();

            foreach (var item in listBoxSelectedItems)
            {
                modelSelectedItems.Add(item);
            }

            SetSelectedItems(list, modelSelectedItems);
        }
    }
}
