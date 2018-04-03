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
    public partial class ListarProyectosCofecyt : System.Web.UI.Page
    {
        ProyectoCofecytNego proyectoCofecytNego = new ProyectoCofecytNego();
        ConvocatoriaNego convocatoriaNego = new ConvocatoriaNego();
        FondoNego fondoNego = new FondoNego();

        public static int idProyectoCofecytSeleccionado = 1;
        public static int idConvocatoriaSeleccionada = 1;
        public static string numeroExpedienteProyectoSeleccionado = null;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack) return;

            LlenarListaConvocatorias();

            //MostrarGrillaProyectos(); //SIRVE PARA LA GRILLA

        }

        private void LlenarListaConvocatorias()
        {
            Fondo fondo = fondoNego.ObtenerFondoSegunNombre("COFECyT");

            ddlConvocatoria.DataSource = convocatoriaNego.MostrarConvocatorias().Where(c => c.IdFondo == fondo.IdFondo).Where(c => c.Activa == true).ToList();
            ddlConvocatoria.DataValueField = "idConvocatoria";
            ddlConvocatoria.DataBind();
        }
        private void MostrarGrillaProyectos()
        {
            dgvProyectos.DataSource = proyectoCofecytNego.MostrarProyectoCofecyts().ToList();
            dgvProyectos.DataBind();

            dgvProyectos.Columns[0].Visible = false;
        }

        protected void dgvProyectos_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {
            //idConvocatoriaSeleccionada = Convert.ToInt32(ddlConvocatoria.SelectedValue.ToString());

            dgvProyectos.Columns[0].Visible = true;
            dgvProyectos.Columns[1].Visible = true;
            dgvProyectos.Columns[2].Visible = true;

            dgvProyectos.DataSource = proyectoCofecytNego.MostrarProyectoCofecyts().Where(c => c.IdConvocatoria == idConvocatoriaSeleccionada).ToList();
            dgvProyectos.DataBind();

            dgvProyectos.Columns[0].Visible = false;

            lblFondo.Text = dgvProyectos.Rows[e.NewSelectedIndex].Cells[0].Text;

            idProyectoCofecytSeleccionado = Convert.ToInt32(dgvProyectos.Rows[e.NewSelectedIndex].Cells[0].Text);

            Response.Redirect("ActuacionesProyectoCofecyt.aspx");
        }

        protected void dgvProyectos_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            //idConvocatoriaSeleccionada = Convert.ToInt32(ddlConvocatoria.SelectedValue.ToString());

            dgvProyectos.Columns[0].Visible = true;
            dgvProyectos.Columns[1].Visible = true;
            dgvProyectos.Columns[2].Visible = true;

            dgvProyectos.DataSource = proyectoCofecytNego.MostrarProyectoCofecyts().Where(c => c.IdConvocatoria == idConvocatoriaSeleccionada).ToList();
            dgvProyectos.DataBind();

            dgvProyectos.Columns[0].Visible = false;

            lblFondo.Text = dgvProyectos.Rows[e.RowIndex].Cells[0].Text;

            idProyectoCofecytSeleccionado = Convert.ToInt32(dgvProyectos.Rows[e.RowIndex].Cells[0].Text);

            Response.Redirect("MostrarProyectoCofecyt.aspx");
        }

        protected void ddlConvocatoria_SelectedIndexChanged(object sender, EventArgs e)
        {
            idConvocatoriaSeleccionada = Convert.ToInt32(ddlConvocatoria.SelectedValue.ToString());


            dgvProyectos.Columns[0].Visible = true;
            dgvProyectos.Columns[1].Visible = true;
            dgvProyectos.Columns[2].Visible = true;

            dgvProyectos.DataSource = proyectoCofecytNego.MostrarProyectoCofecyts().Where(c => c.IdConvocatoria == idConvocatoriaSeleccionada).ToList();
            dgvProyectos.DataBind();

            dgvProyectos.Columns[0].Visible = false;
        }
    }
}