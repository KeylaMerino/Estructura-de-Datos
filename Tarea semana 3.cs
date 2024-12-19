using System;

public class Producto
{
    // Atributos
    public int Id { get; set; }
    public string Nombre { get; set; }
    public string Unidad { get; set; }
    public decimal[] Precios { get; set; } // Array para manejar tres precios por producto

    // Constructor
    public Producto(int id, string nombre, string unidad, decimal[] precios)
    {
        if (precios.Length != 3) // Verificar que sean exactamente tres precios
            throw new ArgumentException("Se requieren exactamente tres precios por producto.");

        Id = id;
        Nombre = nombre;
        Unidad = unidad;
        Precios = precios;
    }

    // Método para mostrar información del producto
    public void MostrarInfo()
    {
        Console.WriteLine($"ID: {Id}\nNombre: {Nombre}\nUnidad: {Unidad}\nPrecios: {string.Join(", ", Precios)}\n");
    }
}

class Program
{
    static void Main()
    {
        // Array para almacenar varios productos
        Producto[] productos = new Producto[3]; // Se inicializa un array de 3 productos

        // Crear productos y agregarlos al array
        productos[0] = new Producto(1, "Leche", "Litro", new decimal[] { 1.25m, 1.50m, 1.75m });
        productos[1] = new Producto(2, "Arroz", "Kilogramo", new decimal[] { 0.75m, 0.80m, 0.85m });
        productos[2] = new Producto(3, "Aceite", "Litro", new decimal[] { 3.00m, 3.25m, 3.50m });

        // Recorrer el array y mostrar información de cada producto
        foreach (Producto producto in productos)
        {
            producto.MostrarInfo();
        }
    }
}
