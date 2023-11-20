using API.Data;
using API.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseInMemoryDatabase("myDatabase"));
builder.Services.AddScoped<LogicLayer>();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var url = "https://localhost:7076/api/";
var client = new HttpClient
{
    BaseAddress = new Uri(url)
};

var response = await client.GetAsync("people");


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