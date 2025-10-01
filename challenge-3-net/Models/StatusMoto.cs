using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace challenge_3_net.Models
{
    /// <summary>
    /// Entidade que representa o status atual de uma moto
    /// </summary>
    public class StatusMoto
    {
        /// <summary>
        /// Identificador único do status
        /// </summary>
        [Key]
        public long Id { get; set; }

        /// <summary>
        /// Status atual da moto
        /// </summary>
        [Required]
        public StatusMotoEnum Status { get; set; }

        /// <summary>
        /// Descrição detalhada do status
        /// </summary>
        [MaxLength(500)]
        public string? Descricao { get; set; }

        /// <summary>
        /// Área onde a moto se encontra
        /// </summary>
        [Required]
        [MaxLength(50)]
        public string Area { get; set; } = string.Empty;

        /// <summary>
        /// Data e hora do status
        /// </summary>
        [Required]
        public DateTime DataStatus { get; set; }

        /// <summary>
        /// ID da moto
        /// </summary>
        [Required]
        public long MotoId { get; set; }

        /// <summary>
        /// ID do usuário que registrou o status
        /// </summary>
        [Required]
        public long UsuarioId { get; set; }

        // Propriedades de navegação
        /// <summary>
        /// Moto relacionada ao status
        /// </summary>
        [ForeignKey("MotoId")]
        public virtual Moto Moto { get; set; } = null!;

        /// <summary>
        /// Usuário que registrou o status
        /// </summary>
        [ForeignKey("UsuarioId")]
        public virtual Usuario Usuario { get; set; } = null!;
    }

    /// <summary>
    /// Enum que define os possíveis status de uma moto
    /// </summary>
    public enum StatusMotoEnum
    {
        /// <summary>
        /// Moto disponível para uso
        /// </summary>
        DISPONIVEL,

        /// <summary>
        /// Moto em uso no momento
        /// </summary>
        EM_USO,

        /// <summary>
        /// Moto em manutenção
        /// </summary>
        MANUTENCAO,

        /// <summary>
        /// Moto indisponível
        /// </summary>
        INDISPONIVEL,

        /// <summary>
        /// Moto com status pendente
        /// </summary>
        PENDENTE,

        /// <summary>
        /// Moto com reparo simples necessário
        /// </summary>
        REPARO_SIMPLES,

        /// <summary>
        /// Moto com danos estruturais
        /// </summary>
        DANOS_ESTRUTURAIS,

        /// <summary>
        /// Moto com motor defeituoso
        /// </summary>
        MOTOR_DEFEITUOSO,

        /// <summary>
        /// Moto com manutenção agendada
        /// </summary>
        MANUTENCAO_AGENDADA,

        /// <summary>
        /// Moto pronta para uso
        /// </summary>
        PRONTA,

        /// <summary>
        /// Moto sem placa
        /// </summary>
        SEM_PLACA,

        /// <summary>
        /// Moto alugada
        /// </summary>
        ALUGADA,

        /// <summary>
        /// Moto aguardando aluguel
        /// </summary>
        AGUARDANDO_ALUGUEL
    }
}
