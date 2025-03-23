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

        // construtor
        public Boleto(string nomePagador, string cpfCnpjPagador, string nomeBeneficiario, string cpfCnpjBeneficiario, decimal valor, DateTime dataVencimento, Guid bancoId)
        {
            Id = Guid.NewGuid();
            NomePagador = nomePagador;
            CpfCnpjPagador = cpfCnpjPagador;
            NomeBeneficiario = nomeBeneficiario;
            CpfCnpjBeneficiario = cpfCnpjBeneficiario;
            Valor = valor;
            DataVencimento = dataVencimento;
            BancoId = bancoId;
        }
    }
}