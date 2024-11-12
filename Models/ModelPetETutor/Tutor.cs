using SQLite;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VetApp.Models.ModelPetETutor
{
    public record Tutor
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string NomeTutor { get; set; } = default!;
        public decimal Celular { get; set; } = default!;
    }
}
