using System;
using System.Collections.Generic;
using System.Linq;
using JustR.Core.Entity;
using SqlKata.Compilers;

namespace JustR.DialogService.Repository
{
    public class DialogRepository : IDialogRepository
    {
        private readonly DialogDbContext _context;
        public DialogRepository(DialogDbContext context)
        {A
            _context = context;
        }

        public Dialog ReadDialog(Guid dialogId)
        {
            return _context.Dialogs.Find(dialogId);
        }

        public Dialog CreateDialog(Dialog dialog)
        {
            Dialog entity = _context.Dialogs.Add(dialog).Entity;
            _context.SaveChanges();

            return entity;
        }

        public IReadOnlyList<Dialog> ReadDialogs(Guid userId, Int32 count, Int32 offset = 0)
        {
            return _context
                .Dialogs
                .Where(k => k.FirstUserId == userId || k.SecondUserid == userId)
                .OrderBy(k => k.LastMessageTime)
                .Skip(offset)
                .Take(count)
                .ToList();
        }

        public Guid ReadDialogId(Guid firstUserId, Guid secondUserId)
        {
            Dialog dialog = _context.Dialogs.SingleOrDefault(k =>
                k.FirstUserId == firstUserId && k.SecondUserid == secondUserId ||
                k.FirstUserId == secondUserId && k.SecondUserid == firstUserId);

            return dialog?.DialogId ?? Guid.Empty;
        }

        public Dialog UpdateLastMessage(Guid dialogId, Guid authorId, String text, DateTime sendDate)
        {
            Dialog dialog = _context.Dialogs.Find(dialogId);

            if (dialog is null)
                return null;

            dialog.LastMessageText = text;
            dialog.LastMessageTime = sendDate;
            dialog.LastMessageAuthor = authorId;

            _context.SaveChanges();

            return dialog;
        }
    }
}