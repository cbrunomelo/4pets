using Api.Conf;
using Api.FIlters;
using Application.Dtos.Contracts;
using Application.Logger;
using Infra.Logger;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services
    .AddControllers( op => 
        op.Filters.Add<GlobalExceptionFilter>()
        )
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.Converters.Add(new IDtoJsonConverter<IDto>());
    }

    );
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddApplicationServices(builder.Configuration);
builder.Services.AddSingleton<ILoggerProvider>(provider =>
{
    var config = new CustomLoggerProviderConfiguration(/* Passe as configurações necessárias */);
    var loggerRepo = provider.GetRequiredService<ILoggerRepo>();  // Obtendo ILoggerRepo do DI container
    return new CustomLoggerProvider(loggerRepo, config);  // Passando o ILoggerRepo para o CustomLoggerProvider
});



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment() || app.Environment.IsEnvironment("DevelopmentDocker"))
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
