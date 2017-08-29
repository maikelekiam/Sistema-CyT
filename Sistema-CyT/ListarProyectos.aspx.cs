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
        TipoEstadoNego tipoEstadoNego = new TipoEstadoNego();

        private static List<Proyecto> listaProyectosFiltrados = new List<Proyecto>();

        public static int idProyectoSeleccionado = 1;
        public static int idConvocatoriaSeleccionada = 1;
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
            ddlEstado.DataSource = tipoEstadoNego.MostrarTipoEstados().ToList();
            ddlEstado.DataValueField = "idTipoEstado";
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

        protected void btnFiltrarProyectos_Click(object sender, EventArgs e)
        {
            FiltrarProyectos();
        }
        private void FiltrarProyectos()
        {
            if ((Convert.ToInt32(ddlEstado.SelectedValue) != -1) && (Convert.ToInt32(ddlConvocatoria.SelectedValue) != -1))
            {
                idConvocatoriaSeleccionada = convocatoriaNego.ObtenerConvocatoriaSegunNombre(ddlConvocatoria.SelectedItem.ToString()).IdConvocatoria;

                idEstadoSeleccionado = tipoEstadoNego.ObtenerTipoEstadoSegunNombre(ddlEstado.SelectedItem.ToString()).IdTipoEstado;

                listaProyectosFiltrados = proyectoNego.MostrarProyectos().Where(c => c.IdTipoEstado == idEstadoSeleccionado).Where(c => c.IdConvocatoria == idConvocatoriaSeleccionada).ToList();

                //dgvProyectos.Columns[0].Visible = true;
                //dgvProyectos.Columns[1].Visible = true;
                //dgvProyectos.Columns[2].Visible = true;
                //dgvProyectos.Columns[3].Visible = true;
                //dgvProyectos.Columns[4].Visible = true;

                dgvProyectos.DataSource = listaProyectosFiltrados;
                dgvProyectos.DataBind();

                dgvProyectos.Columns[0].Visible = false;
                //dgvProyectos.Columns[4].Visible = false;
            }
        }

        protected void btnFiltrarTodos_Click(object sender, EventArgs e)
        {
            if ((Convert.ToInt32(ddlEstado.SelectedValue) != -1))
            {
                idEstadoSeleccionado = tipoEstadoNego.ObtenerTipoEstadoSegunNombre(ddlEstado.SelectedItem.ToString()).IdTipoEstado;

                //dgvProyectos.Columns[0].Visible = true;
                //dgvProyectos.Columns[1].Visible = true;
                //dgvProyectos.Columns[2].Visible = true;
                //dgvProyectos.Columns[3].Visible = true;
                //dgvProyectos.Columns[4].Visible = true;

                dgvProyectos.DataSource = proyectoNego.MostrarProyectos().Where(c => c.IdTipoEstado == idEstadoSeleccionado).ToList();
                dgvProyectos.DataBind();

                dgvProyectos.Columns[0].Visible = false;
                //dgvProyectos.Columns[4].Visible = false;
            }
        }

        protected void btnFiltrarConvocatoriaTodos_Click(object sender, EventArgs e)
        {
            if ((Convert.ToInt32(ddlConvocatoria.SelectedValue) != -1))
            {
                idConvocatoriaSeleccionada = convocatoriaNego.ObtenerConvocatoriaSegunNombre(ddlConvocatoria.SelectedItem.ToString()).IdConvocatoria;

                //dgvProyectos.Columns[0].Visible = true;
                //dgvProyectos.Columns[1].Visible = true;
                //dgvProyectos.Columns[2].Visible = true;
                //dgvProyectos.Columns[3].Visible = true;
                //dgvProyectos.Columns[4].Visible = true;

                dgvProyectos.DataSource = proyectoNego.MostrarProyectos().Where(c => c.IdConvocatoria == idConvocatoriaSeleccionada).ToList();
                dgvProyectos.DataBind();

                dgvProyectos.Columns[0].Visible = false;
                //dgvProyectos.Columns[4].Visible = false;
            }
        }
    }
}