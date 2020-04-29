using System;
using System.Collections.Generic;
using System.Linq;
using JustR.Models.Entity;

namespace JustR.DialogService.Repository
{
    public class DummyDialogRepository : IDialogRepository
    {
        private static List<Dialog> _dummyDialogs = new List<Dialog>();
        public Dialog ReadDialog(Guid dialogId)
        {
            return _dummyDialogs.Single(k => k.DialogId == dialogId);
        }

        public Dialog CreateDialog(Guid firstUserId, Guid secondUserId)
        {
            var newDialog = new Dialog
            {
                DialogId = Guid.NewGuid(),
                DialogName = "TEST DIALOG ! " + _dummyDialogs.Count,
                FirstUserId = firstUserId,
                SecondUserid = secondUserId
            };
            _dummyDialogs.Add(newDialog);
            return newDialog;
        }

        public IEnumerable<Dialog> ReadDialogs(Guid userId, Int32 count, Int32 offset = 0)
        {
            return _dummyDialogs
                .Where(k => k.FirstUserId == userId || k.SecondUserid == userId)
                .Skip(offset)
                .Take(count);

        }
    }
}