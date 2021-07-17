using Microsoft.AspNetCore.Mvc;
using SqlDeneme.WebAPI.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqlDeneme.WebAPI.Controllers
{
    [Route("api/[Controller]/[Action]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {

        private readonly ProductDbContext _context;


        public ProductsController(ProductDbContext context)
        {
            _context = context;
        }


        [HttpGet]
        //localhost:/api/products/getallproducts
        public IActionResult GetAllProducts()
        {
            var products = _context.Products.ToList();
            return Ok(products);
        }

        [HttpGet]
        [Route("{productId:int}")]
        public IActionResult GetProductById(int productId)
        {
            var product = _context.Products.Find(productId);
           
            if(product == null)
            {
                return BadRequest("Ürün Bulunamadı.");
            }

            return Ok(product);
        }


        [HttpPost]
        public IActionResult AddProduct(Product product)
        {
            _context.Products.Add(product);
            _context.SaveChanges();
            return Ok("Ürün Başarıyla Eklendi.");

        }
    }
}
