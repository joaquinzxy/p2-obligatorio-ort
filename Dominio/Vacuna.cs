using Dominio.interfaces;

namespace Dominio;

public class Vacuna : IValidar
{
    private string nombre;
    private string description;
    private string patogeno;

    public Vacuna(string nombre, string description, string patogeno)
    {
        this.nombre = nombre;
        this.description = description;
        this.patogeno = patogeno;
    }

    public string Nombre
    {
        get => nombre;
        set => nombre = value;
    }

    public string Description
    {
        get => description;
        set => description = value;
    }

    public string Patogeno
    {
        get => patogeno;
        set => patogeno = value;
    }
    
    public void Validar()
    {
        if (string.IsNullOrEmpty(nombre))
        {
            throw new Exception("El nombre de la vacuna no puede ser nulo o vacio");
        }
        if (string.IsNullOrEmpty(description))
        {
            throw new Exception("La descripcion de la vacuna no puede ser nulo o vacio");
        }
        if (string.IsNullOrEmpty(patogeno))
        {
            throw new Exception("El patogeno de la vacuna no puede ser nulo o vacio");
        }
    }
    
    public override string ToString()
    {
        return $"Nombre: {nombre}, Descripcion: {description}, Patogeno: {patogeno}";
    }
}