using MercadoFrutas.Core.Application.Interfaces.Repositories;
using MercadoFrutas.Core.Domain.Entities;
using MercadoFrutas.Infrastructure.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;

namespace MercadoFrutas.Infrastructure.Persistence.Repositories
{
    public class FrutaRepositoryAsync : GenericRepositoryAsync<Fruta>, IFrutaRepositoryAsync
    {
        private readonly DbSet<Fruta> _frutas;

        public FrutaRepositoryAsync(ApplicationDbContext dbContext) : base(dbContext)
        {
            _frutas = dbContext.Set<Fruta>();
        }
    }
}