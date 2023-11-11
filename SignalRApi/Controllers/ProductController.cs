using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SignalR.BusinessLayer.Abstract;
using SignalR.DataAccsessLayer.Concrete;
using SignalR.DtoLayer.ProductDto;
using SignalR.EntityLayer.Entities;

namespace SignalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        private readonly IMapper _mapper;

        public ProductController(IProductService productService, IMapper mapper)
        {
            _productService = productService;
            _mapper = mapper;
        }
        [HttpGet("ProductListWithCategory")]
        public IActionResult ProductListWithCategory()
        {
            var context = new SignalRContext();
            var value = context.Products.Include(x => x.Category).Select(y => new ResultProductWithCategories()
            {
                Description = y.Description,
                CategoryName = y.Category.CategoryName,
                ImageUrl = y.ImageUrl,
                Price = y.Price,
                ProductID = y.ProductID,
                ProductName = y.ProductName,
                ProductStatus = y.ProductStatus,
            }).ToList();
            return Ok(value);
        }

        [HttpGet]
        public IActionResult ProductList()
        {
            var value = _mapper.Map<List<ResultProductDto>>(_productService.TGetList());
            return Ok(value);
        }
        [HttpPost]
        public IActionResult CreateProduct(CreateProductDto createProductDto)
        {
            _productService.TInsert(new Product()
            {
                CategoryID=createProductDto.CategoryID,
                Description = createProductDto.Description,
                ImageUrl = createProductDto.ImageUrl,
                ProductName = createProductDto.ProductName,
                ProductStatus = createProductDto.ProductStatus,
                Price = createProductDto.Price,
            });
            return Ok("Ürün Eklendi.");
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteProduct(int id)
        {
            var value = _productService.TgetById(id);
            _productService.TDelete(value);
            return Ok("Ürün Silindi.");

        }
        [HttpGet("{id}")]
        public IActionResult GetProductWithId(int id)
        {
            var values = _productService.TgetById(id);
            return Ok(values);
        }
        [HttpPut]
        public IActionResult UpdateProduct(UpdateProductDto updateProductDto)
        {
            _productService.TUpdate(new Product()
            {
                CategoryID=updateProductDto.CategoryID,
                ProductID = updateProductDto.ProductID,
                Description = updateProductDto.Description,
                ImageUrl = updateProductDto.ImageUrl,
                ProductName = updateProductDto.ProductName,
                ProductStatus = updateProductDto.ProductStatus,
                Price = updateProductDto.Price,
            });
            return Ok("Ürün Başarıyla Guncellendi.");
        }
        [HttpGet("ProductCount")]
        public IActionResult ProductCount()
        {
            return Ok(_productService.TProductCount());
        }
        [HttpGet("ProductCountByCategoryNameHamburger")]
        public IActionResult ProductCountByCategoryNameHamburger()
        {
            return Ok(_productService.TProductCountByCategoryNameHamburger());
        }
        [HttpGet("ProductCountByCategoryNameDrink")]
        public IActionResult ProductCountByCategoryNameDrink()
        {
            return Ok(_productService.TProductCountByCategoryNameDrink());
        }
        [HttpGet("ProductPriceAvg")]
        public IActionResult ProductPriceAvg()
        {
            return Ok(_productService.TProductPriceAvg());
        }
        [HttpGet("ProductNamePriceByMax")]
        public IActionResult ProductNamePriceByMax()
        {
            return Ok(_productService.TProductNamePriceByMax());
        }
        [HttpGet("ProductNameMinPriceByMax")]
        public IActionResult ProductNameMinPriceByMax()
        {
            return Ok(_productService.TProductNameMinPriceByMax());
        }
        [HttpGet("AvgProductPriceByHambuger")]
        public IActionResult AvgProductPriceByHambuger()
        {
            return Ok(_productService.TAvgProductPriceByHambuger());
        }
    }
}
