using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SignalRWebUI.Dtos.BookingDtos;
using System.Text;

namespace SignalRWebUI.Controllers
{

    public class BookingController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public BookingController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();
            var responMessage = await client.GetAsync("https://localhost:7189/api/Booking");
            if (responMessage.IsSuccessStatusCode)
            {
                var jsonData = await responMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultBookingDto>>(jsonData);
                return View(values);
            }
            return View();
        }
        [HttpGet]
        public IActionResult CreateBooking()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateBooking(CreateBookingDto createBookingDto)
        {
            createBookingDto.Description = "Onay Bekliyor";
            createBookingDto.HtmlEncodeProperties();
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(createBookingDto);
            StringContent strContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("https://localhost:7189/api/Booking", strContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }

        public async Task<IActionResult> DeleteBooking(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.DeleteAsync($"https://localhost:7189/api/Booking/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> UpdateBooking(int id)
        {
            
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"https://localhost:7189/api/Booking/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<UpdateBookingDto>(jsonData);
                if (values != null)
                {
                    values.HtmlDecodeProperties();
                }
                TempData["id"] = id;
                return View(values);
            }
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UpdateBooking(UpdateBookingDto updateBookingDto)
        {
            if (TempData["id"] != null)
            {
                int conv = Convert.ToInt32(TempData["id"]);
                if (updateBookingDto.BookingID == conv)
                {
                    updateBookingDto.Description = "deneme";
                    var client = _httpClientFactory.CreateClient();
                    var jsonData = JsonConvert.SerializeObject(updateBookingDto);
                    StringContent strContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
                    var responseMessage = await client.PutAsync("https://localhost:7189/api/Booking", strContent);
                    if (responseMessage.IsSuccessStatusCode)
                    {
                        TempData["id"] = null;
                        return RedirectToAction("Index");
                    }
                }
                else
                {
                    return RedirectToAction("UpdateBooking", "Booking");
                }
            }

            return View();
        }


        public async Task<IActionResult> ApproveBooking(int id)
        {
            var client = _httpClientFactory.CreateClient();
            await client.GetAsync($"https://localhost:7189/api/Booking/BookingStatusApprov/{id}");

            return View("Index");
        }

        public async Task<IActionResult> ApproveCancel(int id)
        {
            var client = _httpClientFactory.CreateClient();
            await client.GetAsync($"https://localhost:7189/api/Booking/BookingStatusCancel/{id}");

            return View("Index");
        }

    }
}
