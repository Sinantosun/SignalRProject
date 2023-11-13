using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;
using SignalR.DtoLayer.NotificationDto;
using SignalR.EntityLayer.Entities;

namespace SignalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotificationsController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly INotificationService _notificationService;

		public NotificationsController(INotificationService notificationService, IMapper mapper)
		{
			_notificationService = notificationService;
			_mapper = mapper;
		}
		[HttpGet]
        public IActionResult NotificationList()
        {
            return Ok(_notificationService.TGetList());
        }
        [HttpGet("NotficationCountByStatusFalse")]
        public IActionResult NotficationCountByStatusFalse()
        {
            return Ok(_notificationService.TNotifactionCountByStatusFalse());
        }

		[HttpGet("NotficationListActive")]
		public IActionResult NotficationListActive()
		{
			return Ok(_notificationService.TgetAllNotificationActive());
		}
        [HttpPost]
        public IActionResult CreateNotification(CreateNotificationDto createNotificationDto)
        {
            createNotificationDto.Status = false;
            createNotificationDto.Date = Convert.ToDateTime(DateTime.Now.ToShortDateString());
			var values = _mapper.Map<Notification>(createNotificationDto);
			_notificationService.TInsert(values);
            return Ok();
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteNotification(int id)
        {
            var value = _notificationService.TgetById(id);
            _notificationService.TDelete(value);
            return Ok();
        }

		[HttpGet("{id}")]
		public IActionResult GetNotification(int id)
		{
			var value = _notificationService.TgetById(id);
			return Ok(value);
		}
        [HttpPut]
		public IActionResult UpdateNotification(UpdateNotificationDto updateNotificationDto)
		{
			var values = _mapper.Map<Notification>(updateNotificationDto);
			_notificationService.TUpdate(values);
			return Ok();
		}
        [HttpGet("ChangeNotificationStatusTrue/{id}")]
        public IActionResult ChangeNotificationStatusTrue(int id)
        {
            _notificationService.TNotificationStatusChangeTrue(id);
            return Ok();
        }

        [HttpGet("ChangeNotificationStatusFalse/{id}")]
        public IActionResult ChangeNotificationStatusFalse(int id)
        {
            _notificationService.TNotificationStatusChangeFalse(id);
            return Ok();
        }

    }
}
