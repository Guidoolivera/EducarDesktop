using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducarWeb.Clases
{
    internal class Alumno : Persona
    {
        public int Legajo { get; set; }
        public string Carrera { get; set; }

        public Alumno(string nombre, string apellido, string email, int numeroMatricula, string carrera)
            : base(nombre, apellido, email)
        {
            Legajo = numeroMatricula;
            Carrera = carrera;
        }
    }
}
