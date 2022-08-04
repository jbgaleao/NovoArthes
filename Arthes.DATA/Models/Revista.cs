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
    public partial class Revista
    {
        public Revista()
        {
            Receita = new HashSet<Receita>();
        }

        [Key]
        public int Id { get; set; }

        public string Tema { get; set; }
        public int NumEdicao { get; set; }
        public Mes MesEdicao { get; set; }
        public int AnoEdicao { get; set; }

        [InverseProperty("IdRevistaNavigation")]
        public virtual ICollection<Receita> Receita { get; set; }
    }
}