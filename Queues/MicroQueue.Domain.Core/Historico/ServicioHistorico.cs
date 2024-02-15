using Newtonsoft.Json;
using System.Net;
using System.Text;

namespace MicroQueue.Domain.Core.Historico
{
    public class ServicioHistorico : IServicioHistorico
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public ServicioHistorico(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<HistoricoDTO?> CrearHistoricoAsync(HistoricoDTO historico)
        {
            try
            {
                HttpClient cliente = _httpClientFactory.CreateClient(HistoricoServices.ApiLogsAlliance);

                HistoricoDTO completedHistoric = new()
                {
                    IdUsuario = historico.IdUsuario,
                    IdRelacionGuid = historico.IdRelacionGuid,
                    IdRelacionVarchar = historico.IdRelacionVarchar,
                    FechaCreacion = historico.FechaCreacion,
                    Descripcion = historico.Descripcion,
                    TipoEvento = historico.TipoEvento,
                    Mensaje = historico.Mensaje
                };

                var jsonHistorico = JsonConvert.SerializeObject(completedHistoric);
                var httpHistoric = new StringContent(jsonHistorico, Encoding.UTF8, "application/json");
                using HttpResponseMessage response = await cliente.PostAsync("api/Historico", httpHistoric);
                switch (response.StatusCode)
                {
                    case HttpStatusCode.Created:
                        var responseSuccess = await response.Content.ReadAsStringAsync();
                        HistoricoDTO responseSerialized = JsonConvert.DeserializeObject<HistoricoDTO>(responseSuccess);
                        return responseSerialized;
                    case HttpStatusCode.Unauthorized:
                        throw new Exception(HttpStatusCode.Unauthorized.ToString());
                    default:
                        throw new Exception();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }

    }
}
