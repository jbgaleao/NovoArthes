using Arthes.WEB.Models;
using Arthes.DATA.Models;

using AutoMapper;

namespace Arthes.MAPPING.Mapping
{
    public class NovaReceitaMappingProfile:Profile
    {
        public NovaReceitaMappingProfile()
        {
            CreateMap<NovaReceitaViewModel, Receita>();
        }
    }
}
