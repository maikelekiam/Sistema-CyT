using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CapaDominio;
using CapaNegocio;
using System.Windows.Forms;
using System.Globalization;

namespace Sistema_CyT
{
    public partial class EditarConvocatoria : System.Web.UI.Page
    {
        private ConvocatoriaNego convocatoriaNego = new ConvocatoriaNego();
        private FondoNego fondoNego = new FondoNego();
        private TipoFinanciamientoNego tipoFinanciamientoNego = new TipoFinanciamientoNego();
        private TipoConvocatoriaNego tipoConvocatoriaNego = new TipoConvocatoriaNego();
        private ModalidadNego modalidadNego = new ModalidadNego();

        IEnumerable<Convocatorium> listaConvocatorias;

        public static int idConvocatoriaActual;
        public static int idModalidadActual;
        public Modalidad modalidadTemporal;

        public static List<Modalidad> listaTemporalModalidades = new List<Modalidad>();
        public static List<Modalidad> listaTemporalModalidadesAgregado = new List<Modalidad>();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                CargarListaConvocatorias();
                LlenarListaFondos();
                LlenarListaTipofinanciamiento();
                LlenarListaTipoConvocatoria();
                //LlenarGrillaModalidades();
                LimpiarFormulario();
            }
        }

        private void CargarListaConvocatorias()
        {
            //DESPUES HAY QUE IMPLEMENTAR UN DROPDOWN ANIDADO ENTRE FONDO-CONVOCATORIA

            listaConvocatorias = convocatoriaNego.MostrarConvocatorias();

            ddlActualizarConvocatoria.DataSource = listaConvocatorias.ToList();
            ddlActualizarConvocatoria.DataTextField = "nombre";
            ddlActualizarConvocatoria.DataValueField = "idConvocatoria";
            ddlActualizarConvocatoria.DataBind();
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

        protected void ddlActualizarConvocatoria_SelectedIndexChanged(object sender, EventArgs e)
        {
            listaTemporalModalidades.Clear();
            listaTemporalModalidadesAgregado.Clear();

            idConvocatoriaActual = Convert.ToInt32(ddlActualizarConvocatoria.SelectedValue.ToString());

            Convocatorium convocatoria = convocatoriaNego.ObtenerConvocatoria(idConvocatoriaActual);

            if (convocatoria == null)
            {
                LimpiarFormulario();
                return;
            }

            //RUTINAS PARA QUE EL TEXTBOX MULTILINE SE AJUSTE AUTOMATICAMENTE
            int contador = 45;
            int rows;
            string cadena;
            string cadcom = "qwertyuiopasdfghjklñzxcvbnm1234567890QWERTYUIOPASDFGHJKLÑZXCVBNM.,";

            //NOMBRE
            cadena = convocatoria.Nombre.ToString();
            for (int i = 0; i < cadena.Length; i++)
            {
                if (cadcom.Contains(cadena.Substring(i, 1))) { contador++; }
                else if (cadena.Substring(i, 1) == " ") { contador++; }
                else if (cadena.Substring(i, 1) == "\n") { contador = contador + 90 - i; }
            }
            rows = contador / 90;
            txtNombre.Rows = rows + 1;
            //FIN DE LA RUTINA PARA ACOMODAR EL TEXTBOX

            txtNombre.Text = convocatoria.Nombre.ToString();

            txtAnio.Text = convocatoria.Anio.ToString();
            ddlFondo.Text = Convert.ToString(convocatoria.IdFondo);
            ddlTipoConvocatoria.Text = Convert.ToString(convocatoria.IdTipoConvocatoria);
            ddlTipoFinanciamiento.Text = Convert.ToString(convocatoria.IdTipoFinanciamiento);



            string dia = Convert.ToString((convocatoria.FechaApertura).Value.Day);
            string mes = Convert.ToString((convocatoria.FechaApertura).Value.Month);
            string anio = Convert.ToString((convocatoria.FechaApertura).Value.Year);
            string t1 = "";
            string t2 = "";
            if ((convocatoria.FechaApertura).Value.Day < 10)
            {
                t1 = "0";
            }
            if ((convocatoria.FechaApertura).Value.Month < 10)
            {
                t2 = "0";
            }
            txtFechaApertura.Text = t2 + mes + "/" + t1 + dia + "/" + anio;

            dia = Convert.ToString((convocatoria.FechaCierre).Value.Day);
            mes = Convert.ToString((convocatoria.FechaCierre).Value.Month);
            anio = Convert.ToString((convocatoria.FechaCierre).Value.Year);
            t1 = "";
            t2 = "";
            if ((convocatoria.FechaCierre).Value.Day < 10)
            {
                t1 = "0";
            }
            if ((convocatoria.FechaCierre).Value.Month < 10)
            {
                t2 = "0";
            }
            txtFechaCierre.Text = t2 + mes + "/" + t1 + dia + "/" + anio;

            //txtFechaApertura.Text = Convert.ToString(convocatoria.FechaApertura);
            //txtFechaCierre.Text = Convert.ToString(convocatoria.FechaCierre);
            //txtFechaApertura.Text = Convert.ToDateTime(convocatoria.FechaApertura).ToShortDateString();
            //txtFechaCierre.Text = Convert.ToDateTime(convocatoria.FechaCierre).ToShortDateString();

            if (convocatoria.Abierta.Value == true)
            {
                chkAbierta.Checked = true;
            }
            else if (convocatoria.Abierta.Value == false)
            {
                chkAbierta.Checked = false;
            }

            if (convocatoria.Activa.Value == true)
            {
                chkActivo.Checked = true;
            }
            else if (convocatoria.Activa.Value == false)
            {
                chkActivo.Checked = false;
            }

            //AHORA TENGO QUE TRAER UNA LISTA DE MODALIDADES SEGUN EL IdConvocatoriaActual
            listaTemporalModalidades = (List<Modalidad>)modalidadNego.TraerModalidadesSegunIdConvocatoria(idConvocatoriaActual).ToList();

            dgvModalidades.Columns[0].Visible = true;
            dgvModalidades.Columns[1].Visible = true;
            dgvModalidades.Columns[2].Visible = true;
            dgvModalidades.Columns[3].Visible = true;
            dgvModalidades.Columns[4].Visible = true;
            dgvModalidades.Columns[5].Visible = true;
            dgvModalidades.Columns[6].Visible = true;
            dgvModalidades.Columns[7].Visible = true;

            dgvModalidades.DataSource = listaTemporalModalidades;
            dgvModalidades.DataBind();

            dgvModalidades.Columns[0].Visible = false;
            dgvModalidades.Columns[7].Visible = false;

            LlenarGrillaModalidades(); //no borrar esta linea!!!
        }

        private void LlenarGrillaModalidades()
        {
            dgvModalidades.Columns[0].Visible = true;
            dgvModalidades.Columns[1].Visible = true;
            dgvModalidades.Columns[2].Visible = true;
            dgvModalidades.Columns[3].Visible = true;
            dgvModalidades.Columns[4].Visible = true;
            dgvModalidades.Columns[5].Visible = true;
            dgvModalidades.Columns[6].Visible = true;
            dgvModalidades.Columns[7].Visible = true;

            dgvModalidades.DataSource = listaTemporalModalidades;

            dgvModalidades.DataBind();

            dgvModalidades.Columns[0].Visible = false;
            dgvModalidades.Columns[7].Visible = false;
        }

        protected void btnActualizarConvocatoria_Click(object sender, EventArgs e)
        {
            ActualizarConvocatoria();

            LlenarGrillaModalidades();

            listaTemporalModalidades.Clear();
            listaTemporalModalidadesAgregado.Clear();

            Response.Redirect("ListarConvocatorias.aspx");
        }

        private void ActualizarConvocatoria()
        {
            Convocatorium convocatoria = new Convocatorium();

            convocatoria.IdConvocatoria = idConvocatoriaActual;

            convocatoria.Nombre = txtNombre.Text;
            convocatoria.Anio = Int32.Parse(txtAnio.Text);
            convocatoria.IdFondo = Int32.Parse(ddlFondo.SelectedValue);
            convocatoria.IdTipoFinanciamiento = Int32.Parse(ddlTipoFinanciamiento.SelectedValue);
            convocatoria.IdTipoConvocatoria = Int32.Parse(ddlTipoConvocatoria.SelectedValue);

            convocatoria.FechaApertura = DateTime.ParseExact(txtFechaApertura.Text, "MM/dd/yyyy", CultureInfo.InvariantCulture);
            convocatoria.FechaCierre = DateTime.ParseExact(txtFechaCierre.Text, "MM/dd/yyyy", CultureInfo.InvariantCulture);

            if (chkActivo.Checked) { convocatoria.Activa = true; }
            else if (!chkActivo.Checked) { convocatoria.Activa = false; }

            //convocatoria.FechaApertura = Convert.ToDateTime(txtFechaApertura.Text);
            //convocatoria.FechaCierre = Convert.ToDateTime(txtFechaCierre.Text);

            if (chkAbierta.Checked) { convocatoria.Abierta = true; }
            else if (!chkAbierta.Checked) { convocatoria.Abierta = false; }

            convocatoriaNego.ActualizarConvocatoria(convocatoria);

            //DESPUES GUARDO LA LISTA DE MODALIDADES DE LA CONVOCATORIA ACTUAL
            foreach (Modalidad mo in listaTemporalModalidades)
            {
                Modalidad modalidad = new Modalidad();

                modalidad.IdModalidad = mo.IdModalidad;
                modalidad.IdConvocatoria = idConvocatoriaActual;
                modalidad.Nombre = mo.Nombre;
                modalidad.Descripcion = mo.Descripcion;
                modalidad.Objetivo = mo.Objetivo;
                modalidad.MontoMaximoProyecto = mo.MontoMaximoProyecto;
                modalidad.PlazoEjecucion = mo.PlazoEjecucion;
                modalidad.PorcentajeFinanciamiento = mo.PorcentajeFinanciamiento;

                modalidadNego.ActualizarModalidad(modalidad);
            }

            LimpiarFormulario();
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
            chkAbierta.Checked = true;
            chkActivo.Checked = true;
            //listaConvocatoriaModalidades.Clear();

            LlenarGrillaModalidades(); //no borrar esta linea!!!
        }

        protected void dgvModalidades_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {
            GridViewRow row = dgvModalidades.Rows[e.NewSelectedIndex];

            //idModalidadActual = Convert.ToInt32(row.Cells[0].Text);

            //Response.Redirect("EditarModalidad.aspx");

            if (row.Cells[0].Text != "")
            {
                idModalidadActual = Convert.ToInt32(row.Cells[0].Text);

                Response.Redirect("EditarModalidad.aspx");
            }
            else
            {
                MessageBox.Show("DEBE ACTUALIZAR LA CONVOCATORIA PARA CONTINUAR", "Advertencia",
                    MessageBoxButtons.OKCancel, MessageBoxIcon.Asterisk);

            }










            //Modalidad modalidad = modalidadNego.ObtenerModalidadSegunId(id);
        }

        protected void btnModalModalidadGuardar_Click(object sender, EventArgs e)
        {
            Modalidad item = new Modalidad();

            item.IdConvocatoria = idConvocatoriaActual;
            item.Nombre = txtNombreModal.Text;
            item.Descripcion = txtDescripcionModal.Text;
            item.Objetivo = txtObjetivoModal.Text;
            item.MontoMaximoProyecto = Int32.Parse(txtMontoMaximoProyectoModal.Text);
            item.PorcentajeFinanciamiento = Int32.Parse(txtPorcentajeFinanciamientoModal.Text);
            item.PlazoEjecucion = Int32.Parse(txtPlazoEjecucionModal.Text);

            txtNombreModal.Text = null;
            txtDescripcionModal.Text = null;
            txtObjetivoModal.Text = null;
            txtMontoMaximoProyectoModal.Text = null;
            txtPlazoEjecucionModal.Text = null;
            txtPorcentajeFinanciamientoModal.Text = null;

            listaTemporalModalidadesAgregado.Add(item);
            listaTemporalModalidades.Add(item);

            dgvModalidades.DataSource = listaTemporalModalidades;
            dgvModalidades.DataBind();
        }
    }
}