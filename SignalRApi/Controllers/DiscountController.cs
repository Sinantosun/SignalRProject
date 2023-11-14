using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;
using SignalR.DtoLayer.DiscountDto;
using SignalR.EntityLayer.Entities;

namespace SignalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DiscountController : ControllerBase
    {
        private readonly IDiscountService _discountService;
        private readonly IMapper _mapper;

        public DiscountController(IDiscountService discountService, IMapper mapper)
        {
            _discountService = discountService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult DiscountList()
        {
            var value = _mapper.Map<List<ResultDiscountDto>>(_discountService.TGetList());
            return Ok(value);
        }
        [HttpPost]
        public IActionResult CreateDiscount(CreateDiscountDto createDiscountDto)
        {

            _discountService.TInsert(new Discount()
            {
                Amout = createDiscountDto.Amout,
                Description = createDiscountDto.Description,
                ImageUrl = createDiscountDto.ImageUrl,
                Title = createDiscountDto.Title,
                status = false,
            });
            return Ok("İndirim Eklendi.");
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteDiscount(int id)
        {
            var value = _discountService.TgetById(id);
            _discountService.TDelete(value);
            return Ok("İndirim Silindi.");

        }
        [HttpGet("{id}")]
        public IActionResult GetDiscountWithId(int id)
        {
            var values = _discountService.TgetById(id);
            return Ok(values);
        }
        [HttpPut]
        public IActionResult UpdateDiscount(UpdateDiscountDto updateDiscountDto)
        {
            _discountService.TUpdate(new Discount()
            {
                status = false,
                Amout = updateDiscountDto.Amout,
                Description = updateDiscountDto.Description,
                DiscountID = updateDiscountDto.DiscountID,
                Title = updateDiscountDto.Title,
                ImageUrl = updateDiscountDto.ImageUrl,
            });
            return Ok("İndirim Başarıyla Guncellendi.");
        }
        [HttpGet("ChangeToTrue/{id}")]
        public IActionResult ChangeToTrue(int id)
        {
            _discountService.TChangeStatusToTrue(id);
            return Ok();
        }

        [HttpGet("ChangeToFalse/{id}")]
        public IActionResult ChangeToFalse(int id)
        {
            _discountService.TChangeStatusToFalse(id);
            return Ok();
        }
        [HttpGet("ListGetByTrue")]
        public IActionResult ListGetByTrue()
        {
            return Ok(_discountService.TGetListByStatusTrue());
        }
    }
}
