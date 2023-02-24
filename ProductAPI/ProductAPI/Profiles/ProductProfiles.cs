using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using ProductAPI.DTO;

namespace ProductAPI.Profiles
{
    public class ProductProfiles:Profile
    {
        public ProductProfiles()
        {
            //Source->Target
            CreateMap<Product, ProductDto>();
            CreateMap<ProductDto, Product>();
        }
    }
}
