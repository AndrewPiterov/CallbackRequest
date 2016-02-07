using CallbackRequest.Web.Models;
using System.Web.Mvc;

namespace CallbackRequest.Web.Controllers
{
    public class CallbacksController : Controller
    {
        private AppRepository _repo;

        public CallbacksController()
        {
            _repo = new AppRepository();
        }

        // GET: Callbacks
        public ActionResult Index()
        {
            return View(_repo.GetAllCallbacks());
        }
    }
}