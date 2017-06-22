using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CapaDominio;
using CapaNegocio;
using System.Data;

namespace Sistema_CyT
{
    public partial class Actuaciones : System.Web.UI.Page
    {
        ProyectoNego proyectoNego = new ProyectoNego();
        ActuacionNego actuacionNego = new ActuacionNego();
        OrganismoNego organismoNego = new OrganismoNego();

        public static int idActuacionActual;
        public static int idOrganismoActual;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack) return;

            MostrarProyecto(FiltrarProyecto.idProyectoSeleccionado);
            MostrarOrganismo();
            PanelNuevaActuacion.Visible = false;

            LlenarGrillaActuaciones();
        }

        //Muestro en el DROPDOWNLIST los ORGANISMOS
        private void MostrarOrganismo()
        {
            ddlOrganismo.DataSource = organismoNego.MostrarOrganismos().ToList();
            ddlOrganismo.DataValueField = "nombre";
            ddlOrganismo.DataBind();
        }



        private void MostrarProyecto(int id)
        {
            Proyecto proyecto = proyectoNego.ObtenerProyecto(id);

            lblProyecto.Text = "Proyecto: "+proyecto.Nombre.ToString();
        
        }

        protected void btnAgregarActuacion_Click(object sender, EventArgs e)
        {
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

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            PanelNuevaActuacion.Visible = false;
            btnAgregarActuacion.Visible = true;
        }

        protected void btnGuardarActuacion_Click(object sender, EventArgs e)
        {
            PanelNuevaActuacion.Visible = false;
            btnAgregarActuacion.Visible = true;
            GuardarActuacion();
        }

        private void GuardarActuacion()
        {
            Actuacion actuacion = new Actuacion();

            actuacion.IdProyecto = FiltrarProyecto.idProyectoSeleccionado;
            actuacion.Fecha = Convert.ToDateTime(txtFechaActuacion.Text);
            actuacion.Detalle = txtDetalle.Text;
            actuacion.IdOrganismo = organismoNego.TraerOrganismoIdSegunItem(ddlOrganismo.SelectedItem.ToString());

            idActuacionActual = actuacionNego.GuardarActuacion(actuacion);

            LlenarGrillaActuaciones();
        }

        private void LlenarGrillaActuaciones()
        {
            dgvActuaciones.Columns[0].Visible = true;
            dgvActuaciones.Columns[1].Visible = true;
            dgvActuaciones.Columns[2].Visible = true;
            dgvActuaciones.Columns[3].Visible = true;
            dgvActuaciones.Columns[4].Visible = true;

            dgvActuaciones.DataSource = actuacionNego.MostrarActuacionSegunProyecto(FiltrarProyecto.idProyectoSeleccionado).ToList();
            dgvActuaciones.DataBind();

            //dgvActuaciones.Columns[0].Visible = false;
            //dgvActuaciones.Columns[1].Visible = false;
        }

        protected void btnModalOrganismoGuardar_Click(object sender, EventArgs e)
        {
            Organismo organismo = new Organismo();

            organismo.Nombre = txtOrganismoNombreModal.Text;
            //organismo.Telefono = txtOrganismoTelefonoModal.Text;
            //organismo.CorreoElectronico = txtOrganismoCorreoElectronicoModal.Text;

            idOrganismoActual = organismoNego.GuardarOrganismo(organismo);

            ddlOrganismo.Items.Clear();
            ddlOrganismo.Text = TraerOrganismo(idOrganismoActual);
            MostrarOrganismo();
        }
        private string TraerOrganismo(int id)
        {
            return organismoNego.TraerOrganismo(id);
        }

        protected void dgvActuaciones_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {

        }

        protected void dgvActuaciones_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {

        }
    }
}