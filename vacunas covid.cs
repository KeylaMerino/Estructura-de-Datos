using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        HashSet<string> ciudadanos = new HashSet<string>();
        HashSet<string> vacunadosPfizer = new HashSet<string>();
        HashSet<string> vacunadosAstrazeneca = new HashSet<string>();
        Random rnd = new Random();

        // Generar 500 ciudadanos
        for (int i = 1; i <= 500; i++)
        {
            ciudadanos.Add($"Ciudadano {i}");
        }

        List<string> ciudadanosLista = new List<string>(ciudadanos);

        // Seleccionar X personas para recibir ambas vacunas (INTERSECCIÓN)
        int interseccion = rnd.Next(0, 20); // Número aleatorio de personas con ambas vacunas
        HashSet<string> vacunadosAmbas = new HashSet<string>();

        for (int i = 0; i < interseccion; i++)
        {
            int index = rnd.Next(ciudadanosLista.Count);
            vacunadosAmbas.Add(ciudadanosLista[index]);
            ciudadanosLista.RemoveAt(index);
        }

        // Seleccionar ciudadanos para SOLO Pfizer
        while (vacunadosPfizer.Count < (75 - interseccion))
        {
            int index = rnd.Next(ciudadanosLista.Count);
            vacunadosPfizer.Add(ciudadanosLista[index]);
            ciudadanosLista.RemoveAt(index);
        }

        // Seleccionar ciudadanos para SOLO AstraZeneca
        while (vacunadosAstrazeneca.Count < (75 - interseccion))
        {
            int index = rnd.Next(ciudadanosLista.Count);
            vacunadosAstrazeneca.Add(ciudadanosLista[index]);
            ciudadanosLista.RemoveAt(index);
        }

        // Sumar los que tienen ambas vacunas
        vacunadosPfizer.UnionWith(vacunadosAmbas);
        vacunadosAstrazeneca.UnionWith(vacunadosAmbas);

        // Ciudadanos no vacunados
        HashSet<string> noVacunados = new HashSet<string>(ciudadanos);
        noVacunados.ExceptWith(vacunadosPfizer);
        noVacunados.ExceptWith(vacunadosAstrazeneca);

        // Mostrar resultados
        Console.WriteLine("Ciudadanos NO vacunados: " + noVacunados.Count);
        Console.WriteLine("Ciudadanos vacunados con SOLO Pfizer: " + (75 - interseccion));
        Console.WriteLine("Ciudadanos vacunados con SOLO AstraZeneca: " + (75 - interseccion));
        Console.WriteLine("Ciudadanos vacunados con AMBAS vacunas: " + interseccion);

        // Listados 
        Console.WriteLine("\n No vacunados:");
        foreach (var ciudadano in noVacunados) { Console.WriteLine(ciudadano); }

        Console.WriteLine("\n Solo vacunados con Pfizer:");
        foreach (var ciudadano in vacunadosPfizer) { Console.WriteLine(ciudadano); }

        Console.WriteLine("\n Solo vacunados con AstraZeneca:");
        foreach (var ciudadano in vacunadosAstrazeneca) { Console.WriteLine(ciudadano); }

        Console.WriteLine("\n Vacunados con ambas vacunas:");
        foreach (var ciudadano in vacunadosAmbas) { Console.WriteLine(ciudadano); }
    }
}
