using Microsoft.AspNetCore.Mvc;
using Orders.Core.ViewModels;
using Microsoft.AspNetCore.Authorization;

namespace Orders.API.Controllers
{
    [ApiController]
    [Authorize]
    [Route("api/[controller]/[action]")]
    public class BaseController : Controller
    {
        protected async Task<APIResponseViewModel> GetResponse(object data)
        {
            var response = new APIResponseViewModel(
                true,
                "Done",
                data);

            return response;
        }
    }
}