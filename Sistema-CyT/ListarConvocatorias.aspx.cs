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
        public static int idConvocatoriaSeleccionada;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack) return;

            MostrarListaConvocatorias();
        }

        private void MostrarListaConvocatorias()
        {
            dgvConvocatoria.Columns[0].Visible = true;
            dgvConvocatoria.Columns[1].Visible = true;
            dgvConvocatoria.Columns[2].Visible = true;
            dgvConvocatoria.Columns[3].Visible = true;
            dgvConvocatoria.Columns[4].Visible = true;
            dgvConvocatoria.Columns[5].Visible = true;

            dgvConvocatoria.DataSource = convocatoriaNego.MostrarConvocatorias().ToList();
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
    }
}