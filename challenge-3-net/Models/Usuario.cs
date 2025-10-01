using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace challenge_3_net.Models
{
    /// <summary>
    /// Entidade que representa um usuário do sistema
    /// </summary>
    public class Usuario
    {
        /// <summary>
        /// Identificador único do usuário
        /// </summary>
        [Key]
        public long Id { get; set; }

        /// <summary>
        /// Nome da filial/empresa
        /// </summary>
        [Required]
        [MaxLength(255)]
        public string NomeFilial { get; set; } = string.Empty;

        /// <summary>
        /// Email do usuário (único)
        /// </summary>
        [Required]
        [MaxLength(255)]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;

        /// <summary>
        /// Hash da senha do usuário
        /// </summary>
        [Required]
        [MaxLength(255)]
        public string SenhaHash { get; set; } = string.Empty;

        /// <summary>
        /// CNPJ da empresa (único)
        /// </summary>
        [Required]
        [MaxLength(18)]
        public string Cnpj { get; set; } = string.Empty;

        /// <summary>
        /// Endereço da empresa
        /// </summary>
        [MaxLength(500)]
        public string? Endereco { get; set; }

        /// <summary>
        /// Telefone de contato
        /// </summary>
        [MaxLength(20)]
        public string? Telefone { get; set; }

        /// <summary>
        /// Perfil do usuário no sistema
        /// </summary>
        [Required]
        public PerfilUsuario Perfil { get; set; }

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
        /// Lista de motos associadas ao usuário
        /// </summary>
        public virtual ICollection<Moto> Motos { get; set; } = new List<Moto>();

        /// <summary>
        /// Lista de operações realizadas pelo usuário
        /// </summary>
        public virtual ICollection<Operacao> Operacoes { get; set; } = new List<Operacao>();
    }

    /// <summary>
    /// Enum que define os perfis de usuário no sistema
    /// </summary>
    public enum PerfilUsuario
    {
        /// <summary>
        /// Administrador com acesso total ao sistema
        /// </summary>
        ADMIN,

        /// <summary>
        /// Gerente com acesso a relatórios e operações
        /// </summary>
        GERENTE,

        /// <summary>
        /// Operador com acesso limitado às operações
        /// </summary>
        OPERADOR
    }
}