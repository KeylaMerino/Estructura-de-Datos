using System;

public class Nodo
{
    public int Valor { get; set; }
    public Nodo Siguiente { get; set; }

    public Nodo(int valor)
    {
        Valor = valor;
        Siguiente = null;
    }
}

public class ListaEnlazada
{
    private Nodo cabeza; // Referencia al primer nodo de la lista
    private int contador; // Contador de elementos en la lista

    public ListaEnlazada()
    {
        cabeza = null;
        contador = 0;
    }

    // Método para agregar al final (números primos)
    public void AgregarAlFinal(int valor)
    {
        Nodo nuevoNodo = new Nodo(valor);
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
            actual.Siguiente = nuevoNodo;
        }
        contador++;
    }

    // Método para agregar al inicio (números Armstrong)
    public void AgregarAlInicio(int valor)
    {
        Nodo nuevoNodo = new Nodo(valor);
        nuevoNodo.Siguiente = cabeza;
        cabeza = nuevoNodo;
        contador++;
    }

    // Método para imprimir la lista
    public void Imprimir()
    {
        Nodo actual = cabeza;
        while (actual != null)
        {
            Console.Write(actual.Valor + " -> ");
            actual = actual.Siguiente;
        }
        Console.WriteLine("null");
    }

    // Obtener el número de elementos de la lista
    public int ObtenerNumeroDeElementos()
    {
        return contador;
    }
}

class Program
{
    // Método para verificar si un número es primo
    static bool EsPrimo(int numero)
    {
        if (numero < 2) return false;
        for (int i = 2; i <= Math.Sqrt(numero); i++)
        {
            if (numero % i == 0) return false;
        }
        return true;
    }

    // Método para verificar si un número es Armstrong
    static bool EsArmstrong(int numero)
    {
        int suma = 0, temp = numero, digitos = 0;

        while (temp > 0)
        {
            digitos++;
            temp /= 10;
        }

        temp = numero;
        while (temp > 0)
        {
            int digito = temp % 10;
            suma += (int)Math.Pow(digito, digitos);
            temp /= 10;
        }

        return suma == numero;
    }

    static void Main(string[] args)
    {
        ListaEnlazada listaPrimos = new ListaEnlazada();
        ListaEnlazada listaArmstrong = new ListaEnlazada();
        Random random = new Random();

        // Generar números aleatorios entre 1 y 999
        for (int i = 0; i < 50; i++)
        {
            int numero = random.Next(1, 1000);

            if (EsPrimo(numero))
            {
                listaPrimos.AgregarAlFinal(numero);
            }
            if (EsArmstrong(numero))
            {
                listaArmstrong.AgregarAlInicio(numero);
            }
        }

        // Mostrar los resultados
        Console.WriteLine("Lista de números primos:");
        listaPrimos.Imprimir();
        Console.WriteLine("Cantidad de números primos: " + listaPrimos.ObtenerNumeroDeElementos());

        Console.WriteLine("\nLista de números Armstrong:");
        listaArmstrong.Imprimir();
        Console.WriteLine("Cantidad de números Armstrong: " + listaArmstrong.ObtenerNumeroDeElementos());

        // Comparar el número de elementos en cada lista
        if (listaPrimos.ObtenerNumeroDeElementos() > listaArmstrong.ObtenerNumeroDeElementos())
        {
            Console.WriteLine("\nLa lista de números primos tiene más elementos.");
        }
        else if (listaPrimos.ObtenerNumeroDeElementos() < listaArmstrong.ObtenerNumeroDeElementos())
        {
            Console.WriteLine("\nLa lista de números Armstrong tiene más elementos.");
        }
        else
        {
            Console.WriteLine("\nAmbas listas tienen la misma cantidad de elementos.");
        }
    }
}
