using Dominio.enums;

namespace Dominio;

public class Bovino : Ganado
{
    private static float precioKgPie;
    private TipoAlimentacion alimentacion;

    public Bovino(string codCaravana, DateTime fechaNacimiento, float costoAdquisicion, float costoAlimentacion, TipoSexo sexo, float peso, bool esHibrido, string raza, TipoAlimentacion alimentacion) : base(codCaravana, fechaNacimiento, costoAdquisicion, costoAlimentacion, sexo, peso, esHibrido, raza)
    {
        this.alimentacion = alimentacion;
    }

    public static float PrecioKgPie
    {
        get => precioKgPie;
        set => precioKgPie = value;
    }

    public TipoAlimentacion Alimentacion
    {
        get => alimentacion;
        set => alimentacion = value;
    }
    
    public override void Validar()
    {
        base.Validar();
        if(alimentacion != TipoAlimentacion.Grano || alimentacion != TipoAlimentacion.Pastura) throw new Exception("El bovino debe tener una alimentacion");
    }
}