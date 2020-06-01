using System.Windows.Controls;
using JustR.Desktop.View;

namespace JustR.Desktop.ViewModel
{ 
    public class MainWindowViewModel : BaseViewModel
    {

        public MainWindowViewModel()
        {
            PageNavigator.Register(this);
        }

        private Page _currentPage = new UserDialogsPage();

        public Page CurrentPage
        {
            get => _currentPage;
            set
            {
                _currentPage = value;
                OnPropertyChanged();
            }
        }
    }
}