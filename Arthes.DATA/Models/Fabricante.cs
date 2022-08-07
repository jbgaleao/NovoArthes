
#nullable disable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Arthes.DATA.Models
{
    public partial class Fabricante
    {
        public Fabricante()
        {
            Linha = new HashSet<Linha>();
        }

        [Key]
        public int Id { get; set; }

        public string Nome { get; set; }

        [InverseProperty("Fabricante")]
        public virtual ICollection<Linha> Linha { get; set; }
    }
}