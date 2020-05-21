using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JustR.Desktop.Services.Abstractions;
using JustR.Models.Dto;

namespace JustR.Desktop.Services.Implementations
{
    public class DummyMessageService : IMessageService
    {
        private static readonly List<DialogMessagesDto> Messages = new List<DialogMessagesDto>
        {
            new DialogMessagesDto
            {
                DialogId = SampleData.SampleData.Sergey.DialogId,
                Messages = new List<MessageDto>
                {
                    new MessageDto
                    {
                        MessageText = "эсчухак",
                        SendDate = DateTime.MinValue,
                        Sender = UserInfo.CurrentUser.ToUserPreviewDto()
                    },
                    new MessageDto
                    {
                        MessageText = "s4xack",
                        SendDate = DateTime.MinValue,
                        Sender = new UserPreviewDto
                        {
                            Avatar = SampleData.SampleData.Sergey.Avatar,
                            UniqueTag = SampleData.SampleData.Sergey.UniqueTag,
                            UserName = SampleData.SampleData.Sergey.Name,
                            UserId = SampleData.SampleData.Sergey.UserId
                        }
                    }
                }
            },
            new DialogMessagesDto
            {
                DialogId = SampleData.SampleData.Katya.DialogId,
                Messages = new List<MessageDto>
                {
                    new MessageDto
                    {
                        MessageText = "когда лицуха цивы",
                        SendDate = DateTime.MinValue,
                        Sender = UserInfo.CurrentUser.ToUserPreviewDto()
                    },
                    new MessageDto
                    {
                        MessageText = "я пират",
                        SendDate = DateTime.MinValue,
                        Sender = new UserPreviewDto
                        {
                            Avatar = SampleData.SampleData.Katya.Avatar,
                            UniqueTag = SampleData.SampleData.Katya.UniqueTag,
                            UserName = SampleData.SampleData.Katya.Name,
                            UserId = SampleData.SampleData.Katya.UserId
                        }
                    }
                }
            },
            new DialogMessagesDto
            {
                DialogId = SampleData.SampleData.Maksim.DialogId,
                Messages = new List<MessageDto>
                {
                    new MessageDto
                    {
                        MessageText = "как там в порталах",
                        SendDate = DateTime.MinValue,
                        Sender = UserInfo.CurrentUser.ToUserPreviewDto()
                    },
                    new MessageDto
                    {
                        MessageText = "академия уже началась?",
                        SendDate = DateTime.MinValue,
                        Sender = new UserPreviewDto
                        {
                            Avatar = SampleData.SampleData.Maksim.Avatar,
                            UniqueTag = SampleData.SampleData.Maksim.UniqueTag,
                            UserName = SampleData.SampleData.Maksim.Name,
                            UserId = SampleData.SampleData.Maksim.UserId
                        }
                    }
                }
            },
            new DialogMessagesDto
            {
                DialogId = SampleData.SampleData.Zeleniy.DialogId,
                Messages = new List<MessageDto>
                {
                    new MessageDto
                    {
                        MessageText = "Когда в маршаллинг будем няшиться?",
                        SendDate = DateTime.MinValue,
                        Sender = UserInfo.CurrentUser.ToUserPreviewDto()
                    },
                    new MessageDto
                    {
                        MessageText = "Ага, держи в курсе",
                        SendDate = DateTime.MinValue,
                        Sender = new UserPreviewDto
                        {
                            Avatar = SampleData.SampleData.Zeleniy.Avatar,
                            UniqueTag = SampleData.SampleData.Zeleniy.UniqueTag,
                            UserName = SampleData.SampleData.Zeleniy.Name,
                            UserId = SampleData.SampleData.Zeleniy.UserId
                        }
                    }
                }
            }
        };
        public async Task<DialogMessagesDto> GetMessagesAsync(Guid dialogId)
        {
            return Messages.Single(k => k.DialogId == dialogId);
        }

        public async Task SendMessage(MessageDto message)
        {
            Messages
                .Single(k => k.DialogId == message.DialogId)
                .Messages
                .Add(message);

            return;
        }
    }
}
