using System;

class Nodo
{
    public string Titulo { get; set; }
    public Nodo? Izquierda { get; set; }
    public Nodo? Derecha { get; set; }

    public Nodo(string titulo)
    {
        Titulo = titulo;
    }
}

class ArbolBinarioBusqueda
{
    private Nodo? raiz;

    public ArbolBinarioBusqueda()
    {
        raiz = null;
    }

    public void Insertar(string titulo)
    {
        raiz = InsertarRecursivo(raiz, titulo);
    }

    private Nodo InsertarRecursivo(Nodo? nodo, string titulo)
    {
        if (nodo == null)
        {
            return new Nodo(titulo);
        }

        if (string.Compare(titulo, nodo.Titulo) < 0)
        {
            nodo.Izquierda = InsertarRecursivo(nodo.Izquierda, titulo);
        }
        else if (string.Compare(titulo, nodo.Titulo) > 0)
        {
            nodo.Derecha = InsertarRecursivo(nodo.Derecha, titulo);
        }

        return nodo;
    }

    public bool Buscar(string titulo)
    {
        return BuscarRecursivo(raiz, titulo) != null;
    }

    private Nodo? BuscarRecursivo(Nodo? nodo, string titulo)
    {
        if (nodo == null)
            return null;

        if (titulo == nodo.Titulo)
            return nodo;

        if (string.Compare(titulo, nodo.Titulo) < 0)
            return BuscarRecursivo(nodo.Izquierda, titulo);
        else
            return BuscarRecursivo(nodo.Derecha, titulo);
    }
}

class Program
{
    static void Main(string[] args)
    {
        ArbolBinarioBusqueda catalogo = new ArbolBinarioBusqueda();

        // Insertar 10 títulos al catálogo
        catalogo.Insertar("National Geographic");
        catalogo.Insertar("Science Today");
        catalogo.Insertar("Tech World");
        catalogo.Insertar("Nature");
        catalogo.Insertar("Time");
        catalogo.Insertar("Forbes");
        catalogo.Insertar("People");
        catalogo.Insertar("Vogue");
        catalogo.Insertar("Scientific American");
        catalogo.Insertar("Popular Mechanics");

        int opcion;
        do
        {
            Console.WriteLine("\n--- Menú del Catálogo de Revistas ---");
            Console.WriteLine("1. Buscar un título");
            Console.WriteLine("2. Salir");
            Console.Write("Seleccione una opción: ");
            string? input = Console.ReadLine();

            if (!int.TryParse(input, out opcion))
            {
                Console.WriteLine("Por favor, ingrese un número válido.");
                continue;
            }

            switch (opcion)
            {
                case 1:
                    Console.Write("Ingrese el título a buscar: ");
                    string? titulo = Console.ReadLine();
                    if (!string.IsNullOrWhiteSpace(titulo))
                    {
                        bool encontrado = catalogo.Buscar(titulo);
                        if (encontrado)
                            Console.WriteLine("¡Título encontrado!");
                        else
                            Console.WriteLine("Título no encontrado.");
                    }
                    else
                    {
                        Console.WriteLine("Título no válido.");
                    }
                    break;

                case 2:
                    Console.WriteLine("Saliendo del programa...");
                    break;

                default:
                    Console.WriteLine("Opción no válida. Intente nuevamente.");
                    break;
            }

        } while (opcion != 2);
    }
}
