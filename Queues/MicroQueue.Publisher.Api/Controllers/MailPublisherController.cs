using MicroQueue.Domain.Core.Models;
using MicroQueue.Publisher.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace PublisherQueueApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MailPublisherController : ControllerBase
    {
        private readonly IService _service;

        public MailPublisherController(IService service)
        {
            _service = service;
        }      

        [HttpPost]
        public IActionResult SendMailMessage([FromBody] MailMessage mailMessage)
        {
            _service.SendMailMessage(mailMessage);
            return Ok(mailMessage);
        }
    }
}
