using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Arthes.DATA.Repositories;

namespace Arthes.DATA.Services
{
    public class RevistaService
    {
        public RepositoryRevista oRepositoryRevista { get; set; }

        public RevistaService()
        {
            oRepositoryRevista = new RepositoryRevista();
        }

    }
}
