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
    public partial class ListarOrganismos : System.Web.UI.Page
    {
        OrganismoNego organismoNego = new OrganismoNego();
        LocalidadNego localidadNego = new LocalidadNego();

        public static int idOrganismoSeleccionado;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack) return;

            MostrarGrillaOrganismos(); //SIRVE PARA LA GRILLA
        }
        private void MostrarGrillaOrganismos()
        {
            dgvOrganismo.DataSource = organismoNego.MostrarOrganismos().ToList().OrderBy(c => c.Nombre);
            dgvOrganismo.DataBind();

            dgvOrganismo.Columns[0].Visible = false;
        }

        protected void dgvOrganismo_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {
            idOrganismoSeleccionado = Convert.ToInt32(dgvOrganismo.Rows[e.NewSelectedIndex].Cells[0].Text);

            lblOrganismo.Text = dgvOrganismo.Rows[e.NewSelectedIndex].Cells[0].Text;

            Response.Redirect("MostrarOrganismo.aspx");
        }
    }
}