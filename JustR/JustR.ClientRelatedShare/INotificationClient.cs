using System.Threading.Tasks;
using JustR.Core.Entity;

namespace JustR.ClientRelatedShare
{
    public interface INotificationClient
    {
        Task ReceiveNewMessage(Message message);
    }
}