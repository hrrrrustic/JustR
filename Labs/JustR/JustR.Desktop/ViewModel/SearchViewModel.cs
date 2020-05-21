using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using Accessibility;
using JustR.Desktop.Commands;
using JustR.Desktop.Services.Abstractions;
using JustR.Desktop.Services.Implementations;
using JustR.Desktop.View;
using JustR.Models.Dto;

namespace JustR.Desktop.ViewModel
{
    public class SearchViewModel : BaseViewModel
    {
        private readonly ISearchService _searchService = new DummySearchService();

        private readonly IFriendService _friendService = new DummyFriendService();

        public SearchViewModel()
        {
            SearchCommand = new ActionCommand<String>(async arg =>
            {
                Users.Clear();
                await _searchService
                    .FindUsersByTagAsync(arg)
                    .ContinueWith(task =>
                    {
                        foreach (UserPreviewDto user in task?.Result)
                        {
                            Users.Add(user);
                        }
                    }, TaskScheduler.FromCurrentSynchronizationContext());
            });

            SendFriendRequest = new ActionCommand<Guid>(async arg =>
            {
                await _friendService.CreateFriendRequestAsync(arg);
            });
        }

        public ICommand SendFriendRequest { get; set; }
        public ICommand OpedDialogCommand { get; set; } = new ActionCommand<Guid>(arg =>
        {
            var page = new UserDialogsPage();
            
           page
                .GetViewModel<UserDialogsViewModel>()
                .OpenDialogByInterlocutorId
                .Execute(arg);
            PageNavigator.NavigateTo(page);
        });
        public ICommand SearchCommand { get; set; }

        public ObservableCollection<UserPreviewDto> Users { get; set; } = new ObservableCollection<UserPreviewDto>();
    }
}