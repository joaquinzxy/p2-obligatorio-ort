using Dominio;

namespace Aplicacion;

public class Program
{
        Sistema sistema = new Sistema(); 
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
                        ListarTodos();
                        break;

                    case 2:
                        ListarEstudiantes();
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
    static void ListarAnimales()
    {
        List<Ganado> lista = sistema.ListarGanado();
        foreach (Ganado unGanado in Ganado)
        {
            Console.WriteLine(unGanado.ToString());
        }
        Console.WriteLine("Enter para continuar");
        Console.ReadLine();
    }



    static void ObtenerPotreroSegunHectareas(float cantidadhectareas, int capacidad)
    {
        Console.WriteLine("Ingrese cantidad de hectáreas y capacidad");
        List<Potrero> lista = sistema.ObtenerPotreroSegunHectareas(cantidadhectareas,capacidad);
        foreach (Potrero unPotrero in potreros)
        {
            Console.WriteLine(unPotrero.ToString());
        }
        Console.WriteLine("Enter para continuar");
        Console.ReadLine();
    }


    static void PrecioKiloLana(float precio)
    {
        Console.WriteLine("Ingrese el precio de la lana");
        List<Ganado> lista = sistema.DefinirPrecioKgLana(precio);
        foreach (Ganado unGanado in listaGanado)
        {
            Console.WriteLine(unGanado.ToString());
        }
        Console.WriteLine("Enter para continuar");
        Console.ReadLine();
    }

    static void AltaDeGanadoBovino(string codCaravana, DateTime fechaNacimiento, float costoAdquisicion, float costoAlimentacion, TipoSexo sexo, float peso, bool esHibrido, string raza, TipoAlimentacion alimentacion)
    {
        Console.WriteLine("Ingrese código de caravana, fecha de nacimiento, costo de adquisición" +
            "costo de alimentación, sexo, peso, si es hibrido, raza y alimentación ");

        List<Ganado> lista = sistema.AltaBovino(codCaravana,fechaNacimiento,costoAdquisicion,costoAlimentacion,sexo,peso,esHibrido,raza,alimentacion);

        Console.WriteLine("Enter para continuar");
        Console.ReadLine();
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
}