using Application.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Messaging
{
    public class ResultService : IResultService
    {
        public IDto Result { get; set; }
        public bool Sucess { get; set; }
        public string Message { get; set; }
        public List<string> Errors { get; set; } = new List<string>();

        public ResultService(bool sucess, string message, IDto result)
        {
            Sucess = sucess;
            Message = message;
            Result = result;
        }

        public ResultService(bool sucess, string message, List<string> errors)
        {
            Sucess = sucess;
            Message = message;
            Errors = errors;
        }

        public ResultService(bool sucess, string message, string error)
        {
            Sucess = sucess;
            Message = message;
            Errors.Add(error);
        }


    }
}
