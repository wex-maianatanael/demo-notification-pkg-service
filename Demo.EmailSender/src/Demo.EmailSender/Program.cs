using Demo.EmailSender;
using WEX.Edge.Core.Clients;
using WEX.Edge.Core.Interfaces;
using WEX.Edge.Notification.Clients;
using WEX.Edge.Notification.Clients.Interfaces;
using WEX.Edge.Notification.DTOs.Domain.Settings;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSingleton(builder.Configuration.GetSection("NotificationAPI").Get<NotificationAPISettings>());
builder.Services.AddTransient<INotificationClient, NotificationClient>();

builder.Services.AddTransient<IAuthServiceClient>(provider => {

    var authURL = builder.Configuration.GetSection("Auth:Url").Value;
    return new AuthServiceClient(authURL);

});

builder.Services.AddTransient<IAuthervice, AuthService>();
builder.Services.AddTransient<IEmailService, EmailService>();

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
