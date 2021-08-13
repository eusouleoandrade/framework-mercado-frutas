using System.Threading;
using System.Threading.Tasks;
using MediatR;
using MercadoFrutas.Core.Application.Exceptions;
using MercadoFrutas.Core.Application.Interfaces.Repositories;
using MercadoFrutas.Core.Application.Wrappers;

namespace MercadoFrutas.Core.Application.Features.Frutas.Commands.DeleteFrutaById
{
    public class DeleteFrutaByIdCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }
    }

    public class DeleteFrutaByIdCommandHandler : IRequestHandler<DeleteFrutaByIdCommand, Response<int>>
    {
        private readonly IFrutaRepositoryAsync _frutaRepository;

        public DeleteFrutaByIdCommandHandler(IFrutaRepositoryAsync frutaRepository)
        {
            _frutaRepository = frutaRepository;
        }
        
        public async Task<Response<int>> Handle(DeleteFrutaByIdCommand command, CancellationToken cancellationToken)
        {
            var fruta = await _frutaRepository.GetByIdAsync(command.Id);
            if (fruta == null) throw new ApiException($"Fruta Not Found.");
            await _frutaRepository.DeleteAsync(fruta);
            return new Response<int>(fruta.Id);
        }
    }
}