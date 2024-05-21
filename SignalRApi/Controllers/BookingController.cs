using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;
using SignalR.DtoLayer.BookingDto;
using SignalR.EntityLayer.Entities;

namespace SignalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        private readonly IBookingService _IBookingService;
        public BookingController(IBookingService ıBooking)
        {
            _IBookingService = ıBooking;
        }
        [HttpGet]
        public IActionResult BookingList()
        {
            var values = _IBookingService.TGetList();
            return Ok(values);
        }
        [HttpPost]
        public IActionResult CreateBooking(CreateBookingDto createBookingDto)
        {
            Booking booking = new Booking()
            {
                Description = createBookingDto.Description,
                Date = createBookingDto.Date,
                Mail = createBookingDto.Mail,
                Name = createBookingDto.Name,
                PersonCount = createBookingDto.PersonCount,
                Phone = createBookingDto.Phone
            };
            _IBookingService.TInsert(booking);
            return Ok("Rezervasyon Yapıldı");
        }
        [HttpPut]
        public IActionResult UpdateBooking(UpdateBookingDto updateBookingDto)
        {;
            Booking booking = new Booking()
            {
                BookingID = updateBookingDto.BookingID,
                Date = updateBookingDto.Date,
                Mail = updateBookingDto.Mail,
                Name = updateBookingDto.Name,
                PersonCount = updateBookingDto.PersonCount,
                Phone = updateBookingDto.Phone
            };
            _IBookingService.TUpdate(booking);
            return Ok("Guncelleme İşlemi Başarıyla Gerçekleşti.");
        }
        [HttpGet("{id}")]
        public IActionResult BookingGetById(int id)
        {
            var values = _IBookingService.TgetById(id);
            return Ok(values);
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteBooking(int id)
        {
            var removeId = _IBookingService.TgetById(id);
            _IBookingService.TDelete(removeId);
            return Ok("Silme İşlemi Başarılı.");
        }

        [HttpGet("BookingStatusApprov/{id}")]
        public IActionResult BookingStatusApprov(int id)
        {
            _IBookingService.TbookingStatusDescriptionApprove(id);
            return Ok();
        }
        [HttpGet("BookingStatusCancel/{id}")]
        public IActionResult BookingStatusCancel(int id)
        {
            _IBookingService.TbookingStatusDescriptionCancel(id);
            return Ok();
        }
    }
}
