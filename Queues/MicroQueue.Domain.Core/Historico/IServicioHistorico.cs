using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicroQueue.Domain.Core.Historico
{
    public interface IServicioHistorico
    {
        Task<HistoricoDTO> CrearHistoricoAsync(HistoricoDTO historico);
    }
}
