using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio.interfaces;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Dominio
{
    internal class Potrero: IValidar
    {
        int id;
        public static int secuencia = 0;
        string? descripcion;
        float cantidadHectareas;
        int capacidadMaxima;

        public int Id { get => id; set => id = value; }
        public string? Descripcion { get => descripcion; set => descripcion = value; }
        public float CantidadHectareas { get => cantidadHectareas; set => cantidadHectareas = value; }
        public int CapacidadMaxima { get => capacidadMaxima; set => capacidadMaxima = value; }


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
    }

}