using Domain.Commands.CategoryCommands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test.Domain.Handlers.Data
{
    internal class ValidCategoryData
    {
        public static IEnumerable<object[]> GetData()
        {
            yield return new object[] { new CreateCategoryCommand("Category 1", "Description 1", 1) };
        }
    }
}
