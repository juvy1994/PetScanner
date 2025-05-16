using Microsoft.EntityFrameworkCore;

using PS.Infrastructure.Data;
using PS.Infrastructure.Interfaces;
using PS.Infrastructure.Interfaces.Repository;
using PS.Infrastructure.Repositories.SqlServer;
using PS.Infrastructure.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IImageAnalysisService, ImageAnalysisService>();
builder.Services.AddScoped<IChatService, ChatService>();
builder.Services.AddSingleton<IOpenAiVisionService, OpenAiVisionService>();
builder.Services.AddDbContext<PetScanDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<IMetricasRepository, MetricasRepository>();


var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();


app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
