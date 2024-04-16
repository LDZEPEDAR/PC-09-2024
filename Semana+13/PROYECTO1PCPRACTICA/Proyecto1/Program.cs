using System;
using System.Threading;
using static Proyecto1.Program;

namespace Proyecto1
{
    class Program

    {
        static void Main(string[] args)
        {
            string tipodecuenta = "";
            int cuenta;
            string nombrepersona;
            int DPI;
            string direccion;
            int numerotelefono;
            double saldo = 2500.00;
            int accion;

            Console.WriteLine("Por favor ingresar el numero correspondiente a su tipo de cuenta");
            Console.WriteLine("1 = Monetaria en quetzales");
            Console.WriteLine("2 = Monetaria en dólares");
            Console.WriteLine("3 = Ahorro en quetzales");
            Console.WriteLine("4 = Ahorro en dólares");
            cuenta = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Por favor ingresar su nombre");
            nombrepersona = Console.ReadLine();
            Console.WriteLine("Por favor ingresar su DPI");
            DPI = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Por favor ingresar su domicilio");
            direccion = Console.ReadLine();
            Console.WriteLine("Por favor ingrese su numero de télefono");
            numerotelefono = Convert.ToInt32(Console.ReadLine());


            switch (cuenta)
            {

                case 1:
                    tipodecuenta ="Monetaria en quetzales";
                    break;
                case 2:
                    tipodecuenta = "Monetaria en dólares";
                    break;
                case 3:
                    tipodecuenta = "Ahorro en quetzales";
                    break;
                case 4:
                    tipodecuenta = "Ahorro en dólares";
                    break;
                default:
                    Console.WriteLine("Valor no valido");
                    break;

            }

            Console.WriteLine("Por favor ingresar el numero correspondiente a la acción que desea realizar");
            Console.WriteLine("1 = Ver información de cuenta");
            Console.WriteLine("2 = Comprar producto financiero");
            Console.WriteLine("3 = Vender producto financiero");
            Console.WriteLine("4 = Abonar a cuenta");
            Console.WriteLine("5 = Simulación del paso del timepo");
            Console.WriteLine("6 = Salir");
            accion = Convert.ToInt32(Console.ReadLine());
            DiasTranscurridos diasTranscurridos;
            switch (accion)
            {
                case 1:
                    Console.WriteLine($"Nombre: {nombrepersona}");
                    Console.WriteLine($"DPI: {DPI}");
                    Console.WriteLine($"Dirección: {direccion}");
                    Console.WriteLine($"Número de telefono: {numerotelefono}");
                    Console.WriteLine($"Tipo de cuenta: {tipodecuenta}");
                    Console.WriteLine($"Saldo: {saldo}");
                    break;
                case 2:
                    saldo = saldo * 0.90;
                    Console.WriteLine($"El saldo de su cuenta {tipodecuenta} es de: {saldo}");
                    break;
                case 3:
                    saldo = saldo * 1.11;
                    Console.WriteLine($"El saldo de su cuenta {tipodecuenta} es de: {saldo}");
                    break;
                case 4:
                    saldo = saldo * 2;
                    Console.WriteLine($"El saldo de su cuenta {tipodecuenta} es de: {saldo}");
                    break;
                    diasTranscurridos.Iniciar(); 
                    break;
                case 6:
                    break;

            }
        }

        public class DiasTranscurridos
        {
            private int _diasTranscurridos;

            public DiasTranscurridos()
            {
                _diasTranscurridos = 0;
            }

            public void Iniciar()
            {
                Console.WriteLine($"Han pasado {_diasTranscurridos} días");

                for (int i = 0; i < 31; i++)
                {
                    _diasTranscurridos++;

                    Console.WriteLine($"Han pasado {_diasTranscurridos} días");

                    Thread.Sleep(1000);
                }

                Console.WriteLine("Simulación finalizada");
            }
        }
    }
}