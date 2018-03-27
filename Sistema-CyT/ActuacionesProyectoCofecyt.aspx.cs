using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CapaDominio;
using CapaNegocio;
using System.Data;
using System.Globalization;
using System.Drawing;

namespace Sistema_CyT
{
    public partial class ActuacionesProyectoCofecyt : System.Web.UI.Page
    {
        ProyectoCofecytNego proyectoCofecytNego = new ProyectoCofecytNego();
        ActuacionProyectoCofecytNego actuacionProyectoCofecytNego = new ActuacionProyectoCofecytNego();

        public static int idActuacionActual;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack) return;

            MostrarProyectoCofecyt(ListarProyectosCofecyt.idProyectoCofecytSeleccionado);

            PanelNuevaActuacionProyectoCofecyt.Visible = false;

            LlenarGrillaActuaciones();
            LimpiarPantalla();
        }
        private void MostrarProyectoCofecyt(int id)
        {
            ProyectoCofecyt proyectoCofecyt = proyectoCofecytNego.ObtenerProyectoCofecyt(id);

            lblProyectoCofecyt.Text = proyectoCofecyt.Titulo.ToString();
        }
        private void LlenarGrillaActuaciones()
        {
            dgvActuaciones.Columns[0].Visible = true;
            dgvActuaciones.Columns[1].Visible = true;
            dgvActuaciones.Columns[2].Visible = true;
            dgvActuaciones.Columns[3].Visible = true;
            dgvActuaciones.Columns[4].Visible = true;

            dgvActuaciones.DataSource = actuacionProyectoCofecytNego.MostrarActuacionProyectoCofecytSegunProyectoCofecyt(ListarProyectosCofecyt.idProyectoCofecytSeleccionado).ToList();
            dgvActuaciones.DataBind();

            dgvActuaciones.Columns[0].Visible = false;
            dgvActuaciones.Columns[1].Visible = false;
        }
        private void LimpiarPantalla()
        {
            txtFechaActuacionProyectoCofecyt.Text = null;
            txtFechaLimite.Text = null;
            txtDetalle.Text = null;
            txtPendiente.Text = null;
            txtResponsable.Text = null;
            txtAgente.Text = null;
            txtObservaciones.Text = null;
            txtDocumentacionAnexada.Text = null;
        }





        protected void btnAgregarActuacionProyectoCofecyt_Click(object sender, EventArgs e)
        {
            btnActualizarActuacion.Visible = false;
            btnGuardarActuacion.Visible = true;
            LimpiarPantalla();

            if (PanelNuevaActuacionProyectoCofecyt.Visible == true)
            {
                PanelNuevaActuacionProyectoCofecyt.Visible = false;
            }
            else if (PanelNuevaActuacionProyectoCofecyt.Visible == false)
            {
                PanelNuevaActuacionProyectoCofecyt.Visible = true;
                btnAgregarActuacionProyectoCofecyt.Visible = false;
            }
        }

        protected void btnGuardarActuacion_Click(object sender, EventArgs e)
        {
            if (txtFechaLimite.Text != "" && txtFechaActuacionProyectoCofecyt.Text != "")
            {
                PanelNuevaActuacionProyectoCofecyt.Visible = false;
                btnAgregarActuacionProyectoCofecyt.Visible = true;
                btnActualizarActuacion.Visible = false;

                GuardarActuacion();
                LimpiarPantalla();
            }
            else
            {
                //FALTA IMPLEMENTAR
            }
        }

        protected void btnActualizarActuacion_Click(object sender, EventArgs e)
        {

        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            PanelNuevaActuacionProyectoCofecyt.Visible = false;
            btnAgregarActuacionProyectoCofecyt.Visible = true;
            PanelActuacionProyectoCofecyt.Visible = true;
        }

        private void GuardarActuacion()
        {
            ActuacionProyectoCofecyt actuacionProyectoCofecyt = new ActuacionProyectoCofecyt();

            actuacionProyectoCofecyt.IdProyectoCofecyt = ListarProyectosCofecyt.idProyectoCofecytSeleccionado;

            if (txtFechaActuacionProyectoCofecyt.Text == "") { actuacionProyectoCofecyt.FechaActuacion = null; }
            else { actuacionProyectoCofecyt.FechaActuacion = DateTime.ParseExact(txtFechaActuacionProyectoCofecyt.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture); }

            actuacionProyectoCofecyt.Detalle = txtDetalle.Text;
            actuacionProyectoCofecyt.Pendiente = txtPendiente.Text;
            actuacionProyectoCofecyt.Responsable = txtResponsable.Text;
            actuacionProyectoCofecyt.Agente = txtAgente.Text;

            if (txtFechaLimite.Text == "") { actuacionProyectoCofecyt.FechaLimite = null; }
            else { actuacionProyectoCofecyt.FechaLimite = DateTime.ParseExact(txtFechaLimite.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture); }

            actuacionProyectoCofecyt.Observaciones = txtObservaciones.Text;
            actuacionProyectoCofecyt.DocumentacionAnexada = txtDocumentacionAnexada.Text;

            idActuacionActual = actuacionProyectoCofecytNego.GuardarActuacionProyectoCofecyt(actuacionProyectoCofecyt);

            LlenarGrillaActuaciones();
        }

        protected void dgvActuaciones_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {
            //lblProyectoCofecyt.Text = dgvActuaciones.Rows[e.NewSelectedIndex].Cells[0].Text;

            idActuacionActual = Convert.ToInt32(dgvActuaciones.Rows[e.NewSelectedIndex].Cells[0].Text);

            Response.Redirect("MostrarActuacionProyectoCofecyt.aspx");
        }
    }
}