using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using JustR.Models.Entity;
using SqlKata;
using SqlKata.Compilers;
using SqlKata.Execution;

namespace JustR.DialogService.Repository
{
    public class DialogRepository : IDialogRepository
    {

        private readonly QueryFactory _queryFactory;
        public DialogRepository(Compiler sqlCompiler)
        {
            _queryFactory = new QueryFactory(new SqlConnection(DbConfiguration.ConnectionString), sqlCompiler);
        }

        public Dialog ReadDialog(Guid dialogId)
        {
            return _queryFactory
                .Query("Dialogs")
                .Where("dialogId", dialogId)
                .First<Dialog>();

        }

        public Dialog CreateDialog(Guid firstUserId, Guid secondUserId)
        {
            var dialog = new Dialog
            {
                FirstUserId = firstUserId,
                LastMessageTime = DateTime.Now,
                SecondUserid = secondUserId,
                DialogId = Guid.NewGuid(),
                LastMessageAuthor = Guid.Empty,
                DialogName = "TEST",
                LastMessageText = String.Empty
            };

            _queryFactory
                .Query("Dialogs")
                .Insert(dialog);

            return dialog;

        }

        public IEnumerable<Dialog> ReadDialogs(Guid userId, Int32 count, Int32 offset = 0)
        {
            return _queryFactory
                .Query("Dialogs")
                .Where("FirstUserId", userId)
                .Or()
                .Where("SecondUserId", userId)
                .Get<Dialog>();
        }
    }
}