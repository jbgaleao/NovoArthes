// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Arthes.DATA.Models
{
    public partial class LinhaReceita
    {
        [Key]
        public int Id { get; set; }
        public int ReceitaId { get; set; }
        public int LinhaId { get; set; }
        public int? QtdNovelo { get; set; }


        [ForeignKey("LinhaId")]
        [InverseProperty("LinhaReceita")]
        public virtual Linha Linha { get; set; }


        [ForeignKey("ReceitaId")]
        [InverseProperty("LinhaReceita")]
        public virtual Receita Receita { get; set; }

    }
}