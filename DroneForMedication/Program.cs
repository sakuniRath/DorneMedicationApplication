using DorneForMedication.BusinessLayer.Iservices;
using DorneForMedication.BusinessLayer.Services;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddScoped<IDorneService, DorneService>();
builder.Services.AddScoped<IMedicationService, MedicationService>();
builder.Services.AddSingleton<TimelyTrigger>(provider => new TimelyTrigger(5000));
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();
var tigger = app.Services.GetService<TimelyTrigger>();
tigger.start();


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
