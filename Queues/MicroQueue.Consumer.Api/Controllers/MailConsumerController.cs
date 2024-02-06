using MicroQueue.Consumer.Application.Interfaces;
using MicroQueue.Domain.Core.LogsAlliance;
using MicroQueue.Domain.Core.Models;
using Microsoft.AspNetCore.Mvc;

namespace ApiConsumerQueue.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MailConsumerController : ControllerBase
    {
        private readonly IService _service;

        public MailConsumerController(IService service)
        {
            _service = service;
        }

        [HttpGet]
        public IActionResult GetConsumerMailQueue(DateTime fechaInicio, DateTime fechaFin)
        {
            List<Historico> documentQueueList =
                _service.GetConsumerQueue(fechaInicio, fechaFin, Constantes.Tipo.Queue, Constantes.Evento.ConsumerEmailQueue);

            return Ok(documentQueueList);
        }
    }
}
