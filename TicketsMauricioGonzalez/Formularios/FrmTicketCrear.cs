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
    public partial class FrmTicketCrear : Form
    {

        public Logica.Models.Ticket MiTicket { get; set; }



        public FrmTicketCrear()
        {
            InitializeComponent();

            MiTicket = new Logica.Models.Ticket();

        }

      

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void txtIdUsuario_DoubleClick(object sender, EventArgs e)
        {
            FrmClienteBuscar MiFormDeBusqueda = new FrmClienteBuscar();

            DialogResult resp = MiFormDeBusqueda.ShowDialog();

            if (resp == DialogResult.OK)
            {
                txtIdUsuario.Text = MiTicket.MiCliente.IDCliente.ToString();
                lblClienteNombre.Text = MiTicket.MiCliente.Nombre.ToString();

            }

        }

        private void FrmTicketCrear_Load(object sender, EventArgs e)
        {
            CargarCategorias();

            LimpiarForm();

        }


        private void LimpiarForm()
        {
            txtIdUsuario.Clear();
            lblClienteNombre.Text = "";
            txtTitulo.Clear();
            txtDescripcion.Clear();
            CboxCategoria.SelectedIndex = -1;

            MiTicket = new Logica.Models.Ticket();
        
        }

        private void CargarCategorias()
        {
            DataTable Datos = new DataTable();
            Datos = MiTicket.MiCategoria.Listar();
            CboxCategoria.ValueMember = "ID";
            CboxCategoria.DisplayMember = "Descrip";
            CboxCategoria.DataSource = Datos;
            CboxCategoria.SelectedIndex = -1;

        }


        private bool Validar() {

            bool R = false;

            if (MiTicket.MiCliente.IDCliente > 0 && CboxCategoria.SelectedIndex > -1 && !string.IsNullOrEmpty(txtTitulo.Text.Trim())
                && !string.IsNullOrEmpty(txtDescripcion.Text.Trim()))
            {
                R = true;
            }
            else
            {
                if (MiTicket.MiCliente.IDCliente == 0)
                {
                    MessageBox.Show("Debe seleccionar un cliente!", "Error de validacion", MessageBoxButtons.OK);
                    return false;
                }

                if (CboxCategoria.SelectedIndex == -1) // -1 es cuando el combo no tiene nunguna seleccion
                {
                    MessageBox.Show("Debe seleccionar una categoria para el ticket!", "Error de validacion", MessageBoxButtons.OK);
                    return false;
                }

                if (string.IsNullOrEmpty(txtDescripcion.Text.Trim()))
                {
                    MessageBox.Show("Debe digitar un titulo para el ticket", "Error de validacion", MessageBoxButtons.OK);
                    txtTitulo.Focus();
                    return false;
                }

                if (string.IsNullOrEmpty(txtDescripcion.Text.Trim()))
                {
                    MessageBox.Show("Debe digitar una descripcion para el ticket", "Error de validacion", MessageBoxButtons.OK);
                    txtDescripcion.Focus();
                    return false;
                }

            }



            return R;
        
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {

            if (Validar())
            {

                // esta todo listo para agregar el ticket

                MiTicket.MiCategoria.IDTicketCategoria = Convert.ToInt32(CboxCategoria.SelectedValue); // Toma el id de la categoria
                MiTicket.MiCategoria.TicketCategoriaDescripcion = Convert.ToString(CboxCategoria.SelectedText); //PARA TOMAR LO ESCRITO DEL COMBO

                // MiTicket.FechaCreacion = DateTime.Now.Date;  se quitar por que ya tenemos el default de la fecha con getdate()
                MiTicket.TicketTitulo = txtTitulo.Text.Trim();
                MiTicket.TicketDescripcion = txtDescripcion.Text.Trim();

                if (MiTicket.Agregar())
                {
                    MessageBox.Show("Ticket Agregado Correctamente", ":)", MessageBoxButtons.OK);
                    LimpiarForm();
                    //TODO Implementar un reporte de crystal para poderlo imprimir y que quede
                    // como atestado de creacion del ticket

                }


            }

        }
    }
}
