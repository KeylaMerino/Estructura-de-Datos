using System;
using System.Collections.Generic;
using System.Linq;

namespace PrecioMayorYMenorConListas
{
    class Program
    {
        static void Main(string[] args)
        {
            // Lista de precios
            List<int> precios = new List<int> { 50, 75, 46, 22, 80, 65, 8 };

            // Encontrar el mayor y el menor precio utilizando LINQ
            int precioMayor = precios.Max();
            int precioMenor = precios.Min();

            // Mostrar los resultados
            Console.WriteLine($"El precio mayor es: {precioMayor}");
            Console.WriteLine($"El precio menor es: {precioMenor}");

            // Esperar para cerrar el programa
            Console.WriteLine("\nPresiona cualquier tecla para salir...");
            Console.ReadKey();
        }
    }
}


