using API.Dto;
using API.Handler;
using System;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();


List<LibroDTO> DB = new List<LibroDTO>();
List<AutorDTO> BD = new List<AutorDTO>();

LibroHandler handlerLibro = new LibroHandler(DB, BD);
AutorHandler handlerAutor = new AutorHandler(BD);


//RUTAS PARA LIBRO
//TRAER TODOS LOS LIBROS
app.MapGet("/api/v1/libros", () => {
    return Results.Ok(handlerLibro.All());
});

//CREAR LIBRO
app.MapPost("/api/v1/libros/CrearLibro", (LibroDTO libro) => {
    handlerLibro.createBook(libro);
});

//TRAER LIBRO CON ID
app.MapGet("/api/v1/libros/{id:guid}/ObtenerLibroPorId", (Guid id) => {
    return Results.Ok(handlerLibro.getBook(id));
});

//ACTUALIZAR LIBRO CON ID
app.MapPut("/api/v1/libros/{id:guid}/ActualizarLibro", (LibroDTO libro, Guid id) => {
    handlerLibro.updateBook(libro, id);
});

//ELIMINAR LIBRO CON ID
app.MapDelete("/api/v1/libros/{id:guid}/EliminarLibro", (Guid id) => {
    handlerLibro.deleteBook(id);
});


//RUTAS PARA AUTOR
//TRAER TODOS LOS AUTORES
app.MapGet("/api/v1/autores", () => {
    return Results.Ok(handlerAutor.All());
});

//CREAR AUTOR
app.MapPost("/api/v1/autores/CrearAutor", (AutorDTO autor) => {
    handlerAutor.createAutor(autor);
});

//TRAER AUTOR CON ID
app.MapGet("/api/v1/autores/{id:guid}/ObtenerAutorPorId", (Guid id) => {
    return Results.Ok(handlerAutor.getAutor(id));
});

//ACTUALIZAR AUTOR CON ID
app.MapPut("/api/v1/autores/{id:guid}/ActualizarAutor", (AutorDTO autor, Guid id) => {
    handlerAutor.updateAutor(autor, id);
});

//ELIMINAR AUTOR CON ID
app.MapDelete("/api/v1/autores/{id:guid}/EliminarAutor", (Guid id) => {
    handlerAutor.deleteAutor(id);
});

app.Run();
