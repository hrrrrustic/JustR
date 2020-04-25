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

        public void Dialog()
        {
            throw new System.NotImplementedException();
        }

        public void GetDialogs()
        {
            throw new System.NotImplementedException();
        }
    }
}