using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica.Models
{
    public class ClienteCategoria
    {
        // prop con doble tab y sale esto, hay varias formas de usar los atributos de una clase
        // esta es auto implementación
        public int IDClienteCategoria { get; set; }
        
        //prop full Esta otra forma es la "normal" muy usada por ejemplo java.
        // las mayus importan mucho...

        private string clienteCategoriaDescripcion;

        public string ClienteCategoriaDescripcion
        {
            get { return clienteCategoriaDescripcion; }
            set { clienteCategoriaDescripcion = value; }
        }


        // Luego de escribir los atributos seguimos con las funciones y metodos
        // ctor doble tab para hacer constructores
        /*public ClienteCategoria()
        {

        }
        */

        public DataTable Listar()
        {
            DataTable R = new DataTable();
             // aca va la funcionalidad para obtener la data desde la base de datos por medio
            // de un SP




            return R;
            
        }


    }
}
