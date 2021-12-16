using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TicketsMauricioGonzalez.Formularios
{
    public partial class FrmMain : Form
    {
        public FrmMain()
        {
            InitializeComponent();
        }

        private void TmrHora_Tick(object sender, EventArgs e)
        {
            LblHora.Text = DateTime.Now.ToLongDateString() + " " + DateTime.Now.ToLongTimeString();
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            TmrHora.Enabled = true;

            LblUsuarioLogueado.Text = Commons.ObjetosGlobales.MiUsuarioDeSistema.Email;
        }

        private void FrmMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            //TODO: Analizar si queremos hacer un logout cuando cerramos el principal
            Logica.Models.Bitacora bitacora = new Logica.Models.Bitacora();

            string accion = "Se cerro el sistema con el usuario: " + Commons.ObjetosGlobales.MiUsuarioDeSistema.Email;

            bitacora.GuardarAccionBitacora(accion, Commons.ObjetosGlobales.MiUsuarioDeSistema.IDUsuario);

            Application.Exit();


        }

        private void gestionDeUsuariosToolStripMenuItem_Click(object sender, EventArgs e)
        {

            // Mostramos el formulario global de gestion de usuarios
            Commons.ObjetosGlobales.FormularioGestionDeUsuarios = new FrmUsuarioGestion();

            Commons.ObjetosGlobales.FormularioGestionDeUsuarios.Show();




        }

        private void creacionDeTicketToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Commons.ObjetosGlobales.FormCrearTicket = new FrmTicketCrear();
            Commons.ObjetosGlobales.FormCrearTicket.Show();


        }

        private void solucionDeTicketToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Commons.ObjetosGlobales.FormAtencion = new FrmAtencionDeTickets();
            Commons.ObjetosGlobales.FormAtencion.Show();
        }
    }
}
