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

            //listaEtapasTemporal.Clear();
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
    }
}