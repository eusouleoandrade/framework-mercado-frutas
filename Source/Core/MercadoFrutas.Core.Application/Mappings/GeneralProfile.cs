using AutoMapper;
using MercadoFrutas.Core.Application.Features.Frutas.Commands.CreateFruta;
using MercadoFrutas.Core.Application.Features.Frutas.Queries.GetAllFrutas;
using MercadoFrutas.Core.Domain.Entities;

namespace MercadoFrutas.Core.Application.Mappings
{
    public class GeneralProfile : Profile
    {
         public GeneralProfile()
        {
            CreateMap<Fruta, GetAllFrutasViewModel>().ReverseMap();
            CreateMap<CreateFrutaCommand, Fruta>();
            CreateMap<GetAllFrutasQuery, GetAllFrutasParameter>();
        }
    }
}