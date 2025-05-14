using System.ComponentModel.DataAnnotations;

namespace SmartMotoZone.API.Models
{
    public class Moto
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "O modelo da moto é obrigatório.")]
        [StringLength(50, ErrorMessage = "O modelo pode ter no máximo 50 caracteres.")]
        public string Modelo { get; set; }

        [Required(ErrorMessage = "A placa da moto é obrigatória.")]
        [RegularExpression(@"^[A-Z]{3}-\d{4}$", ErrorMessage = "A placa deve estar no formato ABC-1234.")]
        public string Placa { get; set; }

        [Required(ErrorMessage = "O status da moto é obrigatório.")]
        [StringLength(20, ErrorMessage = "O status pode ter no máximo 20 caracteres.")]
        public string Status { get; set; } // Exemplo: "Disponível", "Em manutenção", etc.

        [Required(ErrorMessage = "A zona atual da moto é obrigatória.")]
        [RegularExpression(@"^[A-Z]\d$", ErrorMessage = "A zona deve estar no formato A1, B2, etc.")]
        public string ZonaAtual { get; set; }

        [Required]
        public DateTime UltimaAtualizacao { get; set; } = DateTime.UtcNow;
    }
}