using MicroQueue.Domain.Core.LogsAlliance;
using MicroQueue.Domain.Core.Models;
using MicroQueue.Publisher.Application.Interfaces;
using MicroQueue.Publisher.Domain.Commands;
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

        [HttpGet]
        public IActionResult GetPublisherMailQueue(DateTime fechaInicio, DateTime fechaFin)
        {
            List<Historico> documentQueueList =
                _service.GetPublisherQueue(fechaInicio, fechaFin, Constantes.Tipo.Queue, Constantes.Evento.CreateEmailQueue);

            return Ok(documentQueueList);
        }
    }
}
