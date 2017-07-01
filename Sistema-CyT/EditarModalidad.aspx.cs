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
    public partial class EditarModalidad : System.Web.UI.Page
    {
        ModalidadNego modalidadNego = new ModalidadNego();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                CargarDatosModalidad(EditarConvocatoria.idModalidadActual);
            }
        }
        private void CargarDatosModalidad(int id)
        {
            Modalidad item = modalidadNego.ObtenerModalidadSegunId(id);

            txtNombreModal.Text = item.Nombre.ToString();
            txtDescripcionModal.Text = item.Descripcion.ToString();
            txtObjetivoModal.Text = item.Objetivo.ToString();
            txtMontoMaximoProyectoModal.Text = Convert.ToString(item.MontoMaximoProyecto.Value);
            txtPorcentajeFinanciamientoModal.Text = Convert.ToString(item.PorcentajeFinanciamiento.Value);
            txtPlazoEjecucionModal.Text = Convert.ToString(item.PlazoEjecucion.Value);
        }

        protected void btnModalModalidadActualizar_Click(object sender, EventArgs e)
        {
            ActualizarModalidad();
            Response.Redirect("ListarConvocatorias.aspx");
        }

        private void ActualizarModalidad()
        {
            Modalidad item = new Modalidad();

            item.IdModalidad = EditarConvocatoria.idConvocatoriaActual;
            item.Nombre = txtNombreModal.Text;
            item.Descripcion = txtDescripcionModal.Text;
            item.Objetivo = txtObjetivoModal.Text;
            item.MontoMaximoProyecto = Int32.Parse(txtMontoMaximoProyectoModal.Text);
            item.PorcentajeFinanciamiento = Int32.Parse(txtPorcentajeFinanciamientoModal.Text);
            item.PlazoEjecucion = Int32.Parse(txtPlazoEjecucionModal.Text);

            modalidadNego.ActualizarModalidad(item);

            Response.Redirect("ListarConvocatorias.aspx");
        }

        protected void btnModalModalidadSalir_Click(object sender, EventArgs e)
        {
            Response.Redirect("ListarConvocatorias.aspx");
        }
    }
}