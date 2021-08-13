using System;
using MercadoFrutas.Core.Domain.Entities;

namespace MercadoFrutas.Core.Application.Interfaces
{
    public interface IDateTimeService
    {
        DateTime NowUtc { get; }
    }
}