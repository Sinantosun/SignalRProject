using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;
using SignalR.DtoLayer.ProductDto;
using SignalR.DtoLayer.SocialMediaDto;
using SignalR.EntityLayer.Entities;

namespace SignalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SocialMediaController : ControllerBase
    {
        private readonly ISocialMedaiService _socialMedaiService;
        private readonly IMapper _mapper;

        public SocialMediaController(ISocialMedaiService socialMedaiService, IMapper mapper)
        {
            _socialMedaiService = socialMedaiService;
            _mapper = mapper;
        }
        [HttpGet]
        public IActionResult SocailMediaList()
        {
            var value = _mapper.Map<List<ResultSocialMediaDto>>(_socialMedaiService.TGetList());
            return Ok(value);
        }
        [HttpPost]
        public IActionResult CreateSocailMedia(CreateSocialMediaDto resultSocialMediaDto)
        {
            _socialMedaiService.TInsert(new SocailMedia()
            {
                Icon = resultSocialMediaDto.Icon,
                Title = resultSocialMediaDto.Title,
                Url = resultSocialMediaDto.Url,

            });
            return Ok("Yeni Sosyal Medya Eklendi.");
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteSocialMedia(int id)
        {
            var value = _socialMedaiService.TgetById(id);
            _socialMedaiService.TDelete(value);
            return Ok("Sosyal Medaya Silindi.");
        }
        [HttpGet("{id}")]
        public IActionResult GetSocialMediaWithId(int id)
        {
            var values = _socialMedaiService.TgetById(id);
            return Ok(values);
        }
        [HttpPut]
        public IActionResult UpdateSocailMedia(UpdateSocialMediaDto updateSocialMediaDto)
        {
            _socialMedaiService.TUpdate(new SocailMedia()
            {
                SocailMediaID = updateSocialMediaDto.SocailMediaID,
                Icon = updateSocialMediaDto.Icon,
                Title = updateSocialMediaDto.Title,
                Url = updateSocialMediaDto.Url,
            });
            return Ok("Sosyal Medya Guncellendi.");
        }
    }
}
