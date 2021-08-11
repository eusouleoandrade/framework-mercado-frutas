using System;
using MercadoFrutas.Core.Domain.Common;

namespace MercadoFrutas.Core.Domain.Entities
{
    public class Fruta : BaseEntity<Guid>
    {
        public string Nome { get; protected set; }
        public string Descricao { get; protected set; }
        public string Foto { get; protected set; }
        public int Quantidade { get; protected set; }
        public decimal Valor { get; protected set; }

        public Fruta(Guid id, string nome, string descricao, string foto, int quantidade, decimal valor)
        {
            Id = id;
            Nome = nome;
            Descricao = descricao;
            Foto = foto;
            Quantidade = quantidade;
            Valor = valor;
        }

        public Fruta(string nome, string descricao, string foto, int quantidade, decimal valor)
            : this(Guid.NewGuid(), nome, descricao, foto, quantidade, valor)
        {
        }
    }
}