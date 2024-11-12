using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VetApp.Models.ModelPetETutor;

namespace VetApp.Interface
{
    public interface IRacaRepositorio
    {
        public string AddRaca(Raca raca);
        Task<List<Raca>> GetRacas();
        Task<Raca> GetRacaById(int idRaca);
    }
}
