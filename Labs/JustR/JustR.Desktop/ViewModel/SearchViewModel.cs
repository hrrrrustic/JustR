using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using JustR.Core.Dto;
using JustR.Desktop.Commands;
using JustR.Desktop.Services.Abstractions;
using JustR.Desktop.Services.Implementations;
using JustR.Desktop.View;

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
                IReadOnlyList<UserPreviewDto> users = await _searchService
                    .FindUsersByTagAsync(arg);

                if (users is null)
                    return;

                foreach (UserPreviewDto user in users)
                    Users.Add(user);
            });

            SendFriendRequest = new ActionCommand<Guid>(async arg =>
            {
                FriendRequestDto dto = FriendRequestDto.OutputFriendRequest(UserInfo.CurrentUser.UserId, arg);
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