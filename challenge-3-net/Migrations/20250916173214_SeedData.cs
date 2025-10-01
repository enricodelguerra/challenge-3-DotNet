using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace challenge_3_net.Migrations
{
    /// <inheritdoc />
    public partial class SeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Usuarios",
                columns: new[] { "Id", "Cnpj", "DataAtualizacao", "DataCriacao", "Email", "Endereco", "NomeFilial", "Perfil", "SenhaHash", "Telefone" },
                values: new object[,]
                {
                    { 1L, "12.345.678/0001-90", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "admin@fiap.com", "Rua Admin, 123", "Admin FIAP", "ADMIN", "$2a$11$sP/IdKyidixV4jh6CKjkDuzye3vLNrmMOT6yxaWmhxGCqZLiClfk6", "(11) 99999-9999" },
                    { 2L, "12.345.678/0002-90", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "gerente@fiap.com", "Rua Gerente, 456", "Gerente FIAP", "GERENTE", "$2a$11$cqLk2fEnxWAgN1WCDI7neennmOzZMF1mL6nCFtK.c73U2rUwcyYfO", "(11) 88888-8888" },
                    { 3L, "12.345.678/0003-90", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "operador@fiap.com", "Rua Operador, 789", "Operador FIAP", "OPERADOR", "$2a$11$G7Nz51URhoIweSxTZDnn9ObfvjEwQW.vlbr5SH4jYtaOd18Qd4UUa", "(11) 77777-7777" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: 2L);

            migrationBuilder.DeleteData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: 3L);
        }
    }
}
