using Microsoft.AspNetCore.Mvc;

namespace CrudQualidade.API.Controllers
{
    public class PeopleController : Controller
    // herdar de IPeopleService p cruds
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
