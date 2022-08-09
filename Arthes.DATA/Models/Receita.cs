﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using Arthes.DATA.Models.Enum;

using Microsoft.EntityFrameworkCore;

namespace Arthes.DATA.Models
{
    public partial class Receita
    {
        public Receita()
        {
            LinhaReceita = new HashSet<LinhaReceita>();
        }

        [Key]
        public int Id { get; set; }

        public string Nome { get; set; }

        public int Altura { get; set; }
        public NivelDificuldade NivelDificuldade { get; set; }
        public int IdRevista { get; set; }

        [ForeignKey("IdRevista")]
        [InverseProperty("Receita")]
        public virtual Revista IdRevistaNavigation { get; set; }
        [InverseProperty("Receita")]
        public virtual ICollection<LinhaReceita> LinhaReceita { get; set; }
    }
}