using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TicketsMauricioGonzalez.Commons
{
    public static class ObjetosGlobales
    {
        // Formularios de uso recurrente en el sistema
        // Si el formulario deberia verse SOLO UNA VEZ por sesion lo más
        // Conveniente es definirlo de forma estatica, y no dinamica.


        public static Form MiFormPrincipal = new  Formularios.FrmMain();

        public static Formularios.FrmUsuarioGestion FormularioGestionDeUsuarios = new Formularios.FrmUsuarioGestion();



        // Se definen los objetos (Basados en clases) que deben ser accesibles desde cualquier lugar de la app
        public static Logica.Models.Usuario MiUsuarioDeSistema = new Logica.Models.Usuario();




    }
}
