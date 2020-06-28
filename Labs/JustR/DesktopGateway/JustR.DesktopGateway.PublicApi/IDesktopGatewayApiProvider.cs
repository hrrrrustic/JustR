using JustR.DesktopGateway.PublicApi.EntityProvider;
using JustR.DesktopGateway.PublicApi.EntityProvider.Abstractions;

namespace JustR.DesktopGateway.PublicApi
{
    public interface IDesktopGatewayApiProvider
    {
        IDialogApiProvider DialogEntityApiProvider { get; }
        IMessageApiProvider MessageEntityApiProvider { get; }
        IProfileApiProvider ProfileEntityApiProvider { get; }
        IFriendApiProvider FriendEntityApiProvider { get; }
    }
}