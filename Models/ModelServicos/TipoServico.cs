using SQLite;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VetApp.Models.ModelServicos
{
    record class TipoServico
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        public string Servico { get; set; }

        [ForeignKey(nameof(IdValor))]
        public int IdValor { get; set; }

    }
}
