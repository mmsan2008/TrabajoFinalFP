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
        static string[] ingresarDocumento = new string[20];
        static string[] ingresartelefono = new string[20];
        static int contadorHuespedes = 0;

        static int[,] IdReserva = new int[20, 5];
        static int[,] NumReservaHabitacion = new int[20, 5];
        static string[,] DocReservaHuesped = new string[20, 5];
        static string[,] ReservafechaEntrada = new string[20, 5];
        static int[,] numNoches = new int[20, 5];
        static int[] contadorReservashabitacion = new int[20];
        static int contadorReservasGlobal = 1;


        static void Main(string[] args)
        {

            MenuPrincipal();
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
            Console.WriteLine(" Registrar Habitacion ");

            if (contadorHabitaciones >= 20)
            {
                Console.WriteLine("Se alcanzó el máximo de habitaciones (20).");
                Console.WriteLine("Presione una tecla para continuar...");
                Console.ReadKey();
                return;
            }

           
            int numero;
            Console.Write("Ingrese el número de habitación: ");
            while (!int.TryParse(Console.ReadLine(), out numero) || numero <= 0)
            {
                Console.Write("Número inválido, intente nuevamente ");
            }

            
            for (int i = 0; i < contadorHabitaciones; i++)
            {
                if (NumerodeHabitaciones[i] == numero)
                {
                    Console.WriteLine("Ya existe una habitación con ese número.");
                    Console.WriteLine("Presione una tecla para continuar");
                    Console.ReadKey();
                    return;
                }
            }

           
            string tipo;
            decimal precio = 0;

            do
            {
                Console.Write("Tipo de habitación (Normal / Doble / Suite): ");
                tipo = Console.ReadLine().Trim().ToLower();

                if (tipo == "normal")
                    precio = 70000;
                else if (tipo == "doble")
                    precio = 120000;
                else if (tipo == "suite")
                    precio = 300000;
                else
                    Console.WriteLine("Tipo no válido. Intente nuevamente.");

            } while (precio == 0);

            
            NumerodeHabitaciones[contadorHabitaciones] = numero;
            TipoDeHabitaciones[contadorHabitaciones] = tipo;
            PrecioPorNoche[contadorHabitaciones] = precio;
            VerDisponibilidad[contadorHabitaciones] = true;
            contadorHabitaciones++;

            Console.WriteLine($"Habitación #{numero} ({tipo}) registrada con éxito. Precio: ${precio}");
            Console.WriteLine("Presione una tecla para continuar...");
            Console.ReadKey();

        }

        static void VerListaHabitaciones()
        {

            Console.Clear();
            Console.WriteLine("lista de habitaciones");

            if (contadorHabitaciones == 0)
            {
                Console.WriteLine("No hay habitaciones registradas.");
            }
            else
            {
                for (int i = 0; i < contadorHabitaciones; i++)
                {
                    string estado = VerDisponibilidad[i] ? "Disponible" : "Ocupada";
                    Console.WriteLine($"Habitación #{NumerodeHabitaciones[i]} - Tipo: {TipoDeHabitaciones[i]} - Precio: ${PrecioPorNoche[i]} - Estado: {estado}");
                }
            }

            Console.WriteLine("Presione una tecla para continuar");
            Console.ReadKey();


        }

        static void EditarHabitacion()
        {
            Console.Clear();
            Console.WriteLine("Editar Habitaciones");

            int numero;
            Console.Write("Ingrese el número de habitación a editar: ");
            while (!int.TryParse(Console.ReadLine(), out numero))
            {
                Console.Write("Número inválido. Intente de nuevo: ");
            }


            int indice = -1;
            for (int i = 0; i < contadorHabitaciones; i++)
            {
                if (NumerodeHabitaciones[i] == numero)
                {
                    indice = i;
                    break;
                }
            }

            if (indice == -1)
            {
                Console.WriteLine("Habitación no encontrada");
            }
            else
            {
                Console.WriteLine("Datos actuales:");
                string estado = VerDisponibilidad[indice] ? "Disponible" : "Ocupada";
                Console.WriteLine($"Habitación #{NumerodeHabitaciones[indice]} - Tipo: {TipoDeHabitaciones[indice]} - Precio: ${PrecioPorNoche[indice]} - Estado: {estado}");

                Console.Write("\nNuevo tipo de habitación (Enter para mantener): ");
                string tipo = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(tipo))
                {
                    TipoDeHabitaciones[indice] = tipo;
                }

                Console.Write("Nuevo precio por noche (Enter para mantener): $");
                string precioStr = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(precioStr) && decimal.TryParse(precioStr, out decimal precio))
                {
                    PrecioPorNoche[indice] = precio;
                }

                Console.WriteLine("Habitación actualizada exitosamente");
            }

            Console.WriteLine("Presione cualquier tecla para continuar");
            Console.ReadKey();
        }





        static void VerDisponibilidadHabitaciones()
        {
            Console.Clear();
            Console.WriteLine("ver Dispinibilidad");

            int disponibles = 0;
            int ocupadas = 0;


            for (int i = 0; i < contadorHabitaciones; i++)
            {
                if (VerDisponibilidad[i])
                    disponibles++;
                else
                    ocupadas++;
            }

            Console.WriteLine($"Habitaciones disponibles: {disponibles}");
            for (int i = 0; i < contadorHabitaciones; i++)
            {
                if (VerDisponibilidad[i])
                {
                    Console.WriteLine($"Habitación #{NumerodeHabitaciones[i]} - Tipo: {TipoDeHabitaciones[i]} - Precio: ${PrecioPorNoche[i]}");
                }
            }

            Console.WriteLine($"Habitaciones ocupadas: {ocupadas}");
            for (int i = 0; i < contadorHabitaciones; i++)
            {
                if (!VerDisponibilidad[i])
                {
                    Console.WriteLine($"Habitación #{NumerodeHabitaciones[i]} - Tipo: {TipoDeHabitaciones[i]} - Precio: ${PrecioPorNoche[i]}");
                }
            }

            Console.WriteLine("Presione cualquier tecla para continuar");
            Console.ReadKey();
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
            Console.Clear();
            Console.WriteLine("Registrar nuevo huesped");

            if (contadorHuespedes >= 20)
            {
                Console.WriteLine("maximo de huespedes permitidos");
                Console.WriteLine("Presione cualquier tecla para continuar");
                Console.ReadKey();
                return;
            }

            Console.Write("Nombre: ");
            string nombre = Console.ReadLine();

            Console.Write("Documento de identidad: ");
            string documento = Console.ReadLine();


            bool existe = false;
            for (int i = 0; i < contadorHuespedes; i++)
            {
                if (ingresarDocumento[i] == documento)
                {
                    existe = true;
                    break;
                }
            }

            if (existe)
            {
                Console.WriteLine("Ya existe un huésped con ese documento");
                Console.WriteLine("Presione cualquier tecla para continuar");
                Console.ReadKey();
                return;
            }

            Console.Write("Teléfono: ");
            string telefono = Console.ReadLine();


            ingresarNombre[contadorHuespedes] = nombre;
            ingresarDocumento[contadorHuespedes] = documento;
            ingresartelefono[contadorHuespedes] = telefono;
            contadorHuespedes++;

            Console.WriteLine("Huésped registrado exitosamente");
            Console.WriteLine("Presione cualquier tecla para continuar");
            Console.ReadKey();
        }

        static void VerListaHespedes()
        {
            Console.Clear();
            Console.WriteLine("lista de Huespedes");

            if (contadorHuespedes == 0)
            {
                Console.WriteLine("No hay huéspedes registrados.");
            }
            else
            {
                for (int i = 0; i < contadorHuespedes; i++)
                {
                    Console.WriteLine($"{i + 1}. Nombre: {ingresarNombre[i]} - Documento: {ingresarDocumento[i]} - Teléfono: {ingresartelefono[i]}");
                }
            }

            Console.WriteLine("Presione cualquier tecla para continuar");
            Console.ReadKey();
        }

        static void EditarHuespedes()
        {
            Console.Clear();
            Console.WriteLine("Editar Huesped");

            Console.Write("Ingrese el documento del huésped a editar: ");
            string documento = Console.ReadLine();


            int indice = -1;
            for (int i = 0; i < contadorHuespedes; i++)
            {
                if (ingresarDocumento[i] == documento)
                {
                    indice = i;
                    break;
                }
            }

            if (indice == -1)
            {
                Console.WriteLine("Huésped no encontrado.");
            }
            else
            {
                Console.WriteLine("Datos actuales:");
                Console.WriteLine($"Nombre: {ingresarNombre[indice]} - Documento: {ingresarDocumento[indice]} - Teléfono: {ingresartelefono[indice]}");

                Console.Write("Nuevo nombre (Enter para mantener): ");
                string nombre = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(nombre))
                {
                    ingresarNombre[indice] = nombre;
                }

                Console.Write("Nuevo teléfono (Enter para mantener): ");
                string telefono = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(telefono))
                {
                    ingresartelefono[indice] = telefono;
                }

                Console.WriteLine("Huésped actualizado exitosamente");
            }

            Console.WriteLine("Presione cualquier tecla para continuar");
            Console.ReadKey();
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
            Console.Clear();
            Console.WriteLine("Crear Reserva");

            
            if (contadorHabitaciones == 0)
            {
                Console.WriteLine("No hay habitaciones registradas aún.");
                Console.WriteLine("Presione cualquier tecla para continuar...");
                Console.ReadKey();
                return;
            }

            Console.WriteLine("Habitaciones disponibles para reservar:");
            for (int i = 0; i < contadorHabitaciones; i++)
            {
                Console.WriteLine($"Habitación #{NumerodeHabitaciones[i]} - Tipo: {TipoDeHabitaciones[i]} - Precio: ${PrecioPorNoche[i]}");
            }

           
            int numHab;
            Console.Write("Ingrese el número de habitación a reservar: ");
            while (!int.TryParse(Console.ReadLine(), out numHab))
            {
                Console.Write("Número inválido. Intente de nuevo: ");
            }

            int indiceHab = -1;
            for (int i = 0; i < contadorHabitaciones; i++)
            {
                if (NumerodeHabitaciones[i] == numHab)
                {
                    indiceHab = i;
                    break;
                }
            }

            if (indiceHab == -1)
            {
                Console.WriteLine("Habitación no encontrada.");
                Console.WriteLine("Presione cualquier tecla para continuar...");
                Console.ReadKey();
                return;
            }

            
            if (contadorHuespedes == 0)
            {
                Console.WriteLine("No hay huéspedes registrados. Registre uno primero.");
                Console.WriteLine("Presione cualquier tecla para continuar...");
                Console.ReadKey();
                return;
            }

            Console.WriteLine("Huéspedes registrados:");
            for (int i = 0; i < contadorHuespedes; i++)
            {
                Console.WriteLine($"{i + 1}. {ingresarNombre[i]} - Documento: {ingresarDocumento[i]}");
            }

            
            int indiceHuesped;
            Console.Write("Seleccione número de huésped (1-{0}): ", contadorHuespedes);
            while (!int.TryParse(Console.ReadLine(), out indiceHuesped) || indiceHuesped < 1 || indiceHuesped > contadorHuespedes)
            {
                Console.Write("Número inválido. Intente de nuevo: ");
            }
            indiceHuesped--;

            
            Console.Write("Fecha de entrada (dd/mm/yyyy): ");
            string fechaEntrada = Console.ReadLine().Trim();

            
            bool fechaOcupada = false;
            for (int j = 0; j < contadorReservashabitacion[indiceHab]; j++)
            {
                if (ReservafechaEntrada[indiceHab, j] == fechaEntrada)
                {
                    fechaOcupada = true;
                    break;
                }
            }

            if (fechaOcupada)
            {
                Console.WriteLine("Esta habitación ya tiene una reserva en esa fecha.");
                Console.WriteLine("Presione cualquier tecla para continuar...");
                Console.ReadKey();
                return;
            }

            
            int noches;
            Console.Write("Número de noches: ");
            while (!int.TryParse(Console.ReadLine(), out noches) || noches <= 0)
            {
                Console.Write("Número inválido. Intente nuevamente: ");
            }

            
            int posReserva = contadorReservashabitacion[indiceHab];
            IdReserva[indiceHab, posReserva] = contadorReservasGlobal;
            NumReservaHabitacion[indiceHab, posReserva] = NumerodeHabitaciones[indiceHab];
            DocReservaHuesped[indiceHab, posReserva] = ingresarDocumento[indiceHuesped];
            ReservafechaEntrada[indiceHab, posReserva] = fechaEntrada;
            numNoches[indiceHab, posReserva] = noches;

            contadorReservashabitacion[indiceHab]++;
            contadorReservasGlobal++;

            
            decimal total = PrecioPorNoche[indiceHab] * noches;

            Console.WriteLine("Reserva creada exitosamente!");
            Console.WriteLine($"Reserva #{IdReserva[indiceHab, posReserva]}");
            Console.WriteLine($"Habitación: #{NumerodeHabitaciones[indiceHab]} - {TipoDeHabitaciones[indiceHab]}");
            Console.WriteLine($"Huésped: {ingresarNombre[indiceHuesped]}");
            Console.WriteLine($"Fecha de entrada: {fechaEntrada}");
            Console.WriteLine($"Noches: {noches}");
            Console.WriteLine($"Total: ${total}");

            Console.WriteLine("Presione cualquier tecla para continuar");
            Console.ReadKey();
        }

        static void VerReserva()
        {
            Console.Clear();
            Console.WriteLine("Reservas por Habitacion");

            int numHab;
            Console.Write("Ingrese el número de habitación: ");
            while (!int.TryParse(Console.ReadLine(), out numHab))
            {
                Console.Write("Número inválido. Intente de nuevo: ");
            }


            int indiceHab = -1;
            for (int i = 0; i < contadorHabitaciones; i++)
            {
                if (NumerodeHabitaciones[i] == numHab)
                {
                    indiceHab = i;
                    break;
                }
            }

            if (indiceHab == -1)
            {
                Console.WriteLine("Habitación no encontrada.");
            }
            else if (contadorReservashabitacion[indiceHab] == 0)
            {
                Console.WriteLine($"No hay reservas para la habitación #{numHab}.");
            }
            else
            {
                Console.WriteLine($"Reservas de la habitación #{numHab}:");


                for (int j = 0; j < contadorReservashabitacion[indiceHab]; j++)
                {

                    string nombreHuesped = "";
                    for (int k = 0; k < contadorHuespedes; k++)
                    {
                        if (ingresarDocumento[k] == DocReservaHuesped[indiceHab, j])
                        {
                            nombreHuesped = ingresarNombre[k];
                            break;
                        }
                    }

                    decimal total = PrecioPorNoche[indiceHab] * numNoches[indiceHab, j];

                    Console.WriteLine($"- Reserva #{IdReserva[indiceHab, j]} -");
                    Console.WriteLine($"Habitación: #{NumReservaHabitacion[indiceHab, j]}");
                    Console.WriteLine($"Huésped: {nombreHuesped}");
                    Console.WriteLine($"Fecha de entrada: {ReservafechaEntrada[indiceHab, j]}");
                    Console.WriteLine($"Número de noches: {numNoches[indiceHab, j]}");
                    Console.WriteLine($"Total: ${total}");
                }
            }

            Console.WriteLine("Presione cualquier tecla para continuar");
            Console.ReadKey();
        }

        static void VerHistorialReservas()
        {
            Console.Clear();
            Console.WriteLine("Historial de Reservas Por Huesped");

            Console.Write("Ingrese el documento del huésped: ");
            string documento = Console.ReadLine();


            int indiceHuesped = -1;
            for (int i = 0; i < contadorHuespedes; i++)
            {
                if (ingresarDocumento[i] == documento)
                {
                    indiceHuesped = i;
                    break;
                }
            }

            if (indiceHuesped == -1)
            {
                Console.WriteLine("Huésped no encontrado.");
            }
            else
            {
                Console.WriteLine($"Historial de reservas de {ingresarNombre[indiceHuesped]}:");
                bool tieneReservas = false;


                for (int i = 0; i < contadorHabitaciones; i++)
                {
                    for (int j = 0; j < contadorReservashabitacion[i]; j++)
                    {
                        if (DocReservaHuesped[i, j] == documento)
                        {
                            decimal total = PrecioPorNoche[i] * numNoches[i, j];

                            Console.WriteLine($"- Reserva #{IdReserva[i, j]} -");
                            Console.WriteLine($"Habitación: #{NumReservaHabitacion[i, j]}");
                            Console.WriteLine($"Huésped: {ingresarNombre[indiceHuesped]}");
                            Console.WriteLine($"Fecha de entrada: {ReservafechaEntrada[i, j]}");
                            Console.WriteLine($"Número de noches: {numNoches[i, j]}");
                            Console.WriteLine($"Total: ${total}");
                            tieneReservas = true;
                        }
                    }
                }

                if (!tieneReservas)
                {
                    Console.WriteLine("No hay reservas para este huésped.");
                }
            }


            Console.WriteLine("Presione cualquier tecla para continuar");
            Console.ReadKey();
        }



        static void CancelarReserva()
        {
            Console.Clear();
            Console.WriteLine("Cancelar Reserva");

            int numHab;
            Console.Write("Ingrese el número de habitación: ");
            while (!int.TryParse(Console.ReadLine(), out numHab))
            {
                Console.Write("Número inválido. Intente de nuevo: ");
            }

            Console.Write("Ingrese el documento del huésped: ");
            string documento = Console.ReadLine();


            int indiceHab = -1;
            for (int i = 0; i < contadorHabitaciones; i++)
            {
                if (NumerodeHabitaciones[i] == numHab)
                {
                    indiceHab = i;
                    break;
                }
            }

            if (indiceHab == -1)
            {

            }
        }



    }
}

