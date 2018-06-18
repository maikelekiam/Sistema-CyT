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
        PersonaNego personaNego = new PersonaNego();
        TipoProyectoNego tipoProyectoNego = new TipoProyectoNego();
        
        EtapaNego etapaNego = new EtapaNego();
        ActividadNego actividadNego = new ActividadNego();


        public static List<Etapa> listaEtapas = new List<Etapa>();
        public static List<Actividad> listaActividades = new List<Actividad>();

        public static int idProyectoSeleccionado;
        public static int idEtapaSeleccionada;
        public static int idActividadSeleccionada;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack) return;

            ObtenerProyecto();
        }
        private void ObtenerProyecto()
        {
            string nom = ListarProyectos.codigoInternoProyectoSeleccionado;

            Proyecto proyecto = proyectoNego.ObtenerProyectoSegunCodigoInternoYConvocatoria(ListarProyectos.codigoInternoProyectoSeleccionado, ListarProyectos.idConvocatoriaSeleccionada);

            idProyectoSeleccionado = proyecto.IdProyecto;

            //lblNombreProyecto.Text = "Proyecto: " + proyecto.Nombre.ToString();
            lblNombreProyecto.Text = proyecto.Nombre.ToString();//.ToUpper();

            txtConvocatoria.Text = convocatoriaNego.ObtenerConvocatoria(Convert.ToInt32(proyecto.IdConvocatoria)).Nombre;
            txtNumeroExp.Text = proyecto.NumeroExpediente.ToString();
            txtCodigoInterno.Text = proyecto.CodigoInterno;

            txtMontoSolicitado.Text = "$ " + Convert.ToString(proyecto.MontoSolicitado);
            txtMontoContraparte.Text = "$ " + Convert.ToString(proyecto.MontoContraparte);
            txtMontoTotal.Text = "$ " + Convert.ToString(proyecto.MontoTotal);

            txtDescripcion.Text = proyecto.Descripcion.ToString();
            txtObservaciones.Text = proyecto.Observaciones.ToString();

            if (proyecto.IdTipoProyecto == null) { txtTipoProyecto.Text = ""; }
            else { txtTipoProyecto.Text = tipoProyectoNego.ObtenerTipoProyecto(Convert.ToInt32(proyecto.IdTipoProyecto)).Nombre; }


            //txtTipoProyecto.Text = tipoProyectoNego.ObtenerTipoProyecto(Convert.ToInt32(proyecto.IdTipoProyecto)).Nombre;

            if (proyecto.IdPersona == null) { txtContacto.Text = ""; }
            else { txtContacto.Text = personaNego.ObtenerPersona(Convert.ToInt32(proyecto.IdPersona)).Nombre + " " + personaNego.ObtenerPersona(Convert.ToInt32(proyecto.IdPersona)).Apellido; }


            //txtContacto.Text = personaNego.ObtenerPersona(Convert.ToInt32(proyecto.IdPersona)).Nombre + " " + personaNego.ObtenerPersona(Convert.ToInt32(proyecto.IdPersona)).Apellido;

            //txtContacto.Text = personaNego.TraerPersona(Convert.ToInt32(proyecto.IdPersona)).ToString();
            //txtTipoProyecto.Text = tipoProyectoNego.ObtenerTipoProyecto(proyecto.IdTipoProyecto).Nombre;


            //AHORA TENGO QUE TRAER UNA LISTA DE ETAPAS SEGUN EL IdProyectoActual
            listaEtapas = (List<Etapa>)etapaNego.TraerEtapasSegunIdProyecto(proyecto.IdProyecto).ToList();

            dgvEtapas.Columns[0].Visible = true;
            dgvEtapas.Columns[1].Visible = true;
            dgvEtapas.Columns[2].Visible = true;
            dgvEtapas.Columns[3].Visible = true;
            dgvEtapas.Columns[4].Visible = true;
            dgvEtapas.Columns[5].Visible = true;
            dgvEtapas.Columns[6].Visible = true;

            dgvEtapas.DataSource = listaEtapas.OrderBy(c=>c.Nombre);
            dgvEtapas.DataBind();

            dgvEtapas.Columns[0].Visible = false;
            dgvEtapas.Columns[1].Visible = false;

            listaActividades = (List<Actividad>)actividadNego.TraerActividadsSegunIdProyecto(proyecto.IdProyecto).ToList();

            dgvActividades.DataSource = listaActividades.OrderBy(c => c.IdEtapa).ThenBy(c => c.Nombre).ToList();
            dgvActividades.DataBind();
        }

        protected void btnActuaciones_Click(object sender, EventArgs e)
        {
            FiltrarProyecto.idProyectoSeleccionado = idProyectoSeleccionado;
            Response.Redirect("Actuaciones.aspx");
        }

        protected void btnEtapa_Click(object sender, EventArgs e)
        {
            Response.Redirect("AgregarEtapa.aspx");
        }

        protected void btnActividad_Click(object sender, EventArgs e)
        {
            Response.Redirect("AgregarActividad.aspx");
        }
    }
}