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
    public class EspecieRepositorio : IEspecieRepositorio
    {
        private readonly DatabaseService _databaseService;

        public EspecieRepositorio()
        {
            string dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "VetAppDb.db3");
            _databaseService = new DatabaseService(dbPath);
        }

        public string AddEspecie(Especie especie)
        {
            if (especie != null)
            {
                _databaseService.AddEspecie(especie);
                return "Cadastrado com Sucesso !";
            }
            else
            {
                return "Erro";
            }
        }

        public async Task<List<Especie>> GetEspecie()
        {
            return await _databaseService.GetEspecies();
        }

        public async Task<Especie> GetEspecieById(int idEspecie)
        {
            return await _databaseService.GetEspecieById(idEspecie);
        }
    }
}
