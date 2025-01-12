using System;
using System.Collections.Generic;

namespace AsignaturasCurso
{
    // Clase que representa un curso con sus asignaturas
    class Curso
    {
        // Propiedad para almacenar las asignaturas
        public List<string> Asignaturas { get; private set; }

        // Constructor que inicializa las asignaturas
        public Curso()
        {
            Asignaturas = new List<string> { "Matemáticas", "Física", "Química", "Historia", "Lengua" };
        }

        // Método para mostrar las asignaturas por pantalla
        public void MostrarAsignaturas()
        {
            Console.WriteLine("Asignaturas del curso:");
            foreach (var asignatura in Asignaturas)
            {
                Console.WriteLine("- " + asignatura);
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Crear una instancia de Curso
            Curso curso = new Curso();

            // Mostrar las asignaturas del curso
            curso.MostrarAsignaturas();

            // Esperar para cerrar el programa
            Console.WriteLine("\nPresiona cualquier tecla para salir...");
            Console.ReadKey();
        }
    }
}
