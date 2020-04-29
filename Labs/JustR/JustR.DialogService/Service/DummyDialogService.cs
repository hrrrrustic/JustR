using System;
using System.Collections.Generic;
using System.Linq;
using JustR.DialogService.Repository;
using JustR.Models.Dto;

namespace JustR.DialogService.Service
{
    public class DummyDialogService : IDialogService
    {
        private readonly IDialogRepository _dialogRepository;

        public DummyDialogService(IDialogRepository dialogRepository)
        {
            _dialogRepository = dialogRepository;
        }

        public DialogInfoDto GetDialog(Guid dialogId)
        {
            var res = _dialogRepository.ReadDialog(dialogId);

            return new DialogInfoDto
            {
                DialogName = res.DialogName
            };
        }

        public IEnumerable<DialogPreviewDto> GetDialogsPreview(Guid userId, Int32? offset, Int32 count)
        {
            var res = _dialogRepository.ReadDialogs(userId, count, offset ?? 0);

            return res.Select(k => new DialogPreviewDto {DialogName = k.DialogName});
        }

        public DialogInfoDto CreateDialog(Guid firstUserId, Guid secondUserId)
        {
            var res = _dialogRepository.CreateDialog(firstUserId, secondUserId);

            return new DialogInfoDto
            {
                DialogName = res.DialogName
            };
        }
    }
}