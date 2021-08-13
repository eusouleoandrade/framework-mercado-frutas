using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using MercadoFrutas.Core.Application.Interfaces.Repositories;
using MercadoFrutas.Core.Application.Wrappers;
using MercadoFrutas.Core.Domain.Entities;

namespace MercadoFrutas.Core.Application.Features.Frutas.Commands.CreateFruta
{
    public class CreateFrutaCommand : IRequest<Response<int>>
    {
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public string Foto { get; set; }
        public int Quantidade { get; set; }
        public decimal Valor { get; set; }
    }

    public class CreateFrutaCommandHandler : IRequestHandler<CreateFrutaCommand, Response<int>>
    {
        private readonly IFrutaRepositoryAsync _frutaRepository;
        private readonly IMapper _mapper;
        
        public CreateFrutaCommandHandler(IFrutaRepositoryAsync frutaRepository, IMapper mapper)
        {
            _frutaRepository = frutaRepository;
            _mapper = mapper;
        }

        public async Task<Response<int>> Handle(CreateFrutaCommand request, CancellationToken cancellationToken)
        {
            var fruta = _mapper.Map<Fruta>(request);
            await _frutaRepository.AddAsync(fruta);
            return new Response<int>(fruta.Id);
        }
    }
}