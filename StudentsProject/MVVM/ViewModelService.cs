using System.ComponentModel;
using System.Runtime.CompilerServices;
using StudentsProject.Annotations;
using StudentsProject.DataProviding;
using StudentsProject.Properties;
using StudentsProject.Services;
using StudentsProject.ViewModels;

namespace StudentsProject.MVVM
{
    // Предоставляет готовый MainViewModel и 
    public class ViewModelService : INotifyPropertyChanged
    {
        public MainViewModel MainViewModel
        {
            get => _mainViewModel ?? (_mainViewModel = new MainViewModel(new WindowDialogService(), new XmlStudentsProvider()));
            set
            {
                if (Equals(value, _mainViewModel)) return;
                _mainViewModel = value;
                OnPropertyChanged();
            }
        }

        public UpdateDialogViewModel UpdateDialogViewModel
        {
            get => _udateDialogViewModel ?? (_udateDialogViewModel = new UpdateDialogViewModel(new WindowDialogService()));
            set
            {
                if (Equals(value, _udateDialogViewModel)) return;
                _udateDialogViewModel = value;
                OnPropertyChanged();
            }
        }

        private MainViewModel _mainViewModel;
        private UpdateDialogViewModel _udateDialogViewModel;

        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion

    }
}
