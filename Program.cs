using Microsoft.EntityFrameworkCore;
using QLBanHangAPI.Models;
using QLBanHangAPI.Data;
System.AppContext.SetSwitch("Microsoft.Data.SqlClient.DisableStrictTokenValidation", true);
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll",
        policy => policy.AllowAnyOrigin()
                        .AllowAnyMethod()
                        .AllowAnyHeader());
});

// Add services to the container.

builder.Services.AddControllers()
    .AddNewtonsoftJson(options =>
        options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
    );

// Lấy chuỗi kết nối CHBANH từ file appsettings.json
var connectionString = builder.Configuration.GetConnectionString("CHBANH");

// Đăng ký CHBANHDbContext vào hệ thống để các Controller sau này gọi sử dụng

    builder.Services.AddDbContext<CHBANHDbContext>(options =>
        options.UseSqlServer(connectionString));

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();




// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors("AllowAll");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
