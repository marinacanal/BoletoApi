using System.ComponentModel.DataAnnotations;

namespace BoletoApi.DTOs
{
    public class BancoRequestDTO
    {
        [Required(ErrorMessage = "O nome do banco é obrigatório!")]
        public string Nome{ get; set; }

        [Required(ErrorMessage = "O código do banco é obrigatório!")]
        public short Codigo { get; set; }

        [Required(ErrorMessage = "O percentual de juros é obrigatório!")]
        public decimal PercentualJuros { get; set; }
    }
}