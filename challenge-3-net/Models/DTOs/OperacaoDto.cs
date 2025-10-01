using System.ComponentModel.DataAnnotations;

namespace challenge_3_net.Models.DTOs
{
    /// <summary>
    /// DTO para criação de operação
    /// </summary>
    public class CriarOperacaoDto
    {
        /// <summary>
        /// Tipo da operação realizada
        /// </summary>
        [Required(ErrorMessage = "Tipo da operação é obrigatório")]
        public TipoOperacao TipoOperacao { get; set; }

        /// <summary>
        /// Descrição detalhada da operação
        /// </summary>
        [StringLength(1000, ErrorMessage = "Descrição deve ter no máximo 1000 caracteres")]
        public string? Descricao { get; set; }

        /// <summary>
        /// ID da moto envolvida na operação
        /// </summary>
        [Required(ErrorMessage = "ID da moto é obrigatório")]
        [Range(1, long.MaxValue, ErrorMessage = "ID da moto deve ser maior que zero")]
        public long MotoId { get; set; }

        /// <summary>
        /// ID do usuário que realizou a operação
        /// </summary>
        [Required(ErrorMessage = "ID do usuário é obrigatório")]
        [Range(1, long.MaxValue, ErrorMessage = "ID do usuário deve ser maior que zero")]
        public long UsuarioId { get; set; }
    }

    /// <summary>
    /// DTO para atualização de operação
    /// </summary>
    public class AtualizarOperacaoDto
    {
        /// <summary>
        /// Tipo da operação realizada
        /// </summary>
        [Required(ErrorMessage = "Tipo da operação é obrigatório")]
        public TipoOperacao TipoOperacao { get; set; }

        /// <summary>
        /// Descrição detalhada da operação
        /// </summary>
        [StringLength(1000, ErrorMessage = "Descrição deve ter no máximo 1000 caracteres")]
        public string? Descricao { get; set; }

        /// <summary>
        /// ID da moto envolvida na operação
        /// </summary>
        [Required(ErrorMessage = "ID da moto é obrigatório")]
        [Range(1, long.MaxValue, ErrorMessage = "ID da moto deve ser maior que zero")]
        public long MotoId { get; set; }

        /// <summary>
        /// ID do usuário que realizou a operação
        /// </summary>
        [Required(ErrorMessage = "ID do usuário é obrigatório")]
        [Range(1, long.MaxValue, ErrorMessage = "ID do usuário deve ser maior que zero")]
        public long UsuarioId { get; set; }
    }

    /// <summary>
    /// DTO para resposta de operação
    /// </summary>
    public class OperacaoResponseDto
    {
        /// <summary>
        /// Identificador único da operação
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// Tipo da operação realizada
        /// </summary>
        public TipoOperacao TipoOperacao { get; set; }

        /// <summary>
        /// Descrição detalhada da operação
        /// </summary>
        public string? Descricao { get; set; }

        /// <summary>
        /// Data e hora da operação
        /// </summary>
        public DateTime DataOperacao { get; set; }

        /// <summary>
        /// ID da moto envolvida na operação
        /// </summary>
        public long MotoId { get; set; }

        /// <summary>
        /// Placa da moto
        /// </summary>
        public string PlacaMoto { get; set; } = string.Empty;

        /// <summary>
        /// ID do usuário que realizou a operação
        /// </summary>
        public long UsuarioId { get; set; }

        /// <summary>
        /// Nome do usuário que realizou a operação
        /// </summary>
        public string NomeUsuario { get; set; } = string.Empty;

        /// <summary>
        /// Links HATEOAS
        /// </summary>
        public List<LinkDto> Links { get; set; } = new List<LinkDto>();
    }
}
