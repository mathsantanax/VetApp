using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VetApp.Interface;
using VetApp.Models.ModelServicos;

namespace VetApp.Repositorios
{
    public class ServiceRepositorio : IServiceRepositorio
    {
        public Task<List<Servico>> ListarServicos()
        {
            throw new NotImplementedException();
        }
    }
}
