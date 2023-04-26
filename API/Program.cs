using AutoMapper;
using Business.Interfaces;
using Business.Services;
using Data.Context;
using Data.Interfaces;
using Data.Profiles;
using Data.Repositorys;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers().AddNewtonsoftJson(s =>
{
    s.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
});

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddAutoMapper(typeof(AlunoProfile), typeof(TurmaProfile), typeof(AlunoTurmaProfile));

builder.Services.AddTransient<IMapper, Mapper>();
builder.Services.AddTransient<IUnitOfWork, UnitOfWork>();
builder.Services.AddTransient<ITurmaRepository, TurmaRepository>();
builder.Services.AddTransient<ITurmaService, TurmaService>();
builder.Services.AddTransient<IAlunoRepository, AlunoRepository>();
builder.Services.AddTransient<IAlunoService, AlunoService>();
builder.Services.AddTransient<IAlunoTurmaRepository, AlunoTurmaRepository>();
builder.Services.AddTransient<IAlunoTurmaService, AlunoTurmaService>();

builder.Services.AddDbContext<CadastroTurmaDbContext>(opt => opt.UseSqlServer(builder.Configuration.GetConnectionString("SQLServer")));

builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
