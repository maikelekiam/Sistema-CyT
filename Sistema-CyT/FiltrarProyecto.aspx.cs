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
    public partial class FiltrarProyecto : System.Web.UI.Page
    {
        private ProyectoNego proyectoNego = new ProyectoNego();
        private FondoNego fondoNego = new FondoNego();
        private ConvocatoriaNego convocatoriaNego = new ConvocatoriaNego();
        public static int idProyectoSeleccionado;
        private List<Proyecto> listaProyectos = new List<Proyecto>();

        List<pr02ResultSet0> listaProyectosFiltrados = new List<pr02ResultSet0>();
        List<pr02ResultSet0> listaChoiceProyectos = new List<pr02ResultSet0>();

        public static int idConvocatoriaSeleccionada = 1;
        public static int idEstadoSeleccionado = 1;
        public static string numeroExpedienteProyectoSeleccionado = null;


        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack) return;
            
            LlenarListaFondos();
            MostrarListaProyectos();
            //listaProyectos.Clear();
        }
        private void LlenarListaFondos()
        {
            ddlFondo.DataSource = fondoNego.MostrarFondos().ToList();
            ddlFondo.DataValueField = "idFondo";
            ddlFondo.DataBind();
        }
        private void MostrarListaProyectos()
        {
        }

        protected void ddlFondo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlFondo.SelectedValue != "-1")
            {
                LlenarChoiceConvocatorias(Convert.ToInt32(ddlFondo.SelectedValue));
            }
            else
            {
                Response.Redirect("FiltrarProyecto.aspx");
            }
        }

        private void LlenarChoiceConvocatorias(int id)
        {
            ddlConvocatoria.DataSource = convocatoriaNego.ListarChoiceConvocatorias(id).OrderByDescending(c => c.anio);
            ddlConvocatoria.DataTextField = "nombre";
            ddlConvocatoria.DataValueField = "idConvocatoria";
            ddlConvocatoria.DataBind();

            if (ddlConvocatoria.SelectedValue != "-1" && ddlConvocatoria.SelectedValue != "")
            {
                idConvocatoriaSeleccionada = Convert.ToInt32(ddlConvocatoria.SelectedValue.ToString());

                dgvProyectos.DataSource = proyectoNego.ListarChoiceProyectos(idConvocatoriaSeleccionada).ToList();
                dgvProyectos.DataBind();
            }
            else
            {
                dgvProyectos.DataSource = listaProyectosFiltrados.ToList();
                dgvProyectos.DataBind();
            }
        }
        //private void FiltrarProyectosPorFondo(int id)
        //{
        //    //TRAER UNA LISTA DE CONVOCATORIAS QUE PERTENECEN AL idProyecto
        //    List<Convocatorium> listaConvocatorias = convocatoriaNego.MostrarConvocatorias().Where(c => c.IdFondo == id).ToList();

        //    //TRAER UNA LISTA DE PROYECTOS QUE PERTENECEN A listaConvocatorias
        //    foreach (Convocatorium conv in listaConvocatorias)
        //    {
        //        foreach (Proyecto proy in proyectoNego.MostrarProyectos().ToList())
        //        {
        //            if (proy.IdConvocatoria == conv.IdConvocatoria)
        //            {
        //                listaProyectos.Add(proy);
        //            }
        //        }
        //    }


        //    dgvProyectos.Columns[0].Visible = true;
        //    dgvProyectos.Columns[1].Visible = true;
        //    dgvProyectos.Columns[2].Visible = true;
        //    //dgvProyectos.Columns[3].Visible = true;
        //    dgvProyectos.DataSource = listaProyectos.ToList();
        //    dgvProyectos.DataBind();
        //    dgvProyectos.Columns[0].Visible = false;
        //}

        protected void dgvProyectos_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow row = this.dgvProyectos.SelectedRow;

            numeroExpedienteProyectoSeleccionado = row.Cells[0].Text;

            idProyectoSeleccionado = proyectoNego.ObtenerProyectoSegunNumeroExpediente(numeroExpedienteProyectoSeleccionado).IdProyecto;

            Response.Redirect("Actuaciones.aspx");







            ////Accessing BoundField Column
            //idProyectoSeleccionado = Convert.ToInt32(dgvProyectos.SelectedRow.Cells[0].Text);

            ////Accessing TemplateField Column controls
            //string conv = (dgvProyectos.SelectedRow.FindControl("lblConvocatoria") as Label).Text;

            //Response.Redirect("Actuaciones.aspx");
        }

        protected void ddlConvocatoria_SelectedIndexChanged(object sender, EventArgs e)
        {
            idConvocatoriaSeleccionada = Convert.ToInt32(ddlConvocatoria.SelectedValue.ToString());

            dgvProyectos.DataSource = proyectoNego.ListarChoiceProyectos(idConvocatoriaSeleccionada).ToList();
            dgvProyectos.DataBind();

            //dgvProyectos.Columns[0].Visible = false;
        }
                              
    }
}