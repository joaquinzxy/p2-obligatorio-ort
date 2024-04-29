using Dominio;
using Dominio.enums;

namespace Aplicacion;

public class Program
{
        static Sistema sistema = Sistema.Instancia; 
        static void Main(string[] args)
        {
            int opcion = 0;
            string[] opciones = { "Listar Animales", "Mostrar Potreros", "Precio por kilo de lana", "Alta de ganado Bovino"};
            do
            {
                Menu(opciones);
                opcion = LeerNumero();
                switch (opcion)
                {
                    case 1:
                        //use listarAnimales
                        ListarAnimales();
                        break;

                    case 2:
                        //use ObtenerPotreroSegunHectareas
                        break;
                    case 3:
                        PrecioKiloLana();
                        break;
                    case 4:
                        AltaDeGanadoBovino();
                        break;
                }

            } while (opcion != 0);

        }

        static void Menu(string[] opciones)
        {
            int numero = 1;
            Console.Clear();
            Console.WriteLine("Ingrese una de las siguientes opciones (0 para terminar)");
            foreach (string opcion in opciones)
            {
                Console.WriteLine($"{numero} - {opcion} ");
                numero++;
            }
        }
    public static void ListarAnimales()
    {
        Console.WriteLine("Listado de animales:");
        List<Ganado> lista = sistema.ListarGanado();
        if(lista.Count > 0)
        {
            foreach (Ganado unGanado in lista)
            {
                Console.WriteLine("=========================");
                Console.WriteLine(unGanado.ToString());
                Console.WriteLine("=========================");
            }
        }
        else
        {
            Console.WriteLine("No hay animales");
        }
        Console.WriteLine("Enter para continuar");
        Console.ReadLine();
    }



    public static void ObtenerPotreroSegunHectareas()
    {
        Console.WriteLine("Ingrese cantidad de hectáreas y capacidad");
        float cantidadhectareas = Convert.ToSingle(Console.ReadLine());
        int capacidad = Convert.ToInt32(Console.ReadLine());
        List<Potrero> lista = sistema.ObtenerPotreroSegunHectareas(cantidadhectareas,capacidad);
        foreach (Potrero unPotrero in lista)
        {
            Console.WriteLine(unPotrero.ToString());
        }
        Console.WriteLine("Enter para continuar");
        Console.ReadLine();
    }


    public static void PrecioKiloLana()
    {
        Console.WriteLine("Ingrese el precio de la lana");
        float precio = Convert.ToSingle(Console.ReadLine());
        sistema.DefinirPrecioKgLana(precio);
        Console.WriteLine("Enter para continuar");
        Console.ReadLine();
    }

    public static void AltaDeGanadoBovino()
    {
        try
        {
            Console.WriteLine("Ingrese código de caravana, fecha de nacimiento, costo de adquisición" +
                              "costo de alimentación, sexo, peso, si es hibrido, raza y alimentación ");
            string codCaravana = PedirTexto("Ingrese código de caravana");
            DateTime fechaNacimiento = Convert.ToDateTime(PedirTexto("Ingrese fecha de nacimiento: "));
            float costoAdquisicion = Convert.ToSingle(PedirTexto("Ingrese costo de adquisición: "));
            float costoAlimentacion = Convert.ToSingle(PedirTexto("Ingrese costo de alimentación: "));
            float peso = Convert.ToSingle(PedirTexto("Ingrese peso: "));
            string raza = PedirTexto("Ingrese raza: ");
            //int tipoAlimentacion = 1;
            sistema.AltaBovino(codCaravana,fechaNacimiento,costoAdquisicion,costoAlimentacion,TipoSexo.Macho,peso,false,raza, TipoAlimentacion.Grano);

            Console.WriteLine("Enter para continuar");
            Console.ReadLine();
        }
        catch (Exception e)
        {
            Console.WriteLine("Ocurrio un error al registrar bovino");
            Console.WriteLine(e.Message);
            Console.WriteLine("Enter para continuar");
            Console.ReadLine();
        }
    }

    static int LeerNumero()
    {
        int opcion;
        Console.Write("Ingrese número:");
        while (!(int.TryParse(Console.ReadLine(), out opcion)))
        {
            Console.WriteLine("El valor ingresado no es correcto");
            Console.Write("Ingrese número:");
        }
        return opcion;
    }

    static string? PedirTexto(string mensaje = "Ingrese número.")
    {
        bool exito;
        string? valor;
        do
        {
            Console.Write(mensaje);
            valor = Console.ReadLine();
            if (valor == null)
            {
                MensajeError("No se ha ingresado nada");
                exito = false;
            }
            else
            {
                exito = true;
            }

        } while (!exito);
        return valor;
    }

    static void MensajeError(string mensaje)
    {
        Console.BackgroundColor = ConsoleColor.Red;
        Console.WriteLine($"---Error----> {mensaje}");
        Console.BackgroundColor = ConsoleColor.Black;
        Console.ReadLine();
    }
    static void MensajeConfirmacion(string mensaje)
    {
        Console.BackgroundColor = ConsoleColor.Green;
        Console.ForegroundColor = ConsoleColor.Black;
        Console.WriteLine($"---Confirmado----> {mensaje}");
        Console.BackgroundColor = ConsoleColor.Black;
        Console.ForegroundColor = ConsoleColor.White;
        Console.ReadLine();
    }

}