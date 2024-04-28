using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Capataz : Empleado
    {
      
        List<Peon> personasACargo;

        public List<Peon> PersonasACargo { get => personasACargo; set => personasACargo = value; }


        public Capataz() {
        
        }

        public Capataz(string Nombre, string Email, String Password, DateTime Ingreso) 
            : base(Nombre, Email, Password, Ingreso)
        {
           
            this.personasACargo = new List<Peon>();
        }
        
        public void AsignarPeon(Peon peon)
        {
            personasACargo.Add(peon);
        }
        
        public override string ToString()
        {
            return $"{base.ToString()}";
        }
    }
}