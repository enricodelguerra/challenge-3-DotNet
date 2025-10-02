using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using challenge_3_net.Data;
using challenge_3_net.Repositories;
using challenge_3_net.Repositories.Interfaces;
using challenge_3_net.Services;
using challenge_3_net.Services.Interfaces;
using challenge_3_net.Services.Mapping;
using System.Reflection;
using Oracle.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

// Configurar Entity Framework
builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseOracle(builder.Configuration.GetConnectionString("DefaultConnection"));
    options.EnableDetailedErrors();
    options.EnableSensitiveDataLogging();
    options.LogTo(Console.WriteLine,
        events: new[] { RelationalEventId.CommandExecuting, RelationalEventId.CommandError },
        minimumLevel: LogLevel.Information);
});

// Configurar AutoMapper
builder.Services.AddAutoMapper(typeof(AutoMapperProfile));

// Configurar Swagger/OpenAPI
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
    {
        Title = "Sistema de Gestão de Motos API",
        Version = "v1",
        Description = "API RESTful para gerenciamento de motos, usuários, operações e status",
        Contact = new Microsoft.OpenApi.Models.OpenApiContact
        {
            Name = "Equipe de Desenvolvimento",
            Email = "dev@fiap.com"
        }
    });

    // Incluir comentários XML
    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    if (File.Exists(xmlPath))
    {
        c.IncludeXmlComments(xmlPath);
    }

    // Configurar exemplos de payloads
    // c.EnableAnnotations(); // Comentado pois não está disponível na versão atual
});

// Configurar injeção de dependência - Repositórios
builder.Services.AddScoped<IUsuarioRepository, UsuarioRepository>();
builder.Services.AddScoped<IMotoRepository, MotoRepository>();
builder.Services.AddScoped<IOperacaoRepository, OperacaoRepository>();
builder.Services.AddScoped<IStatusMotoRepository, StatusMotoRepository>();

// Configurar injeção de dependência - Serviços
builder.Services.AddScoped<IUsuarioService, UsuarioService>();
builder.Services.AddScoped<IMotoService, MotoService>();
builder.Services.AddScoped<IOperacaoService, OperacaoService>();
builder.Services.AddScoped<IStatusMotoService, StatusMotoService>();

// Configurar HttpContextAccessor para HATEOAS
builder.Services.AddHttpContextAccessor();

// Configurar CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyMethod()
              .AllowAnyHeader();
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Sistema de Gestão de Motos API v1");
        c.RoutePrefix = string.Empty; // Para acessar o Swagger na raiz
        c.DocumentTitle = "Sistema de Gestão de Motos API";
        c.DisplayRequestDuration();
        c.EnableDeepLinking();
        c.EnableFilter();
        c.ShowExtensions();
        c.EnableValidator();
    });
}

app.UseHttpsRedirection();

app.UseCors("AllowAll");

app.UseAuthorization();

app.MapControllers();

// Criar/atualizar banco com migrations
using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
    context.Database.Migrate(); // <- use Migrate em vez de EnsureCreated
}

app.Run();
