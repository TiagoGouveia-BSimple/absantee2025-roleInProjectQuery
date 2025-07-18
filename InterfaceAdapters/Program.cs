using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Infrastructure;
using Application.IService;
using Application.Service;
using Domain.IRepository;
using Infrastructure.Repository;
using Domain.IFactory;
using Domain.Factory;
using Infrastructure.Resolver;
using Domain.Model;
using Application.DTO;
using MassTransit;
using InterfaceAdapters.Consumer;
using Domain.Message;
using Application.IPublisher;
using InterfaceAdapters.Publisher;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddDbContext<RoleInProjectContext>(opt =>
    opt.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"))
    );

// Services
builder.Services.AddScoped<IRoleInProjectService, RoleInProjectService>();
builder.Services.AddScoped<IMessagePublisher, MassTransitPublisher>();

// Repositories
builder.Services.AddScoped<IRoleInProjectRepository, RoleInProjectRepository>();

// Factories
builder.Services.AddScoped<IRoleInProjectFactory, RoleInProjectFactory>();

// Mappers
builder.Services.AddTransient<RoleInProjectDataModelConverter>();
builder.Services.AddAutoMapper(cfg =>
{
    // DataModels
    cfg.AddProfile<DataModelMappingProfile>();

    // DTO
    cfg.CreateMap<RoleInProject, RoleInProjectDTO>();
});

// MassTransit
builder.Services.AddMassTransit(x =>
{
    x.AddConsumer<RoleInProjectCreatedConsumer>();
    x.AddConsumer<RoleInProjectUpdatedConsumer>();

    x.UsingRabbitMq((context, cfg) =>
    {
        cfg.Host("localhost", "/", h =>
        {
            h.Username("guest");
            h.Password("guest");
        });

        var instance = InstanceInfo.InstanceId;
        cfg.ReceiveEndpoint($"roleInProjectQuery-{instance}", conf =>
        {
            conf.ConfigureConsumer<RoleInProjectCreatedConsumer>(context);
            conf.ConfigureConsumer<RoleInProjectUpdatedConsumer>(context);
        });
    });
});

builder.Services.AddOpenApi();

builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(builder => builder
                .AllowAnyHeader()
                .AllowAnyMethod()
                .SetIsOriginAllowed((host) => true)
                .AllowCredentials());

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<RoleInProjectContext>();
    dbContext.Database.Migrate();
}

app.Run();

public partial class Program { }

