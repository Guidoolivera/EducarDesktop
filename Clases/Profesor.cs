using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducarWeb.Clases
{
    internal class Profesor : Persona
    {
        public int NumeroProfesor { get; set; }
        public List<Materia> Materias { get; set; }

        public Profesor(string nombre, string apellido, string email, int numeroProfesor, List<Materia> materias)
            : base(nombre, apellido, email)
        {
            NumeroProfesor = numeroProfesor;
            Materias = materias;
        }
    }
}
