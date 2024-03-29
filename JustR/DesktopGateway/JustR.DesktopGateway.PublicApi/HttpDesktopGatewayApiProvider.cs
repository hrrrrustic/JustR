﻿using System;
using JustR.DesktopGateway.PublicApi.EntityProvider.Abstractions;
using JustR.DesktopGateway.PublicApi.EntityProvider.Implementations;

namespace JustR.DesktopGateway.PublicApi
{
    public class HttpDesktopGatewayApiProvider : IDesktopGatewayApiProvider
    {
        public HttpDesktopGatewayApiProvider(String baseUrl)
        {
            //TODO : Выглядит не очень обнадеживающе
            FriendEntityApiProvider =
                new HttpFriendApiProvider(
                    baseUrl + "/" + DesktopGatewayHttpEndpoints.FriendEndpoints.ControllerEndpoint);
            ProfileEntityApiProvider =
                new HttpProfileApiProvider(baseUrl + "/" +
                                           DesktopGatewayHttpEndpoints.ProfileEndpoints.ControllerEndpoint);
            MessageEntityApiProvider =
                new HttpMessageApiProvider(baseUrl + "/" +
                                           DesktopGatewayHttpEndpoints.MessageEndpoints.ControllerEndpoint);
            DialogEntityApiProvider =
                new HttpDialogApiProvider(
                    baseUrl + "/" + DesktopGatewayHttpEndpoints.DialogEndpoints.ControllerEndpoint);
        }

        public IDialogApiProvider DialogEntityApiProvider { get; }
        public IMessageApiProvider MessageEntityApiProvider { get; }
        public IProfileApiProvider ProfileEntityApiProvider { get; }
        public IFriendApiProvider FriendEntityApiProvider { get; }
    }
}