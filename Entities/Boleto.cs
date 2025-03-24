namespace BoletoApi.Entities
{
    public class Boleto
    {
        public Guid Id { get; set; }
        public string NomePagador { get; set; }
        public string CpfCnpjPagador { get; set; }
        public string NomeBeneficiario { get; set; }
        public string CpfCnpjBeneficiario { get; set; }
        public decimal Valor { get; set; }
        public DateTime DataVencimento { get; set; }
        public string? Observacao { get; set; }

        // referencia
        public Guid BancoId { get; set; }
        public Banco Banco { get; set; }
    }
}