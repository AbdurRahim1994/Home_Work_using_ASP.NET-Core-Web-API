using DinkToPdf;
using DinkToPdf.Contracts;
using Home_Work;
using Home_Work.Helper;
using Home_Work.Models.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);
var ConnectionString = string.Empty;
var _env = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
var isDevelopment = _env == Environments.Development;
if (isDevelopment)
{
    ConnectionString = builder.Configuration.GetConnectionString("Development");
}

// Add services to the container.
builder.Services.AddSingleton(typeof(IConverter), new SynchronizedConverter(new PdfTools()));
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<HomeWorkDbContext>(option => option.UseSqlServer(ConnectionString)); //swagger setting, DB Connection
builder.Services.AddSwaggerGen(a =>
{
    a.SwaggerDoc("v1", new OpenApiInfo() { Title = "Home Work", Version = "v1" });
});
DependencyContainer.RegisterServices(builder.Services);
Connection.Home_Work = ConnectionString;

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
