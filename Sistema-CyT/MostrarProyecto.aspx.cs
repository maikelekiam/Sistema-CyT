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
    public partial class MostrarProyecto : System.Web.UI.Page
    {
        ProyectoNego proyectoNego = new ProyectoNego();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack) return;

            ObtenerProyecto();
        }
        private void ObtenerProyecto()
        {

            string nom = ListarProyectos.numeroExpedienteProyectoSeleccionado;
            lblNombreProyecto.Text = nom;

            Proyecto proyecto = proyectoNego.ObtenerProyectoSegunNombreYConvocatoria(ListarProyectos.idConvocatoriaSeleccionada, ListarProyectos.numeroExpedienteProyectoSeleccionado);

            lblNombreProyecto.Text = "Proyecto: " + proyecto.Nombre.ToString();
        }
    }
}