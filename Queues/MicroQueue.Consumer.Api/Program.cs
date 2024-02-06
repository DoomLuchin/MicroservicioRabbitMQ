using MicroQueue.Consumer.Application.Interfaces;
using MicroQueue.Consumer.Application.Services;
using MicroQueue.Consumer.Domain.EventHandlers;
using MicroQueue.Domain.Core.Bus;
using MicroQueue.Domain.Core.Events;
using MicroQueue.Domain.Core.LogsAlliance;
using MicroQueue.Infra.Bus;
using MicroQueue.Infra.IoC;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.Configure<RabbitMQSettings>(builder.Configuration.GetSection("RabbitMQSettings"));
builder.Services.RegisterServices(builder.Configuration);

builder.Services.AddTransient<IService, Service>();
builder.Services.AddTransient<IHistorico, Historico>();

builder.Services.AddTransient<IEventHandler<DocumentCreatedEvent>, MicroQueue.Consumer.Domain.EventHandlers.EventHandler>();
builder.Services.AddTransient<IEventHandler<MailCreatedEvent>, MicroQueue.Consumer.Domain.EventHandlers.EventHandler>();

//Subscriptions
builder.Services.AddTransient<MicroQueue.Consumer.Domain.EventHandlers.EventHandler>();

builder.Services.AddCors(options =>
{
    options.AddPolicy("CorsPolicy", builder => builder.AllowAnyOrigin()
    .AllowAnyMethod()
    .AllowAnyHeader()
    );

});

var app = builder.Build();
var eventBus = app.Services.GetRequiredService<IEventBus>();
eventBus.Subscribe<DocumentCreatedEvent, MicroQueue.Consumer.Domain.EventHandlers.EventHandler>();
eventBus.Subscribe<MailCreatedEvent, MicroQueue.Consumer.Domain.EventHandlers.EventHandler>();

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
