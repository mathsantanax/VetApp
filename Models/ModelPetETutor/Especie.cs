using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VetApp.Models.ModelPetETutor
{
    public record class Especie
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; } = default!;

        public string NomeEspecie { get; set; } = default!;
    }
}
