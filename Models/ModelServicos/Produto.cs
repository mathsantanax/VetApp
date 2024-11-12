using SQLite;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VetApp.Models.ModelServicos
{
    record class Produto
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        public string NomePruduto { get; set; } = default!;

        [ForeignKey(nameof(IdLab))]
        public int IdLab { get; set; }

        [ForeignKey(nameof(IdValor))]
        public int IdValor { get; set; }
    }
}
