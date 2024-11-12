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
    public class RacaRepositorio : IRacaRepositorio
    {
        private readonly DatabaseService _databaseService;

        public RacaRepositorio()
        {
            string dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "VetAppDb.db3");
            _databaseService = new DatabaseService(dbPath);
        }

        public string AddRaca(Raca raca)
        {
            if (raca != null)
            {
                _databaseService.AddRaca(raca);
                return "Cadastrado com Sucesso !";
            }
            else
            {
                return "Erro";
            }
        }

        public async Task<Raca> GetRacaById(int idRaca)
        {
            return await _databaseService.GetRacaById(idRaca);
        }

        public async Task<List<Raca>> GetRacas()
        {
            return await _databaseService.GetRacas();
        }
    }
}
