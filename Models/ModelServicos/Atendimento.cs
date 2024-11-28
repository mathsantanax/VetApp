using SQLite;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VetApp.Models.ModelServicos
{
    public record Atendimento
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        public DateTime Data { get; set; }
        public decimal ValorTotal { get; set; }

        [ForeignKey(nameof(IdTutor))]
        public int IdTutor { get; set; }
        
        [ForeignKey(nameof(IdPet))]
        public int IdPet { get; set; } 
        
        [ForeignKey(nameof(IdPagamento))]
        public int IdPagamento { get; set; }
    }
}
