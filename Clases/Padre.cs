using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducarWeb.Clases
{
    internal class Padre : Persona
    {
        public int NumeroPadre { get; set; }
        public string RelacionConAlumno { get; set; }

        public Padre(string nombre, string apellido, string email, int numeroPadre, string relacionConAlumno)
            : base(nombre, apellido, email)
        {
            NumeroPadre = numeroPadre;
            RelacionConAlumno = relacionConAlumno;
        }
    }
}
