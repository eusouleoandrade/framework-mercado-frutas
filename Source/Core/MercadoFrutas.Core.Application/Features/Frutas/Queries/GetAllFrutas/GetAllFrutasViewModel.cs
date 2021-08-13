namespace MercadoFrutas.Core.Application.Features.Frutas.Queries.GetAllFrutas
{
    public class GetAllFrutasViewModel
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public string Foto { get; set; }
        public int Quantidade { get; set; }
        public decimal Valor { get; set; }
    }
}