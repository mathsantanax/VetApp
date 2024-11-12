using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VetApp.Models.ModelPetETutor;

namespace VetApp.Interface
{
    public interface IEspecieRepositorio
    {
        public string AddEspecie(Especie especie);
        Task<List<Especie>> GetEspecie();
        Task<Especie> GetEspecieById(int idEspecie);
    }
}
