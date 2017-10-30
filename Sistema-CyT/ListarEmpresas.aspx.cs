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
    public partial class ListarEmpresas : System.Web.UI.Page
    {
        EmpresaNego empresaNego = new EmpresaNego();
        LocalidadNego localidadNego = new LocalidadNego();

        public static int idEmpresaSeleccionada;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack) return;

            MostrarGrillaEmpresas(); //SIRVE PARA LA GRILLA
        }
        private void MostrarGrillaEmpresas()
        {
            dgvEmpresa.DataSource = empresaNego.MostrarEmpresas().ToList().OrderBy(c => c.Nombre);
            dgvEmpresa.DataBind();

            dgvEmpresa.Columns[0].Visible = false;
        }

        protected void dgvEmpresa_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {
            idEmpresaSeleccionada = Convert.ToInt32(dgvEmpresa.Rows[e.NewSelectedIndex].Cells[0].Text);

            lblEmpresa.Text = dgvEmpresa.Rows[e.NewSelectedIndex].Cells[0].Text;

            Response.Redirect("MostrarEmpresa.aspx");
        }
    }
}