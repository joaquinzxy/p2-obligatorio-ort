namespace Dominio;

public class Vacunacion
{
    private Vacuna vacuna;
    private DateTime fechaVacunacion;
    
    public Vacunacion(Vacuna vacuna, DateTime fechaVacunacion)
    {
        this.vacuna = vacuna;
        this.fechaVacunacion = fechaVacunacion;
    }

    public DateTime getFechaVencimiento()
    {
        return this.fechaVacunacion.AddMonths(3);
    } 
}