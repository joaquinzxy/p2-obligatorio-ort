using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio.interfaces;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Dominio
{
    public class Potrero: IValidar
    {
        int id;
        public static int secuencia = 0;
        string? descripcion;
        float cantidadHectareas;
        int capacidadMaxima;
        List<Ganado> listaGanados;

        public int Id { get => id; set => id = value; }
        public string? Descripcion { get => descripcion; set => descripcion = value; }
        public float CantidadHectareas { get => cantidadHectareas; set => cantidadHectareas = value; }
        public int CapacidadMaxima { get => capacidadMaxima; set => capacidadMaxima = value; }
        public List<Ganado> ListaGanados { get => listaGanados; }

        public Potrero(){
            
        }

        public Potrero(int id, string? descripcion, float cantidadHectareas, int capacidadMaxima)
        {
            Id = secuencia++;
            Descripcion = descripcion;
            CantidadHectareas = cantidadHectareas;
            CapacidadMaxima = capacidadMaxima;
        }

        public void Validar()
        {
            if(Descripcion == null || Descripcion == "") throw new Exception("La descripcion no puede ser nula o vacia");
            if(CantidadHectareas < 0) throw new Exception("La cantidad de hectareas no puede ser negativa");
            if (CapacidadMaxima < 0) throw new Exception("La capacidad maxima no puede ser negativa");
            if (id == null) throw new Exception("El id no puede ser nulo");
        }

        private float CalcularGanancias()
        {
            throw new NotImplementedException();
        }

        private bool ListaNoSupereCapacidadMaxima()
        {
            return false;
        }

        private float CostoTotal()
        {
            return 0;
        }



        public override string ToString()
        {
            return $" {Id} {Descripcion} {CantidadHectareas} {CapacidadMaxima}";
        }

        public void AsginarGanado(Ganado ganado)
        {
            try
            {
                if (ListaGanados.Count >= CapacidadMaxima) throw new Exception("No es posible asignarlo");
                listaGanados.Add(ganado);
            } catch (Exception e)
            {
                throw e;
            }
        }
    }

}