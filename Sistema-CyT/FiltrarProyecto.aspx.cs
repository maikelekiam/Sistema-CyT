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
        private List<string> listaAnios = new List<string>(new string[] { "2017", "2016", "2015", "2014", "2013", "2012", "2011", "2010", "2009", "2008", "2007", "2006" });
        private List<Proyecto> listaProyectos = new List<Proyecto>();


        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack) return;

            MostrarListaProyectos();
            LlenarListaFondos();
            LlenarListaAnios();
            //listaProyectos.Clear();
        }
        private void LlenarListaFondos()
        {
            ddlFondo.DataSource = fondoNego.MostrarFondos().ToList();
            ddlFondo.DataValueField = "idFondo";
            ddlFondo.DataBind();
        }
        private void LlenarListaAnios()
        {
            ddlAnio.DataSource = listaAnios;
            ddlAnio.DataBind();
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
            idProyectoSeleccionado = Convert.ToInt32(dgvProyectos.Rows[rIndex].Cells[0].Text);

            Response.Redirect("Actuaciones.aspx");
        }

        protected void ddlFondo_SelectedIndexChanged(object sender, EventArgs e)
        {
            FiltrarProyectosPorFondo(Convert.ToInt32(ddlFondo.SelectedValue.ToString()));
        }
        private void FiltrarProyectosPorFondo(int id)
        {
            //TRAER UNA LISTA DE CONVOCATORIAS QUE PERTENECEN AL idProyecto
            List<Convocatorium> listaConvocatorias = convocatoriaNego.MostrarConvocatorias().Where(c => c.IdFondo == id).ToList();

            //TRAER UNA LISTA DE PROYECTOS QUE PERTENECEN A listaConvocatorias
            foreach (Convocatorium conv in listaConvocatorias)
            {
                foreach (Proyecto proy in proyectoNego.MostrarProyectos().ToList())
                {
                    if (proy.IdConvocatoria == conv.IdConvocatoria)
                    {
                        listaProyectos.Add(proy);
                    }
                }
            }
            dgvProyectos.DataSource = listaProyectos.ToList();
            dgvProyectos.DataBind();
        }

        protected void dgvProyectos_SelectedIndexChanged(object sender, EventArgs e)
        {

        }                
    }
}