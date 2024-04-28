
using Dominio.enums;
using Dominio.interfaces;

namespace Dominio;

public abstract class Ganado : IValidar
{
    private string codCaravana;
    private DateTime fechaNacimiento;
    private float costoAdquisicion;
    private float costoAlimentacion;
    private float peso;
    private bool esHibrido;
    private string raza;
    private TipoSexo sexo;
    private List<Vacunacion> listaVacunaciones;

    protected Ganado(){}
    
    protected Ganado(string codCaravana, DateTime fechaNacimiento, float costoAdquisicion, float costoAlimentacion, TipoSexo sexo, float peso, bool esHibrido, string raza)
    {
        this.codCaravana = codCaravana;
        this.fechaNacimiento = fechaNacimiento;
        this.costoAdquisicion = costoAdquisicion;
        this.costoAlimentacion = costoAlimentacion;
        this.peso = peso;
        this.esHibrido = esHibrido;
        this.sexo = sexo;
        this.raza = raza;
        this.listaVacunaciones = new List<Vacunacion>();
    }

    public string CodCaravana
    {
        get => codCaravana;
        set => codCaravana = value;
    }

    public DateTime FechaNacimiento
    {
        get => fechaNacimiento;
        set => fechaNacimiento = value;
    }

    public float CostoAdquisicion
    {
        get => costoAdquisicion;
        set => costoAdquisicion = value;
    }

    public float CostoAlimentacion
    {
        get => costoAlimentacion;
        set => costoAlimentacion = value;
    }

    public float Peso
    {
        get => peso;
        set => peso = value;
    }

    public bool EsHibrido
    {
        get => esHibrido;
        set => esHibrido = value;
    }

    public string Raza
    {
        get => raza;
        set => raza = value;
    }

    public List<Vacunacion> ListaVacunaciones
    {
        get => listaVacunaciones;
    }

    public void AgregarVacunacion(Vacuna vacuna, DateTime fechaVacunacion)
    {
        listaVacunaciones.Add(new Vacunacion(vacuna, fechaVacunacion));
    }
    
    public bool esVacunable()
    {
        return DateTime.Now >= this.fechaNacimiento.AddMonths(3);
    }

    public virtual void Validar()
    {
        if(costoAdquisicion < 0) throw new Exception("El costo de adquisicion no puede ser negativo");
        if(costoAlimentacion < 0) throw new Exception("El costo de alimentacion no puede ser negativo");
        if(peso < 0) throw new Exception("El peso no puede ser negativo");
        if(string.IsNullOrEmpty(raza)) throw new Exception("La raza no puede ser nula o vacia");
        if (string.IsNullOrEmpty(codCaravana)) throw new Exception("El codigo de caravana no puede ser nulo o vacio");
    }
}