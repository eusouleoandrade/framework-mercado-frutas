using System.Threading;
using System.Threading.Tasks;
using MediatR;
using MercadoFrutas.Core.Application.Exceptions;
using MercadoFrutas.Core.Application.Interfaces.Repositories;
using MercadoFrutas.Core.Application.Wrappers;

namespace MercadoFrutas.Core.Application.Features.Frutas.Commands.UpdateFruta
{
    public class UpdateFrutaCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public string Foto { get; set; }
        public int Quantidade { get; set; }
        public decimal Valor { get; set; }
    }

    public class UpdateFrutaCommandHandler : IRequestHandler<UpdateFrutaCommand, Response<int>>
    {
        private readonly IFrutaRepositoryAsync _frutaRepository;

        public UpdateFrutaCommandHandler(IFrutaRepositoryAsync frutaRepository)
        {
            _frutaRepository = frutaRepository;
        }

        public async Task<Response<int>> Handle(UpdateFrutaCommand command, CancellationToken cancellationToken)
        {
            var fruta = await _frutaRepository.GetByIdAsync(command.Id);

            if (fruta == null)
                throw new ApiException($"Fruta Not Found.");
            else
            {
                fruta.Nome = command.Nome;
                fruta.Descricao = command.Descricao;
                fruta.Foto = command.Foto;
                fruta.Quantidade = command.Quantidade;
                fruta.Valor = command.Valor;

                await _frutaRepository.UpdateAsync(fruta);

                return new Response<int>(fruta.Id);
            }
        }
    }
}