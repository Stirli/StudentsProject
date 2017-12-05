using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace StudentsProject.MVVM
{
    /// <summary>
    /// An attached property for supporting listbox selected items
    /// </summary>
    public class ListBoxMultipleSelection
    {
        #region SelectedItems

        private static ListBox list;
        private static bool _isRegisteredSelectionChanged = false;

        ///
        /// SelectedItems Attached Dependency Property
        ///
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

        private static void OnSelectedItemsChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (!_isRegisteredSelectionChanged)
            {
                list = (ListBox)d;
                list.SelectionChanged += listBox_SelectionChanged;
                _isRegisteredSelectionChanged = true;
            }
        }

        private static void listBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //Get list box's selected items.
            IEnumerable listBoxSelectedItems = list.SelectedItems;
            //Get list from model
            IList modelSelectedItems = GetSelectedItems(list);

            //Update the model
            modelSelectedItems.Clear();

            foreach (var item in listBoxSelectedItems)
                modelSelectedItems.Add(item);
            SetSelectedItems(list, modelSelectedItems);
        }
        #endregion
    }
}
