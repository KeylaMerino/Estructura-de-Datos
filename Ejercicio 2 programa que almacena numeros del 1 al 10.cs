using System;
using System.Collections.Generic;
using System.Linq;

namespace NumerosInversos
{
    // Clase que gestiona los números y sus operaciones
    class Numeros
    {
        // Propiedad para almacenar la lista de números
        public List<int> ListaNumeros { get; private set; }

        // Constructor que inicializa la lista de números del 1 al 10
        public Numeros()
        {
            ListaNumeros = Enumerable.Range(1, 10).ToList(); // Genera los números del 1 al 10
        }

        // Método para obtener los números en orden inverso como un string
        public string ObtenerNumerosInversos()
        {
            var numerosInversos = ListaNumeros.AsEnumerable().Reverse();
            return string.Join(", ", numerosInversos);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Crear una instancia de la clase Numeros
            Numeros numeros = new Numeros();

            // Mostrar los números en orden inverso separados por comas
            Console.WriteLine("Números del 1 al 10 en orden inverso:");
            Console.WriteLine(numeros.ObtenerNumerosInversos());

            // Esperar para cerrar el programa
            Console.WriteLine("\nPresiona cualquier tecla para salir...");
            Console.ReadKey();
        }
    }
}
