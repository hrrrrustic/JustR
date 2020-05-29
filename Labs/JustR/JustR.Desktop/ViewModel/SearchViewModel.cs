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
using JustR.Models.Enum;

namespace JustR.Desktop.ViewModel
{
    public class SearchViewModel : BaseViewModel
    {
        private readonly ISearchService _searchService = new SearchService();

        private readonly IFriendService _friendService = new FriendService();

        public SearchViewModel()
        {
            SearchCommand = new ActionCommand<String>(async arg =>
            {
                Users.Clear();
                await _searchService
                    .FindUsersByTagAsync(arg)
                    .ContinueWith(task =>
                    {
                        if (task.Result is null)
                            return;

                        foreach (UserPreviewDto user in task.Result)
                        {
                            Users.Add(user);
                        }
                    }, TaskScheduler.FromCurrentSynchronizationContext());
            });

            SendFriendRequest = new ActionCommand<Guid>(async arg =>
            {
                FriendRequestDto dto = new FriendRequestDto
                {
                    FirstUserId = UserInfo.CurrentUser.UserId,
                    SecondUserId = arg,
                    State = RelationshipState.OutputFriendRequest
                };

                await _friendService.CreateFriendRequestAsync(dto);
            });
        }

        public ICommand SendFriendRequest { get; }
        public ICommand OpedDialogCommand { get; } = new ActionCommand<Guid>(arg =>
        {
            var page = new UserDialogsPage();
            
           page
                .GetViewModel<UserDialogsViewModel>()
                .OpenDialogByInterlocutorId
                .Execute(arg);
            PageNavigator.NavigateTo(page);
        });
        public ICommand SearchCommand { get; set; }

        public ObservableCollection<UserPreviewDto> Users { get; } = new ObservableCollection<UserPreviewDto>();
    }
}