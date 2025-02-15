using Domain.Entitys;
using Domain.Queries.CategoryQuerys;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Repository
{
    public interface ICategoryRepository : IRequestHandler<VerifyCategoryExist, bool>
    {
        bool CategoryExists(string name);
        int CreateCategory(Category category);
        bool Update(Category category);
        Category GetById(int id);
    }
}
