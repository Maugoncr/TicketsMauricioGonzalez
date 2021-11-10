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
    public partial class FrmUsuarioGestion : Form
    {

        // Este objeto será el que usa para asignar y ibtener los valores que se 
        // mostrarán en el formulaio ( La parte Gráfica)
        // Debería contener toda la funcionalidad que se requiere para cumplir los
        // Requerimiento Funcionales
        private Logica.Models.Usuario MiUsuarioLocal { get; set; }

        private DataTable ListaUsuarios { get; set; }
        private DataTable ListaUsuariosConFiltro { get; set; }


        public FrmUsuarioGestion()
        {
            InitializeComponent();

            //Se instancia el objeto local
            //SDUsuarioRolListar Paso 1 y 1.1
            //SDUsuarioAgregar Paso 1.1 y 1.2
            MiUsuarioLocal = new Logica.Models.Usuario();

            ListaUsuarios = new DataTable();
            ListaUsuariosConFiltro = new DataTable();
        }



        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void FrmUsuarioGestion_Load(object sender, EventArgs e)
        {
            // Este código se desencadena al mostrar el form graficamente en pantalla
            // primero vamos a llenar la info de los tipos de roles que existen en BD

            CargarComboRoles();

            // cargar la lista de usuarios

            LlenarListaUsuarios();

            LimpiarFormulario();
        }


        private void LlenarListaUsuarios()
        {
            ListaUsuarios = MiUsuarioLocal.Listar();

            DgvListaUsuarios.DataSource = ListaUsuarios;

            DgvListaUsuarios.ClearSelection();
        
        }


        private void CargarComboRoles()
        {
            DataTable DatosDeRoles = new DataTable();

            //SDUsuarioRolListar Paso 2
            DatosDeRoles = MiUsuarioLocal.MiRol.Listar();


            cbRol.ValueMember = "ID";
            cbRol.DisplayMember = "Descrip";
            // SDUsuarioRolListar Paso 2.5
            cbRol.DataSource = DatosDeRoles;

            cbRol.SelectedIndex = -1;

        }

        private bool ValidarDatosRequeridos()
        {
            // esta funcion valida los datos requeridos segun se diseño el modelo
            // logico y fisico de base de datos
            bool R = false;

            if (!string.IsNullOrEmpty(MiUsuarioLocal.Nombre) &&
                !string.IsNullOrEmpty(MiUsuarioLocal.Cedula) &&
                !string.IsNullOrEmpty(MiUsuarioLocal.Email) &&
                !string.IsNullOrEmpty(MiUsuarioLocal.Contrasennia) &&
                MiUsuarioLocal.MiRol.IDUsuarioRol > 0)
            {
                // si se cumplen los parematros de validacion se pasa el valor de R a true
                R = true;
            }
            else {
                // Trabajo en clase:
                //retroalimentar al usuario para indicar qué campo hace falta digitar

                if (string.IsNullOrEmpty(MiUsuarioLocal.Nombre))
                {
                    MessageBox.Show("Faltan datos a ingresar", "Falta el nombre", MessageBoxButtons.OK);

                  //  MiUsuarioLocal.Nombre = null;
                   // txtNombre.Clear();
                    //LimpiarFormulario();
                    return R;
                }

                if (string.IsNullOrEmpty(MiUsuarioLocal.Cedula))
                {
                    MessageBox.Show("Faltan datos a ingresar", "Falta la cedula", MessageBoxButtons.OK);
                   // MiUsuarioLocal.Cedula = null;
                   // txtCedula.Clear();
                    //LimpiarFormulario();
                    return R;
                }

                if (string.IsNullOrEmpty(MiUsuarioLocal.Email))
                {
                    MessageBox.Show("Faltan datos a ingresar", "Falta el Email", MessageBoxButtons.OK);
                   // MiUsuarioLocal.Email = null;
                   // txtEmail.Clear();
                    // LimpiarFormulario();
                    return R;
                }
                if (string.IsNullOrEmpty(MiUsuarioLocal.Contrasennia))
                {
                    MessageBox.Show("Faltan datos a ingresar", "Falta la contraseña", MessageBoxButtons.OK);
                    //MiUsuarioLocal.Contrasennia = null;
                   // txtContrasennia.Clear();

                    //LimpiarFormulario();
                    return R;
                }

                if (MiUsuarioLocal.MiRol.IDUsuarioRol == 0)
                {
                    MessageBox.Show("Faltan datos a ingresar", "Falta seleccionar un rol", MessageBoxButtons.OK);
                    //MiUsuarioLocal.MiRol.IDUsuarioRol = 0;
                    //cbRol.SelectedIndex = -1;
                    // LimpiarFormulario();
                    return R;
                }





            }

            return R;
        }

        private void LimpiarFormulario() {
            // se procede a limpiar de datos los controles del formulario
            txtIDUsuario.Clear();
            txtNombre.Clear();
            txtCedula.Clear();
            txtTelefono.Clear();
            txtEmail.Clear();
            txtContrasennia.Clear();
            cbRol.SelectedIndex = -1;

            // al reinstanciar el objeto local se eliminan todos los datos de los atributos
            MiUsuarioLocal = new Logica.Models.Usuario();

            ActivarAgregar();

        }




        private void btnAgregar_Click(object sender, EventArgs e)
        {

            // La Asignación de valores a atributos se realiza en tiempo real, usaremos
           //el evento Leave para almacenar el dato del atributo al objeto local



            //es importante validar que los atributos tengan datos antes de proceder.

            if (ValidarDatosRequeridos())
            {
                //paso 1.3 y 1.3.6
                bool OkCedula = MiUsuarioLocal.ConsultarPorCedula(MiUsuarioLocal.Cedula);



                //paso 1.4 y 1.4.6
                bool OkEmail = MiUsuarioLocal.ConsultarPorEmail();



                //1.5
                if (!OkCedula && !OkEmail)
                {
                    //si no existe la cedula y si no existe el email tengo permiso para continuar con agregar
                    string Mensaje = string.Format("¿Desea Continuar y agregar al Usuario {0}?", MiUsuarioLocal.Nombre);
                    DialogResult Continuar = MessageBox.Show(Mensaje, "???", MessageBoxButtons.YesNo);
                    //si el id (o cualquier atrib obligatorio) tiene datos, se puede
                    //asegurar que el usuario aún existe y proceder con el update
                    if (Continuar == DialogResult.Yes)
                    {
                        //1.6
                        if (MiUsuarioLocal.Agregar())
                        {
                            MessageBox.Show("Usuario Agregado Correctamente", ":)", MessageBoxButtons.OK);
                            LimpiarFormulario();
                            LlenarListaUsuarios();
                        }
                        else
                        {
                            MessageBox.Show("Ha ocurrido un error y no se ha guardado el usuario", ":(", MessageBoxButtons.OK);
                        }
                    }
                }
            }

        }

        private void txtNombre_Leave(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtNombre.Text.Trim()))
            {
                MiUsuarioLocal.Nombre = txtNombre.Text.Trim();

            }
            else {

                MiUsuarioLocal.Nombre = "";
            
            }
        }

        private void txtCedula_Leave(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtCedula.Text.Trim()))
            {
                MiUsuarioLocal.Cedula = txtCedula.Text.Trim();

            }
            else {
                MiUsuarioLocal.Cedula = "";
            }

        }

        private void txtTelefono_Leave(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtTelefono.Text.Trim()))
            {
                MiUsuarioLocal.Telefono = txtTelefono.Text.Trim();

            }
            else {
                MiUsuarioLocal.Telefono = "";


            }
        }

        private void txtEmail_Leave(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtEmail.Text.Trim()))
            {
                if (Commons.ObjetosGlobales.ValidarEmail(txtEmail.Text.Trim()))
                {
                    MiUsuarioLocal.Email = txtEmail.Text.Trim();
                }
                else {
                    MessageBox.Show("El formato del correo no es correcto!!", "Error de validacion", MessageBoxButtons.OK);
                    txtEmail.Focus();
                    txtEmail.SelectAll();
                }
            }
            else {
                MiUsuarioLocal.Email = "";
            }
        }

        private void txtContrasennia_Leave(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtContrasennia.Text.Trim()))
            {
                MiUsuarioLocal.Contrasennia = txtContrasennia.Text.Trim();

            }
            else {

                MiUsuarioLocal.Contrasennia = "";
            }
        }

        private void cbRol_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (cbRol.SelectedIndex >= 0)
            {
                MiUsuarioLocal.MiRol.IDUsuarioRol = Convert.ToInt32(cbRol.SelectedValue);
            }
            else {

                MiUsuarioLocal.MiRol.IDUsuarioRol = 0;
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            LimpiarFormulario();
        }

        

        private void btnEditar_Click(object sender, EventArgs e)
        {
            // Segun el diagrama de casos de uso expandido, se debe consultar por
            // el ID antes de proceder con el proceso de actualizacion.
            // esto deberia estar explicado en el diagrama de secuencia correspondiente

            if (ValidarDatosRequeridos())
            {
                // si se cumplen los datos minimos se procede

                // uso un objeto temporal para no tocar el usuario local y poder evaluar
                // (si tiene datos en los atributos) que el usuario existe aun en BD

                Logica.Models.Usuario ObjUsuario = MiUsuarioLocal.ConsultarPorID(MiUsuarioLocal.IDUsuario);
                if (ObjUsuario.IDUsuario > 0)
                {
                    // si el id (o cualquier atrib obligatorio) tiene datos, se puede 
                    // asegurar que el usuario aun existe y proceder con el update

                    string Mensaje = string.Format("Desea Continuar con la Modificacion del Usuario {0}?", MiUsuarioLocal.Nombre);

                    DialogResult Continuar = MessageBox.Show(Mensaje, "???", MessageBoxButtons.YesNo);

                    if (Continuar == DialogResult.Yes)
                    {

                        if (MiUsuarioLocal.Editar())
                        {
                            // se muestra mensaje de exito y se actualiza la lista
                            MessageBox.Show("El Usuario se ha actualizado correctamente", ":)", MessageBoxButtons.OK);
                            LimpiarFormulario();
                            LlenarListaUsuarios();
                        }
                        else
                        {
                            MessageBox.Show("Ha ocurrido un error y no se actualizo el usuario!", ":(", MessageBoxButtons.OK);
                        }
                    }
                }
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            
                // si se cumplen los datos minimos se procede
                Logica.Models.Usuario ObjUsuarioTemporal = MiUsuarioLocal.ConsultarPorID(MiUsuarioLocal.IDUsuario);
                if (ObjUsuarioTemporal.IDUsuario > 0)
                {
                //EJEMPLO DE CONCATENACION MUY PRO USANDO FORMAT

                string Mensaje = string.Format("Desea Continuar con la Desactivación del Usuario {0}?", MiUsuarioLocal.Nombre);

                DialogResult Continuar = MessageBox.Show(Mensaje, "???", MessageBoxButtons.YesNo);

                if (Continuar == DialogResult.Yes)
                {
                    if (MiUsuarioLocal.Eliminar())
                    {
                        // se muestra mensaje de exito y se actualiza la lista
                        MessageBox.Show("El Usuario se ha desactivado correctamente", ":)", MessageBoxButtons.OK);
                        LimpiarFormulario();
                        LlenarListaUsuarios();
                    }
                        else
                        {
                        MessageBox.Show("Ha ocurrido un error y no se elimino el usuario!", ":(", MessageBoxButtons.OK);
                        }
                    }
                }
            
        }

        private void DgvListaUsuarios_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (DgvListaUsuarios.SelectedRows.Count == 1)
            {
                LimpiarFormulario();

                DataGridViewRow MiFila = DgvListaUsuarios.SelectedRows[0];

                int CodigoUsuario = Convert.ToInt32(MiFila.Cells["CIDUsuario"].Value);

                MiUsuarioLocal = MiUsuarioLocal.ConsultarPorID(CodigoUsuario);

                txtIDUsuario.Text = MiUsuarioLocal.IDUsuario.ToString();
                txtNombre.Text = MiUsuarioLocal.Nombre;
                txtCedula.Text = MiUsuarioLocal.Cedula;
                txtTelefono.Text = MiUsuarioLocal.Telefono;
                txtEmail.Text = MiUsuarioLocal.Email;
                //txtContrasennia.Text = MiUsuarioLocal.Contrasennia;
                cbRol.SelectedValue = MiUsuarioLocal.MiRol.IDUsuarioRol;

                ActivarEditaryEliminar();

            }
        }

        private void txtNombre_KeyPress(object sender, KeyPressEventArgs e)
        {
           e.Handled = Commons.ObjetosGlobales.CaracteresTexto(e, true);
        }

        private void txtCedula_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = Commons.ObjetosGlobales.CaracteresNumeros(e);
        }

        private void txtEmail_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = Commons.ObjetosGlobales.CaracteresTexto(e, false, true);
        }


            private void ActivarAgregar() 
            {
            btnAgregar.Enabled = true;
            btnEditar.Enabled = false;
            btnEliminar.Enabled = false;
        
        
            }


        private void ActivarEditaryEliminar() 
        {
            btnAgregar.Enabled = false;
            btnEditar.Enabled = true;
            btnEliminar.Enabled = true;

        }




    }
}
