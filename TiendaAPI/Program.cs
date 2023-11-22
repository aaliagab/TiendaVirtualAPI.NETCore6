using TiendaAPI.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<CoreDbContext>(
    options => options.UseMySQL(builder.Configuration.GetConnectionString("DefaultConnection"))
);

var app = builder.Build();

//Crear la BD al ejecutar el proyecto
using (var scope = app.Services.CreateScope()) { 
    var dataContex = scope.ServiceProvider.GetRequiredService<CoreDbContext>();
    dataContex.Database.Migrate();
}

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
