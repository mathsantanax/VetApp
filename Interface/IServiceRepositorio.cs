using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VetApp.Models.ModelServicos;

namespace VetApp.Interface
{
    public interface IServiceRepositorio
    {
        Task<List<Servico>> ListarServicos();
    }
}