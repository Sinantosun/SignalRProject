using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;
using SignalR.DtoLayer.AboutDto;
using SignalR.EntityLayer.Entities;

namespace SignalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AboutController : ControllerBase
    {
        private readonly IAboutService _IAboutService;
        private readonly IMapper _mapper;
        public AboutController(IAboutService ıAboutService, IMapper mapper)
        {
            _IAboutService = ıAboutService;
            _mapper = mapper;
        }
        [HttpGet]
        public IActionResult AboutList()
        {
            var values = _IAboutService.TGetList();
            return Ok(values);
        }
        [HttpPost]
        public IActionResult CreateAbout(CreateAboutDto createAboutDto)
        {
            var values = _mapper.Map<About>(createAboutDto);
            _IAboutService.TInsert(values);

            return Ok("Hakkımda Kısmı Başarılı Bir Şekilde Eklendi");
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteAbout(int id)
        {
            var value = _IAboutService.TgetById(id);
            _IAboutService.TDelete(value);
            return Ok("Silinme işlemi başarılı");
        }
        [HttpPut]
        public IActionResult UpdateAbout(UpdateAboutDto updateAboutDto)
        {
            About about = new About()
            {
                AboutID = updateAboutDto.AboutID,
                Title = updateAboutDto.Title,
                Description = updateAboutDto.Description,
                ImageUrl = updateAboutDto.ImageUrl,
            };
            _IAboutService.TUpdate(about);
            return Ok("Alan Güncelleme Işlemi Başarıyla Sonuçlandı.");
        }
        [HttpGet("{id}")]
        public IActionResult GetAbout(int id)
        {
            var value = _IAboutService.TgetById(id);
            return Ok(value);
        }

    }
}
