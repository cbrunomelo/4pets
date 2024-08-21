using Domain.Commands.Contracts;
using Domain.Entitys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Commands.CategoryCommands
{
    public record DeleteCategoryCommand(int Id, int UserId) : ICommand;
}
