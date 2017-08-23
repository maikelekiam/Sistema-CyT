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
    public partial class EditarProyecto : System.Web.UI.Page
    {
        LocalidadNego localidadNego = new LocalidadNego();
        PersonaNego personaNego = new PersonaNego();
        EmpresaNego empresaNego = new EmpresaNego();
        ConvocatoriaNego convocatoriaNego = new ConvocatoriaNego();
        EtapaNego etapaNego = new EtapaNego();
        ProyectoNego proyectoNego = new ProyectoNego();

        IEnumerable<Proyecto> listaProyectos;

        public static List<Etapa> listaTemporalEtapas = new List<Etapa>();

        public static int idProyectoActual;
        public static int idEtapaActual;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack) return;

            CargarListaProyectos();
            MostrarLocalidad(); //SIRVE PARA EL DROP DOWN LIST
            MostrarPersona(); //SIRVE PARA EL DROP DOWN LIST
            MostrarEmpresa(); // SIRVE PARA EL DROP DOWN LIST
            MostrarConvocatoria(); // SIRVE PARA EL DROP DOWN LIST
            LimpiarFormulario();
        }

        private void CargarListaProyectos()
        {
            listaProyectos = proyectoNego.MostrarProyectos();

            ddlActualizarProyecto.DataSource = listaProyectos.ToList();
            ddlActualizarProyecto.DataTextField = "nombre";
            ddlActualizarProyecto.DataValueField = "idProyecto";
            ddlActualizarProyecto.DataBind();
        }

        //Muestra en el DROPDOWNLIST las CONVOCATORIAS
        private void MostrarConvocatoria()
        {
            ddlConvocatoria.DataSource = convocatoriaNego.MostrarConvocatorias().ToList();
            ddlConvocatoria.DataValueField = "IdConvocatoria";
            ddlConvocatoria.DataBind();
        }

        //Muestra en el DROPDOWNLIST las LOCALIDADES
        private void MostrarLocalidad()
        {
            ddlLocalidad.DataSource = localidadNego.MostrarLocalidades().ToList();
            ddlLocalidad.DataValueField = "nombre";
            ddlLocalidad.DataBind();
        }

        //Muestra en el DROPDOWNLIST las EMPRESAS
        private void MostrarEmpresa()
        {
            ddlEmpresa.DataSource = empresaNego.MostrarEmpresas().ToList();
            ddlEmpresa.DataValueField = "nombre";
            ddlEmpresa.DataBind();
        }

        //Muestra en el DROPDOWNLIST las PERSONAS
        private void MostrarPersona()
        {
            ddlContacto.DataSource = personaNego.MostrarPersonas().ToList();
            IList<Persona> nombreCompleto = personaNego.MostrarPersonas().Select(p => new Persona() { Nombre = p.Apellido + "," + p.Nombre, IdPersona = p.IdPersona }).OrderBy(c => c.IdPersona).ToList();
            ddlContacto.DataSource = nombreCompleto;
            ddlContacto.DataValueField = "nombre";
            ddlContacto.DataBind();
        }
        protected void ddlActualizarProyecto_SelectedIndexChanged(object sender, EventArgs e)
        {
            idProyectoActual = Convert.ToInt32(ddlActualizarProyecto.SelectedValue.ToString());

            Proyecto proyecto = proyectoNego.ObtenerProyecto(idProyectoActual);

            if (proyecto == null)
            {
                //LimpiarFormulario();
                return;
            }

            txtNombre.Text = proyecto.Nombre.ToString();
            txtNumeroExp.Text = proyecto.NumeroExpediente.ToString();
            ddlConvocatoria.Text = Convert.ToString(proyecto.IdConvocatoria);
            txtMontoSolicitado.Text = Convert.ToString(proyecto.MontoSolicitado);
            txtMontoContraparte.Text = Convert.ToString(proyecto.MontoContraparte);
            txtMontoTotal.Text = Convert.ToString(proyecto.MontoTotal);

            ddlContacto.Text = personaNego.TraerPersona(proyecto.IdPersona.Value);
            ddlEmpresa.Text = empresaNego.TraerEmpresa(proyecto.IdEmpresa.Value);
            ddlLocalidad.Text = localidadNego.TraerLocalidad(proyecto.IdLocalidad.Value);

            //AHORA TENGO QUE TRAER UNA LISTA DE ETAPAS SEGUN EL IdProyectoActual
            listaTemporalEtapas = (List<Etapa>)etapaNego.TraerEtapasSegunIdProyecto(idProyectoActual).ToList();

            dgvEtapas.Columns[0].Visible = true;
            dgvEtapas.Columns[1].Visible = true;
            dgvEtapas.Columns[2].Visible = true;
            dgvEtapas.Columns[3].Visible = true;
            dgvEtapas.Columns[4].Visible = true;
            dgvEtapas.Columns[5].Visible = true;

            dgvEtapas.DataSource = listaTemporalEtapas;
            dgvEtapas.DataBind();

            dgvEtapas.Columns[0].Visible = false;
            dgvEtapas.Columns[1].Visible = false;

            LlenarGrillaEtapas(); //no borrar esta linea!!!
        }

        private void LlenarGrillaEtapas()
        {
            dgvEtapas.Columns[0].Visible = true;
            dgvEtapas.Columns[1].Visible = true;
            dgvEtapas.Columns[2].Visible = true;
            dgvEtapas.Columns[3].Visible = true;
            dgvEtapas.Columns[4].Visible = true;
            dgvEtapas.Columns[5].Visible = true;

            dgvEtapas.DataSource = listaTemporalEtapas;
            dgvEtapas.DataBind();

            dgvEtapas.Columns[0].Visible = false;
            dgvEtapas.Columns[1].Visible = false;
        }










        protected void btnModalContactoGuardar_Click(object sender, EventArgs e)
        {

        }

        protected void btnModalEmpresaGuardar_Click(object sender, EventArgs e)
        {

        }

        protected void btnModalLocalidadGuardar_Click(object sender, EventArgs e)
        {

        }


        protected void btnModalEtapaGuardar_Click(object sender, EventArgs e)
        {

        }

        protected void btnActualizarProyecto_Click(object sender, EventArgs e)
        {

        }

        protected void dgvEtapas_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {

        }
        private void LimpiarFormulario()
        {
            txtNombre.Text = null;
            txtNumeroExp.Text = null;
            ddlConvocatoria.SelectedIndex=0;
            txtMontoSolicitado.Text = null;
            txtMontoContraparte.Text = null;
            txtMontoTotal.Text = null;
            ddlContacto.SelectedIndex=0;
            ddlEmpresa.SelectedIndex = 0;
            ddlLocalidad.SelectedIndex = 0;
        }
    }
}