using System.ComponentModel.DataAnnotations;

namespace challenge_3_net.Models.DTOs
{
    /// <summary>
    /// DTO para criação de moto
    /// </summary>
    public class CriarMotoDto
    {
        /// <summary>
        /// Placa da moto
        /// </summary>
        [Required(ErrorMessage = "Placa é obrigatória")]
        [StringLength(10, ErrorMessage = "Placa deve ter no máximo 10 caracteres")]
        public string Placa { get; set; } = string.Empty;

        /// <summary>
        /// Número do chassi da moto
        /// </summary>
        [Required(ErrorMessage = "Chassi é obrigatório")]
        [StringLength(17, ErrorMessage = "Chassi deve ter no máximo 17 caracteres")]
        public string Chassi { get; set; } = string.Empty;

        /// <summary>
        /// Informações do motor da moto
        /// </summary>
        [StringLength(100, ErrorMessage = "Motor deve ter no máximo 100 caracteres")]
        public string? Motor { get; set; }

        /// <summary>
        /// ID do usuário proprietário da moto
        /// </summary>
        [Required(ErrorMessage = "ID do usuário é obrigatório")]
        [Range(1, long.MaxValue, ErrorMessage = "ID do usuário deve ser maior que zero")]
        public long UsuarioId { get; set; }
    }

    /// <summary>
    /// DTO para atualização de moto
    /// </summary>
    public class AtualizarMotoDto
    {
        /// <summary>
        /// Placa da moto
        /// </summary>
        [Required(ErrorMessage = "Placa é obrigatória")]
        [StringLength(10, ErrorMessage = "Placa deve ter no máximo 10 caracteres")]
        public string Placa { get; set; } = string.Empty;

        /// <summary>
        /// Número do chassi da moto
        /// </summary>
        [Required(ErrorMessage = "Chassi é obrigatório")]
        [StringLength(17, ErrorMessage = "Chassi deve ter no máximo 17 caracteres")]
        public string Chassi { get; set; } = string.Empty;

        /// <summary>
        /// Informações do motor da moto
        /// </summary>
        [StringLength(100, ErrorMessage = "Motor deve ter no máximo 100 caracteres")]
        public string? Motor { get; set; }

        /// <summary>
        /// ID do usuário proprietário da moto
        /// </summary>
        [Required(ErrorMessage = "ID do usuário é obrigatório")]
        [Range(1, long.MaxValue, ErrorMessage = "ID do usuário deve ser maior que zero")]
        public long UsuarioId { get; set; }
    }

    /// <summary>
    /// DTO para resposta de moto
    /// </summary>
    public class MotoResponseDto
    {
        /// <summary>
        /// Identificador único da moto
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// Placa da moto
        /// </summary>
        public string Placa { get; set; } = string.Empty;

        /// <summary>
        /// Número do chassi da moto
        /// </summary>
        public string Chassi { get; set; } = string.Empty;

        /// <summary>
        /// Informações do motor da moto
        /// </summary>
        public string? Motor { get; set; }

        /// <summary>
        /// ID do usuário proprietário da moto
        /// </summary>
        public long UsuarioId { get; set; }

        /// <summary>
        /// Nome da filial proprietária
        /// </summary>
        public string NomeFilial { get; set; } = string.Empty;

        /// <summary>
        /// Data de criação do registro
        /// </summary>
        public DateTime DataCriacao { get; set; }

        /// <summary>
        /// Data da última atualização do registro
        /// </summary>
        public DateTime DataAtualizacao { get; set; }

        /// <summary>
        /// Links HATEOAS
        /// </summary>
        public List<LinkDto> Links { get; set; } = new List<LinkDto>();
    }
}
