using AutoMapper;
using Domain.Commands;
using Domain.Entitys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dtos.AutoMapper.Profiles
{
    internal class ProdutoProfile : Profile
    {
        public ProdutoProfile()
        {
            CreateMap<ProductDto, CreateProductCommand>()
                            .ConvertUsing((src, dest, context) =>
                            {
                                var userid = context.Items["UserId"];
                                return new CreateProductCommand(src.Name, src.Price, src.Description, src.CategoryId, (int)userid);
                            });


            CreateMap<Product, ProductDto>();


            CreateMap<ProductDto, UpdateProductCommand>()
                .ConstructUsing((src, context) =>
                {
                    var userid = context.Items["UserId"];
                    return new UpdateProductCommand(src.Id, src.Name, src.Price, src.Description, src.CategoryId, (int)userid);
                });

            CreateMap<Product, ProductDto>()
                .ForMember(dest => dest.CategoryId, opt => opt.MapFrom(src => src.CategoryId ?? 0));
        }
    }
}
