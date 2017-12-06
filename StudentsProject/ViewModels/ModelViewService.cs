using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using StudentsProject.DataProviding;
using StudentsProject.Models;
using StudentsProject.Properties;

namespace StudentsProject.ViewModels
{
    //class ModelViewService : INotifyPropertyChanged
    //{
    //    private IDataProvider<Student> _context;
    //    public MainViewModel MainViewModel
    //    {
    //        get { return _mainViewModel ?? (_mainViewModel = new MainViewModel(new XmlStudentsProvider(() => "Students.xml"))); }
    //        set
    //        {
    //            if (Equals(value, _mainViewModel)) return;
    //            _mainViewModel = value;
    //            _mainViewModel.Students.CollectionChanged += (sender, args) => OnPropertyChanged();
    //            OnPropertyChanged();
    //        }
    //    }

    //    public UpdateDialogViewModel UpdateDialogViewModel
    //    {
    //        get { return _updateDialogViewModel ?? (_updateDialogViewModel = new UpdateDialogViewModel()); }
    //        set
    //        {
    //            if (Equals(value, _updateDialogViewModel)) return;
    //            _updateDialogViewModel = value;
    //            OnPropertyChanged();
    //        }
    //    }

    //    #region Singleton
    //    private static ModelViewService _instance;
    //    public static ModelViewService Instance => _instance ?? (_instance = new ModelViewService());
    //    private ModelViewService()
    //    {

    //    }
    //    #endregion

    //    #region INotifyPropertyChanged
    //    private MainViewModel _mainViewModel;
    //    private UpdateDialogViewModel _updateDialogViewModel;



    //    public event PropertyChangedEventHandler PropertyChanged;

    //    [NotifyPropertyChangedInvocator]
    //    protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
    //    {
    //        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    //    }
    //    #endregion
    //}
}
