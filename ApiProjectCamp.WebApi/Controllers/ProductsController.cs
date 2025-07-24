using ApiProjectCamp.WebApi.Context;
using ApiProjectCamp.WebApi.Dtos.ProductDtos;
using ApiProjectCamp.WebApi.Entities;
using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApiProjectCamp.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IValidator<Product> _validator;
        private readonly ApiContext _context;
        private readonly IMapper _mapper;

        public ProductsController(IValidator<Product> validator, ApiContext apiContext, IMapper mapper)
        {
            _validator = validator;
            _context = apiContext;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult ProductList()
        {
            var value = _context.Products.ToList();
            return Ok(value);
        }

        [HttpPost]
        public IActionResult CrateProduct(Product product)
        {
            var validationResult = _validator.Validate(product);
            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors.Select(x => x.ErrorMessage));
            }
            else
            {
                _context.Products.Add(product);
                _context.SaveChanges();
                return Ok("Ürün eklendi");
            }
        }
        [HttpDelete]
        public IActionResult DeleteProduct(int id)
        {

            var product = _context.Products.Find(id);
            _context.Products.Remove(product);
            _context.SaveChanges();
            return Ok("Silme işlemi başarılı");

        }
        [HttpGet("GetProduct")]
        public IActionResult GetProduct(int id)
        {
            var product = _context.Products.Find(id);
            return Ok(product);
        }

        [HttpPut]
        public IActionResult UpdateProduct(Product product)
        {
            var validatorProduct = _validator.Validate(product);
            if (!validatorProduct.IsValid)
            {
                return BadRequest(validatorProduct.Errors.Select(x => x.ErrorMessage));
            }
            else
            {
                _context.Products.Update(product);
                _context.SaveChanges();
                return Ok("Güncelleme İşlemi başarılı");
            }

        }

        [HttpPost("CreateProductWithCategory")]
        public IActionResult CreateProductWithCategory(CreateProductDto createProductDto)
        {
            var value = _mapper.Map<Product>(createProductDto);
            _context.Products.Add(value);
            _context.SaveChanges();
            return Ok("Ekleme işlemi başarılı");
        }

        [HttpGet("ProductListWithCategory")]
        public IActionResult ProductListWithCategory() 
        {
            var value = _context.Products.Include(x=> x.Category).ToList();
            return Ok(_mapper.Map<List<ResultProductWithCategory>>(value));
        }



    }


}

