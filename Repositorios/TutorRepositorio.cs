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
    public class TutorRepositorio : ITutorRepositorio
    {
        private readonly DatabaseService _databaseService;

        public TutorRepositorio()
        {
            string dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "VetAppDb.db3");
            _databaseService = new DatabaseService(dbPath);
        }

        public string AddTutor(Tutor tutor)
        {
           if(tutor != null)
           {
                _databaseService.AddTutor(tutor);
                return "Cadastrado com Sucesso !";
           }
            else
            {
                return "Erro";
            }
        }
        public string UpdateTutor(Tutor tutor)
        {
            if (tutor != null)
            {
                _databaseService.UpdateTutor(tutor);
                return "Alterado com Sucesso !";
            }
            else
            {
                return "Erro";
            }
        }

        public async Task<List<Tutor>> ListarTutores()
        {
            return await _databaseService.ListarTutor();
        }

    }
}
