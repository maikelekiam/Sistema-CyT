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
        ProyectoCofecytNego proyectoCofecytNego = new ProyectoCofecytNego();
        ConvocatoriaNego convocatoriaNego = new ConvocatoriaNego();
        TipoEstadoNego tipoEstadoNego = new TipoEstadoNego();
        FondoNego fondoNego = new FondoNego();

        List<pr02ResultSet0> listaProyectosFiltrados = new List<pr02ResultSet0>();
        List<pr02ResultSet0> listaChoiceProyectos = new List<pr02ResultSet0>();
        List<pr03ResultSet0> listaChoiceProyectoCofecyts = new List<pr03ResultSet0>();

        public static int idProyectoSeleccionado = 1;
        public static int idConvocatoriaSeleccionada = 1;
        public static int idEstadoSeleccionado = 1;
        public static string numeroExpedienteProyectoSeleccionado = null;

        int cantidadProyectosSumatoria = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack) return;

            LlenarListaEstados();
            LlenarListaFondoChoice();
        }
        private void LlenarListaFondoChoice()
        {
            ddlFondoChoice.DataSource = fondoNego.MostrarFondos().ToList();
            ddlFondoChoice.DataValueField = "idFondo";
            ddlFondoChoice.DataBind();
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

        protected void btnFiltrar_Click(object sender, EventArgs e)
        {
            if ((Convert.ToInt32(ddlEstado.SelectedValue) != -1) && (ddlConvocatoria.SelectedValue != "-1") && (ddlConvocatoria.SelectedValue != ""))
            {
                idEstadoSeleccionado = tipoEstadoNego.ObtenerTipoEstadoSegunNombre(ddlEstado.SelectedItem.ToString()).IdTipoEstado;

                idConvocatoriaSeleccionada = Convert.ToInt32(ddlConvocatoria.SelectedValue.ToString());

                dgvProyectos.Columns[0].Visible = true;
                dgvProyectos.Columns[1].Visible = true;
                dgvProyectos.Columns[2].Visible = true;
                dgvProyectos.Columns[3].Visible = true;
                dgvProyectos.Columns[4].Visible = true;

                dgvProyectos.DataSource = proyectoNego.ListarChoiceProyectos(idConvocatoriaSeleccionada).Where(c => c.tipoEstado == ddlEstado.SelectedItem.ToString()).ToList();
                dgvProyectos.DataBind();

                cantidadProyectosSumatoria = proyectoNego.ListarChoiceProyectos(idConvocatoriaSeleccionada).Where(c => c.tipoEstado == ddlEstado.SelectedItem.ToString()).Count();
                lblCantidadProyectosSumatoria.Text = "Cantidad de Proyectos = " + Convert.ToString(cantidadProyectosSumatoria);
            }
        }

        protected void ddlFondoChoice_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlFondoChoice.SelectedValue != "-1")
            {
                LlenarChoiceConvocatorias(Convert.ToInt32(ddlFondoChoice.SelectedValue));
            }
            else
            {
                Response.Redirect("ListarProyectos.aspx");
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
                    dgvProyectos.Visible = false;
                    dgvProyectoCofecyts.Visible = true;
                    //Traer la lista de proyectos cofecyt
                    dgvProyectoCofecyts.DataSource = proyectoCofecytNego.ListarChoiceProyectoCofecyts(idConvocatoriaSeleccionada).ToList();
                    dgvProyectoCofecyts.DataBind();

                    cantidadProyectosSumatoria = proyectoCofecytNego.ListarChoiceProyectoCofecyts(idConvocatoriaSeleccionada).Count();
                    lblCantidadProyectosSumatoria.Text = "Cantidad de Proyectos = " + Convert.ToString(cantidadProyectosSumatoria);
                }
                else
                {
                    dgvProyectos.Visible = true;
                    dgvProyectoCofecyts.Visible = false;
                    dgvProyectos.DataSource = proyectoNego.ListarChoiceProyectos(idConvocatoriaSeleccionada).ToList();
                    dgvProyectos.DataBind();

                    cantidadProyectosSumatoria = proyectoNego.ListarChoiceProyectos(idConvocatoriaSeleccionada).Count();
                    lblCantidadProyectosSumatoria.Text = "Cantidad de Proyectos = " + Convert.ToString(cantidadProyectosSumatoria);
                }
            }
            else
            {
                if (fondoNego.ObtenerFondo(Convert.ToInt32(ddlFondoChoice.SelectedValue)).Nombre.ToUpper() == "COFECYT")
                {
                    dgvProyectos.Visible = false;
                    dgvProyectoCofecyts.Visible = true;
                    dgvProyectoCofecyts.DataSource = proyectoCofecytNego.ListarChoiceProyectoCofecyts(idConvocatoriaSeleccionada).ToList();
                    dgvProyectoCofecyts.DataBind();

                    cantidadProyectosSumatoria = proyectoCofecytNego.ListarChoiceProyectoCofecyts(idConvocatoriaSeleccionada).Count();
                    lblCantidadProyectosSumatoria.Text = "Cantidad de Proyectos = " + Convert.ToString(cantidadProyectosSumatoria);
                }
                else
                {
                    dgvProyectos.Visible = true;
                    dgvProyectoCofecyts.Visible = false;
                    dgvProyectos.DataSource = listaProyectosFiltrados.ToList();
                    dgvProyectos.DataBind();

                    cantidadProyectosSumatoria = listaProyectosFiltrados.Count();
                    lblCantidadProyectosSumatoria.Text = "Cantidad de Proyectos = " + Convert.ToString(cantidadProyectosSumatoria);
                }
            }
        }

        protected void ddlConvocatoria_SelectedIndexChanged(object sender, EventArgs e)
        {
            idConvocatoriaSeleccionada = Convert.ToInt32(ddlConvocatoria.SelectedValue.ToString());

            if (fondoNego.ObtenerFondo(Convert.ToInt32(ddlFondoChoice.SelectedValue)).Nombre.ToUpper() == "COFECYT")
            {
                dgvProyectoCofecyts.DataSource = proyectoCofecytNego.ListarChoiceProyectoCofecyts(idConvocatoriaSeleccionada).ToList();
                dgvProyectoCofecyts.DataBind();

                cantidadProyectosSumatoria = proyectoCofecytNego.ListarChoiceProyectoCofecyts(idConvocatoriaSeleccionada).Count();
                lblCantidadProyectosSumatoria.Text = "Cantidad de Proyectos = " + Convert.ToString(cantidadProyectosSumatoria);
            }
            else
            {
                dgvProyectos.DataSource = proyectoNego.ListarChoiceProyectos(idConvocatoriaSeleccionada).ToList();
                dgvProyectos.DataBind();

                cantidadProyectosSumatoria = proyectoNego.ListarChoiceProyectos(idConvocatoriaSeleccionada).Count();
                lblCantidadProyectosSumatoria.Text = "Cantidad de Proyectos = " + Convert.ToString(cantidadProyectosSumatoria);
            }
        }

        protected void dgvProyectos_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow row = this.dgvProyectos.SelectedRow;

            numeroExpedienteProyectoSeleccionado = row.Cells[0].Text;

            Response.Redirect("MostrarProyecto.aspx");
        }

        protected void btnTodos_Click(object sender, EventArgs e)
        {
            if (ddlConvocatoria.SelectedValue != "-1" && ddlConvocatoria.SelectedValue != "")
            {
                idConvocatoriaSeleccionada = Convert.ToInt32(ddlConvocatoria.SelectedValue.ToString());

                dgvProyectos.Columns[0].Visible = true;
                dgvProyectos.Columns[1].Visible = true;
                dgvProyectos.Columns[2].Visible = true;
                dgvProyectos.Columns[3].Visible = true;
                dgvProyectos.Columns[4].Visible = true;

                dgvProyectos.DataSource = proyectoNego.ListarChoiceProyectos(idConvocatoriaSeleccionada).ToList();
                dgvProyectos.DataBind();

                //dgvProyectos.Columns[0].Visible = false;

                cantidadProyectosSumatoria = proyectoNego.ListarChoiceProyectos(idConvocatoriaSeleccionada).Count();
                lblCantidadProyectosSumatoria.Text = "Cantidad de Proyectos = " + Convert.ToString(cantidadProyectosSumatoria);
            }
            ddlEstado.Text = "-1";
        }

        protected void dgvProyectoCofecyts_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow row = this.dgvProyectoCofecyts.SelectedRow;

            numeroExpedienteProyectoSeleccionado = row.Cells[0].Text;

            Response.Redirect("MostrarProyectoCofecyt.aspx");
        }
    }
}