using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using JustR.Core.Dto;

namespace JustR.DesktopGateway.PublicApi.EntityProvider
{
    public interface IMessageApiProvider
    {
        Task<IReadOnlyList<MessageDto>> GetMessages(Guid userId, Guid dialogId, Int32? offset, Int32 count);
        Task<MessageDto> SendMessage(Guid dialogId, Guid authorId, String text);
    }
}