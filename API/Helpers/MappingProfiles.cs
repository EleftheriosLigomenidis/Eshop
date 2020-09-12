using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Dtos;
using AutoMapper;
using Core.Entities;

namespace API.Helpers
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Product, ProductToReturn>().ForMember(dto => dto.ProductBrand,
                o => o.MapFrom(model => model.ProductBrand.Name))
                .ForMember(dto => dto.ProductType,
                o => o.MapFrom(model => model.ProductType.Name))
                .ForMember(dto => dto.ProductPhotoUrl, o => o.MapFrom<ProductUrlResolver>())
                .ReverseMap();
        }
    }
}
