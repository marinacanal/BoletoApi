using System.ComponentModel.DataAnnotations;

namespace BoletoApi.DTOs
{
    public class BoletoRequestDTO
    {
        [Required(ErrorMessage = "O nome do pagador é obrigatório!")]
        public string NomePagador { get; set; }

        [Required(ErrorMessage = "O CPF/CNPJ do pagador é obrigatório!")]
        public string CpfCnpjPagador { get; set; }

        [Required(ErrorMessage = "O nome do beneficiário é obrigatório!")]
        public string NomeBeneficiario { get; set; }

        [Required(ErrorMessage = "O CPF/CNPJ do beneficiário é obrigatório!")]
        public string CpfCnpjBeneficiario { get; set; }

        [Required(ErrorMessage = "O valor é obrigatório!")]
        [Range(0.01, double.MaxValue, ErrorMessage = "O valor deve ser maior que zero!")]
        public decimal Valor { get; set; }

        [Required(ErrorMessage = "A data de vencimento é obrigatória!")]
        public DateTime DataVencimento { get; set; }

        public string? Observacao { get; set; }

        [Required(ErrorMessage = "O Id do banco é obrigatório!")]
        public Guid BancoId { get; set; }
    }
}