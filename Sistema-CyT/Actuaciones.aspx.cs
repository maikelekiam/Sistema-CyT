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
        private ProyectoNego proyectoNego = new ProyectoNego();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack) return;

            MostrarProyecto(FiltrarProyecto.idProyectoSeleccionado);
        }

        private void MostrarProyecto(int id)
        {
            Proyecto proyecto = proyectoNego.ObtenerProyecto(id);

            lblNombre.Text = proyecto.Nombre.ToString();
        }
    }
}