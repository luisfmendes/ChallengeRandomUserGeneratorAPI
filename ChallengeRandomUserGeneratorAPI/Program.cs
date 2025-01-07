using Microsoft.EntityFrameworkCore;
using ChallengeRandomUserGeneratorAPI.Application.Services;
using ChallengeRandomUserGeneratorAPI.Infrastructure.Database;
using ChallengeRandomUserGeneratorAPI.Infrastructure.Dependency;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<RUGContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("strConexao") ?? throw new InvalidOperationException("Connection string 'strConexao' não encontrada.")));

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddInfrastructureServices();
builder.Services.AddScoped<UserService>();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowSpecificOrigin",
        builder => builder
            .AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader());
});

var app = builder.Build();

// Add Swagger
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.UseCors("AllowSpecificOrigin");

app.Run();
