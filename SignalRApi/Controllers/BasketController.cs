using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SignalR.BusinessLayer.Abstract;
using SignalR.DataAccsessLayer.Concrete;
using SignalR.DtoLayer.BasketDto;
using SignalR.DtoLayer.CouponCodeDto;
using SignalR.EntityLayer.Entities;
using SignalRApi.Models;

namespace SignalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BasketController : ControllerBase
    {
        private readonly IBasketService _basketService;
        private readonly ICouponService _couponService;

        public BasketController(IBasketService basketService, ICouponService couponService)
        {
            _basketService = basketService;
            _couponService = couponService;
        }
        [HttpGet]
        public IActionResult getByBasketMenuTaleID(int id)
        {
            var values = _basketService.TgetBasketByMenuTableNumber(id);
            return Ok(values);
        }
        [HttpGet("BasketListByMenuTableWithProductsName")]
        public IActionResult BasketListByMenuTableWithProductsName(int id)
        {
            using var context = new SignalRContext();
            var values = context.Baskets.Include(x => x.Product).Where(y => y.MenuTableID == id).Select(z => new ResultBasketListWithProducts
            {
                BasketID = z.BasketID,
                Count = z.Count,
                MenuTableID = z.MenuTableID,
                ProductID = z.ProductID,
                ProductName = z.Product.ProductName,
                ProductPrice = z.ProductPrice,
                TotalPrice = z.TotalPrice

            }).ToList();

            return Ok(values);
        }
        [HttpPost]
        public IActionResult CreateBasket(CreateBasketDto createBasketDto)
        {
            using var context = new SignalRContext();
            _basketService.TInsert(new Basket()
            {
                ProductID = createBasketDto.ProductID,
                Count = 1,
                MenuTableID = 20,
                ProductPrice = context.Products.Where(x => x.ProductID == createBasketDto.ProductID).Select(y => y.Price).FirstOrDefault(),
                TotalPrice = 0,


            });
            return Ok();
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteBasket(int id)
        {
            var remove = _basketService.TgetById(id);
            _basketService.TDelete(remove);
            return Ok();
        }

        [HttpGet("{id},{coupun}")]
        public IActionResult SetCouponCode(int id, string coupun)//masanın idsi tutuluyor.
        {
            decimal getCoupun = _basketService.TSetCouponCode(coupun);
            decimal masaTableTotalPrice = _basketService.TgetBasketByMenuTableNumber(id).Sum(y => y.TotalPrice);

            decimal result = (masaTableTotalPrice * getCoupun) / 100;

            ResultBasketWithCoupon resultBasketWithCoupon = new ResultBasketWithCoupon();
            resultBasketWithCoupon.DiscountAmount = getCoupun;
            resultBasketWithCoupon.TotalPrice = masaTableTotalPrice - result;
            resultBasketWithCoupon.DiscountPrice = result;

            return Ok(resultBasketWithCoupon);
        }
    }
}
