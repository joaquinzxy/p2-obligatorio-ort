using Dominio;

namespace Dominio
{
    public class Peon : Empleado
    {
        bool EsResidente;
        List<Tarea> tareas;

        public bool EsResidente1 { get => EsResidente; set => EsResidente = value; }
        internal List<Tarea> Tareas { get => tareas;} // saque set para que no vaguee

        public Peon()
        {
        }

        public Peon(string Nombre, string Email, string Password, DateTime Ingreso, bool esResidente) : base(Nombre,Email, Password, Ingreso)
        {
            EsResidente = esResidente;
            this.tareas = new List<Tarea>();
        }
        
        public void AsignarTarea(Tarea tarea)
        {
            tareas.Add(tarea);
        }

        public override void Validar()
        {
            base.Validar();
            if(EsResidente == null) throw new Exception("El peon debe ser residente o no");
        }

        public override string ToString()
        {
            return $"{base.ToString()}";
        }
    }
}