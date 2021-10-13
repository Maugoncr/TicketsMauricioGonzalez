using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica.Models
{
   public class UsuarioRol : ICrudBase
    {

        public int IDUsuarioRol { get; set; }
        public string UsuarioRolDescripcion { get; set; }

        // estas funciones deben cumplir con el contrato escrito en la inteface ICrudBase

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

        // Las siguientes funciones son las especificas de la clase que No estan en ICrudBase
        // O sea no son comunes para más de una clase.

        bool ConsultarPorID()
        {
            bool R = false;


            return R;
         }

        bool ConsultarPorNombre()
        {
            bool R = false;


            return R;


        }


        DataTable Listar() 
        {
            DataTable R = new DataTable();

            //SEQ: SDUsuarioRolListar


            return R;

         }


    }
}
