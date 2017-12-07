using System.ComponentModel;
using System.Runtime.CompilerServices;
using StudentsProject.DataProviding;
using StudentsProject.Properties;
using StudentsProject.Services;
using StudentsProject.ViewModels;

namespace StudentsProject.MVVM
{
    public class ViewModelService : INotifyPropertyChanged
    {
        public MainViewModel MainViewModel
        {
            get { return _mainViewModel ?? (_mainViewModel = new MainViewModel(new WindowDialogService(), new XmlStudentsProvider())); }
            set
            {
                if (Equals(value, _mainViewModel)) return;
                _mainViewModel = value;
                OnPropertyChanged();
            }
        }
        

        #region Singleton
        private static ViewModelService _instance;
        public static ViewModelService Instance => _instance ?? (_instance = new ViewModelService());
        private ViewModelService()
        {

        }
        #endregion

        #region INotifyPropertyChanged
        private MainViewModel _mainViewModel;
        private UpdateDialogViewModel _updateDialogViewModel;


        public event PropertyChangedEventHandler PropertyChanged;

        [Annotations.NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }


        #endregion

    }
}
