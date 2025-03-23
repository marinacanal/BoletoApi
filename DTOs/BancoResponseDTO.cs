namespace BoletoApi.DTOs
{
    public class BancoResponseDTO
    {
        public Guid Id { get; set; }
        public string Nome{ get; set; }
        public short Codigo { get; set; }
        public decimal PercentualJuros { get; set; }
    }
}