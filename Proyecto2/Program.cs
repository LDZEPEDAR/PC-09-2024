using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAccount
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
            double balance = 2500.00;
            int accion;
            double interessim;
            double interescomp;
            string razonretiro;
            do
            {
                try
                {
                    Console.WriteLine("Por favor ingresar el numero correspondiente a su tipo de cuenta");
                    Console.WriteLine("1 = Monetaria en quetzales");
                    Console.WriteLine("2 = Monetaria en dólares");
                    Console.WriteLine("3 = Ahorro en quetzales");
                    Console.WriteLine("4 = Ahorro en dólares");
                    cuenta = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Por favor ingresar su nombre");
                    nombrepersona = Console.ReadLine();
                    Console.WriteLine("Por favor ingresar su DPI (De 5 digitos)");
                    DPI = Convert.ToInt32(Console.ReadLine());
                    if (DPI > 100000 || DPI < 9999)
                    {
                        throw new ArgumentOutOfRangeException(nameof(DPI), "El DPI debe ser de 5 digitos");
                    }

                    Console.WriteLine("Por favor ingresar su domicilio");
                    direccion = Console.ReadLine();
                    Console.WriteLine("Por favor ingrese su numero de télefono");
                    numerotelefono = Convert.ToInt32(Console.ReadLine());


                    switch (cuenta)
                    {

                        case 1:
                            tipodecuenta = "Monetaria en quetzales";
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
                            Console.WriteLine("Valor no valido de tipo de cuenta");
                            break;

                    }

                    Console.WriteLine("Por favor ingresar el numero correspondiente a la acción que desea realizar");
                    Console.WriteLine("1 = Ver información de cuenta");
                    Console.WriteLine("2 = Comprar producto financiero");
                    Console.WriteLine("3 = Vender producto financiero");
                    Console.WriteLine("4 = Abonar a cuenta");
                    Console.WriteLine("5 = Simulación del paso del timepo");
                    Console.WriteLine("6 = Salir e ir directo a mi cuenta");
                    accion = Convert.ToInt32(Console.ReadLine());
                    switch (accion)
                    {
                        case 1:
                            Console.WriteLine($"Nombre: {nombrepersona}");
                            Console.WriteLine($"DPI: {DPI}");
                            Console.WriteLine($"Dirección: {direccion}");
                            Console.WriteLine($"Número de telefono: {numerotelefono}");
                            Console.WriteLine($"Tipo de cuenta: {tipodecuenta}");
                            Console.WriteLine($"Saldo: {balance}");
                            break;
                        case 2:
                            balance = balance * 0.90;
                            Console.WriteLine($"El saldo de su cuenta {tipodecuenta} es de: {balance}");
                            break;
                        case 3:
                            balance = balance * 1.11;
                            Console.WriteLine($"El saldo de su cuenta {tipodecuenta} es de: {balance}");
                            break;
                        case 4:
                            balance = balance * 2;
                            Console.WriteLine($"El saldo de su cuenta {tipodecuenta} es de: {balance}");
                            break;
                        case 5:
                            for (int diasTranscurridos = 0; diasTranscurridos < 31; diasTranscurridos++)
                            {

                                Console.WriteLine($"Han pasado {diasTranscurridos} días");

                                Thread.Sleep(1000);
                            }
                            interessim = balance * 0.02 / 30;
                            interescomp = balance * 0.02 / (1 / 12);
                            Console.WriteLine($"Interes simple: {interessim}");
                            Console.WriteLine($"Interes compuesto: {interescomp}");
                            break;
                        case 6:
                            break;
                    }
                    //Abrir cuenta
                    bankAccount Usuariocuenta = new bankAccount(nombrepersona, balance, DateTime.Now);
                    Console.WriteLine($"Felicitaciones {Usuariocuenta.Owner} acaba de crear su cuenta con un deposito inicial de: {Usuariocuenta.balance} ");

                    //Deposito a cuenta

                    double retirocuenta = 0;
                    double depositocuenta = 0;

                    Console.WriteLine("Ingrese el monto que desea ingresar a su cuenta");
                    depositocuenta = Convert.ToDouble(Console.ReadLine());
                    Console.WriteLine("Ingrese la razón de este");
                    string razondepos = Console.ReadLine();

                    Usuariocuenta.makeDeposit(depositocuenta, DateTime.Now, razondepos);

                    Console.WriteLine($"Estimado {Usuariocuenta.Owner} debido a esta transaccion tiene un balance de: {Usuariocuenta.balance}");

                    //Retiro 

                    Console.WriteLine("Ingrese el monto para el pago de servicio");
                    retirocuenta = Convert.ToDouble(Console.ReadLine());
                    Console.WriteLine("Ingrese un numero segun que servicio se paga");
                    Console.WriteLine("1 = Electricidad");
                    Console.WriteLine("2 = Agua");
                    Console.WriteLine("3 = Teléfono");
                    int pagoservicio = Convert.ToInt32(Console.ReadLine());
                    switch (pagoservicio)
                    {

                        case 1:
                            razonretiro = "Electricidad";
                            break;
                        case 2:
                            razonretiro = "Agua";
                            break;
                        case 3:
                            razonretiro = "Teléfono";
                            break;
                        default:
                            razonretiro = "Dato no dado correctamente";
                            break;
                    }


                    Usuariocuenta.Withdrawmoney(retirocuenta, DateTime.Now, razonretiro);
                    Console.WriteLine($"Estimado {Usuariocuenta.Owner} debido a esta transaccion tiene un balance de: {Usuariocuenta.balance}");

                    //Historial 

                    Console.WriteLine(" =========== HISTORIAL DE CUENTA =========== ");
                    Console.WriteLine(Usuariocuenta.getAccountHistory());
                    Console.WriteLine($"Estimado {Usuariocuenta.Owner} su balance final es: {Usuariocuenta.balance}");
                    Console.ReadKey();

                }

                catch (Exception ex)
                {

                    Console.WriteLine(ex.Message);
                    Console.WriteLine("Ha habido un error, por favor verifica los datos los datos ingresados");
                }
            }
            while(true);

            }
        }
    }
