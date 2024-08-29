using UCR.ECCI.IS.EvaluacionTecnica.Application;
using UCR.ECCI.IS.EvaluacionTecnica.Infrastructure;
using UCR.ECCI.IS.EvaluacionTecnica.Presentation.Api.InfoCarreras;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddApplicationLayerServices();
builder.Services.AddInfrastructureLayerServices(builder.Configuration);

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(policy =>
    {
        policy.AllowAnyHeader()
            .AllowAnyMethod()
            .AllowAnyOrigin();
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors();

app.RegisterInfoCarreraEndpoints();

app.Run();

