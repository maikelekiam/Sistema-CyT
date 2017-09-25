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
    public partial class MostrarProyecto : System.Web.UI.Page
    {
        ProyectoNego proyectoNego = new ProyectoNego();
        ConvocatoriaNego convocatoriaNego = new ConvocatoriaNego();
        EtapaNego etapaNego = new EtapaNego();
        TipoProyectoNego tipoProyectoNego = new TipoProyectoNego();
        PersonaNego personaNego = new PersonaNego();

        public static List<Etapa> listaTemporalEtapas = new List<Etapa>();
        public static int idProyectoSeleccionado;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack) return;

            ObtenerProyecto();
        }
        private void ObtenerProyecto()
        {

            string nom = ListarProyectos.numeroExpedienteProyectoSeleccionado;

            Proyecto proyecto = proyectoNego.ObtenerProyectoSegunNombreYConvocatoria(ListarProyectos.idConvocatoriaSeleccionada, ListarProyectos.numeroExpedienteProyectoSeleccionado);

            idProyectoSeleccionado = proyecto.IdProyecto;

            //lblNombreProyecto.Text = "Proyecto: " + proyecto.Nombre.ToString();
            lblNombreProyecto.Text = proyecto.Nombre.ToString().ToUpper();

            txtConvocatoria.Text = convocatoriaNego.ObtenerConvocatoria(Convert.ToInt32(proyecto.IdConvocatoria)).Nombre;
            txtNumeroExp.Text = proyecto.NumeroExpediente.ToString();
            txtMontoSolicitado.Text = Convert.ToString(proyecto.MontoSolicitado);
            txtMontoContraparte.Text = Convert.ToString(proyecto.MontoContraparte);
            txtMontoTotal.Text = Convert.ToString(proyecto.MontoTotal);
            txtDescripcion.Text = proyecto.Descripcion.ToString();
            txtObservaciones.Text = proyecto.Observaciones.ToString();
            txtTipoProyecto.Text = tipoProyectoNego.ObtenerTipoProyecto(Convert.ToInt32(proyecto.IdTipoProyecto)).Nombre;

            txtContacto.Text = personaNego.ObtenerPersona(Convert.ToInt32(proyecto.IdPersona)).Nombre + " " + personaNego.ObtenerPersona(Convert.ToInt32(proyecto.IdPersona)).Apellido;

            //txtContacto.Text = personaNego.TraerPersona(Convert.ToInt32(proyecto.IdPersona)).ToString();
            //txtTipoProyecto.Text = tipoProyectoNego.ObtenerTipoProyecto(proyecto.IdTipoProyecto).Nombre;


            //AHORA TENGO QUE TRAER UNA LISTA DE ETAPAS SEGUN EL IdProyectoActual
            listaTemporalEtapas = (List<Etapa>)etapaNego.TraerEtapasSegunIdProyecto(proyecto.IdProyecto).ToList();

            dgvEtapas.Columns[0].Visible = true;
            dgvEtapas.Columns[1].Visible = true;
            dgvEtapas.Columns[2].Visible = true;
            dgvEtapas.Columns[3].Visible = true;
            dgvEtapas.Columns[4].Visible = true;
            dgvEtapas.Columns[5].Visible = true;
            dgvEtapas.Columns[6].Visible = true;

            dgvEtapas.DataSource = listaTemporalEtapas;
            dgvEtapas.DataBind();

            dgvEtapas.Columns[0].Visible = false;
            dgvEtapas.Columns[1].Visible = false;

        }

        protected void btnActuaciones_Click(object sender, EventArgs e)
        {
            FiltrarProyecto.idProyectoSeleccionado = idProyectoSeleccionado;
            Response.Redirect("Actuaciones.aspx");
        }
    }
}