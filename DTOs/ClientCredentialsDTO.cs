using System.ComponentModel.DataAnnotations;

namespace BoletoApi.DTOs
{
    public class ClientCredentialsDTO
    {
        [Required(ErrorMessage = "O ClientId é obrigatório!")]
        public string ClientId { get; set; }

        [Required(ErrorMessage = "O ClientSecret é obrigatório!")]
        public string ClientSecret { get; set; }
    }
}