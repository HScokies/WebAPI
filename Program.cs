using WebAPI;
using Microsoft.EntityFrameworkCore;
using WebAPI.Services;
using WebAPI.Services.Interfaces;


var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var Host = Environment.GetEnvironmentVariable("DB_HOST");
var Catalog = Environment.GetEnvironmentVariable("DB_NAME");
var UID = Environment.GetEnvironmentVariable("DB_USER");
var Password = Environment.GetEnvironmentVariable("DB_SA_PASSWORD");
builder.Services.AddDbContext<AppDbContext>(
    options => options.UseSqlServer(
    $"Data Source={Host};" +
    $"Initial Catalog={Catalog};" +
    $"Password={Password};" +
    $"User ID={UID};" +
    $"TrustServerCertificate=True"
    
));
builder.Services.AddScoped<ICMDs, CMDs>();
var CorsPolicy = "corsPolicy";
builder.Services.AddCors(
    p => p.AddPolicy(name: CorsPolicy,
    build => {
        build.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
        }
    )
);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors(CorsPolicy);

app.UseAuthorization();

app.MapControllers();

app.Run();
