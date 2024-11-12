using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VetApp.Interface;
using VetApp.Models.ModelPetETutor;
using VetApp.Service;

namespace VetApp.Repositorios
{
    public class PetRepositorio : IPetRepositorio
    {
        private readonly DatabaseService _databaseService;

        public PetRepositorio()
        {
            string dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "VetAppDb.db3");
            _databaseService = new DatabaseService(dbPath);
        }

        public string AddPet(Pet pet)
        {
            if (pet != null)
            {
                _databaseService.AddPet(pet);
                return "Cadastrado com Sucesso !";
            }
            else
            {
                return "Erro";
            }
        }

        public async Task<List<Pet>> GetPet(int idTutor)
        {
            return await _databaseService.GetPet(idTutor);
        }
    }
}
