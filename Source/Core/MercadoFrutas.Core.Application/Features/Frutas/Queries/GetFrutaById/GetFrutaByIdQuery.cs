using System.Threading;
using System.Threading.Tasks;
using MediatR;
using MercadoFrutas.Core.Application.Exceptions;
using MercadoFrutas.Core.Application.Interfaces.Repositories;
using MercadoFrutas.Core.Application.Wrappers;
using MercadoFrutas.Core.Domain.Entities;

namespace MercadoFrutas.Core.Application.Features.Frutas.Queries.GetFrutaById
{
    public class GetFrutaByIdQuery : IRequest<Response<Fruta>>
    {
        public int Id { get; set; }
    }

    public class GetFrutaByIdQueryHandler : IRequestHandler<GetFrutaByIdQuery, Response<Fruta>>
        {
            private readonly IFrutaRepositoryAsync _frutaRepository;

            public GetFrutaByIdQueryHandler(IFrutaRepositoryAsync frutaRepository)
            {
                _frutaRepository = frutaRepository;
            }

            public async Task<Response<Fruta>> Handle(GetFrutaByIdQuery query, CancellationToken cancellationToken)
            {
                var fruta = await _frutaRepository.GetByIdAsync(query.Id);
                if (fruta == null) throw new ApiException($"Fruta Not Found.");
                return new Response<Fruta>(fruta);
            }
        }
}