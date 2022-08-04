using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Arthes.DATA.Interfaces;
using Arthes.DATA.Repositories;

namespace Arthes.DATA.Services
{
    public class RevistaService
    {
        public readonly IRepositoryRevista oRepositoryRevista;

        public RevistaService(IRepositoryRevista repositoryRevista)
        {
            oRepositoryRevista = repositoryRevista;
        }

    }
}
