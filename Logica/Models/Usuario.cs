using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica.Models
{
    public class Usuario : ICrudBase, IPersona
    {
        public string Cedula { get; set; }
        public string Nombre { get; set; }
        public string Telefono { get; set; }
        public string Email { get; set; }
        public bool Activo { get; set; }

        public bool Agregar()
        {
            bool R = false;


            return R;
        }

        public bool Editar()
        {
            bool R = false;


            return R;
        }

        public bool Eliminar()
        {
            bool R = false;


            return R;
        }

        // adicionales

        public int IDUsuario { get; set; }

        public string CodigoRecuperacion { get; set; }

        public string Contrasennia { get; set; }

        //Composicion del rol del usuario

        public UsuarioRol MiRol { get; set; }


        // Constructor

        public Usuario()
        {
            MiRol = new UsuarioRol();
        }


        // funciones adicionales

        public bool Agregar(string cedula, string nombre, string telefono, string email, string contrasennia)
        {
            bool R = false;


            return R;
        }


        private Usuario ConsultarPorID(int ID)
        { 
            Usuario R = new Usuario();

            return R;
        }

        private bool ConsultarPorCedula(string cedula)
        {

            bool R = false;

            return R;

        }

        private bool ConsultarPorEmail( )
        {

            bool R = false;

            return R;

        }

        public DataTable Listar(bool VerActivos = true)
        {
            DataTable R = new DataTable();


            return R;
        }


        public bool EnviarCodigoRecuperacion()
        {
            bool R = false;

            return R;
        
        }



        public bool CambiarPassword(int iD, string nuevaContrasennia)
        {
            bool R = false;

            return R;

        }












    }
}
