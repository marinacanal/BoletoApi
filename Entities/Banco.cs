namespace BoletoApi.Entities
{
    public class Banco
    {
        public Guid Id { get; private set; }
        public string Nome{ get; private set; }
        public short Codigo { get; private set; }
        public decimal PercentualJuros { get; private set; }

        // construtor
        public Banco(string nome, short codigo, decimal percentualJuros)
        {
            // ver se adiciono alguma validacao aq tb
            Id = Guid.NewGuid();
            Nome = nome;
            Codigo = codigo;
            PercentualJuros = percentualJuros;
        }
    }
}