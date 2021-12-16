using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica.Models
{
    public class Bitacora
    {

        public int IdBitacora { get; set; }
        public int IDUsuario { get; set; }

        public string Accion { get; set; }


        public void GuardarAccionBitacora(string Accion, int IDUsuario = 0) 
        {

            // verificar si trae parametro en IDUsuario o no

            if (IDUsuario != 0 && !string.IsNullOrEmpty(Accion))
            {
                // si entra aqui hay id y hay accion
                Conexion MiCnn = new Conexion();

                MiCnn.ListadoDeParametros.Add(new SqlParameter("@Accion", Accion));
                MiCnn.ListadoDeParametros.Add(new SqlParameter("@IDUsuario", IDUsuario));

                int resultado = MiCnn.DMLUpdateDeleteInsert("SPGuardarAccionBitacora");

                if (resultado > 0)
                {
                    // si entra aqui significa que se agrego correctamente
                    // aunque claro esto no se deberia decir al usuario esto solo queda para mi prueba de funcionamiento

                }

            }

            // creo esto es innecesario lo usare para probar
            // valido la accion y verifico que el parametro de usuario no este
            if (IDUsuario == 0 && !string.IsNullOrEmpty(Accion))
            {
               
                Conexion MiCnn = new Conexion();

                MiCnn.ListadoDeParametros.Add(new SqlParameter("@Accion", Accion));

                int resultado = MiCnn.DMLUpdateDeleteInsert("SPGuardarAccionBitacora");

                if (resultado > 0)
                {

                }
            }
        }





    }
}
