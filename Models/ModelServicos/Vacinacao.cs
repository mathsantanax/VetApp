﻿using SQLite;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VetApp.Models.ModelServicos
{
    public record class Vacinacao
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        public DateTime DataProxima { get; set; }

        [ForeignKey(nameof(IdPet))]
        public int IdPet { get; set; }

        [ForeignKey(nameof(IdAtendimento))]
        public int IdAtendimento { get; set; }
    }
}
