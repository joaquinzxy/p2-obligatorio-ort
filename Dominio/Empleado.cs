using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio.interfaces;

namespace Dominio
{
    public abstract class Empleado : interfaces.IComparable<Empleado>, IValidar
    {
        string? nombre;
        string? email;
        string? password;
        DateTime ingreso = new DateTime();

        public string? Nombre { get => nombre; set => nombre = value; }
        public string? Email { get => email; set => email = value; }
        public string? Password { set => password = value; }
        public DateTime Ingreso { get => ingreso; set => ingreso = value; }

        protected Empleado() {

        }

        protected Empleado(string? nombre, string? email, string? password, DateTime ingreso) 
        {
            Nombre = nombre;
            Email = email;
            Password = password;
            Ingreso = ingreso;
        }

        public virtual void Validar()
        {
            if(nombre == null || nombre == "") throw new Exception("El nombre no puede ser nulo o vacio");
            if(email == null || email == "") throw new Exception("El email no puede ser nulo o vacio");
            if(password == null || password == "") throw new Exception("El password no puede ser nulo o vacio");
            if(ingreso == null) throw new Exception("La fecha de ingreso no puede ser nula");
            ValidadContraseña();
        }

        private void ValidadContraseña()
        {
            if (password.Length < 8) throw new Exception("La contraseña debe tener al menos 8 caracteres");
            bool tieneMayus = false;
            bool tieneMinus = false;
            bool tieneNum = false;
            bool tieneSimbolo = false;
            foreach (char c in password)
            {
                if (char.IsUpper(c)) tieneMayus = true;
                if (char.IsLower(c)) tieneMinus = true;
                if (char.IsDigit(c)) tieneNum = true;
                if (char.IsSymbol(c) || char.IsPunctuation(c)) tieneSimbolo = true;
            }
            if (!tieneMayus || !tieneMinus || !tieneNum || !tieneSimbolo) throw new Exception("La contraseña debe tener al menos una mayuscula, una minuscula, un numero y un simbolo");
        }
        
        public bool ComprobarPassword(string password)
        {
            return this.password == password;
        }

        public override string ToString()
        {
            return $" {Nombre} {Email} {this.password} {Ingreso}" ;
        }
        
        public int CompareTo(Empleado? empleado)
        {
            if (empleado == null) return 1;
            return Email.CompareTo(empleado.Email);
        }


        // Lanzar excepciones
    }
}