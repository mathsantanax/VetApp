using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using VetApp.Models.ModelPetETutor;
using VetApp.Repositorios;

namespace VetApp.ViewModel
{
    public class AddNewPetViewModel : BaseViewModel
    {
        private readonly RacaRepositorio racaRepositorio = new RacaRepositorio();

        private Tutor _Tutor {  get; set; }

        public Tutor Tutor
        {
            get => _Tutor;
        }

        private bool _IsLoaded = false;
        public bool IsLoaded
        {
            get => _IsLoaded;
            set => SetProperty(ref _IsLoaded, value);
        }

        public ICommand BackCommand { get; }

        public AddNewPetViewModel(Tutor tutor)
        {
            _Tutor = tutor;
            IsLoaded = true;
            BackCommand = new Command<object>(GoBack);
        }


        private async void GoBack(object obj)
        {
            await Application.Current.MainPage.Navigation.PopModalAsync();
        }
    }
}
