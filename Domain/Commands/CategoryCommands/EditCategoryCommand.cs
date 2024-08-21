using Domain.Commands.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Commands.CategoryCommands
{
    public record EditCategoryCommand(int Id, string Name, string Description,int UserId) : ICommand;

}
