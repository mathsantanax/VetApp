using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VetApp.DTO;
using VetApp.Models.ModelPetETutor;
using VetApp.ViewModel;

namespace VetApp.ModelView
{
    public class PetModelView : BaseViewModel
    {
        private petDto pet;

        public string NomePet => pet.NomePet;
        public string NumeroMicrochip => pet.NumeroMicrochip;
        public string Raca => pet.Raca;
        public int Idade => pet.Idade;
        public double Peso => pet.Peso;
        public string Especie => pet.Especie;

        public PetModelView(petDto pet)
        {
            this.pet = pet;
        }
    }
}
