namespace Dominio.interfaces;

public interface IComparable<T>
{
    int CompareTo(T other);
}