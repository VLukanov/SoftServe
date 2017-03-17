using System.Web.Mvc;

namespace Demo2._1.Controllers
{
    public class HomeController : Controller

        //Create a conection with Views
    {
        public ActionResult Index()
        {
            return View();
        }        

        public ActionResult Contact()
        {
            return View();
        }
    }
}