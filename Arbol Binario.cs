using System;

class Nodo
{
    public string dato;
    public Nodo? izquierda { get; set; } = null;
    public Nodo? derecha { get; set; } = null;

    public Nodo(string dato)
    {
        this.dato = dato;
    }
}

class ArbolBinario
{
    private Nodo? raiz = null;

    public void Insertar(string dato)
    {
        raiz = InsertarRecursivo(raiz, dato);
    }

    private Nodo InsertarRecursivo(Nodo? nodo, string dato)
    {
        if (nodo == null) return new Nodo(dato);

        if (string.Compare(dato, nodo.dato, StringComparison.Ordinal) < 0)
            nodo.izquierda = InsertarRecursivo(nodo.izquierda, dato);
        else
            nodo.derecha = InsertarRecursivo(nodo.derecha, dato);

        return nodo;
    }

    public bool Buscar(string dato)
    {
        return BuscarRecursivo(raiz, dato);
    }

    private bool BuscarRecursivo(Nodo? nodo, string dato)
    {
        if (nodo == null) return false;
        if (nodo.dato == dato) return true;

        return string.Compare(dato, nodo.dato, StringComparison.Ordinal) < 0
            ? BuscarRecursivo(nodo.izquierda, dato)
            : BuscarRecursivo(nodo.derecha, dato);
    }

    public void MostrarInorden()
    {
        MostrarInordenRecursivo(raiz);
        Console.WriteLine();
    }

    private void MostrarInordenRecursivo(Nodo? nodo)
    {
        if (nodo == null) return;
        MostrarInordenRecursivo(nodo.izquierda);
        Console.Write(nodo.dato + " ");
        MostrarInordenRecursivo(nodo.derecha);
    }

    public void Eliminar(string dato)
    {
        raiz = EliminarRecursivo(raiz, dato);
    }

    private Nodo? EliminarRecursivo(Nodo? nodo, string dato)
    {
        if (nodo == null) return null;

        if (string.Compare(dato, nodo.dato, StringComparison.Ordinal) < 0)
            nodo.izquierda = EliminarRecursivo(nodo.izquierda, dato);
        else if (string.Compare(dato, nodo.dato, StringComparison.Ordinal) > 0)
            nodo.derecha = EliminarRecursivo(nodo.derecha, dato);
        else
        {
            if (nodo.izquierda == null) return nodo.derecha;
            if (nodo.derecha == null) return nodo.izquierda;

            Nodo sucesor = EncontrarMinimo(nodo.derecha);
            nodo.dato = sucesor.dato;
            nodo.derecha = EliminarRecursivo(nodo.derecha, sucesor.dato);
        }
        return nodo;
    }

    private Nodo EncontrarMinimo(Nodo nodo)
    {
        while (nodo.izquierda != null) nodo = nodo.izquierda;
        return nodo;
    }
}

class Program
{
    static void Main()
    {
        ArbolBinario arbol = new ArbolBinario();
        int opcion;
        do
        {
            Console.WriteLine("Menú:");
            Console.WriteLine("1. Insertar");
            Console.WriteLine("2. Buscar");
            Console.WriteLine("3. Mostrar Inorden");
            Console.WriteLine("4. Eliminar");
            Console.WriteLine("5. Salir");
            Console.Write("Seleccione una opción: ");

            if (!int.TryParse(Console.ReadLine(), out opcion))
            {
                Console.WriteLine("Ingrese un número válido.");
                continue;
            }

            switch (opcion)
            {
                case 1:
                    Console.Write("Ingrese un nombre: ");
                    string? nombre = Console.ReadLine();
                    if (!string.IsNullOrWhiteSpace(nombre))
                        arbol.Insertar(nombre);
                    else
                        Console.WriteLine("Debe ingresar un nombre válido.");
                    break;
                case 2:
                    Console.Write("Ingrese un nombre a buscar: ");
                    string? buscar = Console.ReadLine();
                    if (!string.IsNullOrWhiteSpace(buscar))
                        Console.WriteLine(arbol.Buscar(buscar) ? "Encontrado" : "No encontrado");
                    else
                        Console.WriteLine("Debe ingresar un nombre válido.");
                    break;
                case 3:
                    Console.WriteLine("Recorrido Inorden:");
                    arbol.MostrarInorden();
                    break;
                case 4:
                    Console.Write("Ingrese un nombre a eliminar: ");
                    string? eliminar = Console.ReadLine();
                    if (!string.IsNullOrWhiteSpace(eliminar))
                        arbol.Eliminar(eliminar);
                    else
                        Console.WriteLine("Debe ingresar un nombre válido.");
                    break;
                case 5:
                    Console.WriteLine("Saliendo del programa...");
                    break;
                default:
                    Console.WriteLine("Opción no válida, intente de nuevo.");
                    break;
            }

        } while (opcion != 5);
    }
}
