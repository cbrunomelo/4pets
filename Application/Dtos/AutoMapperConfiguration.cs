using AutoMapper;
using Domain.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dtos
{
    public static class AutoMapperConfiguration
    {

        public static IMapper Get()
        {
            return new MapperConfiguration(cfg =>
        {
            cfg.CreateMap<ProductDto, CreateProductCommand>();
            cfg.CreateMap<ProductDto, UpdateProductCommand>()
                .ConstructUsing((src, context) =>
                {
                    var userId = context.Items["UserId"];
                    return new UpdateProductCommand(src.Id, src.Name, src.Price, src.Description, src.Category, (int)userId);
                });
        
        }).CreateMapper();
        }
    }; 



}
