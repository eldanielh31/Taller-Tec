using Microsoft.AspNetCore.Cors;
using MailKit;
using API.Models;
using API.Email;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
                    {
                        options.AddDefaultPolicy(
                            builder => builder.WithOrigins("http://localhost:4200")
                                        .AllowAnyHeader()
                                        .AllowAnyMethod());
                    });


var emailConfig = builder.Configuration
                        .GetSection("MailSettings")
                        .Get<MailSettings>();
// Add services to the container.
builder.Services.AddSingleton(emailConfig);
builder.Services.AddScoped<IEmailSender,EmailSender>();
builder.Services.AddControllers();
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

app.UseCors();

app.UseAuthorization();

app.MapControllers();

app.Run();