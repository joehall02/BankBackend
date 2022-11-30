using Microsoft.AspNetCore.Mvc;

namespace BankBackend.Controllers
{
	public class CardController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}
