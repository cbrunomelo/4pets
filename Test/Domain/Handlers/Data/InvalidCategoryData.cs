using Domain.Commands.CategoryCommands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test.Domain.Handlers.Data
{
    internal class InvalidCategoryData
    {
        public static IEnumerable<object[]> GetData()
        {
            yield return new object[] { new CreateCategoryCommand("", "Description 1") };
            yield return new object[] { new CreateCategoryCommand("Category 1", "") };
            yield return new object[] { new CreateCategoryCommand("", "") };
            yield return new object[] { new CreateCategoryCommand(null, "Description 1") };
            yield return new object[] { new CreateCategoryCommand("Category 1", null) };
            yield return new object[] { new CreateCategoryCommand(null, null) };
        }
    }
}
