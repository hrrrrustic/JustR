using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;
using JustR.ClientRelatedShare.Dto;
using JustR.Desktop.Commands;
using JustR.Desktop.Services.Abstractions;
using JustR.Desktop.Services.Implementations;
using JustR.Desktop.View;

namespace JustR.Desktop.ViewModel
{
    public class SearchViewModel : BaseViewModel
    {
        public ICommand SendFriendRequest { get; }

        public ICommand OpedDialogCommand { get; } = new ActionCommand<Guid>(arg =>
        {
            UserDialogsPage page =
                new UserDialogsPage(new UserDialogsViewModel(new DialogService(), new ProfileService()));

            page
                .GetViewModel<UserDialogsViewModel>()
                .OpenDialogByInterlocutorId
                .Execute(arg);

            PageNavigator.NavigateTo(page);
        });

        public ICommand SearchCommand { get; set; }

        public ObservableCollection<UserPreviewDto> Users { get; } = new ObservableCollection<UserPreviewDto>();

        public SearchViewModel(ISearchService searchService, IFriendService friendService)
        {
            SearchCommand = new ActionCommand<String>(async arg =>
            {
                Users.Clear();
                IReadOnlyList<UserPreviewDto> users = await searchService
                    .FindUsersByTagAsync(arg);

                if (users is null)
                    return;

                foreach (UserPreviewDto user in users)
                    Users.Add(user);
            });

            SendFriendRequest = new ActionCommand<Guid>(async arg =>
            {
                FriendRequestDto dto = FriendRequestDto.OutputFriendRequest(UserInfo.CurrentUser.UserId, arg);
                await friendService.CreateFriendRequestAsync(dto);
            });
        }
    }
}