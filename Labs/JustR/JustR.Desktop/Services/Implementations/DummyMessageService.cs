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
        private readonly IDialogService _dialogService = new DummyDialogService();
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
                        Sender = SampleData.SampleData.Sergey.ToUserPreviewDto()
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
                        Sender = SampleData.SampleData.Katya.ToUserPreviewDto()
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
                        Sender = SampleData.SampleData.Maksim.ToUserPreviewDto()
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
                        Sender = SampleData.SampleData.Zeleniy.ToUserPreviewDto()
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
            var dialog = Messages.SingleOrDefault(k => k.DialogId == message.DialogId);

            if(dialog is null)
            {
                dialog = new DialogMessagesDto
                {
                    DialogId = message.DialogId,
                    Messages = new List<MessageDto>()
                };

                Messages.Add(dialog);
            }

            dialog.Messages.Add(message);
            await _dialogService.UpdateDialogLastMessageInfo(dialog.DialogId, message.MessageText, message.SendDate);

            return;
        }
    }
}