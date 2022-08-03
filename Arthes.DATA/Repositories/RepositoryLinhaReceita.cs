using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Arthes.DATA.Interfaces;
using Arthes.DATA.Models;

namespace Arthes.DATA.Repositories
{
    public class RepositoryLinhaReceita: RepositoryBase<LinhaReceita>, IRepositoryLinhaReceita
    {
        public RepositoryLinhaReceita(bool SaveChanges = true) : base(SaveChanges)
        {

        }
    }
}
