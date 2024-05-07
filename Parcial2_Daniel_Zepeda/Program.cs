using System;
using System.Diagnostics.CodeAnalysis;
using System.Timers;

namespace DanielZepeda
{
    class Notas
    {

        private string[,] notas;


        public void Cargar()
        {

            notas = new string[10, 10];


            for (int i = 0; i < 10; i++)
            {
                Console.Write($"Ingrese el nombre del alumno no.{i + 1}: ");
                string nombre;
                nombre = Console.ReadLine();
                notas[0, i] = nombre;
                Console.Write($"Ingrese la nota del alumno no.{i + 1}: ");
                string nota;
                nota = Console.ReadLine();
                notas[1, i] = nota;
            }

        }

        public void Imprimirnotas()
        {
            int sumanotas = 0;
            int promedio = 0;
            Console.WriteLine("");
            Console.WriteLine("Notas de los alumnos: ");
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine($"El alumno {notas[0, i]} obtuvo una nota de {notas[i, 1]}");
                int notaint = Convert.ToInt32(notas[i,0]);
                if(notaint >= 65)
                {
                    Console.WriteLine($"El alumno {notas[0, i]} ha ganado el curso ");
                }
                else { Console.WriteLine($"El alumno {notas[0, i]} ha perdido el curso ");
                }
                sumanotas = notaint + sumanotas;
            }

            promedio = sumanotas / 10;
            Console.WriteLine($"El promedio de los alumnos ha sido de {promedio}");
            

            Console.ReadKey();
        }

        static void Main()
        {
            Notas Notas_ = new Notas();
            Notas_.Cargar();
            Notas_.Imprimirnotas();
        }
    }
}