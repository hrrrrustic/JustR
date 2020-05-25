using System;
using System.Collections.Generic;
using System.Linq;
using JustR.DialogService.Repository;
using JustR.Models.Dto;
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

        public IEnumerable<Dialog> GetDialogsPreview(Guid userId, Int32? offset, Int32 count)
        {
            var result =_dialogRepository.ReadDialogs(userId, count, offset ?? 0);
            return result;
        }

        public Dialog CreateDialog(Guid firstUserId, Guid secondUserId)
        {
            return _dialogRepository.CreateDialog(firstUserId, secondUserId);
        }
    }
}