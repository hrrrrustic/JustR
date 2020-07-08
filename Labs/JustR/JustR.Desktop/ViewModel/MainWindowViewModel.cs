using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using JustR.Core.Entity;
using JustR.Desktop.Notifications;
using JustR.Desktop.Services.Implementations;
using JustR.Desktop.View;

namespace JustR.Desktop.ViewModel
{
    public class MainWindowViewModel : BaseViewModel
    {
        private Page _currentPage =
            new UserDialogsPage(new UserDialogsViewModel(new DialogService(), new ProfileService()));

        public NotificationHandler Handler = NotificationHandler.Instance.Value;

        public Page CurrentPage
        {
            get => _currentPage;
            set
            {
                _currentPage = value;
                OnPropertyChanged();
            }
        }

        public MainWindowViewModel()
        {
            PageNavigator.Register(this);

            Handler.NewMessageReceive += Receive;

            Task.Run(() => Handler.StartHandling(UserInfo.CurrentUser.UserId));
        }

        public async Task Receive(Message newMessage)
        {
            if (newMessage.AuthorId == UserInfo.CurrentUser.UserId)
                return;

            // Не хочу ковыряться в впф и делать какие-то всплывающие окошки нормальные :C
            await Task.Run(() => MessageBox.Show("Новое сообщение : " + newMessage.MessageText));
        }
    }
}