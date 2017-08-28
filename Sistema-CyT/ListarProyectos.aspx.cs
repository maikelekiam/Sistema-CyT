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
    public partial class ListarProyectos : System.Web.UI.Page
    {
        ProyectoNego proyectoNego = new ProyectoNego();
        ConvocatoriaNego convocatoriaNego = new ConvocatoriaNego();
        private List<string> listaEstados = new List<string>(new string[] { "Todos", "En Ejecucion", "Finalizado","Dado de Baja" });
        
        public static int idProyectoSeleccionado=1;
        public static int idConvocatoriaSeleccionada=1;
        public static int idEstadoSeleccionado = 1;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack) return;

            MostrarListaProyectos();
            LlenarListaEstados();
            LlenarListaConvocatorias();

        }
        private void LlenarListaEstados()
        {
            ddlEstado.DataSource = listaEstados;
            ddlEstado.DataBind();
        }
        private void LlenarListaConvocatorias()
        {
            ddlConvocatoria.DataSource = convocatoriaNego.MostrarConvocatorias().ToList();
            ddlConvocatoria.DataValueField = "idConvocatoria";
            ddlConvocatoria.DataBind();
        }

        private void MostrarListaProyectos()
        {
            //dgvProyectos.Columns[0].Visible = true;
            //dgvProyectos.Columns[1].Visible = true;
            //dgvProyectos.Columns[2].Visible = true;
            //dgvProyectos.Columns[3].Visible = true;
            //dgvProyectos.Columns[4].Visible = true;

            dgvProyectos.DataSource = proyectoNego.MostrarProyectos().ToList();
            dgvProyectos.DataBind();

            dgvProyectos.Columns[0].Visible = false;
            //dgvProyectos.Columns[4].Visible = false;
        }

        protected void dgvProyectos_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            //Obtengo el indice de la fila seleccionada con el boton MOSTRAR
            GridViewRow row = (GridViewRow)(((Button)e.CommandSource).NamingContainer);
            int rIndex = row.RowIndex;

            //Obtengo el id del proyecto seleccionado
            //idProyectoSeleccionado = Convert.ToInt32(dgvProyectos.Rows[rIndex].Cells[0].Text);

            lblEstado.Text = dgvProyectos.Rows[rIndex].Cells[0].Text;
            ddlConvocatoria.Text = dgvProyectos.Rows[rIndex].Cells[1].Text;
            

            //MostrarProyecto();
        }
        private void MostrarProyecto()
        {
            //Response.Redirect("MostrarFondo.aspx");
        }

        

        //protected void ddlEstado_SelectedIndexChanged(object sender, EventArgs e)
        //{

        //}

        //protected void ddlFiltroConvocatoria_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    FiltrarProyectosPorConvocatoria(convocatoriaNego.ObtenerConvocatoriaSegunNombre(ddlFiltroConvocatoria.SelectedItem.ToString()).IdConvocatoria);
        //}
        //private void FiltrarProyectosPorConvocatoria(int id)
        //{
        //    //dgvProyectos.Columns[0].Visible = true;
        //    //dgvProyectos.Columns[1].Visible = true;
        //    //dgvProyectos.Columns[2].Visible = true;
        //    //dgvProyectos.Columns[3].Visible = true;
        //    //dgvProyectos.Columns[4].Visible = true;

        //    dgvProyectos.DataSource = proyectoNego.MostrarProyectos().Where(c => c.IdConvocatoria == id).ToList();
        //    dgvProyectos.DataBind();

        //    dgvProyectos.Columns[0].Visible = false;
        //    //dgvProyectos.Columns[4].Visible = false;
        //}

        protected void btnFiltrarProyectos_Click(object sender, EventArgs e)
        {
            FiltrarProyectos();
        }
        private void FiltrarProyectos()
        {

        }
    }
}