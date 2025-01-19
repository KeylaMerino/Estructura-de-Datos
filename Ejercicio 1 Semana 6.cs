using System;

public class Nodo
{
    public int Valor { get; set; } // Propiedad para almacenar el valor del nodo
    public Nodo Siguiente { get; set; } 

    // Constructor que inicializa el nodo con un valor
    public Nodo(int valor)
    {
        Valor = valor;
        Siguiente = null; 
    }
}

public class ListaEnlazada
{
    private Nodo cabeza; // Referencia al primer nodo de la lista

    // Constructor que inicializa la lista vacía
    public ListaEnlazada()
    {
        cabeza = null;
    }

    // Método para agregar un nuevo valor al final de la lista
    public void Agregar(int valor)
    {
        Nodo nuevoNodo = new Nodo(valor); // Crea un nuevo nodo
        if (cabeza == null)
        {
            
            cabeza = nuevoNodo;
        }
        else
        {
            
            Nodo actual = cabeza;
            while (actual.Siguiente != null)
            {
                actual = actual.Siguiente;
            }
            // Asigna el nuevo nodo al final de la lista
            actual.Siguiente = nuevoNodo;
        }
    }

    // Método para invertir la lista enlazada
    public void Invertir()
    {
        Nodo previo = null; 
        Nodo actual = cabeza; 
        Nodo siguiente = null; 

        // Recorre la lista para invertir los enlaces
        while (actual != null)
        {
            siguiente = actual.Siguiente; 
            actual.Siguiente = previo; 
            previo = actual; 
            actual = siguiente; 
        }

        // Actualiza la cabeza de la lista para que apunte al último nodo original
        cabeza = previo;
    }

    // Método para imprimir los elementos de la lista
    public void Imprimir()
    {
        Nodo actual = cabeza;
        while (actual != null)
        {
            Console.Write(actual.Valor + " -> "); // Imprime el valor del nodo actual
            actual = actual.Siguiente; // Avanza al siguiente nodo
        }
        Console.WriteLine("null"); // Indica el final de la lista
    }
}

class Program
{
    static void Main(string[] args)
    {
        ListaEnlazada lista = new ListaEnlazada();

        // Agregar elementos a la lista enlazada
        lista.Agregar(1);
        lista.Agregar(2);
        lista.Agregar(3);
        lista.Agregar(4);
        lista.Agregar(5);

        // Mostrar la lista original
        Console.WriteLine("Lista original:");
        lista.Imprimir();

        // Invertir la lista enlazada
        lista.Invertir();

        // Mostrar la lista después de invertirla
        Console.WriteLine("Lista invertida:");
        lista.Imprimir();
    }
}
