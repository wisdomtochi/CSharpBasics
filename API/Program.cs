using API.Data;
using API.Services;
using Microsoft.EntityFrameworkCore;
using System.Net.Http.Headers;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseInMemoryDatabase("myDatabase"));
builder.Services.AddScoped<LogicLayer>();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


HttpClient client = new HttpClient();
client.BaseAddress = new Uri("https://www.github.com");
client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

HttpResponseMessage message = client.GetAsync("wisdomtochi/repositories").Result;
if (message.IsSuccessStatusCode)
{
    Console.WriteLine("Response Message:- " + message.RequestMessage);
    Console.WriteLine("Response Header:- " + message.Content.Headers);
}
else
{
    Console.WriteLine($"{0}, {1}", (int)message.StatusCode, message.ReasonPhrase);
}

Console.ReadLine();

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
