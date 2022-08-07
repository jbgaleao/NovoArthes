
#nullable disable
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

using Microsoft.EntityFrameworkCore;

namespace Arthes.DATA.Models
{
    public partial class Receita : IEnumerable
    {
        public Receita()
        {
            LinhaReceita = new List<LinhaReceita>();
        }

        [Key]
        public int Id { get; set; }

        public string Nome { get; set; }

        public string Altura { get; set; }
        public int NivelDificuldade { get; set; }
        public int IdRevista { get; set; }

        [ForeignKey("IdRevista")]
        [InverseProperty("Receita")]
        public virtual Revista IdRevistaNavigation { get; set; }
        [InverseProperty("Receita")]
        public virtual ICollection<LinhaReceita> LinhaReceita { get; set; }

        public IEnumerator GetEnumerator()
        {
            return ((IEnumerable)LinhaReceita).GetEnumerator();
        }
    }
}