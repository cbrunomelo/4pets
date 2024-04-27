using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Commands.CategoryCommands
{
    public class CreateCategoryCommand
    {
        public string Name { get; set; }
        public string Description { get; set; }

        public CreateCategoryCommand(string name, string description)
        {
            Name = name;
            Description = description;
        }
    }
}
