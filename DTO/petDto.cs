using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VetApp.DTO
{
    public record petDto
    {
        public int Id { get; set; }
        public string NomePet { get; set; } = default!;
        public string NumeroMicrochip { get; set; } = default!;
        public int Idade { get; set; } = default!;
        public string Sexo { get; set; } = default!;
        public float Peso { get; set; } = default!;
        public string Raca { get; set; } = default!;
        public string Especie { get; set; } = default!;
        public int IdTutor { get; set; } = default!;
    }
}
