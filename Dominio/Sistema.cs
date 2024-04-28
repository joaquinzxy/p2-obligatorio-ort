using Dominio.enums;

namespace Dominio;

public class Sistema
{
    private static Sistema instancia;
    private Empleado empleadoLogueado;
    private List<Vacuna> listaVacunas;
    private List<Ganado> listaGanado;
    private List<Empleado> listaEmpleados;
    private List<Tarea> listaTareas;

    static void Main(string[] args)
    {
        Sistema sistema = new Sistema();
        
    }
    
    #region Singleton
    public static Sistema Instancia
    {
        get
        {
            if (instancia == null)
            {
                instancia = new Sistema();
            }
            return instancia;
        }
    }
    #endregion

    #region Ganado

    public List<Ganado> ListarGanado
    {
        get => listaGanado;
    }

    public Ganado BuscarGanado(string codCaravana)
    {
        try
        {
            foreach (Ganado ganado in listaGanado)
            {
                if (ganado.CodCaravana == codCaravana)
                {
                    return ganado;
                }
            }
            return null;
        }
        catch (Exception e)
        {
            throw new Exception("Ocurrio un error al buscar el ganado");
        }
    }

    public void AltaOvino(string codCaravana, DateTime fechaNacimiento, float costoAdquisicion, float costoAlimentacion, TipoSexo sexo, float peso, bool esHibrido, string raza, float pesoLana)
    {
        try
        {
            Ovino ovino = new Ovino(codCaravana, fechaNacimiento, costoAdquisicion, costoAlimentacion, sexo, peso, esHibrido, raza, pesoLana);
            ovino.Validar();
            VerificarExistenciaGanado(ovino);
            listaGanado.Add(ovino);
        }
        catch (Exception e)
        {
            throw e;
        }
    }

    public void AltaBovino(string codCaravana, DateTime fechaNacimiento, float costoAdquisicion, float costoAlimentacion, TipoSexo sexo, float peso, bool esHibrido, string raza, TipoAlimentacion alimentacion)
    {
        try
        {
            Bovino bovino = new Bovino(codCaravana, fechaNacimiento, costoAdquisicion, costoAlimentacion, sexo, peso, esHibrido, raza, alimentacion);
            bovino.Validar();
            VerificarExistenciaGanado(bovino);
            listaGanado.Add(bovino);
        }
        catch (Exception e)
        {
            throw e;
        }
    }

    public void ModificarOvino(string codCaravana, DateTime fechaNacimiento, float costoAdquisicion, float costoAlimentacion, TipoSexo sexo, float peso, bool esHibrido, string raza, float pesoLana)
    {
        try
        {
            Ovino ovino = (Ovino)BuscarGanado(codCaravana);
            if (ovino == null)
            {
                throw new Exception("El ovino no existe");
            }
            ovino.FechaNacimiento = fechaNacimiento;
            ovino.CostoAdquisicion = costoAdquisicion;
            ovino.CostoAlimentacion = costoAlimentacion;
            ovino.Peso = peso;
            ovino.EsHibrido = esHibrido;
            ovino.Raza = raza;
            ovino.PesoLana = pesoLana;
        }
        catch (Exception e)
        {
            throw e;
        }
    }

    public void ModificarBovino(string codCaravana, DateTime fechaNacimiento, float costoAdquisicion, float costoAlimentacion, TipoSexo sexo, float peso, bool esHibrido, string raza, TipoAlimentacion alimentacion)
    {
        try
        {
            Bovino bovino = (Bovino)BuscarGanado(codCaravana);
            if (bovino == null)
            {
                throw new Exception("El bovino no existe");
            }
            bovino.FechaNacimiento = fechaNacimiento;
            bovino.CostoAdquisicion = costoAdquisicion;
            bovino.CostoAlimentacion = costoAlimentacion;
            bovino.Peso = peso;
            bovino.EsHibrido = esHibrido;
            bovino.Raza = raza;
            bovino.Alimentacion = alimentacion;
        }
        catch (Exception e)
        {
            throw e;
        }
    }

    public List<Vacunacion> ObtenerVacunacionesGanado(string codCaravana)
    {
        try
        {
            Ganado ganado = BuscarGanado(codCaravana);
            if (ganado == null)
            {
                throw new Exception("El ganado no existe");
            }
            return ganado.ListaVacunaciones;
        }
        catch (Exception e)
        {
            throw new Exception("Ocurrio un error al obtener las vacunaciones del ganado");
        }
    }

    public void AltaVacunacion(string nombreVacuna, DateTime fechaVacunacion, string codCaravana)
    {
        try
        {
            Ganado ganado = BuscarGanado(codCaravana);
            Vacuna vacuna = BuscarVacuna(nombreVacuna);

            if (ganado == null) throw new Exception("El ganado no existe");
            if (vacuna == null) throw new Exception("La vacuna no existe");

            if(fechaVacunacion < ganado.FechaNacimiento) throw new Exception("La fecha de vacunacion no puede ser anterior a la fecha de nacimiento del ganado");
            
            if (ganado.esVacunable())
            {
                ganado.AgregarVacunacion(vacuna, fechaVacunacion);
            }
            else
            {
                throw new Exception("El ganado no es vacunable");
            }
        }
        catch (Exception e)
        {
            throw e;
        }
    }
    #endregion

    #region preciosVenta
    
    public void DefinirPrecioKgPieOvino(float value)
    {
        Ovino.PrecioKgPie = value;
    }
    
    public void DefinirPrecioKgLana(float value)
    {
        Ovino.PrecioKgLana = value;
    }
    
    public void DefinirPrecioKgPieBovino(float value)
    {
        Bovino.PrecioKgPie = value;
    }
    
    #endregion

    #region Vacunas

    public List<Vacuna> ListaVacunas
    {
        get => listaVacunas;
    }

    public void AltaVacuna(string nombre, string descripcion, string patogeno)
    {
        try
        {
            Vacuna vacuna = new Vacuna(nombre, descripcion, patogeno);
            vacuna.Validar();
            VerificarExistenciaVacuna(vacuna);
            listaVacunas.Add(vacuna);
        }
        catch (Exception e)
        {
            throw e;
        }
    }

    public void ModificarVacuna(string nombre, string descripcion, string patogeno)
    {
        try
        {
            Vacuna vacuna = BuscarVacuna(nombre);
            if (vacuna == null)
            {
                throw new Exception("La vacuna no existe");
            }
            vacuna.Description = descripcion;
            vacuna.Patogeno = patogeno;
        }
        catch (Exception e)
        {
            throw e;
        }
    }

    public Vacuna BuscarVacuna(string nombreVacuna)
    {
        try
        {
            foreach (Vacuna vacuna in listaVacunas)
            {
                if (vacuna.Nombre == nombreVacuna)
                {
                    return vacuna;
                }
            }

            return null;
        }
        catch (Exception e)
        {
            throw new Exception("Ocurrio un error al buscar la vacuna");
        }
    }

    public List<Vacunacion> ObtenerVacunaciones()
    {
        try
        {
            List<Vacunacion> vacunaciones = new List<Vacunacion>();
            foreach (Ganado ganado in listaGanado)
            {
                foreach (Vacunacion vacunacion in ganado.ListaVacunaciones)
                {
                    vacunaciones.Add(vacunacion);
                }
            }
            return vacunaciones;
        }
        catch (Exception e)
        {
            throw e;
        }
    }

    #endregion

    #region Tareas

    public Tarea BuscarTarea(int id)
    {
        foreach (Tarea tarea in listaTareas)
        {
            if (id == tarea.Id)
            {
                return tarea;
            }
        }
        return null;
    }

    public void AltaTarea(string descripcion, DateTime fechaEstimada, string emailCapataz)
    {
        try
        {
            Empleado capataz = BuscarEmpleado(emailCapataz);
            if (capataz == null)
            {
                throw new Exception("El capataz no existe");
            }

            if (capataz.GetType() == typeof(Capataz))
            {
                Tarea tarea = new Tarea(descripcion, fechaEstimada, capataz as Capataz);
                tarea.Validar();
                listaTareas.Add(tarea);
            }
        }
        catch (Exception e)
        {
            throw e;
        }
    }

    public void AltaTarea(string descripcion, DateTime fechaEstimada, string emailCapataz, string emailPeon)
    {
        try
        {
            Empleado capataz = BuscarEmpleado(emailCapataz);
            Peon peon = BuscarEmpleado(emailPeon) as Peon;
            if (capataz == null)
            {
                throw new Exception("El capataz no existe");
            }

            if (capataz.GetType() != typeof(Capataz))
            {
                throw new Exception("El supervisor no es un capataz");
            }

            if (peon.GetType() != typeof(Peon))
            {
                throw new Exception("El responsable no es un peon");
            }
            
            Tarea tarea = new Tarea(descripcion, fechaEstimada, capataz as Capataz);
            tarea.Validar();
            peon.AsignarTarea(tarea);
            listaTareas.Add(tarea);
        }
        catch (Exception e)
        {
            throw e;
        }
    }

    public void AsignarTarea(string email, int id)
    {
        string minEmail = email.ToLower();
        Empleado empleado = BuscarEmpleado(email);
        Peon peon;
        if (empleado.GetType() == typeof(Peon))
        {
            peon = empleado as Peon;
        }
        else
        {
            throw new Exception("El empleado no es un peon");
        }

        Tarea tarea = BuscarTarea(id);
        if (tarea == null)
        {
            throw new Exception("La tarea no existe");
        }
        
        peon.AsignarTarea(tarea);
    }

    public List<Tarea> ListarTareas() //potencial de comprimir
    {
        return listaTareas;
    }

    public List<Tarea> ObtenerTareasPeon(string email)
    {
        try
        {
            Empleado empleado = BuscarEmpleado(email);
            Peon peon;
            if (empleado == null)
            {
                throw new Exception("Peon no encontrado");
            }
            if (empleado.GetType() == typeof(Peon))
            {
                peon = empleado as Peon;
                return peon.Tareas;
            }
            return null;
        }
        catch (Exception e)
        {
            throw e;
        }
    }

    #endregion

    #region Empleados

    public Empleado? BuscarEmpleado(string email)
    {
        string minEmail = email.ToLower();
        foreach (Empleado empleado in listaEmpleados)
        {
            if (minEmail == empleado.Email)
            {
                return empleado;
            }
        }
        return null;
    }
    
    public void AltaCapataz(string nombre, string email, string password)
    {
        try
        {
            Capataz capataz = new Capataz(nombre, email, password, DateTime.Now);
            capataz.Validar();
            VerificarExistenciaEmpleado(capataz);
            listaEmpleados.Add(capataz);
        }
        catch (Exception e)
        {
            throw e;
        }
    }

    public void AltaPeon(string nombre, string email, string password, bool esResidente)
    {
        try
        {
            Peon peon = new Peon(nombre, email, password, DateTime.Now, esResidente);
            peon.Validar();
            VerificarExistenciaEmpleado(peon);
            listaEmpleados.Add(peon);
        }
        catch (Exception e)
        {
            throw e;
        }
    }

    public void ModificarEmpleado(string email, string nombre)
    {
        try
        {
            Empleado empleado = BuscarEmpleado(email);
            if (empleado == null)
            {
                throw new Exception("El empleado no existe");
            }
            empleado.Nombre = nombre;
        }
        catch (Exception e)
        {
            throw e;
        }
    }

    public void ModicarEmpleado(string email, string nombre, bool esResidente)
    {
        try
        {
            Empleado peon = BuscarEmpleado(email);
            if (peon == null)
            {
                throw new Exception("El empleado no existe");
            }
            peon.Nombre = nombre;
            if (peon.GetType() == typeof(Peon))
            {
                // peon. = esResidente;
            }
        }
        catch (Exception e)
        {
            throw e;
        }
    }

    public void VincularPeonCapataz(string emailPeon, string emailCapataz)
    {
        try
        {

            Empleado peon = BuscarEmpleado(emailPeon);
            Empleado capataz = BuscarEmpleado(emailCapataz);

            if (peon == null || capataz == null)
            {
                throw new Exception("El empleado no existe");
            }

            if (peon.GetType() == typeof(Peon) && capataz.GetType() == typeof(Capataz))
            {
                //capataz.AsignarPeon(peon);
            }
            else
            {
                throw new Exception("El empleado no es un peon o capataz");
            }
        }
        catch (Exception e)
        {
            throw e;
        }
    }

    public void DesvincularPeonCapataz(string emailPeon, string emailCapataz)
    {
        try
        {
            Empleado peon = BuscarEmpleado(emailPeon);
            Empleado capataz = BuscarEmpleado(emailCapataz);

            if (peon == null || capataz == null)
            {
                throw new Exception("El empleado no existe");
            }

            if (peon.GetType() == typeof(Peon) && capataz.GetType() == typeof(Capataz))
            {
                //capataz.PersonasACargo.Remove(peon);
            }
            else
            {
                throw new Exception("El empleado no es un peon o capataz");
            }
        }
        catch (Exception e)
        {
            throw e;
        }
    }

    public void CambiarPassword(string email, string password)
    {
        try
        {
            Empleado empleado = BuscarEmpleado(email);
            if (empleado == null)
            {
                throw new Exception("El empleado no existe");
            }
            empleado.Password = password;
        }
        catch (Exception e)
        {
            throw e;
        }
    }
    public bool Login(string email, string password)
    {
        try
        {
            Empleado empleado = BuscarEmpleado(email);
            if (empleado == null)
            {
                throw new Exception("El empleado no existe");
            }

            if (empleado.ComprobarPassword(password))
            {
                empleadoLogueado = empleado;
                return true;
            }
            return false;
        }
        catch (Exception e)
        {
            throw new Exception("Ocurrio un error al realizar login");
        }
    }

    public List<Peon> MostrarPeonPorCapataz(string email)
    {
        Empleado empleado = BuscarEmpleado(email);
        Capataz capataz;
        if (empleado == null)
        {
            throw new Exception("Capataz no encontrado");
        }
        if (empleado.GetType() == typeof(Capataz))
        {
            capataz = empleado as Capataz;
            return capataz.PersonasACargo;
        }
        return null;
    }

    public List<Capataz> ObtenerCapatazSegunPeon(string email)//tiene potencial
    {
        try
        {
            List<Capataz> capataces = new List<Capataz>();
            foreach (Empleado empleado in listaEmpleados)
            {
                if (empleado.GetType() == typeof(Capataz))
                {
                    Capataz capataz = (Capataz)empleado;
                    foreach (Peon peon in capataz.PersonasACargo)
                    {
                        if (peon.Email == email)
                        {
                            capataces.Add(capataz);
                        }
                    }
                }
            }

            return capataces;
        }
        catch (Exception e)
        {
            throw e;
        }
    }

    
    #endregion

    #region Potrero


    #endregion

    #region Validaciones
        public void VerificarExistenciaEmpleado(Empleado nuevoEmpleado)
        {
            string minEmail= nuevoEmpleado.Email.ToLower();

            foreach ( Empleado empleado in listaEmpleados)
            {
                if (empleado.Email != null && empleado.Email.ToLower() == minEmail)
                {
                    throw new Exception("Ya está registrado");
                }
            }
        }
            
        public void VerificarExistenciaGanado(Ganado nuevoGanado)
        {
            foreach ( Ganado ganado in listaGanado)
            {
                if (ganado.CodCaravana != null && ganado.CodCaravana == nuevoGanado.CodCaravana)
                {
                    throw new Exception("Ya está registrado");
                }
            }
        }

        public void VerificarExistenciaVacuna(Vacuna nuevaVacuna)
        {
            foreach ( Vacuna vacuna in listaVacunas)
            {
                if (vacuna.Nombre != null && vacuna.Nombre == nuevaVacuna.Nombre)
                {
                    throw new Exception("Ya está registrado");
                }
            }
        }
    #endregion

    public List<Empleado> ObtenerEmpleadosGenerales()
    {
        return listaEmpleados;
    }
    
    // AltaPotrero *
    // BuscarPotrero @
    // ModificarPotrero
    // CalcularGanancia (NO IMPLEMENTAR) 
    // MostrarGanadoPotrero @
    // ObtenerPotreroSegunHectareas *
}