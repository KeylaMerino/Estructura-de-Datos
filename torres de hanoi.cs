using System;
using System.Collections.Generic;

class TorresDeHanoi
{
    static void Main(string[] args)
    {
        Console.WriteLine("Ingrese la cantidad de discos:");
        int numDiscos = int.Parse(Console.ReadLine());

        // Inicializamos las tres pilas (torres)
        Stack<int> torreOrigen = new Stack<int>();
        Stack<int> torreDestino = new Stack<int>();
        Stack<int> torreAuxiliar = new Stack<int>();

        // Llenamos la torre origen con los discos (mayor abajo, menor arriba)
        for (int i = numDiscos; i >= 1; i--)
        {
            torreOrigen.Push(i);
        }

        // Llamamos a la función para resolver las torres de Hanoi
        ResolverTorres(numDiscos, torreOrigen, torreDestino, torreAuxiliar, 'A', 'C', 'B');
    }

    /// <summary>
    /// Resuelve las Torres de Hanoi utilizando pilas.
    /// </summary>
    /// <param name="n">Cantidad de discos</param>
    /// <param name="origen">Torre de origen</param>
    /// <param name="destino">Torre de destino</param>
    /// <param name="auxiliar">Torre auxiliar</param>
    /// <param name="nombreOrigen">Nombre de la torre de origen</param>
    /// <param name="nombreDestino">Nombre de la torre de destino</param>
    /// <param name="nombreAuxiliar">Nombre de la torre auxiliar</param>
    static void ResolverTorres(int n, Stack<int> origen, Stack<int> destino, Stack<int> auxiliar, char nombreOrigen, char nombreDestino, char nombreAuxiliar)
    {
        if (n == 1)
        {
            // Mover el disco de la torre origen a la torre destino
            int disco = origen.Pop();
            destino.Push(disco);
            Console.WriteLine($"Mover disco {disco} de {nombreOrigen} a {nombreDestino}");
        }
        else
        {
            // Mover los n-1 discos de la torre origen a la torre auxiliar
            ResolverTorres(n - 1, origen, auxiliar, destino, nombreOrigen, nombreAuxiliar, nombreDestino);

            // Mover el disco restante de la torre origen a la torre destino
            int disco = origen.Pop();
            destino.Push(disco);
            Console.WriteLine($"Mover disco {disco} de {nombreOrigen} a {nombreDestino}");

            // Mover los n-1 discos de la torre auxiliar a la torre destino
            ResolverTorres(n - 1, auxiliar, destino, origen, nombreAuxiliar, nombreDestino, nombreOrigen);
        }
    }
}

