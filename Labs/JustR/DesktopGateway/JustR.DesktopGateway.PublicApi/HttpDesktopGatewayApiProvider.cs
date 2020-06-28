using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using JustR.ClientRelatedShare.Dto;
using JustR.DesktopGateway.PublicApi.EntityProvider;
using JustR.DesktopGateway.PublicApi.EntityProvider.Abstractions;
using JustR.DesktopGateway.PublicApi.EntityProvider.Implementations;

namespace JustR.DesktopGateway.PublicApi
{
    public class HttpDesktopGatewayApiProvider : IDesktopGatewayApiProvider
    {
        public IDialogApiProvider DialogEntityApiProvider { get; }
        public IMessageApiProvider MessageEntityApiProvider { get; }
        public IProfileApiProvider ProfileEntityApiProvider { get; }
        public IFriendApiProvider FriendEntityApiProvider { get; }

        public HttpDesktopGatewayApiProvider(String baseUrl)
        {
            FriendEntityApiProvider = new HttpFriendApiProvider(baseUrl);
            ProfileEntityApiProvider = new HttpProfileApiProvider(baseUrl);
            MessageEntityApiProvider = new HttpMessageApiProvider(baseUrl);
            DialogEntityApiProvider = new HttpDialogApiProvider(baseUrl);
        }
    }
}
