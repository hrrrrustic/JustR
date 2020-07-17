using System;
using System.Collections.Generic;
using JustR.Core.Entity;
using JustR.DialogService.Repository;

namespace JustR.DialogService.Service
{
    public class DialogService : IDialogService
    {
        private readonly IDialogRepository _dialogRepository;

        public DialogService(IDialogRepository dialogRepository)
        {
            _dialogRepository = dialogRepository;
        }

        public Dialog FindDialog(Guid dialogId)
        {
            Dialog dialog = _dialogRepository.FindDialog(dialogId);
            return dialog;
        }

        public IReadOnlyList<Dialog> FindDialogsPreview(Guid userId, Int32? offset, Int32 count)
        {
            IReadOnlyList<Dialog> dialogs = _dialogRepository.FindDialogs(userId, count, offset ?? 0);

            return dialogs;
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

        public Guid FindDialogId(Guid firstUserId, Guid secondUserId)
        {
            return _dialogRepository.FindDialogId(firstUserId, secondUserId);
        }

        public Dialog UpdateLastMessage(Guid authorId, Guid dialogId, String text)
        {
            return _dialogRepository.UpdateLastMessage(dialogId, authorId, text, DateTime.UtcNow);
        }
    }
}