using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CapaDominio;
using CapaNegocio;
using System.Windows.Forms;

namespace Sistema_CyT
{
    public partial class AltaConvocatoria : System.Web.UI.Page
    {
        private ConvocatoriaNego convocatoriaNego = new ConvocatoriaNego();
        private FondoNego fondoNego = new FondoNego();
        private TipoFinanciamientoNego tipoFinanciamientoNego = new TipoFinanciamientoNego();
        private TipoConvocatoriaNego tipoConvocatoriaNego = new TipoConvocatoriaNego();
        private ModalidadNego modalidadNego = new ModalidadNego();
        static int idConvocatoriaActual;

        static List<Modalidad> listaConvocatoriaModalidades = new List<Modalidad>();
        private ListaConvocatoriaModalidadNego listaConvocatoriaModalidadNego = new ListaConvocatoriaModalidadNego();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                LlenarListaFondos();
                LlenarListaTipofinanciamiento();
                LlenarListaTipoConvocatoria();
                LimpiarFormulario();

                txtAnio.Text = "2017";
                txtFechaApertura.Text = Convert.ToString(DateTime.Today.ToShortDateString());
                txtFechaCierre.Text = Convert.ToString(DateTime.Today.ToShortDateString());

                //PanelMostrarModalidad.Visible = false;
            }
        }
        private void LlenarListaFondos()
        {
            ddlFondo.DataSource = fondoNego.MostrarFondos().ToList();
            ddlFondo.DataValueField = "idFondo";
            ddlFondo.DataBind();
        }
        private void LlenarListaTipofinanciamiento()
        {
            ddlTipoFinanciamiento.DataSource = tipoFinanciamientoNego.MostrarTipoFinanciamientoes().ToList();
            ddlTipoFinanciamiento.DataValueField = "idTipoFinanciamiento";
            ddlTipoFinanciamiento.DataBind();
        }
        private void LlenarListaTipoConvocatoria()
        {
            ddlTipoConvocatoria.DataSource = tipoConvocatoriaNego.MostrarTipoConvocatorias().ToList();
            ddlTipoConvocatoria.DataValueField = "idTipoConvocatoria";
            ddlTipoConvocatoria.DataBind();
        }

        protected void btnGuardarConvocatoria_Click(object sender, EventArgs e)
        {
            //if (string.IsNullOrEmpty(txtNombre.Text) ||
            //    string.IsNullOrEmpty(txtDescripcion.Text) ||
            //    string.IsNullOrEmpty(txtObjetivo.Text) ||
            //    string.IsNullOrEmpty(txtFechaApertura.Text) ||
            //    string.IsNullOrEmpty(txtFechaCierre.Text) ||
            //    string.IsNullOrEmpty(txtAnio.Text)
            //    )
            //{
            //    MessageBox.Show("Debe completar todos los campos");
            //    return;
            //}


            GuardarConvocatoria();
            LimpiarFormulario();
            
        }

        private void GuardarConvocatoria()
        {
            Convocatorium convocatoria = new Convocatorium();

            //PRIMERO GUARDO LA CONVOCATORIA
            convocatoria.Nombre = txtNombre.Text;
            convocatoria.Descripcion = txtDescripcion.Text;
            convocatoria.Objetivo = txtObjetivo.Text;
            convocatoria.Anio = Int32.Parse(txtAnio.Text);
            convocatoria.IdFondo = Int32.Parse(ddlFondo.SelectedValue);
            convocatoria.IdTipoFinanciamiento = Int32.Parse(ddlTipoFinanciamiento.SelectedValue);
            convocatoria.IdTipoConvocatoria = Int32.Parse(ddlTipoConvocatoria.SelectedValue);
            convocatoria.FechaApertura = Convert.ToDateTime(txtFechaApertura.Text);
            convocatoria.FechaCierre = Convert.ToDateTime(txtFechaCierre.Text);

            if (chkAbierta.Checked)
            {
                convocatoria.Abierta = true;
            }
            else if (!chkAbierta.Checked)
            {
                convocatoria.Abierta = false;
            }

            //DESPUES GUARDO LA LISTA DE MODALIDADES DE LA CONVOCATORIA ACTUAL
            int idConvocatoria = convocatoriaNego.GuardarConvocatoria(convocatoria);
            idConvocatoriaActual = idConvocatoria;

            foreach (Modalidad t in listaConvocatoriaModalidades)
            {
                ListaConvocatoriaModalidad listaConvocatoriaModalidad = new ListaConvocatoriaModalidad();
                listaConvocatoriaModalidad.IdConvocatoria = idConvocatoria;
                listaConvocatoriaModalidad.IdModalidad = t.IdModalidad;
                listaConvocatoriaModalidadNego.GuardarListaConvocatoriaModalidad(listaConvocatoriaModalidad);
            }
        }

        protected void btnModalModalidadGuardar_Click(object sender, EventArgs e)
        {
            //if (string.IsNullOrEmpty(txtNombreModal.Text) ||
            //    string.IsNullOrEmpty(txtDescripcionModal.Text) ||
            //    string.IsNullOrEmpty(txtObjetivoModal.Text) ||
            //    string.IsNullOrEmpty(txtMontoMaximoProyectoModal.Text) ||
            //    string.IsNullOrEmpty(txtPlazoEjecucionModal.Text) ||
            //    string.IsNullOrEmpty(txtPorcentajeFinanciamientoModal.Text)
            //    )
            //{
            //    MessageBox.Show("Debe completar todos los campos");
            //    return;
            //}

            Modalidad item = new Modalidad();
            item.Nombre = txtNombreModal.Text;
            item.Descripcion = txtDescripcionModal.Text;
            item.Objetivo = txtObjetivoModal.Text;
            item.MontoMaximoProyecto = Int32.Parse(txtMontoMaximoProyectoModal.Text);
            item.PorcentajeFinanciamiento = Int32.Parse(txtPorcentajeFinanciamientoModal.Text);
            item.PlazoEjecucion = Int32.Parse(txtPlazoEjecucionModal.Text);

            modalidadNego.GuardarModalidad(item);

            listaConvocatoriaModalidades.Add(item);

            txtNombreModal.Text = null;
            txtDescripcionModal.Text = null;
            txtObjetivoModal.Text = null;
            txtMontoMaximoProyectoModal.Text = null;
            txtPlazoEjecucionModal.Text = null;
            txtPorcentajeFinanciamientoModal.Text = null;

            LlenarGrillaModalidades();
        }

        private void LlenarGrillaModalidades()
        {
            dgvModalidades.DataSource = listaConvocatoriaModalidades;
            dgvModalidades.DataBind();
        }

        private void LimpiarFormulario()
        {
            txtNombre.Text = null;
            txtDescripcion.Text = null;
            txtObjetivo.Text = null;
            txtAnio.Text = null;
            ddlFondo.SelectedIndex = 0;
            ddlTipoConvocatoria.SelectedIndex = 0;
            ddlTipoFinanciamiento.SelectedIndex = 0;
            txtFechaApertura.Text = null;
            txtFechaCierre.Text = null;
            chkAbierta.Checked = false;
            listaConvocatoriaModalidades.Clear();
            LlenarGrillaModalidades();
        }
    }
}