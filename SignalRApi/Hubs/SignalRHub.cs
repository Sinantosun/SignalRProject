using Microsoft.AspNetCore.SignalR;
using SignalR.BusinessLayer.Abstract;
using SignalR.DataAccsessLayer.Concrete;

namespace SignalRApi.Hubs
{
    public class SignalRHub : Hub
    {

        private readonly ICategoryService _categoryService;
        private readonly IProductService _productService;
        private readonly IOrderService _orderService;
        private readonly IMoneyCaseService _moneyCaseService;
        private readonly IMenuTableService _menuTableService;
        private readonly IBookingService _bookingService;
        private readonly INotificationService _notificationService;

        public static int clientCount { get; set; } = 0;

        public SignalRHub(ICategoryService categoryService, IProductService productService, IOrderService orderService, IMoneyCaseService moneyCaseService, IMenuTableService menuTableService, IBookingService bookingService, INotificationService notificationService)
        {
            _categoryService = categoryService;
            _productService = productService;
            _orderService = orderService;
            _moneyCaseService = moneyCaseService;
            _menuTableService = menuTableService;
            _bookingService = bookingService;
            _notificationService = notificationService;
        }

        public async Task SendIstastisc()
        {
            var ReciveCategoryCount = _categoryService.TCategoryCount();
            await Clients.All.SendAsync("ReciveCategoryCount", ReciveCategoryCount);

            var ReciveProductCount = _productService.TProductCount();
            await Clients.All.SendAsync("ReciveProductCount", ReciveProductCount);

            var ReciveActiveCategoryCount = _categoryService.TActiveCategoryCount();
            await Clients.All.SendAsync("ReciveActiveCategoryCount", ReciveActiveCategoryCount);

            var RecivePassiveCategoryCount = _categoryService.TPassiveCategoryCount();
            await Clients.All.SendAsync("RecivePassiveCategoryCount", RecivePassiveCategoryCount);

            var HamburgerCount = _productService.TProductCountByCategoryNameHamburger();
            await Clients.All.SendAsync("ReciveHamburgerCount", HamburgerCount);

            var DrinkCount = _productService.TProductCountByCategoryNameDrink();//
            await Clients.All.SendAsync("ReciveDrinkCount", HamburgerCount);

            var AvgPrdouct = _productService.TProductPriceAvg();
            await Clients.All.SendAsync("ReciveAvgProduct", AvgPrdouct.ToString("0.00") + "₺");

            var ExpensiveProduct = _productService.TProductNamePriceByMax();
            await Clients.All.SendAsync("ReciveExpensivePrdouct", ExpensiveProduct);

            var ChepperProduct = _productService.TProductNameMinPriceByMax();
            await Clients.All.SendAsync("ReciveCheaperPrdouct", ChepperProduct);

            var HamburgerPrice = _productService.TAvgProductPriceByHambuger();
            await Clients.All.SendAsync("ReciveHamburgerPrice", HamburgerPrice);

            var TotalOrder = _orderService.TTotalOrderCount();
            await Clients.All.SendAsync("ReciveTotelOrder", TotalOrder);

            var ActiveOrder = _orderService.TActiveOrderCount();
            await Clients.All.SendAsync("ReciveActiveOrder", ActiveOrder);

            var LastOrder = _orderService.TLastOrderPrice();
            await Clients.All.SendAsync("ReciveLastOrder", LastOrder);

            var MoneyCaseAmount = _moneyCaseService.TTotalMoneyCaseAmount();
            await Clients.All.SendAsync("ReciveMoneyCase", MoneyCaseAmount);

            var TodayProfit = _orderService.TTodayTotalPrice();
            await Clients.All.SendAsync("ReciveTodayProfit", TodayProfit);

            var TableCount = _menuTableService.TMenuTableCount();
            await Clients.All.SendAsync("ReciveTableCount", TableCount);
        }
        public async Task SendProgress()
        {
            var ReciveMoneyCase = _moneyCaseService.TTotalMoneyCaseAmount();
            await Clients.All.SendAsync("ReciveMoneyCase", ReciveMoneyCase.ToString("0.00" + "₺"));

            var ActiveOrderCount = _orderService.TActiveOrderCount();
            await Clients.All.SendAsync("ReciveActiveOrderCount", ActiveOrderCount);

            var MenuActive = _menuTableService.TMenuTableCount();
            await Clients.All.SendAsync("ReciveMenuActive", MenuActive);

            var ProductPriceAvg = _productService.TProductPriceAvg();
            await Clients.All.SendAsync("ReciveProductAvgPriceProggres", ProductPriceAvg);

            var ProductMamburgerAvg = _productService.TAvgProductPriceByHambuger();
            await Clients.All.SendAsync("ReciveHamurgerAvgProggres", ProductMamburgerAvg);

            var DrinkCount = _productService.TProductCountByCategoryNameDrink();
            await Clients.All.SendAsync("ReciveDrinkCountProggres", DrinkCount);

            var GetRateForMenuTables = _menuTableService.TTableRateToAll();
            await Clients.All.SendAsync("ReciveMenuTablesRateProggres", GetRateForMenuTables);
        }

        public async Task GetBookingList()
        {
            var values = _bookingService.TGetList();
            await Clients.All.SendAsync("ReciveBookingList", values);
        }

        public async Task SendNotification()
        {
            var ActiveNotificationCount = _notificationService.TNotifactionCountByStatusFalse();
            await Clients.All.SendAsync("ReciveActiveNotification", ActiveNotificationCount);


            var ActiveNotificationList = _notificationService.TgetAllNotificationActive();
            await Clients.All.SendAsync("ReciveActiveList", ActiveNotificationList);

        }

        public async Task GetMenuTablesStatus()
        {
            var value = _menuTableService.TGetList();
            await Clients.All.SendAsync("ReciveMenuTableStatus", value);
        }

        public async Task SendMessage(string user, string message)
        {
            await Clients.All.SendAsync("ReciveMessage", user, message);
        }

        public override async Task OnConnectedAsync()
        {
            clientCount++;
            await Clients.All.SendAsync("ReciveClientCount", clientCount);
            await base.OnConnectedAsync();
        }

        public override async Task OnDisconnectedAsync(Exception? exception)
        {
            clientCount--;
            await Clients.All.SendAsync("ReciveClientCount", clientCount);
            await base.OnDisconnectedAsync(exception);
        }
    }
}
