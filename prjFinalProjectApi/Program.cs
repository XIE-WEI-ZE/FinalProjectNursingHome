using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using prjFinalProjectApi.Models;
using prjFinalProjectApi.Helpers;
using System.Security.Claims;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// CORS
builder.Services.AddCors(o => o.AddPolicy("AllowAll", p =>
    p.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod()));

builder.Services.AddControllers();

// 3. Swagger
builder.Services.AddScoped<EmailSender>();
builder.Services.AddSingleton<OneTimeTokenHelper>();

// Swagger + JWT
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "NursingHome API", Version = "v1" });
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        Scheme = "bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Description = "輸入 JWT Token，格式: Bearer {your token}"
    });
    c.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        { new OpenApiSecurityScheme
            { Reference = new OpenApiReference { Type = ReferenceType.SecurityScheme, Id = "Bearer" } },
          Array.Empty<string>() }
    });
});

// EF Core
var conn = builder.Configuration.GetConnectionString("NursingHomeConnection");
builder.Services.AddDbContext<DbNursingHomeContext>(opt => opt.UseSqlServer(conn));

//  綁定 Jwt 強型別設定 + 啟動期檢查
builder.Services.Configure<JwtOptions>(builder.Configuration.GetSection("Jwt"));
var jwt = builder.Configuration.GetSection("Jwt").Get<JwtOptions>()
          ?? throw new InvalidOperationException("Jwt 設定缺失");
if (string.IsNullOrWhiteSpace(jwt.Key) ||
    string.IsNullOrWhiteSpace(jwt.Issuer) ||
    string.IsNullOrWhiteSpace(jwt.Audience))
    throw new InvalidOperationException("Jwt:Key/Issuer/Audience 不可為空");

// JWT 驗證
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = jwt.Issuer,
            ValidAudience = jwt.Audience,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwt.Key)),
            ClockSkew = TimeSpan.Zero,
            NameClaimType = ClaimTypes.Name
        };
    });

builder.Services.AddAuthorization();



var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.UseCors("AllowAll");
app.UseHttpsRedirection();
app.UseStaticFiles();      // wwwroot
app.UseAuthentication();   // 先驗證
app.UseAuthorization();    // 再授權
app.MapControllers();
app.Run();
