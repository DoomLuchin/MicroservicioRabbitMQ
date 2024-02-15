using Microsoft.AspNetCore.Mvc;

namespace ApiConsumerQueue.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DocumentConsumerController : ControllerBase
    {
        public DocumentConsumerController()
        {
        }

        [HttpGet]
        public IActionResult GetConsumerDocumentQueue()
        {
            return Ok();
        }
    }
}
