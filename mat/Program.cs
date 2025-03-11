using System;
using System.Threading;

class MatrixCode
{
    static void Main(string[] args)
    {
        // Ajustar la consola para que tenga un fondo negro
        Console.BackgroundColor = ConsoleColor.Black;
        Console.Clear();

        Random rand = new Random();

        // Dimensiones de la pantalla
        int ancho = Console.WindowWidth;
        int alto = Console.WindowHeight;

        // Arreglo que guarda la posición "y" de cada columna de caracteres
        int[] columnas = new int[ancho];
        for (int i = 0; i < columnas.Length; i++)
        {
            columnas[i] = rand.Next(alto);
        }

        // Bucle infinito para mantener el efecto en ejecución
        while (true)
        {
            for (int x = 0; x < ancho; x++)
            {
                // Elegir un carácter aleatorio para mostrar en la consola
                char caracter = (char)rand.Next(33, 126); // Caracteres ASCII visibles

                // Elegir color para los caracteres (verde para el efecto Matrix)
                Console.ForegroundColor = ConsoleColor.Green;

                // Mover el cursor a la posición actual de la columna
                Console.SetCursorPosition(x, columnas[x]);

                // Imprimir el carácter
                Console.Write(caracter);

                // Con un cierto porcentaje de probabilidad, limpiar la línea
                if (rand.Next(10) < 2) // 20% de probabilidad de limpiar la línea
                {
                    Console.SetCursorPosition(x, (columnas[x] - 2 + alto) % alto);
                    Console.Write(" ");
                }

                // Incrementar la posición de la columna "y"
                columnas[x] = (columnas[x] + 1) % alto;
            }

            // Añadir un pequeño retraso para que el efecto no sea demasiado rápido
            Thread.Sleep(50);
        }
    }
}
