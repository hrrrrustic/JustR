using JustR.DesktopGateway.PublicApi.EntityProvider;

namespace JustR.DesktopGateway.PublicApi
{
    public interface IDesktopGatewayApiProvider : IDialogApiProvider, IFriendApiProvider, IProfileApiProvider, IMessageApiProvider
    {
        IDialogApiProvider DialogEntityProvider { get; }
        IMessageApiProvider MessageEntityProvider { get; }
        IProfileApiProvider ProfileEntityProvider { get; }
        IFriendApiProvider FriendEntityProvider { get; }
    }
}