using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CapaDominio;
using CapaNegocio;
using System.Data;
using System.Windows.Forms;

namespace Sistema_CyT
{
    public partial class Actuaciones : System.Web.UI.Page
    {
        private ProyectoNego proyectoNego = new ProyectoNego();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack) return;

            MostrarProyecto(FiltrarProyecto.idProyectoSeleccionado);
            PanelNuevaActuacion.Visible = false;
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
            }
        }
    }
}