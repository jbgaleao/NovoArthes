using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Arthes.DATA.Interfaces;
using Arthes.DATA.Models;

namespace Arthes.DATA.Repositories
{
    public class RepositoryRevista : RepositoryBase<Revista>, IRepositoryRevista
    {
        public RepositoryRevista(bool SaveChanges = true) : base(SaveChanges)
        {

        }
    }
}
