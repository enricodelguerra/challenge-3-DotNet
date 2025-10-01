using System.ComponentModel.DataAnnotations;

namespace challenge_3_net.Models.DTOs
{
    /// <summary>
    /// DTO para criação de usuário
    /// </summary>
    public class CriarUsuarioDto
    {
        /// <summary>
        /// Nome da filial/empresa
        /// </summary>
        [Required(ErrorMessage = "Nome da filial é obrigatório")]
        [StringLength(255, ErrorMessage = "Nome da filial deve ter no máximo 255 caracteres")]
        public string NomeFilial { get; set; } = string.Empty;

        /// <summary>
        /// Email do usuário
        /// </summary>
        [Required(ErrorMessage = "Email é obrigatório")]
        [EmailAddress(ErrorMessage = "Email deve ter um formato válido")]
        [StringLength(255, ErrorMessage = "Email deve ter no máximo 255 caracteres")]
        public string Email { get; set; } = string.Empty;

        /// <summary>
        /// Senha do usuário
        /// </summary>
        [Required(ErrorMessage = "Senha é obrigatória")]
        [StringLength(100, MinimumLength = 6, ErrorMessage = "Senha deve ter entre 6 e 100 caracteres")]
        public string Senha { get; set; } = string.Empty;

        /// <summary>
        /// CNPJ da empresa
        /// </summary>
        [Required(ErrorMessage = "CNPJ é obrigatório")]
        [StringLength(18, ErrorMessage = "CNPJ deve ter no máximo 18 caracteres")]
        public string Cnpj { get; set; } = string.Empty;

        /// <summary>
        /// Endereço da empresa
        /// </summary>
        [StringLength(500, ErrorMessage = "Endereço deve ter no máximo 500 caracteres")]
        public string? Endereco { get; set; }

        /// <summary>
        /// Telefone de contato
        /// </summary>
        [StringLength(20, ErrorMessage = "Telefone deve ter no máximo 20 caracteres")]
        public string? Telefone { get; set; }

        /// <summary>
        /// Perfil do usuário no sistema
        /// </summary>
        [Required(ErrorMessage = "Perfil é obrigatório")]
        public PerfilUsuario Perfil { get; set; }
    }

    /// <summary>
    /// DTO para atualização de usuário
    /// </summary>
    public class AtualizarUsuarioDto
    {
        /// <summary>
        /// Nome da filial/empresa
        /// </summary>
        [Required(ErrorMessage = "Nome da filial é obrigatório")]
        [StringLength(255, ErrorMessage = "Nome da filial deve ter no máximo 255 caracteres")]
        public string NomeFilial { get; set; } = string.Empty;

        /// <summary>
        /// Email do usuário
        /// </summary>
        [Required(ErrorMessage = "Email é obrigatório")]
        [EmailAddress(ErrorMessage = "Email deve ter um formato válido")]
        [StringLength(255, ErrorMessage = "Email deve ter no máximo 255 caracteres")]
        public string Email { get; set; } = string.Empty;

        /// <summary>
        /// CNPJ da empresa
        /// </summary>
        [Required(ErrorMessage = "CNPJ é obrigatório")]
        [StringLength(18, ErrorMessage = "CNPJ deve ter no máximo 18 caracteres")]
        public string Cnpj { get; set; } = string.Empty;

        /// <summary>
        /// Endereço da empresa
        /// </summary>
        [StringLength(500, ErrorMessage = "Endereço deve ter no máximo 500 caracteres")]
        public string? Endereco { get; set; }

        /// <summary>
        /// Telefone de contato
        /// </summary>
        [StringLength(20, ErrorMessage = "Telefone deve ter no máximo 20 caracteres")]
        public string? Telefone { get; set; }

        /// <summary>
        /// Perfil do usuário no sistema
        /// </summary>
        [Required(ErrorMessage = "Perfil é obrigatório")]
        public PerfilUsuario Perfil { get; set; }
    }

    /// <summary>
    /// DTO para resposta de usuário
    /// </summary>
    public class UsuarioResponseDto
    {
        /// <summary>
        /// Identificador único do usuário
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// Nome da filial/empresa
        /// </summary>
        public string NomeFilial { get; set; } = string.Empty;

        /// <summary>
        /// Email do usuário
        /// </summary>
        public string Email { get; set; } = string.Empty;

        /// <summary>
        /// CNPJ da empresa
        /// </summary>
        public string Cnpj { get; set; } = string.Empty;

        /// <summary>
        /// Endereço da empresa
        /// </summary>
        public string? Endereco { get; set; }

        /// <summary>
        /// Telefone de contato
        /// </summary>
        public string? Telefone { get; set; }

        /// <summary>
        /// Perfil do usuário no sistema
        /// </summary>
        public PerfilUsuario Perfil { get; set; }

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
