using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace challenge_3_net.Models
{
    /// <summary>
    /// Entidade que representa uma moto no sistema
    /// </summary>
    public class Moto
    {
        /// <summary>
        /// Identificador único da moto
        /// </summary>
        [Key]
        public long Id { get; set; }

        /// <summary>
        /// Placa da moto (única)
        /// </summary>
        [Required]
        [MaxLength(10)]
        public string Placa { get; set; } = string.Empty;

        /// <summary>
        /// Número do chassi da moto (único)
        /// </summary>
        [Required]
        [MaxLength(17)]
        public string Chassi { get; set; } = string.Empty;

        /// <summary>
        /// Informações do motor da moto
        /// </summary>
        [MaxLength(100)]
        public string? Motor { get; set; }

        /// <summary>
        /// ID do usuário proprietário da moto
        /// </summary>
        [Required]
        public long UsuarioId { get; set; }

        /// <summary>
        /// Data de criação do registro
        /// </summary>
        [Required]
        public DateTime DataCriacao { get; set; }

        /// <summary>
        /// Data da última atualização do registro
        /// </summary>
        public DateTime DataAtualizacao { get; set; }

        // Propriedades de navegação
        /// <summary>
        /// Usuário proprietário da moto
        /// </summary>
        [ForeignKey("UsuarioId")]
        public virtual Usuario Usuario { get; set; } = null!;

        /// <summary>
        /// Lista de operações realizadas com a moto
        /// </summary>
        public virtual ICollection<Operacao> Operacoes { get; set; } = new List<Operacao>();

        /// <summary>
        /// Lista de status da moto
        /// </summary>
        public virtual ICollection<StatusMoto> StatusMotos { get; set; } = new List<StatusMoto>();
    }
}
