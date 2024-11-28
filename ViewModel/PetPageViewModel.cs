using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using VetApp.DTO;
using VetApp.Models.ModelPetETutor;

namespace VetApp.ViewModel
{
    public class PetPageViewModel : BaseViewModel
    {
        public petDto Pet { get; set; }
        public ObservableCollection<ServiceDto> serviceDtos { get; set; }

        private bool _IsLoaded = false;
        public bool IsLoaded
        {
            get => _IsLoaded;
            set => SetProperty(ref _IsLoaded, value);
        }

        public ICommand BackCommand { get; }

        public PetPageViewModel(petDto pet)
        {
            Pet = pet;
            BackCommand = new Command<object>(GoBack);
            _ = InitializeAsync();
        }

        private async Task InitializeAsync()
        {
            IsLoaded = true;
        }

        private async Task GetServices()
        {

        }

        private async void GoBack(object obj)
        {
            await Application.Current.MainPage.Navigation.PopModalAsync();
        }

    }
}
