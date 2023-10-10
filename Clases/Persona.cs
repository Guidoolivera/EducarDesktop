using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducarWeb.Clases
{
    internal class Persona
    {
        public long Id { get; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Username { get; }
        public string Email { get; set; }
        public string Rol { get; set; }

        public Persona(long idUsuario, string nombreUsuario, string apellidoUsuario, string username, string emailUsuario,string rol)
        {
            Id = idUsuario;
            Nombre = nombreUsuario;
            Apellido = apellidoUsuario;
            Username = username;
            Email = emailUsuario;
            Rol = rol;
        }

        public Persona(string nombre, string apellido, string email)
        {
            Nombre = nombre;
            Apellido = apellido;
            Email = email;
        }
    }
}
