using MediatR;
using MicroQueue.Domain.Core.Historico;
using MicroQueue.Infra.Bus;
using MicroQueue.Infra.IoC;
using MicroQueue.Publisher.Application.Interfaces;
using MicroQueue.Publisher.Application.Services;
using MicroQueue.Publisher.Domain.CommandHandlers;
using MicroQueue.Publisher.Domain.Commands;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.Configure<RabbitMQSettings>(builder.Configuration.GetSection("RabbitMQSettings"));
builder.Services.RegisterServices(builder.Configuration);

builder.Services.AddTransient<IService, Service>();
builder.Services.AddTransient<IServicioHistorico, ServicioHistorico>();

builder.Services.AddTransient<IRequestHandler<CreateDocumentCommand, bool>, CommandHandler>();
builder.Services.AddTransient<IRequestHandler<CreateMailCommand, bool>, CommandHandler>();

builder.Services.AddCors(options =>
{
    options.AddPolicy("CorsPolicy", builder => builder.AllowAnyOrigin()
    .AllowAnyMethod()
    .AllowAnyHeader()
    );
});

builder.Services.AddHttpClient("Historico", config =>
{
    HistoricoSettings? settings = builder.Configuration.Get<HistoricoSettings>();

    var address = $"{settings?.URL}";
    config.BaseAddress = new Uri(address);
    config.DefaultRequestHeaders.Add("Api-Key", settings?.ApiKey);
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseCors("CorsPolicy");

app.MapControllers();

app.Run();
