using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using prjFinalProjectApi.Models;

var builder = WebApplication.CreateBuilder(args);

// 1. CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", p =>
        p.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());
});

// 2. Controllers
builder.Services.AddControllers();

// 3. Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "NursingHome API", Version = "v1" });
});

// 4. EF Core + SQL Server
var conn = builder.Configuration.GetConnectionString("NursingHomeConnection");
builder.Services.AddDbContext<DbNursingHomeContext>(opt => opt.UseSqlServer(conn));

var app = builder.Build();

// 5. Middlewares
app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "NursingHome API v1");
    c.DocumentTitle = "NursingHome API Docs";
});

app.UseCors("AllowAll");
app.UseHttpsRedirection();
app.UseStaticFiles();

app.MapControllers();
app.Run();
