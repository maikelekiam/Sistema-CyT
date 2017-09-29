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
    public partial class ListarFondos : System.Web.UI.Page
    {
        FondoNego fondoNego = new FondoNego();
        public static int idFondoSeleccionado;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack) return;

            MostrarListaFondos();
        }

        private void MostrarListaFondos()
        {
            dgvFondos.Columns[0].Visible = true;
            dgvFondos.Columns[1].Visible = true;
            dgvFondos.Columns[2].Visible = true;
            dgvFondos.Columns[3].Visible = true;
            dgvFondos.Columns[4].Visible = true;

            dgvFondos.DataSource = fondoNego.MostrarFondos().OrderBy(c => c.Nombre).ToList();
            dgvFondos.DataBind();

            dgvFondos.Columns[0].Visible = false;
            dgvFondos.Columns[4].Visible = false;
        }

        protected void dgvFondos_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            idFondoSeleccionado = Convert.ToInt32(dgvFondos.Rows[e.RowIndex].Cells[0].Text);

            Response.Redirect("MostrarFondo.aspx");
        }
    }
}