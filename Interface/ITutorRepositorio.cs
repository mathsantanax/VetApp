using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VetApp.Models.ModelPetETutor;

namespace VetApp.Interface
{
    public interface ITutorRepositorio
    {
        public string AddTutor(Tutor tutor);
        public string UpdateTutor(Tutor tutor);
        Task<List<Tutor>> ListarTutores();
    }
}
