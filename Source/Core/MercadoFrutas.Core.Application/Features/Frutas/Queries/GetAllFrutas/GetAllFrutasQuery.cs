using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using MercadoFrutas.Core.Application.Interfaces.Repositories;
using MercadoFrutas.Core.Application.Wrappers;

namespace MercadoFrutas.Core.Application.Features.Frutas.Queries.GetAllFrutas
{
    public class GetAllFrutasQuery : IRequest<PagedResponse<IEnumerable<GetAllFrutasViewModel>>>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
    }

    public class GetAllFrutasQueryHandler : IRequestHandler<GetAllFrutasQuery, PagedResponse<IEnumerable<GetAllFrutasViewModel>>>
    {
        private readonly IFrutaRepositoryAsync _frutaRepository;
        private readonly IMapper _mapper;
        public GetAllFrutasQueryHandler(IFrutaRepositoryAsync frutaRepository, IMapper mapper)
        {
            _frutaRepository = frutaRepository;
            _mapper = mapper;
        }

        public async Task<PagedResponse<IEnumerable<GetAllFrutasViewModel>>> Handle(GetAllFrutasQuery request, CancellationToken cancellationToken)
        {
            var validFilter = _mapper.Map<GetAllFrutasParameter>(request);
            var fruta = await _frutaRepository.GetPagedReponseAsync(validFilter.PageNumber,validFilter.PageSize);
            var frutaViewModel = _mapper.Map<IEnumerable<GetAllFrutasViewModel>>(fruta);
            return new PagedResponse<IEnumerable<GetAllFrutasViewModel>>(frutaViewModel, validFilter.PageNumber, validFilter.PageSize);           
        }
    }
}