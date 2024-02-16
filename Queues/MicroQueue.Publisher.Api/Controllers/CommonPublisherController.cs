using MicroQueue.Domain.Core.Models;
using MicroQueue.Publisher.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace PublisherQueueApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommonPublisherController : ControllerBase
    {
        private readonly ICommonService _commonService;

        public CommonPublisherController(ICommonService commonService)
        {
            _commonService = commonService;
        }       

        [HttpPost]
        public IActionResult SendDocumentMessage([FromBody] CommonMessage commonMessage)
        {
            _commonService.SendCommonMessage(commonMessage);
            return Ok(commonMessage);
        }
    }
}
