using SQLite;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.InteropServices.Marshalling;
using System.Text;
using System.Threading.Tasks;

namespace VetApp.Models.ModelServicos
{
    public record ItemAtendimento
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public int Quantidade { get; set; }
        public decimal PrecoUnitario { get; set; }
        public decimal Total {  get; set; }

        [ForeignKey(nameof(IdProduto))]
        public int IdProduto { get; set; }

        [ForeignKey(nameof(IdAtendimento))]
        public int IdAtendimento { get; set; }
    }
}
