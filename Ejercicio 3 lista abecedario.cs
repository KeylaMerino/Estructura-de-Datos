using System;
using System.Collections.Generic;

namespace AbecedarioConMultiplesDeTres
{
    // Clase que gestiona el abecedario y la eliminación de letras en posiciones múltiples de 3
    class Abecedario
    {
        // Propiedad para almacenar el abecedario
        public List<char> Letras { get; private set; }

        // Constructor que inicializa la lista del abecedario
        public Abecedario()
        {
            Letras = new List<char>();

            // Agregar las letras del abecedario a la lista
            for (char letra = 'A'; letra <= 'Z'; letra++)
            {
                Letras.Add(letra);
            }
        }

        // Método para eliminar letras en posiciones múltiplos de 3
        public void EliminarLetrasMultiploDeTres()
        {
            // Recorrer la lista y eliminar las letras de posiciones múltiplos de 3
            for (int i = Letras.Count - 1; i >= 0; i--) 
            {
                if ((i + 1) % 3 == 0) // El índice empieza desde 0, por lo que sumamos 1
                {
                    Letras.RemoveAt(i);
                }
            }
        }

        // Método para mostrar las letras restantes en la lista
        public void MostrarAbecedario()
        {
            Console.WriteLine("Abecedario después de eliminar letras en posiciones múltiplos de 3:");
            foreach (var letra in Letras)
            {
                Console.Write(letra + " ");
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Crear una instancia de la clase Abecedario
            Abecedario abecedario = new Abecedario();

            // Eliminar las letras en posiciones múltiplos de 3
            abecedario.EliminarLetrasMultiploDeTres();

            // Mostrar el abecedario modificado
            abecedario.MostrarAbecedario();

            // Esperar para cerrar el programa
            Console.WriteLine("\nPresiona cualquier tecla para salir...");
            Console.ReadKey();
        }
    }
}
