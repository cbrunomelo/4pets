using Domain.Entitys;
using Domain.Handlers.Contracts;

namespace Domain.Handlers
{
    public class HandleResult : IHandleResult
    {
        public bool Sucess { get; }
        public string Message { get; }
        public object Data { get; }
        public List<String> Errors { get; }

        public HandleResult(bool sucess, string message, object data)
        {
            this.Sucess = sucess;
            this.Message = message;
            this.Data = data;
            this.Errors = new List<string>();
        }

        public HandleResult(string message, List<string> errors)
        {
            this.Sucess = false;
            this.Message = message;
            this.Errors = errors;
        }   
    }
}