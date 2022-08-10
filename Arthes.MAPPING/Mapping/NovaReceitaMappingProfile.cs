using Arthes.DATA.Models;
using Arthes.WEB.Models;

using AutoMapper;

namespace Arthes.MAPPING.Mapping
{
    public class NovaReceitaMappingProfile : Profile
    {
        public NovaReceitaMappingProfile()
        {
            _ = CreateMap<NovaReceitaVM, Receita>();
        }
    }
}
