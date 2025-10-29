
using System.Runtime.ConstrainedExecution;
using Microsoft.Win32;

namespace ProgramaHotelFP
{
    class Program
    {
        static int[] NumerodeHabitaciones = new int[20];
        static string[] TipoDeHabitaciones = new string[20];
        static decimal[] PrecioPorNoche = new decimal[20];
        static bool[] VerDisponibilidad = new bool[20];
        static int contadorHabitaciones = 0;


        static string[] ingresarNombre = new string[20];
        static int[] ingresarDocumento = new int[20];
        static int[] ingresartelefono = new int[20];
        static int contadorHuespedes = 0;

        static int[,] IdReserva = new int[20, 5];
        static int[,] NumHabitacion = new int[20, 5];
        static string[,] DocHuesped = new string[20, 5];
        static string[,] fechaEntrada = new string[20, 5];
        static int[,] numNoches = new int[20, 5];
        static int[] contadorReservashabitacion = new int[20];


        static void Main(string[] args)
        {
            inicializarHabitaciones();
            MenuPrincipal();
        }

        static void inicializarHabitaciones()
        {

            for (int i = 0; i < 10; i++)
            {
                NumerodeHabitaciones[contadorHabitaciones] = i + 1;
                TipoDeHabitaciones[contadorHabitaciones] = "Normal";
                PrecioPorNoche[contadorHabitaciones] = 70000;
                VerDisponibilidad[contadorHabitaciones] = true;
                contadorHabitaciones++;
            }

            for (int i = 0; i < 5; i++)
            {
                NumerodeHabitaciones[contadorHabitaciones] = i + 11;
                TipoDeHabitaciones[contadorHabitaciones] = "Doble";
                PrecioPorNoche[contadorHabitaciones] = 120000;
                VerDisponibilidad[contadorHabitaciones] = true;
                contadorHabitaciones++;
            }

            for (int i = 0; i < 5; i++)
            {
                NumerodeHabitaciones[contadorHabitaciones] = i + 16;
                TipoDeHabitaciones[contadorHabitaciones] = "Suite";
                PrecioPorNoche[contadorHabitaciones] = 300000;
                VerDisponibilidad[contadorHabitaciones] = true;
                contadorHabitaciones++;
            }


        }

        static void MenuPrincipal()
        {
            int opcion;

            do
            {
                Console.WriteLine("Sistema de Reservas del Hotel UPB");
                Console.WriteLine("1.Gestion Habitaciones");
                Console.WriteLine("2.Gestion Huespedes");
                Console.WriteLine("3.Gestion Reservas");
                Console.WriteLine("4.Salir Del Sistema");

                while (!int.TryParse(Console.ReadLine(), out opcion) || opcion < 1 || opcion > 4)
                {
                    Console.WriteLine("Opcion Invalida Intente de Nuevo");
                }
                switch (opcion)
                {
                    case 1:
                        MenuGestionHabitaciones();
                        break;
                    case 2:
                        MenuGestionHuespedes();
                        break;
                    case 3:
                        MenuGestionReservas();
                        break;
                    case 4:
                        Console.WriteLine("Gracias Por usar el Sistema");
                        break;
                }

            } while (opcion != 4);
        }

        static void MenuGestionHabitaciones()
        {
            int opcion;

            do
            {

                Console.WriteLine("GestionDeHabitaciones");
                Console.WriteLine("1.Registrar Habitacion");
                Console.WriteLine("2.Ver Lista Habitaciones");
                Console.WriteLine("3.Editar informacion");
                Console.WriteLine("4.Ver Disponibilidad");
                Console.WriteLine("5.Salir");

                while (!int.TryParse(Console.ReadLine(), out opcion) || opcion < 1 || opcion > 5)
                {
                    Console.WriteLine("Opcion Invalida Intente de Nuevo");
                }

                switch (opcion)
                {
                    case 1:
                        RegistrarHabitacion();
                        break;
                    case 2:
                        VerListaHabitaciones();
                        break;
                    case 3:
                        EditarHabitacion();
                        break;
                    case 4:
                        VerDisponibilidadHabitaciones();
                        break;
                    case 5:
                        Console.WriteLine("Gracias Por usar el Sistema");
                        break;

                }

            } while (opcion != 5);

        }
        static void RegistrarHabitacion()
        {
            Console.Clear();
            Console.WriteLine("Registra una habitacion");

            if (contadorHabitaciones < 20)
            {
                Console.WriteLine("Maximo de habitaciones");
                Console.WriteLine("precione una tecla para continuar");
                Console.ReadKey();
                return;
            }
            int numero;
            Console.Write("Numero de Habitacion: ");
            while (!int.TryParse(Console.ReadLine(), out numero) || numero <= 0)
            {
                Console.Write("Numeoro invalido ingrese nuevo: ");
            }

            bool existe = false;
            for (int i = 0; i < contadorHabitaciones; i++)
            {
                if (NumerodeHabitaciones[i] == numero)
                {
                    existe = true;
                    break;
                }
            }

            if (existe)
            {
                Console.WriteLine("ya existe una habitacion con este numero ");
            }

            Console.WriteLine("Tipo De Habitacion (Normal/Doble/Suite):");
            string tipo = Console.ReadLine();

            decimal Precio;
            Console.WriteLine("Precio Por Noche: $");
            while (!decimal.TryParse(tipo, out Precio) || Precio <= 0)
            {
                Console.WriteLine("Precio invalido, intente de nuevo ");
            }


            NumerodeHabitaciones[contadorHabitaciones] = numero;
            TipoDeHabitaciones[contadorHabitaciones] = tipo;
            PrecioPorNoche[contadorHabitaciones] = Precio;
            VerDisponibilidad[contadorHabitaciones] = true;
            contadorHabitaciones++;

            Console.WriteLine("Habitacion Registrada Exitosamente");
            Console.WriteLine("Precione tecla Para continuar");

        }

        static void VerListaHabitaciones()
        {

        }

        static void EditarHabitacion()
        {

        }

        static void VerDisponibilidadHabitaciones()
        {

        }








        static void MenuGestionHuespedes()
        {
            int opcion;

            do
            {
                Console.WriteLine("GestionDEHuespedes");
                Console.WriteLine("1.Resgistrar Huesped");
                Console.WriteLine("2.Ver Lista Huespedes");
                Console.WriteLine("3.Editar Informacion");
                Console.WriteLine("4.salir");

                while (!int.TryParse(Console.ReadLine(), out opcion) || opcion < 1 || opcion > 4)
                {
                    Console.WriteLine("Opcion Invalida Intente de Nuevo");
                }

                switch (opcion)
                {
                    case 1:
                        RegistrarHuesped();
                        break;
                    case 2:
                        VerListaHespedes();
                        break;
                    case 3:
                        EditarHuespedes();
                        break;
                    case 4:
                        Console.WriteLine("Gracias Por usar el Sistema");
                        break;

                }

            } while (opcion != 4);

        }

        static void RegistrarHuesped()
        {

        }

        static void VerListaHespedes()
        {

        }

        static void EditarHuespedes()
        {

        }


        static void MenuGestionReservas()
        {
            int opcion;

            do
            {
                Console.WriteLine("GestionDeReservas");
                Console.WriteLine("1.Crear Reserva");
                Console.WriteLine("2.Ver Reserva");
                Console.WriteLine("3.Ver Historial De Reservas");
                Console.WriteLine("4.Cancelar una Reserva");
                Console.WriteLine("5.Salir");

                while (!int.TryParse(Console.ReadLine(), out opcion) || opcion < 1 || opcion > 5)
                {
                    Console.WriteLine("Opcion Invalida Intente de Nuevo");
                }
                switch (opcion)
                {
                    case 1:
                        CrearReserva();
                        break;
                    case 2:
                        VerReserva();
                        break;
                    case 3:
                        VerHistorialReservas();
                        break;
                    case 4:
                        CancelarReserva();
                        break;
                    case 5:
                        Console.WriteLine("Gracias Por usar el Sistema");
                        break;

                }

            } while (opcion != 5);


        }

        static void CrearReserva()
        {

        }

        static void VerReserva()
        {

        }

        static void VerHistorialReservas()
        {

        }

        static void CancelarReserva()
        {

        }



    }
}
