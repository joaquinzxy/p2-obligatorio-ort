using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Dominio
{
    public class Tarea
    {
        int id;
        static int secuendiaId = 0;
        string descripcion;
        DateTime finalizacionEstimada;
        bool tareaFinalizada;
        DateTime fechaDeFinalizacion;
        string? comentarioSobreTarea;
        DateTime fechaPactada;
        private Capataz supervisor;
        string emailResponsable;

        public int Id { get => id; }
        public string EmailResponsable { get => emailResponsable; }
        public Capataz Supervisor { get => supervisor; }
        public string Descripcion { get => descripcion; set => descripcion = value; }
        public DateTime FinalizacionEstimada { get => finalizacionEstimada; set => finalizacionEstimada = value; }
        public bool TareaFinalizada { get => tareaFinalizada; set => tareaFinalizada = value; }
        public DateTime FechaDeFinalizacion { get => fechaDeFinalizacion; set => fechaDeFinalizacion = value; }
        public string? ComentarioSobreTarea { get => comentarioSobreTarea; set => comentarioSobreTarea = value; }

        public Tarea()
        {

        }
        
        public Tarea(string descripcion, DateTime fechaEstimadaFin, Capataz supervisor, string email)
        {
            id = secuendiaId++;
            Descripcion = descripcion;
            Descripcion = descripcion;
            FinalizacionEstimada = fechaEstimadaFin;
            TareaFinalizada = false;
            this.supervisor = supervisor;
            this.emailResponsable = email;
        }

        public Tarea(string descripcion, DateTime fechaEstimadaFin, Capataz supervisor, string email,  bool estaFinalizada, DateTime fechaFinalizacion, string comentario)
        {
            id = secuendiaId++;
            Descripcion = descripcion;
            FinalizacionEstimada = fechaEstimadaFin;
            TareaFinalizada = estaFinalizada;
            FechaDeFinalizacion = fechaFinalizacion;
            ComentarioSobreTarea = comentario;
            this.supervisor = supervisor;
            this.emailResponsable = email;
        }

        public void CerrarTarea(string comentario)
        {
            if(tareaFinalizada) throw new Exception("La tarea ya esta finalizada");
            TareaFinalizada = true;
            ComentarioSobreTarea = comentario;
            FechaDeFinalizacion = new DateTime();
        }
        
        public void Validar()
        {

        }
        public override string ToString()
        {
            return $" {Id} {Descripcion} {FinalizacionEstimada} {TareaFinalizada} {FechaDeFinalizacion} {ComentarioSobreTarea}";
        }
    }

}