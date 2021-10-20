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

        

        public FrmUsuarioGestion()
        {
            InitializeComponent();

            //Se instancia el objeto local
            //SDUsuarioRolListar Paso 1 y 1.1
            //SDUsuarioAgregar Paso 1.1 y 1.2
            MiUsuarioLocal = new Logica.Models.Usuario();

        }

       

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void FrmUsuarioGestion_Load(object sender, EventArgs e)
        {
            // Este código se desencadena al mostrar el form graficamente en pantalla
            // primero vamos a llenar la info de los tipos de roles que existen en BD

            CargarComboRoles();


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

        private void btnAgregar_Click(object sender, EventArgs e)
        {

            //Asignacion de valores a atributos
            MiUsuarioLocal.Cedula = txtCedula.Text.Trim();
            MiUsuarioLocal.Email = txtEmail.Text.Trim();



            // SDUsuarioAgregar Paso 1.3 y 1.3.6
            bool OkCedula = MiUsuarioLocal.ConsultarPorCedula(MiUsuarioLocal.Cedula);

            // Paso 1.4 y 1.4.6

            bool OkEmail = MiUsuarioLocal.ConsultarPorEmail();

            // 1.5

            if (!OkCedula && !OkEmail)
            {
                // Si no existe la cedula y si no existe el email tengo permiso para continuar con agregar

                // 1.6
                bool OkAgregar = MiUsuarioLocal.Agregar();


            }


        }
    }
}
