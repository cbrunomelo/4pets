using Application.Dtos.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Messaging
{
    public interface IResultService
    {
        IDto Data { get; }
        bool Sucess { get; }
        string Message { get; }
        List<string> Errors { get; }

    }
}
