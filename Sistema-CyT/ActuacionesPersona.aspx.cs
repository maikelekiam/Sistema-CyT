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


namespace Sistema_CyT
{
    public partial class ActuacionesPersona : System.Web.UI.Page
    {
        PersonaNego personaNego = new PersonaNego();
        ActuacionPersonaNego actuacionPersonaNego = new ActuacionPersonaNego();
        ViaComunicacionNego viaComunicacionNego = new ViaComunicacionNego();
        ActuacionPersona actuacionPersona = new ActuacionPersona();

        public static int idViaComunicacionActual; // = 0;
        public static int idActuacionActual;
        public static int idPersonaActual;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack) return;

            MostrarPersona(ListarPersonas.idPersonaSeleccionada);
            PanelNuevaActuacion.Visible = false;
            MostrarViaComunicacion(); //SIRVE PARA CARGAR DATOS EN EL DROPDOWNLIST

            LlenarGrillaActuaciones();
            LimpiarPantalla();

        }
        private void MostrarPersona(int id)
        {
            Persona persona = personaNego.ObtenerPersona(id);
            idPersonaActual = id;
            lblPersona.Text = persona.Nombre.ToString().ToUpper() + " " + persona.Apellido.ToString().ToUpper();
        }
        protected void btnModalViaComunicacionGuardar_Click(object sender, EventArgs e)
        {
            ViaComunicacion viaComunicacion = new ViaComunicacion();

            viaComunicacion.Nombre = txtViaComunicacionModal.Text;

            idViaComunicacionActual = viaComunicacionNego.GuardarViaComunicacion(viaComunicacion);

            ddlViaComunicacion.Items.Clear();
            ddlViaComunicacion.Text = TraerViaComunicacion(idViaComunicacionActual);
            MostrarViaComunicacion();
        }
        private void MostrarViaComunicacion()
        {
            ddlViaComunicacion.DataSource = viaComunicacionNego.MostrarViaComunicacion().ToList();
            ddlViaComunicacion.DataValueField = "nombre";
            ddlViaComunicacion.DataBind();
        }
        private string TraerViaComunicacion(int id)
        {
            return viaComunicacionNego.TraerViaComunicacion(id);
        }
        private void LlenarGrillaActuaciones()
        {
            dgvActuaciones.Columns[0].Visible = true;
            dgvActuaciones.Columns[1].Visible = true;
            dgvActuaciones.Columns[2].Visible = true;
            dgvActuaciones.Columns[3].Visible = true;

            dgvActuaciones.DataSource = actuacionPersonaNego.MostrarActuacionPersonaSegunPersona(ListarPersonas.idPersonaSeleccionada).ToList();
            dgvActuaciones.DataBind();

            dgvActuaciones.Columns[0].Visible = false;
        }
        private void LimpiarPantalla()
        {
            txtFechaActuacion.Text = null;
            txtDetalle.Text = null;
            ddlViaComunicacion.Text = null;
        }

        protected void btnAgregarActuacion_Click(object sender, EventArgs e)
        {
            btnActualizarActuacion.Visible = false;
            btnGuardarActuacion.Visible = true;
            LimpiarPantalla();

            if (PanelNuevaActuacion.Visible == true)
            {
                PanelNuevaActuacion.Visible = false;
            }
            else if (PanelNuevaActuacion.Visible == false)
            {
                PanelNuevaActuacion.Visible = true;
                btnAgregarActuacion.Visible = false;
            }
        }

        protected void btnGuardarActuacion_Click(object sender, EventArgs e)
        {
            if (ddlViaComunicacion.SelectedValue != "-1" && txtFechaActuacion.Text != "") //agregar tambien para la fecha que no sea vacia o null
            {
                PanelNuevaActuacion.Visible = false;
                btnAgregarActuacion.Visible = true;
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
            if (
                ddlViaComunicacion.SelectedValue != "-1"
                && txtFechaActuacion.Text != ""
                )
            {
                ActuacionPersona actuacionPersona = new ActuacionPersona();

                actuacionPersona.Fecha = DateTime.ParseExact(txtFechaActuacion.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                actuacionPersona.Detalle = txtDetalle.Text;
                actuacionPersona.IdViaComunicacion = viaComunicacionNego.TraerViaComunicacionIdSegunItem(ddlViaComunicacion.SelectedItem.ToString());
                
                actuacionPersona.IdPersona = idPersonaActual;

                actuacionPersona.IdActuacionPersona = idActuacionActual;

                actuacionPersonaNego.ActualizarActuacionPersona(actuacionPersona);

                LlenarGrillaActuaciones();

                PanelNuevaActuacion.Visible = false;
                PanelActuacion.Visible = true;

                btnActualizarActuacion.Visible = false;
                LimpiarPantalla();
            }
            else
            {
                // Mostrar aviso de completar todos los datos
            }
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            PanelNuevaActuacion.Visible = false;
            btnAgregarActuacion.Visible = true;
            PanelActuacion.Visible = true;
        }

        
        private void GuardarActuacion()
        {
            ActuacionPersona actuacionPersona = new ActuacionPersona();

            actuacionPersona.Fecha = DateTime.ParseExact(txtFechaActuacion.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);
            actuacionPersona.Detalle = txtDetalle.Text;
            actuacionPersona.IdViaComunicacion = viaComunicacionNego.TraerViaComunicacionIdSegunItem(ddlViaComunicacion.SelectedItem.ToString());
            actuacionPersona.IdPersona = idPersonaActual;

            idActuacionActual = actuacionPersonaNego.GuardarActuacionPersona(actuacionPersona);

            LlenarGrillaActuaciones();
        }

        protected void dgvActuaciones_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {
            btnGuardarActuacion.Visible = false;
            btnActualizarActuacion.Visible = true;
            PanelNuevaActuacion.Visible = true;
            PanelActuacion.Visible = false;

            GridViewRow row = dgvActuaciones.Rows[e.NewSelectedIndex];

            idActuacionActual = Convert.ToInt32(row.Cells[0].Text);

            ActuacionPersona actuacionPersona = actuacionPersonaNego.ObtenerActuacionPersona(idActuacionActual);

            if (actuacionPersona.Fecha == null) { txtFechaActuacion.Text = ""; }
            else { txtFechaActuacion.Text = Convert.ToDateTime(actuacionPersona.Fecha).ToShortDateString(); };

            txtDetalle.Text = actuacionPersona.Detalle.ToString();

            ddlViaComunicacion.Text = viaComunicacionNego.TraerViaComunicacion(Convert.ToInt32(actuacionPersona.IdViaComunicacion));
        }
    }
}