using System;

namespace FigurasGeometricas
{
    // Clase para representar un Círculo
    public class Circulo
    {
        private double radio; // Propiedad encapsulada para el radio del círculo

        // Constructor para inicializar el radio
        public Circulo(double radio)
        {
            this.radio = radio;
        }

        // Método para calcular el área del círculo
        public double CalcularArea()
        {
            return Math.PI * Math.Pow(radio, 2); // Fórmula: π * radio²
        }

        // Método para calcular el perímetro del círculo
        public double CalcularPerimetro()
        {
            return 2 * Math.PI * radio; // Fórmula: 2 * π * radio
        }
    }

    // Clase para representar un Rectángulo
    public class Rectangulo
    {
        private double baseRectangulo; // Propiedad encapsulada para la base
        private double altura; // Propiedad encapsulada para la altura

        // Constructor para inicializar base y altura
        public Rectangulo(double baseRectangulo, double altura)
        {
            this.baseRectangulo = baseRectangulo;
            this.altura = altura;
        }

        // Método para calcular el área del rectángulo
        public double CalcularArea()
        {
            return baseRectangulo * altura; // Fórmula: base * altura
        }

        // Método para calcular el perímetro del rectángulo
        public double CalcularPerimetro()
        {
            return 2 * (baseRectangulo + altura); // Fórmula: 2 * (base + altura)
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Ejemplo de uso de la clase Circulo
            Circulo circulo = new Circulo(5);
            Console.WriteLine("Círculo - Área: " + circulo.CalcularArea());
            Console.WriteLine("Círculo - Perímetro: " + circulo.CalcularPerimetro());

            // Ejemplo de uso de la clase Rectángulo
            Rectangulo rectangulo = new Rectangulo(4, 6);
            Console.WriteLine("Rectángulo - Área: " + rectangulo.CalcularArea());
            Console.WriteLine("Rectángulo - Perímetro: " + rectangulo.CalcularPerimetro());
        }
    }
}

