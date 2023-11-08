using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using TestTecnicoAdsum.Model;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSqlServer<ContactContext>(builder.Configuration.GetConnectionString("DefaultConnection"));

// Add services to the container.

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

app.UseCors(x => x
            .AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader());


app.MapPost("/api/contacto", async ([FromServices] ContactContext dbContext, [FromBody] ContactModel contacto) =>
{
    try
    {
        // Intenta agregar el contacto a la base de datos
        await dbContext.AddAsync(contacto);
        await dbContext.SaveChangesAsync();

        // Si todo va bien, devuelve una respuesta exitosa
        return Results.Ok("Si se envio pa, todo bien");
    }
    catch (DbUpdateException ex)
    {
        // En caso de un error al guardar los cambios en la base de datos, registra la excepción interna
        // Esto ayudará a identificar la causa raíz del error.
        Console.WriteLine($"Error al guardar los cambios en la base de datos: {ex.InnerException?.Message}");

        // Luego, crea una respuesta incorrecta (código de estado HTTP 400) con un mensaje de error
        return Results.BadRequest("Error al guardar los cambios en la base de datos. Consulta los registros para más detalles.");
    }
    catch (Exception ex)
    {
        // Otras excepciones generales
        Console.WriteLine($"Error inesperado: {ex.Message}");
        return Results.BadRequest("Error inesperado al procesar la solicitud.");
    }
});


app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
