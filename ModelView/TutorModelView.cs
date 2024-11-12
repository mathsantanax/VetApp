using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using VetApp.Models.ModelPetETutor;
using VetApp.Pages;
using VetApp.Repositorios;

namespace VetApp.ModelView
{
    public class TutorModelView : BaseViewModel
    {
        const int RefreshDuration = 2;
        private bool isRefreshing;

        public bool IsRefreshing
        {
            get => isRefreshing;
            set => SetProperty(ref isRefreshing, value);
        }

        private readonly TutorRepositorio tutorRepositorio = new TutorRepositorio();
        public ObservableCollection<Tutor> BindingTutores { get; private set; }
        public ICommand RefreshCommand => new Command(async () => await RefreshItemsAsync());
        public ICommand ItemSelectedCommand { get; }
        public ICommand AddNewTutor { get; }

        public TutorModelView()
        {
            BindingTutores = new ObservableCollection<Tutor>();
            ItemSelectedCommand = new Command<Tutor>(OnItemSelected);
            AddNewTutor = new Command(AddTutor);
            GetRegisterAsync();
        }

        private Tutor selectedTutor;
        public Tutor SelectedTutor
        {
            get => selectedTutor;
            set
            {
                if (SetProperty(ref selectedTutor, value))
                {
                    ItemSelectedCommand.Execute(selectedTutor);
                }
            }
        }

        private async Task GetRegisterAsync()
        {
            try
            {
                BindingTutores.Clear();
                var getTutor = await tutorRepositorio.ListarTutores();
                if (getTutor != null && getTutor.Any())
                {
                    foreach (var tutor in getTutor)
                    {
                        BindingTutores.Add(new Tutor
                        {
                            Id = tutor.Id,
                            NomeTutor = tutor.NomeTutor,
                            Celular = tutor.Celular
                        });
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Erro ao obter registros: {ex.Message}");
            }
        }

        private async void OnItemSelected(Tutor selectedTutor)
        {
            try
            {
                if (selectedTutor != null)
                {
                    await Application.Current.MainPage.Navigation.PushAsync(new TutorPage(selectedTutor));
                    SelectedTutor = null;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Erro ao selecionar pet: {ex.Message}");
                await Application.Current.MainPage.DisplayAlert("Erro", $"Ocorreu um problema ao tentar abrir o serviço.{ex.Message}", "OK");
            }
        }

        private async Task RefreshItemsAsync()
        {
            IsRefreshing = true;
            try
            {
                BindingTutores.Clear();
                await Task.Delay(TimeSpan.FromSeconds(RefreshDuration));
                await GetRegisterAsync();
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Erro ao atualizar itens: {ex.Message}");
            }
            finally
            {
                IsRefreshing = false;
            }
        }

        private async void AddTutor()
        {
            string nome = await Application.Current.MainPage.DisplayPromptAsync("Cadastro", "Nome do Tutor");

            if (nome != null)
            {
                string ddd = await Application.Current.MainPage.DisplayPromptAsync("Cadastro", "Insira o DDD", maxLength: 3, keyboard: Keyboard.Numeric);
                if (ddd != null)
                {
                    string celular = await Application.Current.MainPage.DisplayPromptAsync("Cadastro", "Nº de Celular", maxLength: 9, keyboard: Keyboard.Numeric);
                    if (celular != null)
                    {
                        tutorRepositorio.AddTutor(new Tutor
                        {
                            NomeTutor = nome.ToUpper(),
                            Celular = decimal.Parse($"{ddd}{celular}")
                        });
                        await Application.Current.MainPage.DisplayAlert("Sucesso", "Realizado com Sucesso", "OK");
                    }
                    else
                    {
                        await Application.Current.MainPage.DisplayAlert("Alerta", "Celular nulo", "OK");
                    }
                }
                else
                {
                    await Application.Current.MainPage.DisplayAlert("Alerta", "DDD nulo", "OK");
                }
            }
        }
    }
}
