namespace BoletoApi.Entities
{
    public class Banco
    {
        public Guid Id { get; set; }
        public string Nome{ get; set; }
        public short Codigo { get; set; }
        public decimal PercentualJuros { get; set; }
    }
}