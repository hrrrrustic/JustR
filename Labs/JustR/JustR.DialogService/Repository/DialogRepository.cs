using System;
using System.Collections.Generic;
using JustR.Models.Entity;
using SqlKata.Compilers;

namespace JustR.DialogService.Repository
{
    public class DialogRepository : IDialogRepository
    {
        private readonly Compiler _sqlCompiler;

        public DialogRepository(Compiler sqlCompiler)
        {
            _sqlCompiler = sqlCompiler;
        }

        public Dialog ReadDialog(Guid dialogId)
        {
            throw new NotImplementedException();
        }

        public Dialog CreateDialog(Guid firstUserId, Guid secondUserId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Dialog> ReadDialogs(Guid userId, Int32 count, Int32 offset = 0)
        {
            throw new NotImplementedException();
        }
    }
}