using MicroQueue.Domain.Core.Models;
using MicroQueue.Publisher.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace PublisherQueueApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MailPublisherController : ControllerBase
    {
        private readonly IMailService _mailService;

        public MailPublisherController(IMailService mailService)
        {
            _mailService = mailService;
        }      

        [HttpPost]
        public IActionResult SendMailMessage([FromBody] MailMessage mailMessage)
        {
            _mailService.SendMailMessage(mailMessage);
            return Ok(mailMessage);
        }
    }
}
