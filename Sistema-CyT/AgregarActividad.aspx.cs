using System;
using System.Linq;
using CapaDominio;
using CapaNegocio;
using System.Globalization;
using System.Web.UI.WebControls;

namespace Sistema_CyT
{
    public partial class AgregarActividad : System.Web.UI.Page
    {
        ProyectoNego proyectoNego = new ProyectoNego();
        ConvocatoriaNego convocatoriaNego = new ConvocatoriaNego();
        FondoNego fondoNego = new FondoNego();

        EtapaNego etapaNego = new EtapaNego();
        ActividadNego actividadNego = new ActividadNego();

        public static int idProyectoSeleccionado;
        public static int idConvocatoriaSeleccionada;
        public static int idEstadoSeleccionado;
        public static string codigoInternoProyectoSeleccionado;

        public static int idActividadActual;
        public static int idEtapaActual;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack) return;

            btnGuardar.Visible = true;
            btnActualizar.Visible = false;

            MostrarProyectoSeleccionado();
            MostrarActividades(); //para la grilla

            LlenarListaEtapas(); //para el dropdownlist
        }

        public void MostrarActividades()
        {
            dgvActividades.Columns[0].Visible = true;
            dgvActividades.Columns[1].Visible = true;
            dgvActividades.Columns[2].Visible = true;

            dgvActividades.DataSource = actividadNego.TraerActividadsSegunIdProyecto(MostrarProyecto.idProyectoSeleccionado).OrderBy(c => c.IdEtapa).ThenBy(c => c.Nombre);
            dgvActividades.DataBind();

            dgvActividades.Columns[0].Visible = false;
        }
        public void LlenarListaEtapas()
        {
            ddlEtapa.DataSource = etapaNego.TraerEtapasSegunIdProyecto(idProyectoSeleccionado).OrderBy(c => c.Nombre);
            ddlEtapa.DataValueField = "idEtapa";
            ddlEtapa.DataBind();
        }

        public void MostrarProyectoSeleccionado()
        {
            idProyectoSeleccionado = MostrarProyecto.idProyectoSeleccionado;

            Proyecto proyecto = proyectoNego.ObtenerProyecto(MostrarProyecto.idProyectoSeleccionado);

            lblPanelSuperiorTitulo.InnerText = proyecto.Nombre;
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            if (txtNombreActividad.Text != "" && ddlEtapa.SelectedValue != "-1")
            {
                GuardarActividad();

                Response.Redirect("MostrarProyecto.aspx");
            }
            else
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Correct", "alert('Debe completar los campos NOMBRE y ETAPA.')", true);
            }
        }

        private void GuardarActividad()
        {
            Actividad actividad = new Actividad();

            actividad.IdEtapa = Convert.ToInt32(ddlEtapa.SelectedValue);
            actividad.Nombre = txtNombreActividad.Text;

            actividad.IdProyecto = idProyectoSeleccionado;
            actividad.Descripcion = txtDescripcionActividad.Text;
            actividad.ResultadosEsperados = txtResultadosEsperadosActividad.Text;
            actividad.Localizacion = txtLocalizacionActividad.Text;

            actividadNego.GuardarActividad(actividad);

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
            if (txtNombreActividad.Text != "" && ddlEtapa.SelectedValue != "-1")
            {
                ActualizarActividad();

                Response.Redirect("MostrarProyecto.aspx");
            }
            else
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Correct", "alert('Debe completar los campos NOMBRE y ETAPA.')", true);
            }
        }

        protected void dgvActividades_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {
            btnGuardar.Visible = false;
            btnActualizar.Visible = true;

            GridViewRow row = dgvActividades.Rows[e.NewSelectedIndex];

            idActividadActual = Convert.ToInt32(row.Cells[0].Text);

            Actividad actividad = actividadNego.ObtenerActividadSegunId(idActividadActual);

            ddlEtapa.Text = Convert.ToString(actividad.IdEtapa);
            txtNombreActividad.Text = actividad.Nombre;
            txtDescripcionActividad.Text = actividad.Descripcion;
            txtResultadosEsperadosActividad.Text = actividad.ResultadosEsperados;
            txtLocalizacionActividad.Text = actividad.Localizacion;
        }
        public void ActualizarActividad()
        {
            Actividad actividad = new Actividad();

            actividad.IdEtapa = Convert.ToInt32(ddlEtapa.SelectedValue);
            actividad.Nombre = txtNombreActividad.Text;
            actividad.IdActividad = idActividadActual;

            actividad.IdProyecto = idProyectoSeleccionado;
            actividad.Descripcion = txtDescripcionActividad.Text;
            actividad.ResultadosEsperados = txtResultadosEsperadosActividad.Text;
            actividad.Localizacion = txtLocalizacionActividad.Text;

            actividadNego.ActualizarActividad(actividad);

            Limpiar();
        }
        public void Limpiar()
        {
            txtNombreActividad.Text = null;
            txtDescripcionActividad.Text = null;
            txtLocalizacionActividad.Text = null;
            txtResultadosEsperadosActividad.Text = null;
            ddlEtapa.Text = null;
        }
    }
}