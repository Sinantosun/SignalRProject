using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;
using SignalR.DataAccsessLayer.Abstract;
using SignalR.DtoLayer.MessagesDto;
using SignalR.EntityLayer.Entities;

namespace SignalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessagesController : ControllerBase
    {
        private readonly IMessageService _messageService;
        private readonly IMapper _mapper;

        public MessagesController(IMessageService messageService, IMapper mapper)
        {
            _messageService = messageService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult MessageList()
        {
            var values = _messageService.TGetList();
            return Ok(values);
        }
        [HttpPost]
        public IActionResult CreateMessage(CreateMessagesDto createMessagesDto)
        {
            createMessagesDto.status = false;
            var values = _mapper.Map<Messages>(createMessagesDto);
            _messageService.TInsert(values);
            return Ok("Hakkımda Kısmı Başarılı Bir Şekilde Eklendi");
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteMessage(int id)
        {
            var value = _messageService.TgetById(id);
            _messageService.TDelete(value);
            return Ok("Silinme işlemi başarılı");
        }
        [HttpPut]
        public IActionResult UpdateMessage(UpdateMessageDto updateMessageDto)
        {
            updateMessageDto.status = false;
            var mapMessage = _mapper.Map<Messages>(updateMessageDto);
            _messageService.TUpdate(mapMessage);
            return Ok("Alan Güncelleme Işlemi Başarıyla Sonuçlandı.");
        }
        [HttpGet("{id}")]
        public IActionResult GetMessage(int id)
        {
            var value = _messageService.TgetById(id);
            return Ok(value);
        }
    }
}
