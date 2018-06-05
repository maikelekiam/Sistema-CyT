using System;
using System.Linq;
using CapaDominio;
using CapaNegocio;
using System.Globalization;
using System.Web.UI.WebControls;

namespace Sistema_CyT
{
    public partial class AgregarEtapa : System.Web.UI.Page
    {
        ProyectoNego proyectoNego = new ProyectoNego();
        ConvocatoriaNego convocatoriaNego = new ConvocatoriaNego();
        TipoEstadoNego tipoEstadoNego = new TipoEstadoNego();
        FondoNego fondoNego = new FondoNego();

        EtapaNego etapaNego = new EtapaNego();

        TipoEstadoEtapaNego tipoEstadoEtapaNego = new TipoEstadoEtapaNego();

        public static int idProyectoSeleccionado;
        public static int idConvocatoriaSeleccionada;
        public static int idEstadoSeleccionado;
        public static string codigoInternoProyectoSeleccionado;
        public static int idEtapaActual;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack) return;

            btnGuardar.Visible = true;
            btnActualizar.Visible = false;

            MostrarProyectoSeleccionado();
            MostrarEtapas();
            LlenarListaTipoEstadoEtapasCofecyt();
        }

        public void MostrarProyectoSeleccionado()
        {
            idProyectoSeleccionado = MostrarProyecto.idProyectoSeleccionado;

            Proyecto proyecto = proyectoNego.ObtenerProyecto(MostrarProyecto.idProyectoSeleccionado);

            lblPanelSuperiorTitulo.InnerText = proyecto.Nombre;
        }

        public void MostrarEtapas()
        {
            dgvEtapas.Columns[0].Visible = true;
            dgvEtapas.Columns[1].Visible = true;
            dgvEtapas.Columns[2].Visible = true;

            dgvEtapas.DataSource = etapaNego.TraerEtapasSegunIdProyecto(MostrarProyecto.idProyectoSeleccionado).OrderBy(c=>c.Nombre);
            dgvEtapas.DataBind();

            dgvEtapas.Columns[0].Visible = false;
        }

        private void LlenarListaTipoEstadoEtapasCofecyt()
        {
            ddlTipoEstadoEtapa.DataSource = tipoEstadoEtapaNego.MostrarTipoEstadoEtapas().ToList();
            ddlTipoEstadoEtapa.DataValueField = "nombre";
            ddlTipoEstadoEtapa.DataValueField = "idTipoEstadoEtapa";
            ddlTipoEstadoEtapa.DataBind();
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            if (txtNombreEtapa.Text != "" && ddlTipoEstadoEtapa.SelectedValue != "-1")
            {
                GuardarEtapa();

                Response.Redirect("MostrarProyecto.aspx");
            }
            else
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Correct", "alert('Debe completar los campos NOMBRE y ESTADO ETAPA.')", true);
            }
        }

        private void GuardarEtapa()
        {
            Etapa etapa = new Etapa();

            etapa.IdProyecto = idProyectoSeleccionado;
            etapa.Nombre = txtNombreEtapa.Text;

            if (txtFechaInicioEtapa.Text == "") { etapa.FechaInicio = null; }
            else { etapa.FechaInicio = DateTime.ParseExact(txtFechaInicioEtapa.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture); }

            if (txtFechaFinEtapa.Text == "") { etapa.FechaFin = null; }
            else { etapa.FechaFin = DateTime.ParseExact(txtFechaFinEtapa.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture); }

            etapa.IdTipoEstadoEtapa = Convert.ToInt32(ddlTipoEstadoEtapa.SelectedValue);

            if (chkRendicionEtapa.Checked) { etapa.Rendicion = true; }
            else if (!chkRendicionEtapa.Checked) { etapa.Rendicion = false; }

            if (chkInformeEtapa.Checked) { etapa.Informe = true; }
            else if (!chkInformeEtapa.Checked) { etapa.Informe = false; }

            etapaNego.GuardarEtapa(etapa);

            Limpiar();
        }

        protected void btnVolver_Click(object sender, EventArgs e)
        {
            btnGuardar.Visible = true;
            btnActualizar.Visible = false;

            Response.Redirect("MostrarProyecto.aspx");
        }

        protected void btnActualizar_Click(object sender, EventArgs e)
        {
            btnGuardar.Visible = false;
            btnActualizar.Visible = true;

            if (txtNombreEtapa.Text != "" && ddlTipoEstadoEtapa.SelectedValue != "-1")
            {
                ActualizarEtapa();

                Response.Redirect("MostrarProyecto.aspx");
            }
            else
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Correct", "alert('Debe completar los campos NOMBRE y ESTADO ETAPA.')", true);
            }
        }

        protected void dgvEtapas_SelectedIndexChanging(object sender, System.Web.UI.WebControls.GridViewSelectEventArgs e)
        {
            btnGuardar.Visible = false;
            btnActualizar.Visible = true;

            GridViewRow row = dgvEtapas.Rows[e.NewSelectedIndex];

            idEtapaActual = Convert.ToInt32(row.Cells[0].Text);

            Etapa etapa = etapaNego.ObtenerEtapaSegunId(idEtapaActual);

            if (etapa.FechaInicio == null) { txtFechaInicioEtapa.Text = ""; }
            else { txtFechaInicioEtapa.Text = Convert.ToDateTime(etapa.FechaInicio).ToShortDateString(); };

            if (etapa.FechaFin == null) { txtFechaFinEtapa.Text = ""; }
            else { txtFechaFinEtapa.Text = Convert.ToDateTime(etapa.FechaFin).ToShortDateString(); };

            txtNombreEtapa.Text = etapa.Nombre;

            ddlTipoEstadoEtapa.Text = Convert.ToString(etapa.IdTipoEstadoEtapa);

            if (etapa.Informe.Value == true) { chkInformeEtapa.Checked = true; }
            else if (etapa.Informe.Value == false) { chkInformeEtapa.Checked = false; }

            if (etapa.Rendicion.Value == true) { chkRendicionEtapa.Checked = true; }
            else if (etapa.Rendicion.Value == false) { chkRendicionEtapa.Checked = false; }
        }

        public void ActualizarEtapa()
        {
            Etapa etapa = new Etapa();

            etapa.IdProyecto = idProyectoSeleccionado;
            etapa.Nombre = txtNombreEtapa.Text;
            etapa.IdEtapa = idEtapaActual;

            if (txtFechaInicioEtapa.Text == "") { etapa.FechaInicio = null; }
            else { etapa.FechaInicio = DateTime.ParseExact(txtFechaInicioEtapa.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture); }

            if (txtFechaFinEtapa.Text == "") { etapa.FechaFin = null; }
            else { etapa.FechaFin = DateTime.ParseExact(txtFechaFinEtapa.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture); }

            etapa.IdTipoEstadoEtapa = Convert.ToInt32(ddlTipoEstadoEtapa.SelectedValue);

            if (chkRendicionEtapa.Checked) { etapa.Rendicion = true; }
            else if (!chkRendicionEtapa.Checked) { etapa.Rendicion = false; }

            if (chkInformeEtapa.Checked) { etapa.Informe = true; }
            else if (!chkInformeEtapa.Checked) { etapa.Informe = false; }

            etapaNego.ActualizarEtapa(etapa);

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
        }
    }
}