﻿using System;
using System.Collections.Generic;
using System.Linq;
using JustR.DialogService.Repository;
using JustR.Models.Dto;
using JustR.Models.Entity;

namespace JustR.DialogService.Service
{
    public class DummyDialogService : IDialogService
    {
        private readonly IDialogRepository _dialogRepository;

        public DummyDialogService(IDialogRepository dialogRepository)
        {
            _dialogRepository = dialogRepository;
        }

        public Dialog GetDialog(Guid dialogId)
        {
            var res = _dialogRepository.ReadDialog(dialogId);

            return res;
        }

        public IEnumerable<Dialog> GetDialogsPreview(Guid userId, Int32? offset, Int32 count)
        {
            var res = _dialogRepository.ReadDialogs(userId, count, offset ?? 0);

            return res;
        }

        public Dialog CreateDialog(Guid firstUserId, Guid secondUserId)
        {
            var res = _dialogRepository.CreateDialog(firstUserId, secondUserId);

            return res;
        }
    }
}