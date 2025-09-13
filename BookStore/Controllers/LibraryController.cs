using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LibraryController : ControllerBase
    {
        public async Task<ActionResult> TestMethod1()
        {
            var error = "ошибка доступа баляяя";
            return Forbid(error);
        }
        public async Task<ActionResult> TestMethod2()
        {
            var error = "ошибка доступа баляяя";
            return Forbid(error);
        }
        public async Task<ActionResult> TestMethod3()
        {
            var error = "ошибка доступа баляяя";
            return Forbid(error);
        }
    }
}
