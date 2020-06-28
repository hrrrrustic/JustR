using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using JustR.ClientRelatedShare.Dto;
using JustR.DesktopGateway.PublicApi.EntityProvider;

namespace JustR.DesktopGateway.PublicApi
{
    public class HttpDesktopGatewayApiProvider : IDesktopGatewayApiProvider
    {
        public IDialogApiProvider DialogEntityProvider { get; }
        public IMessageApiProvider MessageEntityProvider { get; }
        public IProfileApiProvider ProfileEntityProvider { get; }
        public IFriendApiProvider FriendEntityProvider { get; }
        public Task<Guid> GetDialogId(Guid firstUserId, Guid secondUserid)
        {
            throw new NotImplementedException();
        }

        public Task<IReadOnlyList<DialogPreviewDto>> GetDialogs(Guid userId, Int32? offset, Int32 count)
        {
            throw new NotImplementedException();
        }

        public Task<DialogInfoDto> GetDialog(Guid dialogId, Guid userId)
        {
            throw new NotImplementedException();
        }

        public Task<DialogInfoDto> CreateDialog(Guid firstUserId, Guid secondUserId)
        {
            throw new NotImplementedException();
        }

        public Task<IReadOnlyList<UserPreviewDto>> GetUserFriends(Guid userId)
        {
            throw new NotImplementedException();
        }

        public Task<FriendRequestDto> CreateFriendRequest(FriendRequestDto dto)
        {
            throw new NotImplementedException();
        }

        public Task<FriendRequestDto> CreateFriendResponse(FriendRequestDto dto)
        {
            throw new NotImplementedException();
        }

        public void DeleteFriend(Guid userId, Guid secondUserId)
        {
            throw new NotImplementedException();
        }

        public Task<UserProfileDto> GetUserProfile(Guid userId)
        {
            throw new NotImplementedException();
        }

        public Task<IReadOnlyList<UserPreviewDto>> SearchUser(String query)
        {
            throw new NotImplementedException();
        }

        public Task<UserPreviewDto> GetUserPreview(Guid userId)
        {
            throw new NotImplementedException();
        }

        public Task<UserPreviewDto> SimpleAuth(String userTag)
        {
            throw new NotImplementedException();
        }

        public Task<IReadOnlyList<MessageDto>> GetMessages(Guid userId, Guid dialogId, Int32? offset, Int32 count)
        {
            throw new NotImplementedException();
        }

        public Task<MessageDto> SendMessage(Guid dialogId, Guid authorId, String text)
        {
            throw new NotImplementedException();
        }
    }
}
