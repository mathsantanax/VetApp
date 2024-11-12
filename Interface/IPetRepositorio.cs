using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VetApp.Models.ModelPetETutor;

namespace VetApp.Interface
{
    public interface IPetRepositorio
    {
        public string AddPet(Pet pet);
        Task<List<Pet>> GetPet(int idTutor);
    }
}
