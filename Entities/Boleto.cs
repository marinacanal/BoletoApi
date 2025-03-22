namespace BoletoApi.Entities
{
    public class Boleto
    {
        public Guid Id { get; private set; }
        public string NomePagador { get; private set; }
        public string CpfCnpjPagador { get; private set; }
        public string NomeBeneficiario { get; private set; }
        public string CpfCnpjBeneficiario { get; private set; }
        public decimal Valor { get; private set; }
        public DateTime DataVencimento { get; private set; }
        public string? Observacao { get; private set; }

        // referencia
        public Guid BancoId { get; private set; }
        public Banco Banco { get; private set; }

        // construtor
        public Boleto(string nomePagador, string cpfCnpjPagador, string nomeBeneficiario, string cpfCnpjBeneficiario, decimal valor, DateTime dataVencimento, Guid bancoId)
        {
            // ver se adiciono alguma validacao aq tb
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