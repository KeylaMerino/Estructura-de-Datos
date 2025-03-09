using System;
using System.Collections.Generic;

public class Libro
{
    public string Titulo { get; set; }
    public string Autor { get; set; }
    public string Genero { get; set; }
    public int AnoPublicacion { get; set; }

    public Libro(string titulo, string autor, string genero, int anoPublicacion)
    {
        Titulo = titulo;
        Autor = autor;
        Genero = genero;
        AnoPublicacion = anoPublicacion;
    }
}

public class Biblioteca
{
    private Dictionary<int, Libro> catalogoLibros;

    public Biblioteca()
    {
        catalogoLibros = new Dictionary<int, Libro>();
    }

    // Método para registrar un libro
    public void RegistrarLibro(int id, string titulo, string autor, string genero, int anoPublicacion)
    {
        var libro = new Libro(titulo, autor, genero, anoPublicacion);
        catalogoLibros[id] = libro;
    }

    // Mostrar todos los libros del catálogo
    public void MostrarCatalogo()
    {
        if (catalogoLibros.Count == 0)
        {
            Console.WriteLine("No hay libros registrados en el catálogo.");
            return;
        }

        foreach (var libro in catalogoLibros)
        {
            Console.WriteLine($"ID: {libro.Key}, Titulo: {libro.Value.Titulo}, Autor: {libro.Value.Autor}, Genero: {libro.Value.Genero}, Año: {libro.Value.AnoPublicacion}");
        }
    }

    // Buscar libros por autor
    public void BuscarPorAutor(string autor)
    {
        var encontrados = new List<Libro>();
        foreach (var libro in catalogoLibros.Values)
        {
            if (libro.Autor.Equals(autor, StringComparison.OrdinalIgnoreCase))
            {
                encontrados.Add(libro);
            }
        }

        if (encontrados.Count > 0)
        {
            Console.WriteLine($"Libros encontrados por autor {autor}:");
            foreach (var libro in encontrados)
            {
                Console.WriteLine($"Titulo: {libro.Titulo}, Genero: {libro.Genero}, Año: {libro.AnoPublicacion}");
            }
        }
        else
        {
            Console.WriteLine("No se encontraron libros de ese autor.");
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        Biblioteca biblioteca = new Biblioteca();

        // Registramos algunos libros
        biblioteca.RegistrarLibro(1, "Cien años de soledad", "Gabriel García Márquez", "Realismo Mágico", 1967);
        biblioteca.RegistrarLibro(2, "Don Quijote de la Mancha", "Miguel de Cervantes", "Novela", 1605);
        biblioteca.RegistrarLibro(3, "1984", "George Orwell", "Distopía", 1949);
        biblioteca.RegistrarLibro(4, "La sombra del viento", "Carlos Ruiz Zafón", "Misterio", 2001);
        biblioteca.RegistrarLibro(5, "Orgullo y prejuicio", "Jane Austen", "Romántico", 1813);
        biblioteca.RegistrarLibro(6, "Fahrenheit 451", "Ray Bradbury", "Ciencia Ficción", 1953);
        biblioteca.RegistrarLibro(7, "El Gran Gatsby", "F. Scott Fitzgerald", "Ficción", 1925);

        // Menú interactivo
        while (true)
        {
            Console.WriteLine("\nOpciones de Reporte:");
            Console.WriteLine("1. Mostrar todo el catálogo");
            Console.WriteLine("2. Buscar libros por autor");
            Console.WriteLine("3. Salir");
            Console.Write("Selecciona una opción: ");
            string opcion = Console.ReadLine();

            switch (opcion)
            {
                case "1":
                    biblioteca.MostrarCatalogo();
                    break;
                case "2":
                    Console.Write("Introduce el nombre del autor: ");
                    string autor = Console.ReadLine();
                    biblioteca.BuscarPorAutor(autor);
                    break;
                case "3":
                    return; // Salir del programa
                default:
                    Console.WriteLine("Opción no válida. Intenta de nuevo.");
                    break;
            }
        }
    }
}
