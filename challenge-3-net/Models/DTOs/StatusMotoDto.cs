using System.ComponentModel.DataAnnotations;

namespace challenge_3_net.Models.DTOs
{
    /// <summary>
    /// DTO para criação de status de moto
    /// </summary>
    public class CriarStatusMotoDto
    {
        /// <summary>
        /// Status atual da moto
        /// </summary>
        [Required(ErrorMessage = "Status é obrigatório")]
        public StatusMotoEnum Status { get; set; }

        /// <summary>
        /// Descrição detalhada do status
        /// </summary>
        [StringLength(500, ErrorMessage = "Descrição deve ter no máximo 500 caracteres")]
        public string? Descricao { get; set; }

        /// <summary>
        /// Área onde a moto se encontra
        /// </summary>
        [Required(ErrorMessage = "Área é obrigatória")]
        [StringLength(50, ErrorMessage = "Área deve ter no máximo 50 caracteres")]
        public string Area { get; set; } = string.Empty;

        /// <summary>
        /// ID da moto
        /// </summary>
        [Required(ErrorMessage = "ID da moto é obrigatório")]
        [Range(1, long.MaxValue, ErrorMessage = "ID da moto deve ser maior que zero")]
        public long MotoId { get; set; }

        /// <summary>
        /// ID do usuário que registrou o status
        /// </summary>
        [Required(ErrorMessage = "ID do usuário é obrigatório")]
        [Range(1, long.MaxValue, ErrorMessage = "ID do usuário deve ser maior que zero")]
        public long UsuarioId { get; set; }
    }

    /// <summary>
    /// DTO para atualização de status de moto
    /// </summary>
    public class AtualizarStatusMotoDto
    {
        /// <summary>
        /// Status atual da moto
        /// </summary>
        [Required(ErrorMessage = "Status é obrigatório")]
        public StatusMotoEnum Status { get; set; }

        /// <summary>
        /// Descrição detalhada do status
        /// </summary>
        [StringLength(500, ErrorMessage = "Descrição deve ter no máximo 500 caracteres")]
        public string? Descricao { get; set; }

        /// <summary>
        /// Área onde a moto se encontra
        /// </summary>
        [Required(ErrorMessage = "Área é obrigatória")]
        [StringLength(50, ErrorMessage = "Área deve ter no máximo 50 caracteres")]
        public string Area { get; set; } = string.Empty;

        /// <summary>
        /// ID da moto
        /// </summary>
        [Required(ErrorMessage = "ID da moto é obrigatório")]
        [Range(1, long.MaxValue, ErrorMessage = "ID da moto deve ser maior que zero")]
        public long MotoId { get; set; }

        /// <summary>
        /// ID do usuário que registrou o status
        /// </summary>
        [Required(ErrorMessage = "ID do usuário é obrigatório")]
        [Range(1, long.MaxValue, ErrorMessage = "ID do usuário deve ser maior que zero")]
        public long UsuarioId { get; set; }
    }

    /// <summary>
    /// DTO para resposta de status de moto
    /// </summary>
    public class StatusMotoResponseDto
    {
        /// <summary>
        /// Identificador único do status
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// Status atual da moto
        /// </summary>
        public StatusMotoEnum Status { get; set; }

        /// <summary>
        /// Descrição detalhada do status
        /// </summary>
        public string? Descricao { get; set; }

        /// <summary>
        /// Área onde a moto se encontra
        /// </summary>
        public string Area { get; set; } = string.Empty;

        /// <summary>
        /// Data e hora do status
        /// </summary>
        public DateTime DataStatus { get; set; }

        /// <summary>
        /// ID da moto
        /// </summary>
        public long MotoId { get; set; }

        /// <summary>
        /// Placa da moto
        /// </summary>
        public string PlacaMoto { get; set; } = string.Empty;

        /// <summary>
        /// ID do usuário que registrou o status
        /// </summary>
        public long UsuarioId { get; set; }

        /// <summary>
        /// Nome do usuário que registrou o status
        /// </summary>
        public string NomeUsuario { get; set; } = string.Empty;

        /// <summary>
        /// Links HATEOAS
        /// </summary>
        public List<LinkDto> Links { get; set; } = new List<LinkDto>();
    }
}
