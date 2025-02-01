using System;
using System.Collections.Generic;
using System.Diagnostics;

class AsignacionAsientos
{
    private Queue<int> asientos;
    private const int capacidad = 30;
    private Stopwatch reloj;

    public AsignacionAsientos()
    {
        asientos = new Queue<int>();
        reloj = new Stopwatch();
        for (int i = 1; i <= capacidad; i++)
        {
            asientos.Enqueue(i);
        }
    }

    public void AsignarAsiento()
    {
        reloj.Restart();
        if (asientos.Count > 0)
        {
            int asientoAsignado = asientos.Dequeue();
            reloj.Stop();
            Console.WriteLine($"Asiento {asientoAsignado} asignado en {reloj.ElapsedTicks} ticks.");
        }
        else
        {
            reloj.Stop();
            Console.WriteLine("Todos los asientos están ocupados.");
        }
    }

    public void MostrarAsientosDisponibles()
    {
        if (asientos.Count > 0)
        {
            Console.WriteLine("Asientos disponibles:");
            foreach (var asiento in asientos)
            {
                Console.Write(asiento + " ");
            }
            Console.WriteLine();
        }
        else
        {
            Console.WriteLine("No hay asientos disponibles.");
        }
    }

    public void Reporte()
    {
        Console.WriteLine("\n--- Reporte de Asignación de Asientos ---");
        Console.WriteLine($"Total de asientos disponibles: {asientos.Count}");
        MostrarAsientosDisponibles();
    }
}

class Program
{
    static void Main()
    {
        AsignacionAsientos asignacion = new AsignacionAsientos();

        while (true)
        {
            Console.WriteLine("\nOpciones:");
            Console.WriteLine("1. Asignar un asiento");
            Console.WriteLine("2. Mostrar asientos disponibles");
            Console.WriteLine("3. Ver reporte");
            Console.WriteLine("4. Salir");
            Console.Write("Seleccione una opción: ");

            string opcion = Console.ReadLine();

            switch (opcion)
            {
                case "1":
                    asignacion.AsignarAsiento();
                    break;
                case "2":
                    asignacion.MostrarAsientosDisponibles();
                    break;
                case "3":
                    asignacion.Reporte();
                    break;
                case "4":
                    Console.WriteLine("Saliendo del programa...");
                    return;
                default:
                    Console.WriteLine("Opción no válida, intente de nuevo.");
                    break;
            }
        }
    }
}
