using System;
using System.Collections.Generic;
using System.Diagnostics;

class Libro
{
    public string Titulo { get; set; }
    public string Autor { get; set; }
    public int Año { get; set; }
    public string Categoria { get; set; }

    public Libro(string titulo, string autor, int año, string categoria)
    {
        Titulo = titulo;
        Autor = autor;
        Año = año;
        Categoria = categoria;
    }

    public void MostrarInfo()
    {
        Console.WriteLine($"Título: {Titulo}, Autor: {Autor}, Año: {Año}, Categoría: {Categoria}");
    }
}

class Biblioteca
{
    private Dictionary<string, Libro> libros = new Dictionary<string, Libro>();
    private Dictionary<string, List<Libro>> categorias = new Dictionary<string, List<Libro>>();

    public void AgregarLibro(string titulo, string autor, int año, string categoria)
    {
        // Validaciones para evitar valores nulos o vacíos
        if (string.IsNullOrWhiteSpace(titulo) || string.IsNullOrWhiteSpace(autor) || string.IsNullOrWhiteSpace(categoria))
        {
            Console.WriteLine("Error: Ningún campo puede estar vacío o nulo.");
            return;
        }

        var libro = new Libro(titulo, autor, año, categoria);
        libros[titulo] = libro;

        if (!categorias.ContainsKey(categoria))
        {
            categorias[categoria] = new List<Libro>();
        }
        categorias[categoria].Add(libro);
    }

    public void MostrarLibros()
    {
        if (libros.Count == 0)
        {
            Console.WriteLine("No hay libros en la biblioteca.");
            return;
        }

        Console.WriteLine("Lista de libros en la biblioteca:");
        foreach (var libro in libros.Values)
        {
            libro.MostrarInfo();
        }
    }

    public void ConsultarLibro(string titulo)
    {
        if (string.IsNullOrWhiteSpace(titulo))
        {
            Console.WriteLine("Error: Debe ingresar un título válido.");
            return;
        }

        if (libros.ContainsKey(titulo))
        {
            libros[titulo].MostrarInfo();
        }
        else
        {
            Console.WriteLine("Libro no encontrado.");
        }
    }

    public void LibrosPorCategoria(string categoria)
    {
        if (string.IsNullOrWhiteSpace(categoria))
        {
            Console.WriteLine("Error: Debe ingresar una categoría válida.");
            return;
        }

        if (categorias.ContainsKey(categoria))
        {
            Console.WriteLine($"Libros en la categoría '{categoria}':");
            foreach (var libro in categorias[categoria])
            {
                libro.MostrarInfo();
            }
        }
        else
        {
            Console.WriteLine("Categoría no encontrada.");
        }
    }
}

class Program
{
    static void Main()
    {
        Biblioteca biblioteca = new Biblioteca();

        // Libros predefinidos
        biblioteca.AgregarLibro("Cien Años de Soledad", "Gabriel García Márquez", 1967, "Ficción");
        biblioteca.AgregarLibro("El Quijote", "Miguel de Cervantes", 1605, "Clásicos");
        biblioteca.AgregarLibro("1984", "George Orwell", 1949, "Ciencia Ficción");

        while (true)
        {
            Console.WriteLine("\n--- MENÚ ---");
            Console.WriteLine("1. Agregar libro");
            Console.WriteLine("2. Mostrar todos los libros");
            Console.WriteLine("3. Consultar un libro");
            Console.WriteLine("4. Mostrar libros por categoría");
            Console.WriteLine("5. Salir");
            Console.Write("Seleccione una opción: ");

            string opcion = Console.ReadLine() ?? "";
            Console.WriteLine();

            switch (opcion)
            {
                case "1":
                    Console.Write("Ingrese el título del libro: ");
                    string titulo = Console.ReadLine() ?? "";

                    Console.Write("Ingrese el autor: ");
                    string autor = Console.ReadLine() ?? "";

                    Console.Write("Ingrese el año de publicación: ");
                    int año;
                    while (!int.TryParse(Console.ReadLine(), out año) || año <= 0)
                    {
                        Console.Write("Error: Ingrese un año válido: ");
                    }

                    Console.Write("Ingrese la categoría: ");
                    string categoria = Console.ReadLine() ?? "";

                    biblioteca.AgregarLibro(titulo, autor, año, categoria);
                    break;

                case "2":
                    biblioteca.MostrarLibros();
                    break;

                case "3":
                    Console.Write("Ingrese el título del libro a consultar: ");
                    string tituloBuscar = Console.ReadLine() ?? "";
                    biblioteca.ConsultarLibro(tituloBuscar);
                    break;

                case "4":
                    Console.Write("Ingrese la categoría a buscar: ");
                    string categoriaBuscar = Console.ReadLine() ?? "";
                    biblioteca.LibrosPorCategoria(categoriaBuscar);
                    break;

                case "5":
                    Console.WriteLine("Saliendo del programa...");
                    return;

                default:
                    Console.WriteLine("Opción no válida. Intente nuevamente.");
                    break;
            }
        }
    }
}
