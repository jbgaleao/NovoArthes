﻿
#nullable disable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Arthes.DATA.Models
{
    public partial class Linha
    {
        public Linha()
        {
            LinhaReceita = new HashSet<LinhaReceita>();
        }

        [Key]
        public int Id { get; set; }

        public string CodLinha { get; set; }
        public string NomeCor { get; set; }
        public int TipoLinhaId { get; set; }
        public int FabricanteId { get; set; }

        [ForeignKey("FabricanteId")]
        [InverseProperty("Linha")]
        public virtual Fabricante Fabricante { get; set; }
        [ForeignKey("TipoLinhaId")]
        [InverseProperty("Linha")]
        public virtual TipoLinha TipoLinha { get; set; }
        [InverseProperty("Linha")]
        public virtual ICollection<LinhaReceita> LinhaReceita { get; set; }
    }
}