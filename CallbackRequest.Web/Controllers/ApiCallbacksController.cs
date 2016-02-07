using CallbackRequest.Web.Models;
using CallbackRequest.Web.ViewModels;
using System.Collections.Generic;
using System.Threading;
using System.Web.Http;
using System.Web.Http.Results;

namespace CallbackRequest.Web.Controllers
{
    [Route("api/callbacks")]
    public class ApiCallbacksController : ApiController
    {
        private AppRepository _repo;

        public ApiCallbacksController()
        {
            _repo = new AppRepository();
        }

        public JsonResult<IEnumerable<CallbackModel>> Get()
        {
            var res = _repo.GetAllCallbacks();
            return Json(res);
        }

        public JsonResult<bool> Post([FromBody] CallbackViewModel vm)
        {
            // TODO Add status codes
            // Catch Exceptions

            Thread.Sleep(2000);

            if (ModelState.IsValid)
            {
                if (_repo.SaveCallback(vm.ToModel()))
                {
                    return Json(true);
                }
                else {
                    return Json(false);
                }
            }



            return Json(false);
        }
    }
}
