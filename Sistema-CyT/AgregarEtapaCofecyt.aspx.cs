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
    public partial class AgregarEtapaCofecyt : System.Web.UI.Page
    {
        ProyectoNego proyectoNego = new ProyectoNego();
        ProyectoCofecytNego proyectoCofecytNego = new ProyectoCofecytNego();
        ConvocatoriaNego convocatoriaNego = new ConvocatoriaNego();
        TipoEstadoNego tipoEstadoNego = new TipoEstadoNego();
        FondoNego fondoNego = new FondoNego();

        public static int idProyectoSeleccionado = 1;
        public static int idConvocatoriaSeleccionada = 1;
        public static int idEstadoSeleccionado = 1;
        public static string codigoInternoProyectoSeleccionado = null;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack) return;

            LlenarListaFondoChoice();
        }

        private void LlenarListaFondoChoice()
        {
            ddlFondoChoice.DataSource = fondoNego.MostrarFondos().ToList();
            ddlFondoChoice.DataValueField = "idFondo";
            ddlFondoChoice.DataBind();
        }



        protected void ddlFondoChoice_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlFondoChoice.SelectedValue != "-1")
            {
                if (fondoNego.ObtenerFondo(Convert.ToInt32(ddlFondoChoice.SelectedValue)).Nombre.ToUpper() == "COFECYT")
                {
                    Response.Redirect("AgregarEtapaCofecyt.aspx");
                }
                else
                {

                }





                //lblPanelSuperiorTitulo.InnerText = "Proyectos: " + fondoNego.ObtenerFondo(Convert.ToInt32(ddlFondoChoice.SelectedValue)).Nombre;
                LlenarChoiceConvocatorias(Convert.ToInt32(ddlFondoChoice.SelectedValue));
            }
            else
            {
                Response.Redirect("AgregarEtapa.aspx");
            }
        }

        private void LlenarChoiceConvocatorias(int id)
        {
            ddlConvocatoria.DataSource = convocatoriaNego.ListarChoiceConvocatorias(id);
            ddlConvocatoria.DataTextField = "nombre";
            ddlConvocatoria.DataValueField = "idConvocatoria";
            ddlConvocatoria.DataBind();

            if (ddlConvocatoria.SelectedValue != "-1" && ddlConvocatoria.SelectedValue != "")
            {
                idConvocatoriaSeleccionada = Convert.ToInt32(ddlConvocatoria.SelectedValue.ToString());

                //Me fijo si es un proyecto simple o un proyectocofecyt
                if (fondoNego.ObtenerFondo(Convert.ToInt32(ddlFondoChoice.SelectedValue)).Nombre.ToUpper() == "COFECYT")
                {
                    Response.Redirect("AgregarEtapaCofecyt.aspx");

                    //dgvProyectos.Visible = false;

                    //cantidadProyectosSumatoria = proyectoCofecytNego.ListarChoiceProyectoCofecyts(idConvocatoriaSeleccionada).Count();
                    //lblCantidadProyectosSumatoria.Text = "Cantidad de Proyectos = " + Convert.ToString(cantidadProyectosSumatoria);
                }
                else
                {
                }
            }
            else
            {
                if (fondoNego.ObtenerFondo(Convert.ToInt32(ddlFondoChoice.SelectedValue)).Nombre.ToUpper() == "COFECYT")
                {

                }
                else
                {

                }
            }
        }


        protected void ddlConvocatoria_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void ddlProyectoChoice_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void dgvProyectoCofecyts_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void dgvProyectos_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}