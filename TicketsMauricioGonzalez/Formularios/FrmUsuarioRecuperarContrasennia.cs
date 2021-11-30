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
    public partial class FrmUsuarioRecuperarContrasennia : Form
    {

        public Logica.Email MyEmail { get; set; }
        public Logica.Models.Usuario MyUser { get; set; }




        public FrmUsuarioRecuperarContrasennia()
        {
            InitializeComponent();

            MyEmail = new Logica.Email();
            MyUser = new Logica.Models.Usuario();




        }

        private void FrmUsuarioRecuperarContrasennia_Load(object sender, EventArgs e)
        {
            txtCodigoEnviado.Enabled = false;
            txtPass1.Enabled = false;
            txtPass2.Enabled = false;
            BtnAceptar.Enabled = false;

            txtCodigoEnviado.Clear();
            txtPass1.Clear();
            txtPass2.Clear();


        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void btnEnviarCodigo_Click(object sender, EventArgs e)
        {

            try
            {
                this.Cursor = Cursors.WaitCursor;
                if (!string.IsNullOrEmpty(txtUsuario.Text.Trim()) &&
                Commons.ObjetosGlobales.ValidarEmail(txtUsuario.Text.Trim()))
                {

                    MyUser.Email = txtUsuario.Text.Trim();

                    if (MyUser.ConsultarPorEmail())
                    {
                        // Si el correo existe para un usuario activo se procede a enviar el correo con un
                        //codigo de verificacion que el usuario debera digitar para comprobar que sea el

                        //Este codigo se deberia generar aleatoriamente.
                        // TO DO: ???

                         string CodigoVerificacion = GenerarCode();


                        if (MyUser.EnviarCodigoRecuperacion(CodigoVerificacion))
                        {
                            // Se procede a enviar el correo al usuario con el codigo

                            MyEmail.Asunto = "Su código de Recuperación de contraseña de Tickets Progra 5 2021-3";

                            MyEmail.CorreoDestino = MyUser.Email;

                            string Mensaje = string.Format("Su código de recuperación de contraseña es: {0}", CodigoVerificacion);

                            MyEmail.Mensaje = Mensaje;

                            if (MyEmail.EnviarCorreo_Net_Mail_SmtpClient())
                            {
                                MessageBox.Show("Correo enviado correctamente", ":)", MessageBoxButtons.OK);

                                txtCodigoEnviado.Enabled = true;
                                txtPass1.Enabled = true;
                                txtPass2.Enabled = true;
                                BtnAceptar.Enabled = true;

                            }
                            else
                            {
                                MessageBox.Show("El correo no se pudo enviar!", ":(", MessageBoxButtons.OK);
                            }

                        }


                    }
                    else
                    {
                        MessageBox.Show("El correo no existe o al usuario está desactivado", "Error de validación", MessageBoxButtons.OK);
                    }
                }

            }
            catch (Exception)
            {

                throw;
            }
            finally 
            {

                this.Cursor = Cursors.Default;
            
            }








            
        }

        private void BtnAceptar_Click(object sender, EventArgs e)
        {

            //1. Se debe verificar que el codigo digitado sea el mismo que esta almacenado en la tabla usuario
            //2. las contraseñas deben ser las mismas
            //3. se procede con el cambio de contraseña

            if (!string.IsNullOrEmpty(txtCodigoEnviado.Text.Trim()) && ValidarContrasennias() )
            {
                // el dato del email ya se habia asignado en el proceso de enviar el email al usuario
                MyUser.CodigoRecuperacion = txtCodigoEnviado.Text.Trim();
                MyUser.Contrasennia = txtPass1.Text.Trim();

                if (MyUser.ComprobarCodigoRecuperacion())
                {
                    //se tiene permiso de modificar la contraseniia
                    if (MyUser.CambiarPassword())
                    {
                        MessageBox.Show("La Contraseña se ha actualizado correctamente", ":)", MessageBoxButtons.OK);
                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("No se ha cambiado la contraseña", ":(", MessageBoxButtons.OK);
                    }
                }
                else {
                    MessageBox.Show("El codigo de verificacion digitado no es correcto", ":(", MessageBoxButtons.OK);

                }
            }
        }


        private bool ValidarContrasennias()
        {
            bool R = false;

            if (!string.IsNullOrEmpty(txtPass1.Text.Trim()) && !string.IsNullOrEmpty(txtPass2.Text.Trim())
                && txtPass1.Text.Trim() == txtPass2.Text.Trim()
                )
            {
                R = true;
            }
            else {

                if (string.IsNullOrEmpty(txtPass1.Text.Trim()))
                {
                    MessageBox.Show("Debe digitar la contraseña", "Error de validacion", MessageBoxButtons.OK);
                    txtPass1.Focus();
                    return false;
                
                }

                if (string.IsNullOrEmpty(txtPass2.Text.Trim()))
                {
                    MessageBox.Show("Debe digitar la confirmacion de contraseña", "Error de validacion", MessageBoxButtons.OK);
                    txtPass2.Focus();
                    return false;

                }

                if (!string.IsNullOrEmpty(txtPass1.Text.Trim()) && !string.IsNullOrEmpty(txtPass2.Text.Trim())
                && txtPass1.Text.Trim() != txtPass2.Text.Trim())
                {
                    MessageBox.Show("Las contraseñas no coinciden", "Error de validacion", MessageBoxButtons.OK);
                    txtPass2.Focus();
                    return false;

                }



            }



            return R;
        }


        private string GenerarCode() {

            var Caracteres = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789abcdefghijklmnopqrstuvwxyz*/-";
            var Code = new char[8];
            var random = new Random();
            for (int i = 0; i < Code.Length; i++)
            {
                Code[i] = Caracteres[random.Next(Caracteres.Length)];
            }
            var codeResultado = new String(Code);
            return codeResultado;
        }




    }
}
