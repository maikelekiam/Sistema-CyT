using System;
using System.Linq;
using CapaDominio;
using CapaNegocio;
using System.Globalization;
using System.Web.UI.WebControls;

namespace Sistema_CyT
{
    public partial class AgregarActividadCofecyt : System.Web.UI.Page
    {
        ProyectoCofecytNego proyectoCofecytNego = new ProyectoCofecytNego();
        ConvocatoriaNego convocatoriaNego = new ConvocatoriaNego();
        FondoNego fondoNego = new FondoNego();

        EtapaCofecytNego etapaCofecytNego = new EtapaCofecytNego();
        ActividadCofecytNego actividadCofecytNego = new ActividadCofecytNego();

        public static int idProyectoCofecytSeleccionado;
        public static int idConvocatoriaSeleccionada;
        public static int idEstadoSeleccionado;
        public static string codigoInternoProyectoCofecytSeleccionado;

        public static int idActividadCofecytActual;
        public static int idEtapaCofecytActual;

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

            dgvActividades.DataSource = actividadCofecytNego.TraerActividadCofecytsSegunIdProyecto(MostrarProyectoCofecyt.idProyectoCofecytSeleccionado).OrderBy(c => c.IdEtapaCofecyt).ThenBy(c => c.Nombre);
            dgvActividades.DataBind();

            dgvActividades.Columns[0].Visible = false;
        }
        public void LlenarListaEtapas()
        {
            ddlEtapa.DataSource = etapaCofecytNego.TraerEtapaCofecytsSegunIdProyecto(idProyectoCofecytSeleccionado).OrderBy(c => c.Nombre);
            ddlEtapa.DataValueField = "idEtapaCofecyt";
            ddlEtapa.DataBind();
        }
        public void MostrarProyectoSeleccionado()
        {
            idProyectoCofecytSeleccionado = MostrarProyectoCofecyt.idProyectoCofecytSeleccionado;

            ProyectoCofecyt proyectoCofecyt = proyectoCofecytNego.ObtenerProyectoCofecyt(MostrarProyectoCofecyt.idProyectoCofecytSeleccionado);

            lblPanelSuperiorTitulo.InnerText = proyectoCofecyt.Titulo;
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            if (txtNombreActividad.Text != "" && ddlEtapa.SelectedValue != "-1")
            {
                GuardarActividad();

                Response.Redirect("MostrarProyectoCofecyt.aspx");
            }
            else
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Correct", "alert('Debe completar los campos NOMBRE y ETAPA.')", true);
            }
        }
        private void GuardarActividad()
        {
            ActividadCofecyt actividadCofecyt = new ActividadCofecyt();

            actividadCofecyt.IdEtapaCofecyt = Convert.ToInt32(ddlEtapa.SelectedValue);
            actividadCofecyt.Nombre = txtNombreActividad.Text;

            actividadCofecyt.IdProyectoCofecyt = idProyectoCofecytSeleccionado;
            actividadCofecyt.Descripcion = txtDescripcionActividad.Text;
            actividadCofecyt.ResultadosEsperados = txtResultadosEsperadosActividad.Text;
            actividadCofecyt.Localizacion = txtLocalizacionActividad.Text;

            actividadCofecytNego.GuardarActividadCofecyt(actividadCofecyt);

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
            if (txtNombreActividad.Text != "" && ddlEtapa.SelectedValue != "-1")
            {
                ActualizarActividad();

                Response.Redirect("MostrarProyectoCofecyt.aspx");
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

            idActividadCofecytActual = Convert.ToInt32(row.Cells[0].Text);

            ActividadCofecyt actividadCofecyt = actividadCofecytNego.ObtenerActividadCofecytSegunId(idActividadCofecytActual);

            ddlEtapa.Text = Convert.ToString(actividadCofecyt.IdEtapaCofecyt);
            txtNombreActividad.Text = actividadCofecyt.Nombre;
            txtDescripcionActividad.Text = actividadCofecyt.Descripcion;
            txtResultadosEsperadosActividad.Text = actividadCofecyt.ResultadosEsperados;
            txtLocalizacionActividad.Text = actividadCofecyt.Localizacion;
        }
        public void ActualizarActividad()
        {
            ActividadCofecyt actividadCofecyt = new ActividadCofecyt();

            actividadCofecyt.IdEtapaCofecyt = Convert.ToInt32(ddlEtapa.SelectedValue);
            actividadCofecyt.Nombre = txtNombreActividad.Text;
            actividadCofecyt.IdActividadCofecyt = idActividadCofecytActual;

            actividadCofecyt.IdProyectoCofecyt = idProyectoCofecytSeleccionado;
            actividadCofecyt.Descripcion = txtDescripcionActividad.Text;
            actividadCofecyt.ResultadosEsperados = txtResultadosEsperadosActividad.Text;
            actividadCofecyt.Localizacion = txtLocalizacionActividad.Text;

            actividadCofecytNego.ActualizarActividadCofecyt(actividadCofecyt);

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