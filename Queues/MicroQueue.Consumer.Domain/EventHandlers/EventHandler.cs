using MicroQueue.Domain.Core.Bus;
using MicroQueue.Domain.Core.Events;
using MicroQueue.Domain.Core.Historico;

namespace MicroQueue.Consumer.Domain.EventHandlers
{
    public class EventHandler
        :
        IEventHandler<DocumentCreatedEvent>,
        IEventHandler<MailCreatedEvent>
    {
        private readonly IServicioHistorico _historico;
        private readonly HttpClient _clientLogCloudApi = new HttpClient();

        public EventHandler(IServicioHistorico historico)
        {
            _historico = historico;
        }

        public Task Handle(DocumentCreatedEvent @event)
        {
            //ManifiestoQueue transaction = new ManifiestoQueue();
            //transaction.JsonMessage = @event.JsonMessage;
            //transaction.Printer = @event.Printer;
            //transaction.IdUsuarioLog = @event.IdUsuarioLog;

            //_historico.AddManifiestoQueue(transaction);

            return Task.CompletedTask;
        }

        public Task Handle(MailCreatedEvent @event)
        {
            //using (var client = new HttpClient())
            //{
            //    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            //    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", @event.Token);

            //    //var serialized = new StringContent(@event.Body, Encoding.UTF8, "application/json");

            //    using (HttpResponseMessage response = client.GetAsync("http://localhost:51332/api/Guias/ObtenerGuiaDetalle/").Result)
            //    {
            //        switch (response.StatusCode)
            //        {
            //            case HttpStatusCode.OK:
            //                response.EnsureSuccessStatusCode();
            //                string responseBody = response.Content.ReadAsStringAsync().Result;
            //                //GenericResponse genericResponse = JsonConvert.DeserializeObject<GenericResponse>(responseBody);
            //                //transaction.MessageResponse = genericResponse.Message;
            //                //transaction.StatusResponse = genericResponse.Status;
            //                break;
            //            case HttpStatusCode.Unauthorized:
            //                //transaction.MessageResponse = "Unauthorized";
            //                //transaction.StatusResponse = (int)HttpStatusCode.Unauthorized;
            //                break;
            //            default:
            //                //transaction.MessageResponse = response.StatusCode.ToString();
            //                //transaction.StatusResponse = (int)response.StatusCode;
            //                break;
            //        }
            //    }
            //}

            //var transaction = new MailQueue
            //{
            //    Body = @event.Body,
            //    IdUsuarioLog = @event.IdUsuarioLog,
            //    Id = @event.Id
            //};

            //_historico.UpdateMailQueue(transaction);

            return Task.CompletedTask;
        }
    }
}
