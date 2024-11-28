using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using VetApp.Models.ModelPetETutor;
using VetApp.Models.ModelServicos;

namespace VetApp.Service
{
    internal class DatabaseService
    {
        private readonly SQLiteAsyncConnection _database;

        public DatabaseService(string dbPath)
        {
            _database = new SQLiteAsyncConnection(dbPath);

            try
            {
                // apagar a base de dados

                //_database.DropTableAsync<Raca>().Wait();
                //_database.DropTableAsync<Tutor>().Wait();
                //_database.DropTableAsync<Pet>().Wait();
                //_database.DropTableAsync<Especie>().Wait();

                //_database.DropTableAsync<Servico>().Wait();
                //_database.DropTableAsync<Produto>();
                //_database.DropTableAsync<Pagamento>().Wait();
                //_database.DropTableAsync<Lab>().Wait();
                //_database.DropTableAsync<Vacinacao>().Wait();
                //_database.DropTableAsync<Atendimento>().Wait();
                //_database.DropTableAsync<ItemAtendimento>().Wait();
                //_database.DropTableAsync<ItemServico>().Wait();

                // base de dados para entities Pet e tutor
                _database.CreateTableAsync<Raca>().Wait();
                 _database.CreateTableAsync<Tutor>().Wait();
                 _database.CreateTableAsync<Pet>().Wait();
                 _database.CreateTableAsync<Especie>().Wait();

                // base de dados para entities Servicos
                _database.CreateTableAsync<Atendimento>().Wait();
                _database.CreateTableAsync<ItemAtendimento>().Wait();
                _database.CreateTableAsync<ItemServico>().Wait();
                 _database.CreateTableAsync<Servico>().Wait();
                 _database.CreateTableAsync<Produto>().Wait();
                 _database.CreateTableAsync<Pagamento>().Wait();
                 _database.CreateTableAsync<Lab>().Wait();
                 _database.CreateTableAsync<Vacinacao>().Wait();

            }
            catch (SQLiteException sqlException)
            {
                Debug.Write(sqlException.Message);
            }
            catch (Exception e)
            {
                Debug.Write(e.Message);
            }
            finally
            {
                _database.CloseAsync();
            }
        }

        #region Tutor

        // Listar todos os tutores
        public async Task<List<Tutor>> ListarTutor()
        {
            return await _database.Table<Tutor>().OrderBy(tutor => tutor.NomeTutor).ToListAsync();
        }

        // Adicionar os tutor
        public async void AddTutor(Tutor tutor)
        {
            await _database.InsertAsync(tutor);
        }
        // Atualizar o dados do tutor
        public async void UpdateTutor(Tutor tutor)
        {
            await _database.UpdateAsync(tutor);
        }

        // Listar todos os pets com base no id do tutor
        public async Task<List<Pet>> GetPet(int tutor)
        {
            return await _database.Table<Pet>().Where(pet => pet.IdTutor == tutor).ToListAsync();
        }

        #endregion

        // Adicionar pet
        public async void AddPet(Pet pet)
        {
            await _database.InsertAsync(pet);
        }

        // Adicionar Especie
        public async void AddEspecie(Especie especie)
        {
            await _database.InsertAsync(especie);
        }

        // lista especie conforme o id
        public async Task<Especie> GetEspecieById(int IdEspecie)
        {
            return await _database.Table<Especie>().Where(e => e.Id == IdEspecie).FirstOrDefaultAsync();
        }

        // Listar todas as Especie
        public async Task<List<Especie>> GetEspecies()
        {
            return await _database.Table<Especie>().ToListAsync();
        }

        // Adicionar Raça
        public async void AddRaca(Raca raca)
        {
            await _database.InsertAsync(raca);
        }

        // lista raca conforme o id
        public async Task<Raca> GetRacaById(int IdRaca)
        {
            return await _database.Table<Raca>().Where(r => r.Id == IdRaca).FirstOrDefaultAsync();
        }

        //Listar todas as Racas
        public async Task<List<Raca>> GetRacas()
        {
            return await _database.Table<Raca>().ToListAsync();
        }
    }
}
