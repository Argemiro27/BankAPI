using BankAccounts.Application.Services.Interfaces;
using BankAccounts.Application.Services;
using BankAccounts.Domains;
using Microsoft.EntityFrameworkCore;
using BankAccounts.InfraRead.Repositories.Interfaces;
using BankAccounts.InfraRead.Repositories;
using BankAccounts.InfraWrite.Repositories;
using BankAccounts.InfraWrite.Repositories.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<IAccountService, AccountService>();

builder.Services.AddScoped<IAccountQuery, AccountQuery>();
builder.Services.AddScoped<IUserQuery, UserQuery>();

builder.Services.AddScoped<IAccountCommand, AccountCommand>();
builder.Services.AddScoped<IAuthCommand, AuthCommand>();
builder.Services.AddScoped<IUserCommand, UserCommand>();


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
