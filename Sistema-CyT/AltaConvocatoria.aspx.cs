using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CapaDominio;
using CapaNegocio;
using System.Globalization;

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

        static List<Modalidad> listaModalidades = new List<Modalidad>();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                LlenarListaFondos();
                LlenarListaTipofinanciamiento();
                LlenarListaTipoConvocatoria();
                LimpiarFormulario();

                txtAnio.Text = Convert.ToString(DateTime.Now.Year);
                txtFechaApertura.Text = Convert.ToString(DateTime.Today.ToShortDateString());
                txtFechaCierre.Text = Convert.ToString(DateTime.Today.ToShortDateString());

                txtFechaCierre.Visible = true;
                lblFechaCierre.Visible = true;
                fc.Visible = true;
            }
        }
        private void LlenarListaFondos()
        {
            ddlFondo.DataSource = fondoNego.MostrarFondos().OrderBy(c => c.Nombre).ToList();
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

            if (txtNombre.Text != "" && txtFechaApertura != null)
            {
                GuardarConvocatoria();
                LimpiarFormulario();
                listaModalidades.Clear();

                Response.Redirect("ListarConvocatorias.aspx");
            }
            else
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Correct", "alert('Debe completar los campos NOMBRE y FECHA APERTURA.')", true);
            }
        }

        private void GuardarConvocatoria()
        {
            Convocatorium convocatoria = new Convocatorium();

            //PRIMERO GUARDO LA CONVOCATORIA
            convocatoria.Nombre = txtNombre.Text;

            if (txtAnio.Text == "") { convocatoria.Anio = null; }
            else { convocatoria.Anio = Int32.Parse(txtAnio.Text); }

            convocatoria.IdFondo = Int32.Parse(ddlFondo.SelectedValue);
            convocatoria.IdTipoFinanciamiento = Int32.Parse(ddlTipoFinanciamiento.SelectedValue);
            convocatoria.IdTipoConvocatoria = Int32.Parse(ddlTipoConvocatoria.SelectedValue);

            if (txtFechaApertura.Text == "") { convocatoria.FechaApertura = null; }
            else { convocatoria.FechaApertura = DateTime.ParseExact(txtFechaApertura.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture); }

            if (txtFechaCierre.Text == "") { convocatoria.FechaCierre = null; }
            else { convocatoria.FechaCierre = DateTime.ParseExact(txtFechaCierre.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture); }

            //convocatoria.FechaApertura = DateTime.ParseExact(txtFechaApertura.Text, "dd/MMM/yyyy", CultureInfo.InvariantCulture);
            //convocatoria.FechaCierre = DateTime.ParseExact(txtFechaCierre.Text, "dd/MMM/yyyy", CultureInfo.InvariantCulture);

            //convocatoria.FechaApertura = Convert.ToDateTime(txtFechaApertura.Text);
            //convocatoria.FechaCierre = Convert.ToDateTime(txtFechaCierre.Text);

            if (chkAbierta.Checked) { convocatoria.Abierta = true; }
            else if (!chkAbierta.Checked) { convocatoria.Abierta = false; }

            convocatoria.Activa = true;

            //DESPUES GUARDO LA LISTA DE MODALIDADES DE LA CONVOCATORIA ACTUAL
            int idConvocatoria = convocatoriaNego.GuardarConvocatoria(convocatoria);
            idConvocatoriaActual = idConvocatoria;

            //FALTA EL METODO PARA GUARDAR LA LISTA DE MODALIDADES ACTUAL
            foreach (Modalidad mo in listaModalidades)
            {
                Modalidad modalidad = new Modalidad();

                modalidad.IdConvocatoria = idConvocatoria;
                modalidad.Nombre = mo.Nombre;
                modalidad.Descripcion = mo.Descripcion;
                modalidad.Objetivo = mo.Objetivo;
                modalidad.MontoMaximoProyecto = mo.MontoMaximoProyecto;
                modalidad.PlazoEjecucion = mo.PlazoEjecucion;
                modalidad.PorcentajeFinanciamiento = mo.PorcentajeFinanciamiento;

                modalidadNego.GuardarModalidad(modalidad);
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

            if (txtMontoMaximoProyectoModal.Text == "") { item.MontoMaximoProyecto = null; }
            else { item.MontoMaximoProyecto = Int32.Parse(txtMontoMaximoProyectoModal.Text); }

            if (txtPorcentajeFinanciamientoModal.Text == "") { item.PorcentajeFinanciamiento = null; }
            else { item.PorcentajeFinanciamiento = Int32.Parse(txtPorcentajeFinanciamientoModal.Text); }

            if (txtPlazoEjecucionModal.Text == "") { item.PlazoEjecucion = null; }
            else { item.PlazoEjecucion = Int32.Parse(txtPlazoEjecucionModal.Text); }


            //modalidadNego.GuardarModalidad(item);

            listaModalidades.Add(item);

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
            dgvModalidades.DataSource = listaModalidades;
            dgvModalidades.DataBind();
        }

        private void LimpiarFormulario()
        {
            txtNombre.Text = null;
            txtAnio.Text = null;
            ddlFondo.SelectedIndex = 0;
            ddlTipoConvocatoria.SelectedIndex = 0;
            ddlTipoFinanciamiento.SelectedIndex = 0;
            txtFechaApertura.Text = null;
            txtFechaCierre.Text = null;
            chkAbierta.Checked = false;
            //listaModalidades.Clear();
            //LlenarGrillaModalidades();
        }

        protected void ddlTipoConvocatoria_SelectedIndexChanged(object sender, EventArgs e)
        {
            string str = tipoConvocatoriaNego.ObtenerTipoConvocatoriaString(Convert.ToInt32(ddlTipoConvocatoria.SelectedValue));

            if (str == "Ventanilla Permanente")
            {
                fc.Visible = false;
                txtFechaCierre.Text = "";
                txtFechaCierre.Visible = false;
                lblFechaCierre.Visible = false;
            }
            else
            {
                fc.Visible = true;
                txtFechaCierre.Visible = true;
                lblFechaCierre.Visible = true;
            }
        }
    }
}