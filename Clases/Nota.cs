using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducarWeb.Clases
{
    internal class Nota
    {
        private int id;
        private int calificacion;
        private DateTime fecha;
        private int materia;
        private int personal;

        public int Id { get => id; set => id = value; }
        public int Calificacion { get => calificacion; set => calificacion = value; }
        public DateTime Fecha { get => fecha; set => fecha = value; }
        public int Materia { get => materia; set => materia = value; }
        public int Personal { get => personal; set => personal = value; }
    }
    
}
