using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VetApp.DTO
{
    public record ServiceDto
    {
        public int Id { get; set; }
        public int IdPet {  get; set; }
        public int IdTutor { get; set; }
        public string Servico { get; set; } = string.Empty;
        public decimal ValorServico { get; set; }
        public string Produto { get; set; } = string.Empty;
        public string Pagamento { get; set; } = string.Empty;
        public int NumeroDeParcelas { get; set; }
        public decimal ValorProduto { get; set; }
        public decimal Desconto {  get; set; }
        public decimal Total { get; set; }
    }
}
