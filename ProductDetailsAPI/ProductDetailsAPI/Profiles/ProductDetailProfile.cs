using AutoMapper;
using ProductDetailsAPI.DTO;
using ProductDetailsAPI.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductDetailsAPI.Profiles
{
    public class ProductDetailProfile:Profile
    {
        public ProductDetailProfile()
        {
            //Source->Target
            CreateMap<ProductDetails, ProductDetailDto>();
            CreateMap<ProductDetailDto, ProductDetails>();
        }
    }
}
