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
    public partial class ListarConvocatorias : System.Web.UI.Page
    {
        ConvocatoriaNego convocatoriaNego = new ConvocatoriaNego();
        FondoNego fondoNego = new FondoNego();
        public static int idConvocatoriaSeleccionada;
        private List<string> listaEstados = new List<string>(new string[] { "Todas", "Abiertas", "Cerradas", "En Evaluacion" });
        private static List<Convocatorium> listaConvocatoriasFiltradas = new List<Convocatorium>();

        public static int idFondoSeleccionado = 1;
        public static int idEstadoActual = 1;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack) return;

            listaConvocatoriasFiltradas = convocatoriaNego.MostrarConvocatorias().ToList();
            MostrarListaConvocatorias();
            LlenarListaEstados();
            LlenarListaFiltroFondo();
        }
        private void LlenarListaEstados()
        {
            ddlEstado.DataSource = listaEstados;
            ddlEstado.DataBind();
        }
        private void LlenarListaFiltroFondo()
        {
            ddlFiltroFondo.DataSource = fondoNego.MostrarFondos().ToList();
            ddlFiltroFondo.DataValueField = "idFondo";
            ddlFiltroFondo.DataBind();
        }

        private void MostrarListaConvocatorias()
        {
            dgvConvocatoria.Columns[0].Visible = true;
            dgvConvocatoria.Columns[1].Visible = true;
            dgvConvocatoria.Columns[2].Visible = true;
            dgvConvocatoria.Columns[3].Visible = true;
            dgvConvocatoria.Columns[4].Visible = true;
            dgvConvocatoria.Columns[5].Visible = true;

            dgvConvocatoria.DataSource = listaConvocatoriasFiltradas;
            dgvConvocatoria.DataBind();

            dgvConvocatoria.Columns[0].Visible = false;
        }

        protected void dgvConvocatoria_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            //Obtengo el indice de la fila seleccionada con el boton MOSTRAR
            GridViewRow row = (GridViewRow)(((Button)e.CommandSource).NamingContainer);
            int rIndex = row.RowIndex;

            //Obtengo el id de la convocatoria seleccionada
            idConvocatoriaSeleccionada = Convert.ToInt32(dgvConvocatoria.Rows[rIndex].Cells[0].Text);

            MostrarConvocatoria();
        }
        private void MostrarConvocatoria()
        {
            Response.Redirect("MostrarConvocatoria.aspx");
        }

        protected void btnFiltrarConvocatorias_Click(object sender, EventArgs e)
        {
            FiltrarConvocatorias();
        }
        public void FiltrarConvocatorias()
        {
            idEstadoActual = Convert.ToInt32(ddlEstado.SelectedIndex.ToString());

            if (Convert.ToInt32(ddlFiltroFondo.SelectedValue) != -1)
            {
                idFondoSeleccionado = fondoNego.ObtenerFondoSegunNombre(ddlFiltroFondo.SelectedItem.ToString()).IdFondo;

                if (idEstadoActual == 0) //todas
                {
                    listaConvocatoriasFiltradas = convocatoriaNego.MostrarConvocatorias().Where(c => c.IdFondo == idFondoSeleccionado).ToList();
                }
                else if (idEstadoActual == 1) //abiertas
                {
                    listaConvocatoriasFiltradas = convocatoriaNego.MostrarConvocatorias().Where(c => (c.Abierta == true && c.IdFondo == idFondoSeleccionado)).ToList();
                }
                else if (idEstadoActual == 2) //cerradas
                {
                    listaConvocatoriasFiltradas = convocatoriaNego.MostrarConvocatorias().Where(c => (c.Abierta == false && c.IdFondo == idFondoSeleccionado)).ToList();
                }
                else if (idEstadoActual == 3) //en evaluacion
                {
                    listaConvocatoriasFiltradas = convocatoriaNego.MostrarConvocatorias().Where(c => (c.Anio == 5 && c.IdFondo == idFondoSeleccionado)).ToList();
                }

                dgvConvocatoria.Columns[0].Visible = true;
                dgvConvocatoria.Columns[1].Visible = true;
                dgvConvocatoria.Columns[2].Visible = true;
                dgvConvocatoria.Columns[3].Visible = true;
                dgvConvocatoria.Columns[4].Visible = true;
                dgvConvocatoria.Columns[5].Visible = true;

                dgvConvocatoria.DataSource = listaConvocatoriasFiltradas;
                dgvConvocatoria.DataBind();

                dgvConvocatoria.Columns[0].Visible = false;
            }
        }

        protected void btnFiltrarConvocatoriasAbiertas_Click(object sender, EventArgs e)
        {
            //Response.Redirect("ListarConvocatorias.aspx");

            dgvConvocatoria.Columns[0].Visible = true;
            dgvConvocatoria.Columns[1].Visible = true;
            dgvConvocatoria.Columns[2].Visible = true;
            dgvConvocatoria.Columns[3].Visible = true;
            dgvConvocatoria.Columns[4].Visible = true;
            dgvConvocatoria.Columns[5].Visible = true;

            dgvConvocatoria.DataSource = convocatoriaNego.MostrarConvocatorias().Where(c => c.Abierta == true).ToList();
            dgvConvocatoria.DataBind();

            dgvConvocatoria.Columns[0].Visible = false;
        }
    }
}