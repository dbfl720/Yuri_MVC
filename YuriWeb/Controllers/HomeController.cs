using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using YuriWeb.Models;

namespace YuriWeb.Controllers
{
    public class HomeController : Controller       // HomController 이기 때문에 views -> home 으로 매칭됨. 
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }


        // 아래 것들은 ACTION method 
        public IActionResult Index()  // displayed in the RenderBody of shared -  layout
        {
            return View(); // View()안에 아무 것도 없으면 Index() 이름이 액션네임으로 자동으로 매칭됨. 즉 INDEX VIEW로 가게됨 , 이름 매칭으로 오버라이딩 하는 것임.
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
