using Microsoft.EntityFrameworkCore;
using challenge_3_net.Models;
using Microsoft.Extensions.Configuration;

namespace challenge_3_net.Data
{
    /// <summary>
    /// Contexto do Entity Framework para a aplicação
    /// </summary>
    public class ApplicationDbContext : DbContext
    {
        private readonly IConfiguration _configuration;

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options, IConfiguration configuration) : base(options)
        {
            _configuration = configuration;
        }

        /// <summary>
        /// Tabela de usuários
        /// </summary>
        public DbSet<Usuario> Usuarios { get; set; } = null!;

        /// <summary>
        /// Tabela de motos
        /// </summary>
        public DbSet<Moto> Motos { get; set; } = null!;

        /// <summary>
        /// Tabela de operações
        /// </summary>
        public DbSet<Operacao> Operacoes { get; set; } = null!;

        /// <summary>
        /// Tabela de status das motos
        /// </summary>
        public DbSet<StatusMoto> StatusMotos { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configura delete em cascata para StatusMoto
            modelBuilder.Entity<Moto>()
                .HasMany(m => m.StatusMotos)
                .WithOne(s => s.Moto)
                .HasForeignKey(s => s.MotoId)
                .OnDelete(DeleteBehavior.Cascade);

            // Configura delete em cascata para Operacao
            modelBuilder.Entity<Moto>()
                .HasMany(m => m.Operacoes)
                .WithOne(o => o.Moto)
                .HasForeignKey(o => o.MotoId)
                .OnDelete(DeleteBehavior.Cascade);

            // Configuração da entidade Usuario
            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.NomeFilial).IsRequired().HasMaxLength(255);
                entity.Property(e => e.Email).IsRequired().HasMaxLength(255);
                entity.Property(e => e.SenhaHash).IsRequired().HasMaxLength(255);
                entity.Property(e => e.Cnpj).IsRequired().HasMaxLength(18);
                entity.Property(e => e.Endereco).HasMaxLength(500);
                entity.Property(e => e.Telefone).HasMaxLength(20);
                entity.Property(e => e.Perfil).IsRequired().HasConversion<string>();
                entity.Property(e => e.DataCriacao).IsRequired();
                entity.Property(e => e.DataAtualizacao).IsRequired();

                // Índices únicos
                entity.HasIndex(e => e.Email).IsUnique();
                entity.HasIndex(e => e.Cnpj).IsUnique();
            });

            // Configuração da entidade Moto
            modelBuilder.Entity<Moto>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Placa).IsRequired().HasMaxLength(10);
                entity.Property(e => e.Chassi).IsRequired().HasMaxLength(17);
                entity.Property(e => e.Motor).HasMaxLength(100);
                entity.Property(e => e.UsuarioId).IsRequired();
                entity.Property(e => e.DataCriacao).IsRequired();
                entity.Property(e => e.DataAtualizacao).IsRequired();

                // Índices únicos
                entity.HasIndex(e => e.Placa).IsUnique();
                entity.HasIndex(e => e.Chassi).IsUnique();

                // Relacionamento com Usuario
                entity.HasOne(e => e.Usuario)
                      .WithMany(u => u.Motos)
                      .HasForeignKey(e => e.UsuarioId)
                      .OnDelete(DeleteBehavior.Cascade);
            });

            // Configuração da entidade Operacao
            modelBuilder.Entity<Operacao>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.MotoId).IsRequired();
                entity.Property(e => e.UsuarioId).IsRequired();
                entity.Property(e => e.TipoOperacao).IsRequired().HasConversion<string>();
                entity.Property(e => e.Descricao).HasMaxLength(1000);
                entity.Property(e => e.DataOperacao).IsRequired();

                // Relacionamentos
                entity.HasOne(e => e.Moto)
                      .WithMany(m => m.Operacoes)
                      .HasForeignKey(e => e.MotoId)
                      .OnDelete(DeleteBehavior.Cascade);

                entity.HasOne(e => e.Usuario)
                      .WithMany(u => u.Operacoes)
                      .HasForeignKey(e => e.UsuarioId)
                      .OnDelete(DeleteBehavior.NoAction);
            });

            // Configuração da entidade StatusMoto
            modelBuilder.Entity<StatusMoto>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.MotoId).IsRequired();
                entity.Property(e => e.UsuarioId).IsRequired();
                entity.Property(e => e.Status).IsRequired().HasConversion<string>();
                entity.Property(e => e.Descricao).HasMaxLength(500);
                entity.Property(e => e.Area).IsRequired().HasMaxLength(50);
                entity.Property(e => e.DataStatus).IsRequired();

                // Relacionamentos
                entity.HasOne(e => e.Moto)
                      .WithMany(m => m.StatusMotos)
                      .HasForeignKey(e => e.MotoId)
                      .OnDelete(DeleteBehavior.Cascade);

                entity.HasOne(e => e.Usuario)
                      .WithMany()
                      .HasForeignKey(e => e.UsuarioId)
                      .OnDelete(DeleteBehavior.NoAction);
            });

            // Seed data - desabilitado temporariamente
            // SeedData(modelBuilder);
        }

        private void SeedData(ModelBuilder modelBuilder)
        {
            var dataCriacao = new DateTime(2025, 1, 1, 0, 0, 0, DateTimeKind.Utc);
            
            // Usuários iniciais
            modelBuilder.Entity<Usuario>().HasData(
                new Usuario
                {
                    Id = 1,
                    NomeFilial = "Admin FIAP",
                    Email = "admin@fiap.com",
                    SenhaHash = BCrypt.Net.BCrypt.HashPassword("admin123"),
                    Cnpj = "12.345.678/0001-90",
                    Endereco = "Rua Admin, 123",
                    Telefone = "(11) 99999-9999",
                    Perfil = PerfilUsuario.ADMIN,
                    DataCriacao = dataCriacao,
                    DataAtualizacao = dataCriacao
                },
                new Usuario
                {
                    Id = 2,
                    NomeFilial = "Gerente FIAP",
                    Email = "gerente@fiap.com",
                    SenhaHash = BCrypt.Net.BCrypt.HashPassword("gerente123"),
                    Cnpj = "12.345.678/0002-90",
                    Endereco = "Rua Gerente, 456",
                    Telefone = "(11) 88888-8888",
                    Perfil = PerfilUsuario.GERENTE,
                    DataCriacao = dataCriacao,
                    DataAtualizacao = dataCriacao
                },
                new Usuario
                {
                    Id = 3,
                    NomeFilial = "Operador FIAP",
                    Email = "operador@fiap.com",
                    SenhaHash = BCrypt.Net.BCrypt.HashPassword("operador123"),
                    Cnpj = "12.345.678/0003-90",
                    Endereco = "Rua Operador, 789",
                    Telefone = "(11) 77777-7777",
                    Perfil = PerfilUsuario.OPERADOR,
                    DataCriacao = dataCriacao,
                    DataAtualizacao = dataCriacao
                }
            );
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseOracle(_configuration.GetConnectionString("DefaultConnection"));
            }
        }
    }
}
