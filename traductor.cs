using System;
using System.Collections.Generic;

class Traductor
{
    static Dictionary<string, string> diccionarioEspañolAIngles = new Dictionary<string, string>()
    {
        {"tiempo", "time"}, {"persona", "person"}, {"grande", "big"}, {"camino", "way"},
        {"casa", "house"}, {"cosa", "thing"}, {"hombre", "man"}, {"mundo", "world"},
        {"vida", "life"}, {"mano", "hand"}, {"parte", "part"}, {"ojo", "eye"},
        {"mujer", "woman"}, {"lugar", "place"}, {"trabajo", "work"}, {"semana", "week"},
        {"caso", "case"}, {"punto", "point"}, {"gobierno", "government"}, {"empresa", "company"}
    };

    static void Main()
    {
        while (true)
        {
            Console.WriteLine("\nMENU");
            Console.WriteLine("=======================================================");
            Console.WriteLine("1. Traducir una frase");
            Console.WriteLine("2. Ingresar más palabras al diccionario");
            Console.WriteLine("0. Salir");
            Console.Write("Seleccione una opción: ");

            int opcion;
            if (!int.TryParse(Console.ReadLine(), out opcion))
            {
                Console.WriteLine("Entrada inválida. Intente nuevamente.");
                continue;
            }

            if (opcion == 0) break;

            switch (opcion)
            {
                case 1:
                    Console.Write("Ingrese la frase: ");
                    string? frase = Console.ReadLine();
                    if (string.IsNullOrWhiteSpace(frase))
                    {
                        Console.WriteLine("No ingresaste ninguna frase.");
                        continue;
                    }
                    Console.WriteLine("Su frase traducida es: " + TraducirFrase(frase));
                    break;

                case 2:
                    Console.Write("Ingrese la palabra en español: ");
                    string? palabraEsp = Console.ReadLine();
                    Console.Write("Ingrese la traducción en inglés: ");
                    string? palabraIng = Console.ReadLine();

                    if (string.IsNullOrWhiteSpace(palabraEsp) || string.IsNullOrWhiteSpace(palabraIng))
                    {
                        Console.WriteLine("Entrada inválida. No se agregaron palabras.");
                    }
                    else
                    {
                        diccionarioEspañolAIngles[palabraEsp.ToLower()] = palabraIng.ToLower();
                        Console.WriteLine("Palabra agregada correctamente.");
                    }
                    break;

                default:
                    Console.WriteLine("Opción inválida.");
                    break;
            }
        }
    }

    static string TraducirFrase(string frase)
    {
        string[] palabras = frase.Split(' ');
        for (int i = 0; i < palabras.Length; i++)
        {
            string palabraLimpia = palabras[i].ToLower().Trim(new char[] { ',', '.', '!', '?' });

            if (diccionarioEspañolAIngles.TryGetValue(palabraLimpia, out string? traduccion))
            {
                palabras[i] = traduccion;
            }
        }
        return string.Join(" ", palabras);
    }
}
