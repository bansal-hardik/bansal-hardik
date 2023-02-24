using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProductAPI.DTO;
using ProductAPI.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductServices _productServices;
        private readonly IMapper _mapper;

        public ProductController(IProductServices productServices,IMapper mapper)
        {
            _productServices = productServices;
            _mapper = mapper;
        }
        

        /// <summary>
        /// GET All Product Names
        /// Ex: ./api/product
        /// </summary>

        [HttpGet]
        [Authorize(Policy = "UserSecure")]
        public ActionResult<IEnumerable<ProductDto>> GetAllData()
        {
            var allProduct = _productServices.GetDetails();
            return Ok(_mapper.Map<IEnumerable<ProductDto>>(allProduct));

        }

        /// <summary>
        /// Get Product data By Id
        /// Ex: ./api/product/1
        /// </summary>
        [HttpGet("{id}")]
        
        public ActionResult <ProductDto> GetProductDataById(int id)
        {
            var idProduct = _productServices.GetProductById(id);
            if (idProduct != null)
            {
                return Ok(_mapper.Map<ProductDto>(idProduct));
            }
            return NotFound();
        }

        /// <summary>
        /// POST Product  
        /// Ex: ./api/product
        /// </summary>
        [HttpPost]
        [Authorize(Policy = "AdminSecure")]
        public ActionResult<ProductDto> CreateProduct(ProductDto productCreateDTO)
        {
            var productModel = _mapper.Map<Product>(productCreateDTO);
            _productServices.Create(productModel);
            _productServices.SaveChanges();

            var productReadDTO= _mapper.Map<ProductDto>(productModel);
            return Ok(productReadDTO);
        }

        /// <summary>
        /// PUT the Product By Id
        /// Ex: ./api/product/1
        /// </summary>
        [HttpPut("{id}")]
        [Authorize(Policy = "AdminSecure")]
        public ActionResult UpdateProduct(int id, ProductDto productDto)
        {
            var productModelfromDb = _productServices.GetProductById(id);
            if (productModelfromDb == null)
            {
                return NotFound();
            }
            productDto.Id = id;
            _mapper.Map(productDto, productModelfromDb);

            _productServices.Update(productModelfromDb);
            _productServices.SaveChanges();
            return NoContent();
        }

        /// <summary>
        /// DELETE Product  
        /// Ex: .api/product/1
        /// </summary>
        [HttpDelete("{id}")]
        [Authorize(Policy = "AdminSecure")]
        public ActionResult DeleteProduct(int id)
        {
            var productModelfromDb = _productServices.GetProductById(id);
            if (productModelfromDb == null)
            {
                return NotFound();
            }
            _productServices.Delete(productModelfromDb);
            _productServices.SaveChanges();

            return NoContent();
        }
    }
}
