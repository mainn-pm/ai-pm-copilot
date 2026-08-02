    using AI.PM.Application.Interfaces;
    using AI.PM.Application.Services;
    using AI.PM.Infrastructure.Configuration;
    using AI.PM.Infrastructure.DependencyInjection;
    
    var builder = WebApplication.CreateBuilder(args);
    builder.Services.AddControllers();

    // Add services to the container.
    // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
    builder.Services.AddOpenApi();
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();
    
    builder.Services.AddScoped<IChatService, ChatService>();
    builder.Services.AddInfrastructure(builder.Configuration);
    builder.Services.Configure<OllamaSettings>(builder.Configuration.GetSection(OllamaSettings.SectionName));

    var app = builder.Build();

    // Configure the HTTP request pipeline.
    if (app.Environment.IsDevelopment())
    {
        app.MapOpenApi();
    }

    app.UseHttpsRedirection();

    app.UseSwagger();
    app.UseSwaggerUI();
    app.MapControllers();
    app.Run();

