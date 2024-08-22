using Application.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Messaging
{
    internal interface IResultService
    {
        IDto Result { get; }
        bool Sucess { get; }
        string Message { get; }
        List<string> Errors { get; }

    }
}
