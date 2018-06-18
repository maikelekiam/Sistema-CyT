using System;
using System.Linq;
using CapaDominio;
using CapaNegocio;
using System.Globalization;
using System.Web.UI.WebControls;

namespace Sistema_CyT
{
    public partial class AgregarEtapaCofecyt : System.Web.UI.Page
    {
        ProyectoCofecytNego proyectoCofecytNego = new ProyectoCofecytNego();
        ConvocatoriaNego convocatoriaNego = new ConvocatoriaNego();
        TipoEstadoCofecytNego tipoEstadoCofecytNego = new TipoEstadoCofecytNego();
        FondoNego fondoNego = new FondoNego();

        EtapaCofecytNego etapaCofecytNego = new EtapaCofecytNego();

        TipoEstadoEtapaNego tipoEstadoEtapaNego = new TipoEstadoEtapaNego();

        public static int idProyectoCofecytSeleccionado;
        public static int idConvocatoriaSeleccionada;
        public static int idEstadoSeleccionado;
        public static string codigoInternoProyectoCofecytSeleccionado;
        public static int idEtapaCofecytActual;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack) return;

            btnGuardar.Visible = true;
            btnActualizar.Visible = false;

            MostrarProyectoCofecytSeleccionado();
            MostrarEtapas();
            LlenarListaTipoEstadoEtapas();
        }

        public void MostrarProyectoCofecytSeleccionado()
        {
            idProyectoCofecytSeleccionado = MostrarProyectoCofecyt.idProyectoCofecytSeleccionado;

            ProyectoCofecyt proyectoCofecyt = proyectoCofecytNego.ObtenerProyectoCofecyt(idProyectoCofecytSeleccionado);

            lblPanelSuperiorTitulo.InnerText = proyectoCofecyt.Titulo;
        }
        private void LlenarListaTipoEstadoEtapas()
        {
            ddlTipoEstadoEtapa.DataSource = tipoEstadoEtapaNego.MostrarTipoEstadoEtapas().ToList();
            ddlTipoEstadoEtapa.DataValueField = "nombre";
            ddlTipoEstadoEtapa.DataValueField = "idTipoEstadoEtapa";
            ddlTipoEstadoEtapa.DataBind();
        }

        public void MostrarEtapas()
        {
            dgvEtapas.Columns[0].Visible = true;
            dgvEtapas.Columns[1].Visible = true;
            dgvEtapas.Columns[2].Visible = true;

            dgvEtapas.DataSource = etapaCofecytNego.TraerEtapaCofecytsSegunIdProyecto(idProyectoCofecytSeleccionado).OrderBy(c => c.Nombre);
            dgvEtapas.DataBind();

            dgvEtapas.Columns[0].Visible = false;
        }

                

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            if (txtNombreEtapa.Text != "" && ddlTipoEstadoEtapa.SelectedValue != "-1")
            {
                GuardarEtapa();

                Response.Redirect("MostrarProyectoCofecyt.aspx");
            }
            else
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Correct", "alert('Debe completar los campos NOMBRE y ESTADO ETAPA.')", true);
            }
        }

        private void GuardarEtapa()
        {
            EtapaCofecyt etapaCofecyt = new EtapaCofecyt();

            etapaCofecyt.IdProyectoCofecyt = idProyectoCofecytSeleccionado;
            etapaCofecyt.Nombre = txtNombreEtapa.Text;

            if (txtFechaInicioEtapa.Text == "") { etapaCofecyt.FechaInicio = null; }
            else { etapaCofecyt.FechaInicio = DateTime.ParseExact(txtFechaInicioEtapa.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture); }

            if (txtFechaFinEtapa.Text == "") { etapaCofecyt.FechaFin = null; }
            else { etapaCofecyt.FechaFin = DateTime.ParseExact(txtFechaFinEtapa.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture); }

            etapaCofecyt.IdTipoEstadoEtapa = Convert.ToInt32(ddlTipoEstadoEtapa.SelectedValue);

            if (chkRendicionEtapa.Checked) { etapaCofecyt.Rendicion = true; }
            else if (!chkRendicionEtapa.Checked) { etapaCofecyt.Rendicion = false; }

            if (chkInformeEtapa.Checked) { etapaCofecyt.Informe = true; }
            else if (!chkInformeEtapa.Checked) { etapaCofecyt.Informe = false; }

            etapaCofecyt.DuracionSegunUvt = txtDuracionSegunUvt.Text;

            etapaCofecytNego.GuardarEtapaCofecyt(etapaCofecyt);

            Limpiar();
        }

        protected void btnVolver_Click(object sender, EventArgs e)
        {
            btnGuardar.Visible = true;
            btnActualizar.Visible = false;

            Response.Redirect("MostrarProyectoCofecyt.aspx");
        }

        protected void btnActualizar_Click(object sender, EventArgs e)
        {
            btnGuardar.Visible = false;
            btnActualizar.Visible = true;

            if (txtNombreEtapa.Text != "" && ddlTipoEstadoEtapa.SelectedValue != "-1")
            {
                ActualizarEtapa();

                Response.Redirect("MostrarProyectoCofecyt.aspx");
            }
            else
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Correct", "alert('Debe completar los campos NOMBRE y ESTADO ETAPA.')", true);
            }
        }

        protected void dgvEtapas_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {
            btnGuardar.Visible = false;
            btnActualizar.Visible = true;

            GridViewRow row = dgvEtapas.Rows[e.NewSelectedIndex];

            idEtapaCofecytActual = Convert.ToInt32(row.Cells[0].Text);

            EtapaCofecyt etapaCofecyt = etapaCofecytNego.ObtenerEtapaCofecytSegunId(idEtapaCofecytActual);

            if (etapaCofecyt.FechaInicio == null) { txtFechaInicioEtapa.Text = ""; }
            else { txtFechaInicioEtapa.Text = Convert.ToDateTime(etapaCofecyt.FechaInicio).ToShortDateString(); };

            if (etapaCofecyt.FechaFin == null) { txtFechaFinEtapa.Text = ""; }
            else { txtFechaFinEtapa.Text = Convert.ToDateTime(etapaCofecyt.FechaFin).ToShortDateString(); };

            txtNombreEtapa.Text = etapaCofecyt.Nombre;

            txtDuracionSegunUvt.Text = etapaCofecyt.DuracionSegunUvt;

            ddlTipoEstadoEtapa.Text = Convert.ToString(etapaCofecyt.IdTipoEstadoEtapa);

            if (etapaCofecyt.Informe.Value == true) { chkInformeEtapa.Checked = true; }
            else if (etapaCofecyt.Informe.Value == false) { chkInformeEtapa.Checked = false; }

            if (etapaCofecyt.Rendicion.Value == true) { chkRendicionEtapa.Checked = true; }
            else if (etapaCofecyt.Rendicion.Value == false) { chkRendicionEtapa.Checked = false; }
        }

        public void ActualizarEtapa()
        {
            EtapaCofecyt etapaCofecyt = new EtapaCofecyt();

            etapaCofecyt.IdProyectoCofecyt = idProyectoCofecytSeleccionado;
            etapaCofecyt.Nombre = txtNombreEtapa.Text;
            etapaCofecyt.IdEtapaCofecyt = idEtapaCofecytActual;

            if (txtFechaInicioEtapa.Text == "") { etapaCofecyt.FechaInicio = null; }
            else { etapaCofecyt.FechaInicio = DateTime.ParseExact(txtFechaInicioEtapa.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture); }

            if (txtFechaFinEtapa.Text == "") { etapaCofecyt.FechaFin = null; }
            else { etapaCofecyt.FechaFin = DateTime.ParseExact(txtFechaFinEtapa.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture); }

            etapaCofecyt.IdTipoEstadoEtapa = Convert.ToInt32(ddlTipoEstadoEtapa.SelectedValue);

            if (chkRendicionEtapa.Checked) { etapaCofecyt.Rendicion = true; }
            else if (!chkRendicionEtapa.Checked) { etapaCofecyt.Rendicion = false; }

            if (chkInformeEtapa.Checked) { etapaCofecyt.Informe = true; }
            else if (!chkInformeEtapa.Checked) { etapaCofecyt.Informe = false; }

            etapaCofecyt.DuracionSegunUvt = txtDuracionSegunUvt.Text;

            etapaCofecytNego.ActualizarEtapaCofecyt(etapaCofecyt);

            Limpiar();
        }

        public void Limpiar()
        {
            txtNombreEtapa.Text = null;
            txtFechaInicioEtapa.Text = null;
            txtFechaFinEtapa.Text = null;
            chkInformeEtapa.Text = null;
            chkRendicionEtapa.Text = null;
            ddlTipoEstadoEtapa.Text = null;
            txtDuracionSegunUvt.Text = null;
        }
    }
}