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
    public partial class ListarUdts : System.Web.UI.Page
    {
        UdtUvtNego udtUvtNego = new UdtUvtNego();
        LocalidadNego localidadNego = new LocalidadNego();
        PersonaNego personaNego = new PersonaNego();

        public static int idUdtUvtSeleccionada;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack) return;

            MostrarGrilla(); //SIRVE PARA LA GRILLA
        }
        private void MostrarGrilla()
        {
            dgvUdtUvt.DataSource = udtUvtNego.MostrarUdtUvts().ToList().OrderBy(c => c.Nombre);
            dgvUdtUvt.DataBind();

            dgvUdtUvt.Columns[0].Visible = false;
        }

        protected void dgvUdtUvt_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {
            idUdtUvtSeleccionada = Convert.ToInt32(dgvUdtUvt.Rows[e.NewSelectedIndex].Cells[0].Text);

            lblUdtUvt.Text = dgvUdtUvt.Rows[e.NewSelectedIndex].Cells[0].Text;

            Response.Redirect("MostrarUdtUvt.aspx");
        }
    }
}