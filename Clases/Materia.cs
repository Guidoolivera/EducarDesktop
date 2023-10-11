using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducarWeb.Clases
{

    internal class Materia
    {
        public string Nombre { get => Nombre; set => Nombre = value; }

        public Materia(string nombre) 
        {
            this.Nombre = nombre;
        }
    }
}
