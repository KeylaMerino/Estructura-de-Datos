using System;
using System.Collections.Generic;

class Program
{
    // Función para verificar si una expresión matemática tiene paréntesis balanceados
    static bool VerificarBalance(string formula)
    {
        // Crear una pila para almacenar los paréntesis abiertos
        Stack<char> pila = new Stack<char>();

        // Recorremos cada carácter de la fórmula
        foreach (char c in formula)
        {
            // Si encontramos un paréntesis abierto, lo agregamos a la pila
            if (c == '(' || c == '[' || c == '{')
            {
                pila.Push(c);
            }
            // Si encontramos un paréntesis cerrado, verificamos si coincide con el último abierto
            else if (c == ')' || c == ']' || c == '}')
            {
                // Verificamos si la pila está vacía o si el paréntesis no coincide
                if (pila.Count == 0 || !Coincide(pila.Pop(), c))
                {
                    return false; // La fórmula no está balanceada
                }
            }
        }

        // Si la pila está vacía, los paréntesis están balanceados, de lo contrario, no
        return pila.Count == 0;
    }

    // Función auxiliar para verificar si los paréntesis coinciden correctamente
    static bool Coincide(char abierto, char cerrado)
    {
        // Compara los paréntesis correspondientes
        return (abierto == '(' && cerrado == ')') ||
               (abierto == '[' && cerrado == ']') ||
               (abierto == '{' && cerrado == '}');
    }

    static void Main()
    {
        // Ejemplo de fórmula
        string formula = "{7+(8*5)-[(9-7)+(4+1)]}";
        
        // Verificamos si la fórmula está balanceada
        if (VerificarBalance(formula))
        {
            Console.WriteLine("La fórmula está balanceada.");
        }
        else
        {
            Console.WriteLine("La fórmula no está balanceada.");
        }
    }
}
