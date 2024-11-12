using SQLite;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VetApp.Models.ModelServicos
{
    record class Servico
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        public decimal ValorTipoServico { get; set; }
        public decimal ValorProduto { get; set; }
        public decimal ValorDesconto { get; set; }
        public decimal ValorTotal { get; set; }

        [ForeignKey(nameof(IdPet))]
        public int IdPet { get; set; }

        [ForeignKey(nameof(IdTipoServico))]
        public int IdTipoServico { get; set; }

        [ForeignKey(nameof(IdTutor))]
        public int IdTutor { get; set; }

        [ForeignKey(nameof(IdProduto))]
        public int IdProduto { get; set; }

        [ForeignKey(nameof(IdMetodoPagamento))]
        public int IdMetodoPagamento { get; set; }

        public int QuantidadeParcela { get; set; }


    }
}
