using System;
using System.Collections.Generic;
using System.Linq;
using JustR.Core.Entity;
using JustR.DialogService.Repository;
using JustR.Models.Entity;

namespace JustR.DialogService.Service
{
    public class DialogService : IDialogService
    {
        private readonly IDialogRepository _dialogRepository;

        public DialogService(IDialogRepository dialogRepository)
        {
            _dialogRepository = dialogRepository;
        }

        public Dialog GetDialog(Guid dialogId)
        {
            Dialog dialog = _dialogRepository.ReadDialog(dialogId);
            return dialog;
        }

        public List<Dialog> GetDialogsPreview(Guid userId, Int32? offset, Int32 count)
        {
            var result = _dialogRepository.ReadDialogs(userId, count, offset ?? 0);
            return result;
        }

        public Dialog CreateDialog(Guid firstUserId, Guid secondUserId)
        {
            Dialog dialog = new Dialog
            {
                DialogId = Guid.NewGuid(),
                FirstUserId = firstUserId,
                SecondUserid = secondUserId,
                LastMessageTime = DateTime.MinValue,
                LastMessageAuthor = Guid.Empty,
                LastMessageText = null
            };

            return _dialogRepository.CreateDialog(dialog);
        }

        public Guid GetUserId(Guid firstUserId, Guid secondUserId)
        {
            return _dialogRepository.ReadDialogId(firstUserId, secondUserId);
        }

        public void UpdateLastMessage(Guid authorId, Guid dialogId, String text)
        {
            _dialogRepository.UpdateLastMessage(dialogId, authorId, text, DateTime.Now);
        }
    }
}