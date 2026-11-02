using System.Security.Cryptography;
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using ODVEXA.API.Data;
using ODVEXA.API.Models;
var builder=WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<AppDbContext>(o=>o.UseSqlite(builder.Configuration.GetConnectionString("Default")??"Data Source=odvexa.db"));
var jwt=builder.Configuration.GetSection("Jwt");
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(o=>{o.TokenValidationParameters=new TokenValidationParameters{ValidateIssuer=true,ValidIssuer=jwt["Issuer"],ValidateAudience=true,ValidAudience=jwt["Audience"],ValidateIssuerSigningKey=true,IssuerSigningKey=new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwt["Key"]!)),ValidateLifetime=true,ClockSkew=TimeSpan.FromSeconds(30)};});
builder.Services.AddAuthorization();
builder.Services.AddCors(o=>o.AddPolicy("frontend",p=>p.WithOrigins("http://localhost:5173").AllowAnyHeader().AllowAnyMethod()));
var app=builder.Build();
app.UseCors("frontend");if(app.Environment.IsDevelopment()){app.UseSwagger();app.UseSwaggerUI();}
app.UseAuthentication();app.UseAuthorization();app.MapControllers();
using(var scope=app.Services.CreateScope()){var db=scope.ServiceProvider.GetRequiredService<AppDbContext>();db.Database.EnsureCreated();SeedData.Initialize(db);var cfg=scope.ServiceProvider.GetRequiredService<IConfiguration>();var email=cfg["AdminSeed:Email"]!.ToLowerInvariant();if(!db.Users.Any(x=>x.Email==email)){var salt=RandomNumberGenerator.GetBytes(16);var hash=Convert.ToBase64String(salt)+"."+Convert.ToBase64String(Rfc2898DeriveBytes.Pbkdf2(cfg["AdminSeed:Password"]!,salt,120000,HashAlgorithmName.SHA256,32));db.Users.Add(new AppUser{Name=cfg["AdminSeed:Name"]!,Email=email,PasswordHash=hash,Role="Admin"});db.SaveChanges();}}
app.Run();
