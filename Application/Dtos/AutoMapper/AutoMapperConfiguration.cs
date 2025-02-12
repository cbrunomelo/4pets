using Application.Dtos.AutoMapper.Profiles;
using AutoMapper;
using Domain.Commands;
using Domain.Entitys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dtos.Conf
{
    public static class AutoMapperConfiguration
    {
        private static IMapper _mapper;
        public static IMapper Get()
        {
            if (_mapper == null)
                _mapper = BuildMapper();

            return _mapper;
        }
        public static IMapper BuildMapper()
        {
            var Conf = new MapperConfiguration(cfg =>
        {
            cfg.AddProfile(new ProdutoProfile());
        }); 
            return Conf.CreateMapper();
        }
    };



}
