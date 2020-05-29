using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using JustR.Models.Entity;
using SqlKata;
using SqlKata.Compilers;
using SqlKata.Execution;

namespace JustR.DialogService.Repository
{
    public class DialogRepository : IDialogRepository
    {

        private readonly QueryFactory _queryFactory;

        private readonly DialogDbContext _context;
        public DialogRepository(Compiler sqlCompiler, DialogDbContext context)
        {
            _context = context;
            _queryFactory = new QueryFactory(new SqlConnection(DbConfiguration.ConnectionString), sqlCompiler);
        }

        public Dialog ReadDialog(Guid dialogId)
        {
            return _context.Dialogs.Find(dialogId);



            return _queryFactory
                .Query("Dialogs")
                .Where("dialogId", dialogId)
                .First<Dialog>();

        }

        public Dialog CreateDialog(Dialog dialog)
        {
            var entity = _context.Dialogs.Add(dialog).Entity;
            _context.SaveChanges();
            return entity;



            _queryFactory
                .Query("Dialogs")
                .Insert(dialog);

            return dialog;

        }

        public List<Dialog> ReadDialogs(Guid userId, Int32 count, Int32 offset = 0)
        {
            return _context
                .Dialogs
                .Where(k => k.FirstUserId == userId || k.SecondUserid == userId)
                .OrderBy(k => k.LastMessageTime)
                .Skip(offset)
                .Take(count)
                .ToList();

            return _queryFactory
                .Query("Dialogs")
                .Where("FirstUserId", userId)
                .Or()
                .Where("SecondUserId", userId)
                .Get<Dialog>()
                .ToList();
        }

        public Guid ReadDialogId(Guid firstUserId, Guid secondUserId)
        {
            var dialog = _context.Dialogs.SingleOrDefault(k =>
                k.FirstUserId == firstUserId && k.SecondUserid == secondUserId ||
                k.FirstUserId == secondUserId && k.SecondUserid == firstUserId);

            return dialog?.DialogId ?? Guid.Empty;
        }

        public Dialog UpdateLastMessage(Guid dialogId, Guid authorId, String text, DateTime sendDate)
        {
            var dialog = _context.Dialogs.Find(dialogId);

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