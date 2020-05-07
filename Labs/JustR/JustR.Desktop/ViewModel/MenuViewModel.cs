using System.Windows.Input;
using JustR.Desktop.Commands;
using JustR.Desktop.View;

namespace JustR.Desktop.ViewModel
{
    public class MenuViewModel
    {
        public ICommand ProfileCommand { get; set; } = new ActionCommand(() => new ProfileWindow().Show());
        public ICommand SearchCommand { get; set; } = new ActionCommand(() => new ProfileWindow().Show());
        public ICommand SettingCommand { get; set; } = new ActionCommand(() => new ProfileWindow().Show());
        public ICommand FriendCommand { get; set; } = new ActionCommand(() => new ProfileWindow().Show());

    }
}