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




            if (item.MontoMaximoProyecto == null) { txtMontoMaximoProyectoModal.Text = ""; }
            else { txtMontoMaximoProyectoModal.Text = Convert.ToString(item.MontoMaximoProyecto); }

            if (item.PorcentajeFinanciamiento == null) { txtPorcentajeFinanciamientoModal.Text = ""; }
            else { txtPorcentajeFinanciamientoModal.Text = Convert.ToString(item.PorcentajeFinanciamiento); }

            if (item.PlazoEjecucion == null) { txtPlazoEjecucionModal.Text = ""; }
            else { txtPlazoEjecucionModal.Text = Convert.ToString(item.PlazoEjecucion); }

            //txtMontoMaximoProyectoModal.Text = Convert.ToString(item.MontoMaximoProyecto.Value);
            //txtPorcentajeFinanciamientoModal.Text = Convert.ToString(item.PorcentajeFinanciamiento.Value);
            //txtPlazoEjecucionModal.Text = Convert.ToString(item.PlazoEjecucion.Value);
        }

        protected void btnModalModalidadActualizar_Click(object sender, EventArgs e)
        {
            if ((txtNombreModal.Text != "")
                //&& (txtMontoMaximoProyectoModal.Text != "") &&
                //(txtPorcentajeFinanciamientoModal.Text != "") &&
                //(txtPlazoEjecucionModal.Text != "")
                )
            {
                ActualizarModalidad();

                EditarConvocatoria.listaTemporalModalidades.Clear();
                EditarConvocatoria.listaTemporalModalidadesAgregado.Clear();

                Response.Redirect("EditarConvocatoria.aspx");
            }
            else
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Correct", "alert('Complete todos los campos.')", true);
            }

        }

        private void ActualizarModalidad()
        {
            Modalidad item = new Modalidad();

            item.IdModalidad = EditarConvocatoria.idModalidadActual;
            item.IdConvocatoria = EditarConvocatoria.idConvocatoriaActual;

            item.Nombre = txtNombreModal.Text;
            item.Descripcion = txtDescripcionModal.Text;
            item.Objetivo = txtObjetivoModal.Text;

            if (txtMontoMaximoProyectoModal.Text == "") { item.MontoMaximoProyecto = null; }
            else { item.MontoMaximoProyecto = Int32.Parse(txtMontoMaximoProyectoModal.Text); }

            if (txtPorcentajeFinanciamientoModal.Text == "") { item.PorcentajeFinanciamiento = null; }
            else { item.PorcentajeFinanciamiento = Int32.Parse(txtPorcentajeFinanciamientoModal.Text); }

            if (txtPlazoEjecucionModal.Text == "") { item.PlazoEjecucion = null; }
            else { item.PlazoEjecucion = Int32.Parse(txtPlazoEjecucionModal.Text); }

            //item.MontoMaximoProyecto = Int32.Parse(txtMontoMaximoProyectoModal.Text);
            //item.PorcentajeFinanciamiento = Int32.Parse(txtPorcentajeFinanciamientoModal.Text);
            //item.PlazoEjecucion = Int32.Parse(txtPlazoEjecucionModal.Text);

            modalidadNego.ActualizarModalidad(item);
        }

        protected void btnModalModalidadSalir_Click(object sender, EventArgs e)
        {
            Response.Redirect("Default.aspx");
        }
    }
}