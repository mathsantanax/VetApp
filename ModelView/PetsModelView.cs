using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using VetApp.DTO;
using VetApp.Models.ModelPetETutor;
using VetApp.Pages;
using VetApp.Repositorios;

namespace VetApp.ModelView
{
    public class PetsModelView : BaseViewModel
    {
        private readonly PetRepositorio petRepositorio = new PetRepositorio();
        private readonly RacaRepositorio racaRepositorio = new RacaRepositorio();
        private readonly EspecieRepositorio especieRepositorio = new EspecieRepositorio();
        private Tutor tutor;
        private Pet selectedPet;

        public ObservableCollection<petDto> BindingPets { get; private set; }
        public ObservableCollection<Tutor> BindingTutor { get; private set; }
        public ICommand ItemSelectedCommand { get; }
        public ICommand AddNewPet { get; }

        public PetsModelView(Tutor tutor)
        {
            BindingPets = new ObservableCollection<petDto>();
            BindingTutor = new ObservableCollection<Tutor>();
            setTutor(tutor);
            ItemSelectedCommand = new Command<petDto>(OnItemSelected);
            AddNewPet = new Command<Tutor>(OnAddPetClicked);
        }

        private async void setTutor(Tutor tutor)
        {
            this.tutor = tutor;
            BindingTutor.Clear();
            BindingTutor.Add(tutor);
            await LoadPetsAsync();
        }

        private async Task LoadPetsAsync()
        {
            try
            {
                BindingPets.Clear();
                var pets = await petRepositorio.GetPet(tutor.Id);
                if (pets != null && pets.Any())
                {
                    foreach (var pet in pets)
                    {
                        var raca = await racaRepositorio.GetRacaById(pet.IdRaca);
                        var especie = await especieRepositorio.GetEspecieById(pet.IdEspecie);
                        BindingPets.Add(new petDto
                        {
                            Id = pet.Id,
                            NomePet = pet.NomePet,
                            Idade = pet.Idade,
                            Peso = pet.Peso,
                            Especie = especie.NomeEspecie,
                            Raca = raca.TipoRaca,
                            NumeroMicrochip = pet.NumeroMicrochip,
                            Sexo = pet.Sexo
                        });
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Erro ao obter registros: {ex.Message}");
            }
        }

        private async void OnItemSelected(petDto selectedPet)
        {
            //if (selectedPet == null)
            //    return;
                await Application.Current.MainPage.Navigation.PushAsync(new PetPage(selectedPet));
            try
            {
                await Application.Current.MainPage.DisplayAlert("HI", $"Erro ao selecionar pet: {selectedPet.NomePet}", "Ok");
                //await Application.Current.MainPage.Navigation.PopAsync();
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Erro ao selecionar pet: {ex.Message}");
            }
        }

        private async void OnAddPetClicked(Tutor tutor)
        {
            if (tutor == null)
            {
                Debug.WriteLine("Tutor é nulo no comando OnAddPetClicked");
                return;
            }

            try
            {
                await Application.Current.MainPage.Navigation.PushAsync(new AddPetPage(tutor));
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Erro ao adicionar pet: {ex.Message}");
            }
        }
    }
}
