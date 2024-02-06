using MicroQueue.Domain.Core.LogsAlliance;
using MicroQueue.Domain.Core.Models;
using MicroQueue.Publisher.Application.Interfaces;
using MicroQueue.Publisher.Domain.Commands;
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

        [HttpGet]
        public IActionResult GetDocumentQueue(DateTime fechaInicio, DateTime fechaFin)
        {
            List<Historico> documentQueueList = 
                _service.GetPublisherQueue(fechaInicio, fechaFin, Constantes.Tipo.Queue, Constantes.Evento.CreateDocumentQueue);

            return Ok(documentQueueList);
        }
    }
}
