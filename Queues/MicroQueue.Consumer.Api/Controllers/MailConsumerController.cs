using Microsoft.AspNetCore.Mvc;

namespace ApiConsumerQueue.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MailConsumerController : ControllerBase
    {
        public MailConsumerController()
        {
        }

        //Quitar
        [HttpGet]
        public IActionResult GetConsumerMailQueue()
        {
            return Ok();
        }
    }
}
