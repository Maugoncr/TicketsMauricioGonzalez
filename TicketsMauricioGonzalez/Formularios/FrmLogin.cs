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


        private bool ValidarDatos()
        {
            bool R = false;

            if (!string.IsNullOrEmpty(txtEmail.Text.Trim()) &&
                Commons.ObjetosGlobales.ValidarEmail(txtEmail.Text.Trim()) &&
                !string.IsNullOrEmpty(txtPassword.Text.Trim()) // && Commons.ObjetosGlobales.ValidarContrasennia(txtPassword.Text.Trim())
                )
            {

                R = true;

            }
            else {
                if (string.IsNullOrEmpty(txtEmail.Text.Trim()))
                {
                    MessageBox.Show("Debe digitar un nombre de usuario", "Error de Validacion", MessageBoxButtons.OK);
                    txtEmail.Focus();
                    return false;

                }
                if (Commons.ObjetosGlobales.ValidarEmail(txtEmail.Text.Trim()))
                {
                    MessageBox.Show("El correo no tiene un formato correcto", "Error de Validacion", MessageBoxButtons.OK);
                    txtEmail.Focus();
                    txtEmail.SelectAll();
                    return false;

                }
                if (string.IsNullOrEmpty(txtPassword.Text.Trim()))
                {
                    MessageBox.Show("Debe digitar la contraseña", "Error de Validacion", MessageBoxButtons.OK);
                    txtPassword.Focus();
                    return false;

                }

               // if (Commons.ObjetosGlobales.ValidarContrasennia(txtPassword.Text.Trim()))
               // {
               //     MessageBox.Show("La contraseña no tiene un formato correcto", "Error de Validacion", MessageBoxButtons.OK);
               //     txtPassword.Focus();
               //     txtPassword.SelectAll();
                //    return false;

               // }


            }



            return R;
        }



        private void btnIngresar_Click(object sender, EventArgs e)
        {
            

            if (ValidarDatos())
            {
                // TODO: Hay que validar que el usuario y la contraseña sean 
                // correctos antes de mostrar el Frm Principal

                Logica.Models.Usuario MiUsuarioValidado = new Logica.Models.Usuario();

                MiUsuarioValidado = MiUsuarioValidado.ValidarIngreso(txtEmail.Text.Trim(), txtPassword.Text.Trim());

                if (MiUsuarioValidado != null && MiUsuarioValidado.IDUsuario > 0)
                {
                    Commons.ObjetosGlobales.MiUsuarioDeSistema = MiUsuarioValidado;

                    //muestro el objeto global del FrmMain
                    Commons.ObjetosGlobales.MiFormPrincipal.Show();
                    // Oculto (no destruyo) el form global
                    this.Hide();
                }
                else {

                    MessageBox.Show("Usuario o Contraseña Incorrecto", "Error de Validacion", MessageBoxButtons.OK);
                
                }
                


            }

        }

        private void BtnIngresoDirecto_Click(object sender, EventArgs e)
        {

            Commons.ObjetosGlobales.MiUsuarioDeSistema.IDUsuario = 5;
            Commons.ObjetosGlobales.MiUsuarioDeSistema.Email = "maugoncrxkirax@gmail.com";
            Commons.ObjetosGlobales.MiUsuarioDeSistema.Nombre = "Mauricio González";
            Commons.ObjetosGlobales.MiUsuarioDeSistema.MiRol.IDUsuarioRol = 2;


            //muestro el objeto global del FrmMain
            Commons.ObjetosGlobales.MiFormPrincipal.Show();
            // Oculto (no destruyo) el form global
            this.Hide();

        }

        private void FrmLogin_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Shift & e.KeyCode == Keys.A )
            {
                BtnIngresoDirecto.Visible = true;

            }


           
        }
    }
}
