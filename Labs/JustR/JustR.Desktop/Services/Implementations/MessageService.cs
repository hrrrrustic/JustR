using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using JustR.ClientRelatedShare.Dto;
using JustR.Core.Extensions;
using JustR.Desktop.Services.Abstractions;
using JustR.DesktopGateway.PublicApi;
using RestSharp;
using RestSharp.Serializers.NewtonsoftJson;

namespace JustR.Desktop.Services.Implementations
{
    public class MessageService : IMessageService
    {
        private readonly IDesktopGatewayApiProvider _desktopGatewayApiProvider =
            new HttpDesktopGatewayApiProvider(GatewayConfiguration.ApiGatewaySource);

        public async Task<IReadOnlyList<MessageDto>> GetMessagesAsync(Guid dialogId, Guid userId)
        {
            //TODO : убрать хардкор офсета 
            return await _desktopGatewayApiProvider.MessageEntityApiProvider.GetMessages(userId, dialogId, 0, 100);
        }

        public async Task SendMessage(MessageDto message)
        {
            //TODO : Опять же просто await куда-то там не оч

            await _desktopGatewayApiProvider.MessageEntityApiProvider.SendMessage(message.DialogId,
                message.Sender.UserId, message.MessageText);
        }
    }
}