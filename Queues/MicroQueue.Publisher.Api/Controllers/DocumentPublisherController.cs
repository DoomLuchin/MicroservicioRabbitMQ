using MicroQueue.Domain.Core.Models;
using MicroQueue.Publisher.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace PublisherQueueApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DocumentPublisherController : ControllerBase
    {
        private readonly IService _service;

        public DocumentPublisherController(IService service)
        {
            _service = service;
        }       

        [HttpPost]
        public IActionResult SendDocumentMessage([FromBody] DocumentMessage documentMessage)
        {
            _service.SendDocumentMessage(documentMessage);
            return Ok(documentMessage);
        }
    }
}
