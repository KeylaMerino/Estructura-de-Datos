using System;

namespace AgendaTelefonica
{
    struct Contacto
    {
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Telefono { get; set; }
        public string Correo { get; set; }

        public Contacto(string nombre, string apellido, string telefono, string correo)
        {
            Nombre = nombre;
            Apellido = apellido;
            Telefono = telefono;
            Correo = correo;
        }

        public override string ToString()
        {
            return $"{Nombre} {Apellido} - Tel: {Telefono} - Email: {Correo}";
        }
    }

    class Agenda
    {
        private Contacto[] contactos; // Vector (array) para almacenar contactos
        private int[,] estadisticas;  // Matriz para estadísticas, filas representan valores distintos
        private int cantidadContactos;

        public Agenda(int capacidadMaxima)
        {
            contactos = new Contacto[capacidadMaxima];
            estadisticas = new int[1, 1]; // Por simplicidad
            cantidadContactos = 0;
        }

        public void AgregarContacto(Contacto contacto)
        {
            if (cantidadContactos < contactos.Length)
            {
                contactos[cantidadContactos++] = contacto;
                Console.WriteLine("Contacto agregado con éxito.");
            }
            else
            {
                Console.WriteLine("La agenda está llena. No se pueden agregar más contactos.");
            }
        }

        public void ListarContactos()
        {
            if (cantidadContactos == 0)
            {
                Console.WriteLine("La agenda está vacía.");
            }
            else
            {
                Console.WriteLine("\nContactos en la agenda:");
                for (int i = 0; i < cantidadContactos; i++)
                {
                    Console.WriteLine($"{i + 1}. {contactos[i]}");
                }
            }
        }

        public void BuscarContacto(string criterio)
        {
            bool encontrado = false;
            Console.WriteLine("\nResultados de la búsqueda:");
            for (int i = 0; i < cantidadContactos; i++)
            {
                if (contactos[i].Nombre.Contains(criterio, StringComparison.OrdinalIgnoreCase) ||
                    contactos[i].Apellido.Contains(criterio, StringComparison.OrdinalIgnoreCase) ||
                    contactos[i].Telefono.Contains(criterio) ||
                    contactos[i].Correo.Contains(criterio, StringComparison.OrdinalIgnoreCase))
                {
                    Console.WriteLine(contactos[i]);
                    encontrado = true;
                }
            }

            if (!encontrado)
            {
                Console.WriteLine("No se encontraron contactos que coincidan con el criterio.");
            }
        }

        public void EliminarContacto(string telefono)
        {
            bool eliminado = false;
            for (int i = 0; i < cantidadContactos; i++)
            {
                if (contactos[i].Telefono == telefono)
                {
                    for (int j = i; j < cantidadContactos - 1; j++)
                    {
                        contactos[j] = contactos[j + 1];
                    }
                    cantidadContactos--;
                    eliminado = true;
                    Console.WriteLine($"El contacto con teléfono {telefono} fue eliminado.");
                    break;
                }
            }
            if (!eliminado)
            {
                Console.WriteLine($"No se encontró un contacto con teléfono {telefono}.");
            }
        }

        public void ReporteEstadisticas()
        {
            estadisticas[0, 0] = cantidadContactos; // Actualizar valor en la matriz
            Console.WriteLine("\n--- Reporte de la Agenda ---");
            Console.WriteLine($"Total de contactos: {estadisticas[0, 0]}");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Agenda miAgenda = new Agenda(5);

            // Agregar contactos
            miAgenda.AgregarContacto(new Contacto("Keyla", "Merino", "123456789", "Keyla.mrn@email.com"));
            miAgenda.AgregarContacto(new Contacto("María", "López", "987654321", "maria.lopez@email.com"));
            miAgenda.AgregarContacto(new Contacto("Patricio", "Merino", "555444333", "Patricio.merino@email.com"));

            // Listar contactos
            miAgenda.ListarContactos();

            // Buscar contacto
            Console.WriteLine("\nBuscar contacto (criterio: 'Keyla'):");
            miAgenda.BuscarContacto("Keyla");

            // Eliminar contacto
            Console.WriteLine("\nEliminar contacto con teléfono 123456789:");
            miAgenda.EliminarContacto("123456789");

            // Mostrar contactos después de eliminar
            miAgenda.ListarContactos();

            // Generar reporte
            miAgenda.ReporteEstadisticas();
        }
    }
}
