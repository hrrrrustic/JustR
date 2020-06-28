using System;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Threading;
using JustR.Core.Entity;
using JustR.Desktop.Notifications;
using JustR.Desktop.View;

namespace JustR.Desktop.ViewModel
{ 
    public class MainWindowViewModel : BaseViewModel
    {
        public NotificationHandler Handler = NotificationHandler.Instance.Value;
        public MainWindowViewModel()
        {
            PageNavigator.Register(this);

            Handler.NewMessageReceive += Receive;

            Task.Run(() => Handler.StartHandling(UserInfo.CurrentUser.UserId));
        }

        public async Task Receive(Message newMessage)
        {
            if(newMessage.AuthorId == UserInfo.CurrentUser.UserId)
                return;

            // Не хочу ковыряться в впф и делать какие-то всплывающие окошки нормальные :C
            await Task.Run(() => MessageBox.Show("Новое сообщение : " + newMessage.MessageText));
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