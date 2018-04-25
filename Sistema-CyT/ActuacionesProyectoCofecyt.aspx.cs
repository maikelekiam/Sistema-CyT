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
        public static int idProyectoCofecytActual;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack) return;

            
            txtFechaLimite.Text = Convert.ToString(DateTime.Today.ToShortDateString());

            MostrarProyectoCofecyt(ListarProyectosCofecyt.idProyectoCofecytSeleccionado);

            PanelNuevaActuacionProyectoCofecyt.Visible = false;

            LlenarGrillaActuaciones();
            LimpiarPantalla();

            txtFechaActuacionProyectoCofecyt.Text = Convert.ToString(DateTime.Today.ToShortDateString());
        }
        private void MostrarProyectoCofecyt(int id)
        {
            ProyectoCofecyt proyectoCofecyt = proyectoCofecytNego.ObtenerProyectoCofecyt(id);

            idProyectoCofecytActual = id;

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
            txtFechaActuacionProyectoCofecyt.Text = Convert.ToString(DateTime.Today.ToShortDateString());

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
            if (txtDetalle.Text != "" && txtFechaActuacionProyectoCofecyt.Text != "")
            {
                PanelNuevaActuacionProyectoCofecyt.Visible = false;
                btnAgregarActuacionProyectoCofecyt.Visible = true;
                btnActualizarActuacion.Visible = false;

                GuardarActuacion();
                LimpiarPantalla();
            }
            else
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Correct", "alert('Debe completar los campos FECHA y DETALLE.')", true);
            }
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

        protected void btnActualizarActuacion_Click(object sender, EventArgs e)
        {
            if (txtDetalle.Text != "" && txtFechaActuacionProyectoCofecyt.Text != "")
            {
                ActuacionProyectoCofecyt actuacionProyectoCofecyt = new ActuacionProyectoCofecyt();

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

                actuacionProyectoCofecyt.IdProyectoCofecyt = idProyectoCofecytActual;
                actuacionProyectoCofecyt.IdActuacionProyectoCofecyt = idActuacionActual;

                actuacionProyectoCofecytNego.ActualizarActuacionProyectoCofecyt(actuacionProyectoCofecyt);

                LlenarGrillaActuaciones();

                PanelNuevaActuacionProyectoCofecyt.Visible = false;
                PanelActuacionProyectoCofecyt.Visible = true;

                btnActualizarActuacion.Visible = false;
                LimpiarPantalla();
            }
            else
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Correct", "alert('Debe completar los campos FECHA y DETALLE.')", true);
            }
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            PanelNuevaActuacionProyectoCofecyt.Visible = false;
            btnAgregarActuacionProyectoCofecyt.Visible = true;
            PanelActuacionProyectoCofecyt.Visible = true;
        }

        protected void dgvActuaciones_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {
            idActuacionActual = Convert.ToInt32(dgvActuaciones.Rows[e.NewSelectedIndex].Cells[0].Text);

            Response.Redirect("MostrarActuacionProyectoCofecyt.aspx");
        }

        protected void dgvActuaciones_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            btnGuardarActuacion.Visible = false;
            btnActualizarActuacion.Visible = true;
            PanelNuevaActuacionProyectoCofecyt.Visible = true;
            PanelActuacionProyectoCofecyt.Visible = false;

            idActuacionActual = Convert.ToInt32(dgvActuaciones.Rows[e.RowIndex].Cells[0].Text);

            ActuacionProyectoCofecyt actuacionProyectoCofecyt = actuacionProyectoCofecytNego.ObtenerActuacionProyectoCofecyt(idActuacionActual);

            if (actuacionProyectoCofecyt.FechaActuacion == null) { txtFechaActuacionProyectoCofecyt.Text = ""; }
            else { txtFechaActuacionProyectoCofecyt.Text = Convert.ToDateTime(actuacionProyectoCofecyt.FechaActuacion).ToShortDateString(); };

            txtDetalle.Text = actuacionProyectoCofecyt.Detalle;
            txtPendiente.Text = actuacionProyectoCofecyt.Pendiente;
            txtResponsable.Text = actuacionProyectoCofecyt.Responsable;
            txtAgente.Text = actuacionProyectoCofecyt.Agente;

            if (actuacionProyectoCofecyt.FechaLimite == null) { txtFechaLimite.Text = ""; }
            else { txtFechaLimite.Text = Convert.ToDateTime(actuacionProyectoCofecyt.FechaLimite).ToShortDateString(); };

            txtObservaciones.Text = actuacionProyectoCofecyt.Observaciones;
            txtDocumentacionAnexada.Text = actuacionProyectoCofecyt.DocumentacionAnexada;
        }
    }
}