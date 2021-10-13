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
    public partial class FrmLogin : Form
    {
        public FrmLogin()
        {
            InitializeComponent();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            // Salimos de la aplicacion

            Application.Exit();
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {

            txtPassword.UseSystemPasswordChar = false;



        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            txtPassword.UseSystemPasswordChar = true;
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            // TODO: Hay que validar que el usuario y la contraseña sean 
            // correctos antes de mostrar el Frm Principal

            //muestro el objeto global del FrmMain

            Commons.ObjetosGlobales.MiFormPrincipal.Show();


            // Oculto (no destruyo) el form global
            this.Hide();


        }
    }
}
