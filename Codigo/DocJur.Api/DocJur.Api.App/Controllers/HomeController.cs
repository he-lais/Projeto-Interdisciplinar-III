using DocJur.Api.App.Models.Responses;
using Microsoft.AspNetCore.Mvc;

namespace DocJur.Api.App.Controllers
{
    /// <summary>
    /// Home Controller used for static endpoints.
    /// </summary>
    public class HomeController : Controller
    {
        /// <summary>
        /// Index endpoint used to test the connection with the api.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult<BasicResponse> Index()
        {
            return new BasicResponse { Success = true, Message = "Testando conexao com a api." };
        }
    }
}
