using BankAccounts.Application.Services.Interfaces;
using BankAccounts.Application.Services;
using BankAccounts.Domains;
using Microsoft.EntityFrameworkCore;
using BankAccounts.InfraRead.Repositories.Interfaces;
using BankAccounts.InfraRead.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IAuthRepository, AuthRepository>();

builder.Services.AddEntityFrameworkSqlServer()
    .AddDbContext<BankAccountsDbContext>(
        options => options.UseSqlServer(builder.Configuration.GetConnectionString("stringConexao"))
    );


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
