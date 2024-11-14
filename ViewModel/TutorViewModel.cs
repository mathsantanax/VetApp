using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using VetApp.DTO;
using VetApp.Models.ModelPetETutor;
using VetApp.Pages;
using VetApp.Repositorios;
using VetApp.Views;

namespace VetApp.ViewModel
{
    public class TutorViewModel : BaseViewModel
    {
        private readonly PetRepositorio petRepositorio = new PetRepositorio();
        private readonly RacaRepositorio racaRepositorio = new RacaRepositorio();
        private readonly EspecieRepositorio especieRepositorio = new EspecieRepositorio();

        private Tutor _Tutor { get; set; }
        public Tutor Tutor
        {
            get => _Tutor;
        }

        private ObservableCollection<petDto> _Pets = [];
        public ObservableCollection<petDto> Pets
        {
            get => _Pets;
            set => SetProperty(ref _Pets, value);
        }

        private bool _IsLoaded = false;
        public bool IsLoaded
        {
            get => _IsLoaded;
            set => SetProperty(ref _IsLoaded, value);
        }

        public ICommand BackCommand { get; }
        public ICommand PetTapCommand { get; }
        public ICommand AddNewPet { get; }

        public TutorViewModel(Tutor tutor)
        {
            _Tutor = tutor;
            AddNewPet =new Command(OnAddPetClicked);
            Pets = new ObservableCollection<petDto>();
            PetTapCommand = new Command<petDto>(OnItemSelected);
            BackCommand = new Command<object>(GoBack);
            _ = InitializeAsync();
        }
        private async Task InitializeAsync()
        {
            await LoadPetsAsync();
        }

        private async Task LoadPetsAsync()
        {
            try
            {
                Pets.Clear();
                await Task.Delay(500);
                var pets = await petRepositorio.GetPet(Tutor.Id);
                if (pets != null && pets.Any())
                {
                    foreach (var pet in pets)
                    {
                        var raca = await racaRepositorio.GetRacaById(pet.IdRaca);
                        var especie = await especieRepositorio.GetEspecieById(pet.IdEspecie);
                        Pets.Add(new petDto
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
            finally
            {
                IsLoaded = true;
            }
        }

        private async void OnItemSelected(petDto selectedPet)
        {
            try
            {
                await Application.Current.MainPage.Navigation.PushAsync(new PetPage(selectedPet));
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Erro ao selecionar pet: {ex.Message}");
            }
        }
        private async void OnAddPetClicked()
        {
            try
            {
                await Application.Current.MainPage.Navigation.PushModalAsync(new AddNewPetPageView(_Tutor));
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Erro ao adicionar pet: {ex.Message}");
            }
        }
        private async void GoBack(object obj)
        {
            await Application.Current.MainPage.Navigation.PopModalAsync();
        }

    }
}
