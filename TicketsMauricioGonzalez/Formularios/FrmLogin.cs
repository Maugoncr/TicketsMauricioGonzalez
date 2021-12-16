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

        static int contador = 0;
        static Keys[] vector = {Keys.None, Keys.None, Keys.None, Keys.None, Keys.None, Keys.None, Keys.None, Keys.None, Keys.None, Keys.None};
        static Keys[] vector1 = {Keys.Up, Keys.Up, Keys.Down, Keys.Down, Keys.Left, Keys.Right, Keys.Left, Keys.Right, Keys.A, Keys.B};

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
            Logica.Models.Bitacora MiBitacora = new Logica.Models.Bitacora();


            if (ValidarDatos())
            {
                // TODO: Hay que validar que el usuario y la contraseña sean 
                // correctos antes de mostrar el Frm Principal

                Logica.Models.Usuario MiUsuarioValidado = new Logica.Models.Usuario();

                MiUsuarioValidado = MiUsuarioValidado.ValidarIngreso(txtEmail.Text.Trim(), txtPassword.Text.Trim());

                if (MiUsuarioValidado != null && MiUsuarioValidado.IDUsuario > 0)
                {
                    string accion = "El usuario: " + txtEmail.Text.Trim() + " ingreso al sistema con exito!";

                    MiBitacora.GuardarAccionBitacora(accion, MiUsuarioValidado.IDUsuario);

                    Commons.ObjetosGlobales.MiUsuarioDeSistema = MiUsuarioValidado;
                    //muestro el objeto global del FrmMain
                    Commons.ObjetosGlobales.MiFormPrincipal.Show();
                    // Oculto (no destruyo) el form global
                    this.Hide();
                }
                else {

                    MessageBox.Show("Usuario o Contraseña Incorrecto", "Error de Validacion", MessageBoxButtons.OK);
                    string accion = "Se intento ingresar al sistema de manera fallida con el usuario: " + txtEmail.Text.Trim();
                    MiBitacora.GuardarAccionBitacora(accion);
                }
            }
            else
            {
                string accion = "Se intento ingresar al sistema de manera fallida con el usuario: " + txtEmail.Text.Trim();
                MiBitacora.GuardarAccionBitacora(accion);
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

            // Crear un contador static que se vaya incrementando a como vaya pasando if
            // crear un if donde valide un vector con [contador] con la combinacion exacta de teclas
            // if que espere arriba, arriba, abajo, abajo, iz, derecha, iz, derecha, a, b
            // si alguno de los if no se cumple ya sea que caiga antes o en el medio recurrir a la funcion que limpie el vector y regrese el contador = 0

            //ValidarTeclas(e);

        }

        private void LblRecuperarContrasennia_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

            Commons.ObjetosGlobales.FormularioRecuperacionContrasennia.txtUsuario.Text = this.txtEmail.Text.Trim();

            Commons.ObjetosGlobales.FormularioRecuperacionContrasennia.Show();

        }

        private void FrmLogin_Load(object sender, EventArgs e)
        {

        }

        private void ValidarTeclas(KeyEventArgs e)
        {
            
            FrmLogin.vector[contador] = e.KeyCode;

            if (vector[9] != Keys.None)
            {
                if (vector[0] == Keys.Up)
                {
                    

                    if (vector[1] == Keys.Up)
                    {
                       
                        if (vector[2] == Keys.Down)
                        {
                            
                            if (vector[3] == Keys.Down)
                            {
                                
                                if (vector[4] == Keys.Left)
                                {
                                    
                                    if (vector[5] == Keys.Right)
                                    {
                                     
                                        if (vector[6] == Keys.Left)
                                        {
                                          
                                            if (vector[7] == Keys.Right)
                                            {
                                                
                                                if (vector[8] == Keys.A)
                                                {
                                                 
                                                    if (vector[9] == Keys.B)
                                                    {
                                                        BtnIngresoDirecto.Visible = true;
                                                    }
                                                    else
                                                    {
                                                        Reset();
                                                    }
                                                }
                                                else
                                                {
                                                    Reset();
                                                }
                                            }
                                            else
                                            {
                                                Reset();
                                            }
                                        }
                                        else
                                        {
                                            Reset();
                                        }
                                    }
                                    else
                                    {
                                        Reset();
                                    }
                                }
                                else
                                {
                                    Reset();
                                }
                            }
                            else
                            {
                                Reset();
                            }
                        }
                        else
                        {
                            Reset();
                        }
                    }
                    else
                    {
                        Reset();
                    }
                }
                else
                {
                    Reset();
                }
            }
            else
            {
                contador++;
            }

         

        }


            private void Reset() {

             contador = 0;
             vector[0] = Keys.None;
             vector[1] = Keys.None;
             vector[2] = Keys.None;
             vector[3] = Keys.None;
             vector[4] = Keys.None;
             vector[5] = Keys.None;
             vector[6] = Keys.None;
             vector[7] = Keys.None;
             vector[8] = Keys.None;
             vector[9] = Keys.None;
        }

        private void FrmLogin_KeyUp(object sender, KeyEventArgs e)
        {

            ValidarTeclas(e);

        }
    }
}
