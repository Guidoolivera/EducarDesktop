using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducarWeb.Clases
{
    internal class Autoridad : Persona
    {
        public string Cargo { get; set; }

        public Autoridad(string nombre, string apellido, string email, string cargo)
            : base(nombre, apellido, email)
        {
            Cargo = cargo;
        }
    }
}
