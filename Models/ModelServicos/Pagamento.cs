using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VetApp.Models.ModelServicos
{
    record class Pagamento
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        public string MetodoPagamento { get; set; } = default!;
    }
}
