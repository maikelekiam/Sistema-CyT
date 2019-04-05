using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CapaDominio;
using CapaNegocio;

namespace Sistema_CyT
{
    public partial class MostrarActuacionProyectoCofecyt : System.Web.UI.Page
    {
        ProyectoCofecytNego proyectoCofecytNego = new ProyectoCofecytNego();
        ActuacionProyectoCofecytNego actuacionProyectoCofecytNego = new ActuacionProyectoCofecytNego();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack) return;

            MostrarActuacionSeleccionada();
        }
        public void MostrarActuacionSeleccionada()
        {
            ActuacionProyectoCofecyt actuacionProyectoCofecyt = actuacionProyectoCofecytNego.ObtenerActuacionProyectoCofecyt(ActuacionesProyectoCofecyt.idActuacionActual);

            txtFechaActuacion.Text = Convert.ToDateTime(actuacionProyectoCofecyt.FechaActuacion).ToShortDateString();
            txtDetalle.Text = actuacionProyectoCofecyt.Detalle;
            txtPendiente.Text = actuacionProyectoCofecyt.Pendiente;
            txtResponsable.Text = actuacionProyectoCofecyt.Responsable;
            txtAgente.Text = actuacionProyectoCofecyt.Agente;

            if (actuacionProyectoCofecyt.FechaLimite != null) {txtFechaLimite.Text = Convert.ToDateTime(actuacionProyectoCofecyt.FechaLimite).ToShortDateString(); }
            else { txtFechaLimite.Text = ""; }

            
            txtObservaciones.Text = actuacionProyectoCofecyt.Observaciones;
            txtDocumentacionAnexada.Text = actuacionProyectoCofecyt.DocumentacionAnexada;
        }

        protected void btnVolver_Click(object sender, EventArgs e)
        {
            Response.Redirect("ActuacionesProyectoCofecyt.aspx");
        }
    }
}