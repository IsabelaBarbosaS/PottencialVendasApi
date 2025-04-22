
using FluentValidation;
using FluentValidation.AspNetCore;
using Pottencial.VendasApi.Application.Services;
using Pottencial.VendasApi.Repositories;
using Pottencial.VendasApi.Validators;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSingleton<IVendaRepository, VendaMemoryRepository>();
builder.Services.AddTransient<VendaService>();

builder.Services.AddFluentValidationAutoValidation();
builder.Services.AddValidatorsFromAssemblyContaining<AtualizarStatusDTOValidator>();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();
app.UseAuthorization();

app.MapControllers();

app.Run();
