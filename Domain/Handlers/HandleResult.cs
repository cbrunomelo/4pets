using Domain.Entitys;
using Domain.Handlers.Contracts;

namespace Domain.Handlers
{
    internal class HandleResult : IHandleResult
    {
        private bool Sucess;
        private string Message;
        private object Data;
        private List<String> Errors;

        public HandleResult(bool sucess, string message, object data)
        {
            this.Sucess = sucess;
            this.Message = message;
            this.Data = data;
        }

        public HandleResult(bool sucess, string message, List<string> errors)
        {
            this.Sucess = sucess;
            this.Message = message;
            this.Errors = errors;
        }   
    }
}