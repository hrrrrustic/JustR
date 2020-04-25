using SqlKata.Compilers;

namespace JustR.MessageService.Repository
{
    public class MessageRepository : IMessageRepository
    {
        private readonly Compiler _sqlCompiler;

        public MessageRepository(Compiler sqlCompiler)
        {
            _sqlCompiler = sqlCompiler;
        }

        public void GetMessage()
        {
            throw new System.NotImplementedException();
        }

        public void AddMessage()
        {
            throw new System.NotImplementedException();
        }
    }
}