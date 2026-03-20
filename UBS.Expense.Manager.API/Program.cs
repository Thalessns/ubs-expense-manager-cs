using Microsoft.EntityFrameworkCore;
using DotNetEnv;
using UBS.Expense.Manager.API;
using UBS.Expense.Manager.Application.Services.Departamento;
using UBS.Expense.Manager.Application.Services.Despesa;
using UBS.Expense.Manager.Application.Services.Funcionario;
using UBS.Expense.Manager.Infra.Repositories.Departamento;
using UBS.Expense.Manager.Infra.Repositories.Despesa;
using UBS.Expense.Manager.Infra.Repositories.Funcionario;
using UBS.Expense.Manager.Infra.Database;

var builder = WebApplication.CreateBuilder(args);

Env.TraversePath().Load();

builder.Configuration.AddEnvironmentVariables();

builder.Services.AddScoped<IDepartamentoService, DepartamentoService>();
builder.Services.AddScoped<IDespesaService, DespesaService>();
builder.Services.AddScoped<IFuncionarioService, FuncionarioService>();

builder.Services.AddScoped<IDepartamentoRepository, DepartamentoRepository>();
builder.Services.AddScoped<IDespesaRepository, DespesaRepository>();
builder.Services.AddScoped<IFuncionarioRepository, FuncionarioRepository>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<DatabaseContext>(options =>
{
    options.UseNpgsql(
        builder.Configuration.GetConnectionString("DefaultConnection"),
        npgsqlOptions =>
        {
            npgsqlOptions.EnableRetryOnFailure(
                maxRetryCount: 3,
                maxRetryDelay: TimeSpan.FromSeconds(5),
                errorCodesToAdd: null
            );
        }
    );
});

builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.Converters.Add(new System.Text.Json.Serialization.JsonStringEnumConverter());
});

builder.Services.AddExceptionHandler<ExceptionHandler>();
builder.Services.AddProblemDetails();

var app = builder.Build();

app.UseExceptionHandler();
app.MapControllers();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(s =>
    {
        s.SwaggerEndpoint("/swagger/v1/swagger.json", "UBS Expense Manager API");
        s.RoutePrefix = "swagger";
    });
}

app.UseHttpsRedirection();

app.Run();
