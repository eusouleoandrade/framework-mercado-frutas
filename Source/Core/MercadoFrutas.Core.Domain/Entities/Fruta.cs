using System;
using MercadoFrutas.Core.Domain.Common;

namespace MercadoFrutas.Core.Domain.Entities
{
    public class Fruta : AuditableBaseEntity
    {
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public string Foto { get; set; }
        public int Quantidade { get; set; }
        public decimal Valor { get; set; }

        public Fruta(int id, string nome, string descricao, string foto, int quantidade, decimal valor)
        {
            Id = id;
            Nome = nome;
            Descricao = descricao;
            Foto = foto;
            Quantidade = quantidade;
            Valor = valor;
        }

        public Fruta(string nome, string descricao, string foto, int quantidade, decimal valor)
            : this(default, nome, descricao, foto, quantidade, valor)
        {
        }
    }
}