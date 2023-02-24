using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProductDetailsAPI.DTO;
using ProductDetailsAPI.Model;
using ProductDetailsAPI.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductDetailsAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductDetailsController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IProductDetailsServices _productDetailsServices;

        public ProductDetailsController(IProductDetailsServices productDetailsServices,
            IMapper mapper)
        {
            _mapper = mapper;
            _productDetailsServices = productDetailsServices;
        }

        /// <summary>
        /// GET All Product Details
        /// Ex: ./api/productdetails
        /// </summary>
        [HttpGet]
        [Authorize(Policy = "UserSecure")]
        public ActionResult<IEnumerable<ProductDetailDto>> GetAllData()
        {
            var allProduct = _productDetailsServices.GetDetails();
            return Ok(_mapper.Map<IEnumerable<ProductDetailDto>>(allProduct));
        }

        /// <summary>
        /// POST Product Details 
        /// Ex: ./api/productdetails
        /// </summary>
        [HttpPost]
        [Authorize(Policy = "AdminSecure")]
        public ActionResult<ProductDetailDto> CreateProduct(ProductDetailDto productCreateDTO)
        {
            var productModel = _mapper.Map<ProductDetails>(productCreateDTO);
            _productDetailsServices.Create(productModel);
            _productDetailsServices.SaveChanges();

            var productReadDTO = _mapper.Map<ProductDetailDto>(productModel);
            return Ok(productReadDTO);
        }

        /// <summary>
        /// DELETE Product Details 
        /// Ex: .api/productdetails/1
        /// </summary>
        [HttpDelete("{id}")]
        [Authorize(Policy = "AdminSecure")]
        public ActionResult DeleteProduct(int id)
        {
            var productModelfromDb = _productDetailsServices.GetProductDetailsById(id);
            if (productModelfromDb == null)
            {
                return NotFound();
            }
            _productDetailsServices.Delete(productModelfromDb);
            _productDetailsServices.SaveChanges();

            return NoContent();
        }

        
    }
}
