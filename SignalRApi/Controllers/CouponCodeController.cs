using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;
using SignalR.DtoLayer.CouponCodeDto;
using SignalR.EntityLayer.Entities;

namespace SignalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CouponCodeController : ControllerBase
    {
        private readonly ICouponService _couponService;
        private readonly IMapper _mapper;

        public CouponCodeController(ICouponService couponService, IMapper mapper)
        {
            _couponService = couponService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult CodeList()
        {
            var values = _couponService.TGetList();
            return Ok(values);
        }
        [HttpPost]
        public IActionResult CreateCode(CreateCoponCodeDto createCoponCodeDto)
        {
            var values = _mapper.Map<CouponCode>(createCoponCodeDto);
            _couponService.TInsert(values);

            return Ok("Başarılı Bir Şekilde Eklendi");
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteCode(int id)
        {
            var value = _couponService.TgetById(id);
            _couponService.TDelete(value);
            return Ok("Silinme işlemi başarılı");
        }
        [HttpPut]
        public IActionResult UpdateCode(UpdateCoponCodeDto updateCoponCodeDto)
        {
            CouponCode code = new CouponCode()
            {
              Amout=updateCoponCodeDto.Amout,
               CouponCodeID=updateCoponCodeDto.CouponCodeID,
               Title=updateCoponCodeDto.Title,
            };
            _couponService.TUpdate(code);
            return Ok("Alan Güncelleme Işlemi Başarıyla Sonuçlandı.");
        }
        [HttpGet("{id}")]
        public IActionResult GetCode(int id)
        {
            var value = _couponService.TgetById(id);
            return Ok(value);
        }
    }
}
