using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        // Definir los vectores como listas
        List<int> vector1 = new List<int> { 1, 2, 3 };
        List<int> vector2 = new List<int> { -1, 0, 2 };

        // Comprobar que los vectores tienen el mismo tamaño
        if (vector1.Count != vector2.Count)
        {
            Console.WriteLine("Los vectores deben tener el mismo tamaño.");
            return;
        }

        // Calcular el producto escalar
        int productoEscalar = 0;
        for (int i = 0; i < vector1.Count; i++)
        {
            productoEscalar += vector1[i] * vector2[i];
        }

        // Mostrar el resultado
        Console.WriteLine($"El producto escalar de los vectores es: {productoEscalar}");
    }
}
