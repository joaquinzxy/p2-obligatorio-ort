using Dominio.enums;

namespace Dominio;

public class Ovino : Ganado
{
    private static float precioKgPie;
    private static float precioKgLana;
    private float pesoLana;

    public Ovino(string codCaravan, DateTime fechaNacimiento, float costoAdquisicion, float costoAlimentacion, TipoSexo sexo, float peso, bool esHibrido, string raza, float pesoLana) : base(codCaravan, fechaNacimiento, costoAdquisicion, costoAlimentacion, sexo, peso, esHibrido, raza)
    {
        this.pesoLana = pesoLana;
    }

    public static float PrecioKgPie
    {
        get => precioKgPie;
        set => precioKgPie = value;
    }

    public static float PrecioKgLana
    {
        get => precioKgLana;
        set => precioKgLana = value;
    }

    public float PesoLana
    {
        get => pesoLana;
        set => pesoLana = value;
    }

    public override void Validar()
    {
        base.Validar();
        if(pesoLana < 0) throw new Exception("El peso de la lana no puede ser negativo");
    }
}