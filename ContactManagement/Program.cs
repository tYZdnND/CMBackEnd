//global using ContactManagement.Models;
//global using ContactManagement.Data;
using ContactManagement.Data;
using ContactManagement.Services.ContactService;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IContactService, ContactService>();
builder.Services.AddDbContext<DataContext>();

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

//temporary cors bypass
app.UseCors(x => x
.AllowAnyOrigin()
.AllowAnyMethod()
.AllowAnyHeader());

app.Run();
