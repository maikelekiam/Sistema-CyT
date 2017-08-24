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
    public partial class AltaProyecto : System.Web.UI.Page
    {
        LocalidadNego localidadNego = new LocalidadNego();
        PersonaNego personaNego = new PersonaNego();
        EmpresaNego empresaNego = new EmpresaNego();
        ConvocatoriaNego convocatoriaNego = new ConvocatoriaNego();
        EtapaNego etapaNego = new EtapaNego();
        ProyectoNego proyectoNego = new ProyectoNego();

        static int idProyectoActual;
        static int idEmpresaActual = 0;
        static int idLocalidadActual = 0;
        static int idPersonaActual = 0;

        static List<Etapa> listaEtapasTemporal = new List<Etapa>();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack) return;

            ListarLocalidades(); //SIRVE PARA EL DROP DOWN LIST
            ListarPersonas(); //SIRVE PARA EL DROP DOWN LIST
            ListarEmpresas(); // SIRVE PARA EL DROP DOWN LIST
            DdlListarConvocatorias(); // SIRVE PARA EL DROP DOWN LIST

            //txtFechaInicioModal.Text = Convert.ToString(DateTime.Today.ToShortDateString());
            //txtFechaFinalModal.Text = Convert.ToString(DateTime.Today.ToShortDateString());

            listaEtapasTemporal.Clear();
        }

        //Muestra en el DROPDOWNLIST las CONVOCATORIAS
        private void DdlListarConvocatorias()
        {
            ddlConvocatoria.DataSource = convocatoriaNego.MostrarConvocatorias().ToList();
            ddlConvocatoria.DataValueField = "IdConvocatoria";
            ddlConvocatoria.DataBind();
        }

        //Muestra en el DROPDOWNLIST las LOCALIDADES
        private void ListarLocalidades()
        {
            ddlLocalidad.DataSource = localidadNego.MostrarLocalidades().ToList();
            ddlLocalidad.DataValueField = "nombre";
            ddlLocalidad.DataBind();
        }

        //Muestra en el DROPDOWNLIST las EMPRESAS
        private void ListarEmpresas()
        {
            ddlEmpresa.DataSource = empresaNego.MostrarEmpresas().ToList();
            ddlEmpresa.DataValueField = "nombre";
            ddlEmpresa.DataBind();
        }

        //Muestra en el DROPDOWNLIST las PERSONAS
        private void ListarPersonas()
        {
            ddlContacto.DataSource = personaNego.MostrarPersonas().ToList();
            IList<Persona> nombreCompleto = personaNego.MostrarPersonas().Select(p => new Persona() { Nombre = p.Apellido + "," + p.Nombre, IdPersona = p.IdPersona }).OrderBy(c => c.IdPersona).ToList();
            ddlContacto.DataSource = nombreCompleto;
            ddlContacto.DataValueField = "nombre";
            ddlContacto.DataBind();
        }

        protected void btnGuardarProyecto_Click(object sender, EventArgs e)
        {
            GuardarProyecto();

            Response.Redirect("ListarProyectos.aspx");
        }

        protected void btnModalEtapaGuardar_Click(object sender, EventArgs e)
        {
            ModalEtapaGuardar();
        }

        private void ModalEtapaGuardar()
        {
            Etapa etapa = new Etapa();

            etapa.Nombre = txtNombreModal.Text;
            etapa.FechaInicio = DateTime.ParseExact(txtFechaInicioModal.Text, "MM/dd/yyyy", CultureInfo.InvariantCulture);
            etapa.FechaFin = DateTime.ParseExact(txtFechaFinalModal.Text, "MM/dd/yyyy", CultureInfo.InvariantCulture);
            etapa.Duracion = Int32.Parse(txtDuracionModal.Text);

            listaEtapasTemporal.Add(etapa);

            txtNombreModal.Text = null;
            txtDuracionModal.Text = null;
            txtFechaInicioModal.Text = null;
            txtFechaFinalModal.Text = null;
            //txtFechaInicioModal.Text = Convert.ToString(DateTime.Today.ToShortDateString());
            //txtFechaFinalModal.Text = Convert.ToString(DateTime.Today.ToShortDateString());

            LlenarGrillaEtapas();
        }

        private void LlenarGrillaEtapas()
        {
            dgvEtapas.DataSource = listaEtapasTemporal;
            dgvEtapas.DataBind();
        }

        private void GuardarProyecto()
        {
            Proyecto proyecto = new Proyecto();

            proyecto.Nombre = txtNombre.Text;
            proyecto.NumeroExpediente = txtNumeroExp.Text;
            proyecto.IdConvocatoria = Int32.Parse(ddlConvocatoria.SelectedValue);
            proyecto.MontoSolicitado = Int32.Parse(txtMontoSolicitado.Text);
            proyecto.MontoContraparte = Int32.Parse(txtMontoContraparte.Text);
            proyecto.MontoTotal = Int32.Parse(txtMontoTotal.Text);

            string cadena = ddlContacto.SelectedItem.ToString();
            string[] separadas;
            separadas = cadena.Split(',');
            string itemApellido = separadas[0];
            string itemNombre = separadas[1];

            proyecto.IdPersona = personaNego.TraerPersonaIdSegunItem(itemApellido, itemNombre);
            //proyecto.IdPersona = Int32.Parse(ddlContacto.SelectedValue);
            proyecto.IdEmpresa = empresaNego.TraerEmpresaIdSegunItem(ddlEmpresa.SelectedItem.ToString());
            //proyecto.IdLocalidad = Int32.Parse(ddlLocalidad.SelectedValue);
            proyecto.IdLocalidad = localidadNego.TraerLocalidadIdSegunItem(ddlLocalidad.SelectedItem.ToString());

            int idProyecto = proyectoNego.GuardarProyecto(proyecto);

            //DESPUES GUARDO LA LISTA DE ETAPAS DEL PROYECTO ACTUAL
            idProyectoActual = idProyecto;

            foreach (Etapa item in listaEtapasTemporal)
            {
                Etapa etapa = new Etapa();

                etapa.IdProyecto = idProyectoActual;
                etapa.Nombre = item.Nombre.ToString();
                etapa.FechaInicio = Convert.ToDateTime(item.FechaInicio.ToString());
                etapa.FechaFin = Convert.ToDateTime(item.FechaFin.ToString());
                etapa.Duracion = Int32.Parse(item.Duracion.ToString());

                etapaNego.GuardarEtapa(etapa);
            }
        }

        protected void btnModalEmpresaGuardar_Click(object sender, EventArgs e)
        {
            Empresa empresa = new Empresa();

            empresa.Nombre = txtEmpresaNombreModal.Text;
            empresa.Telefono = txtEmpresaTelefonoModal.Text;
            empresa.CorreoElectronico = txtEmpresaCorreoElectronicoModal.Text;

            idEmpresaActual = empresaNego.GuardarEmpresa(empresa);

            ddlEmpresa.Items.Clear();
            ddlEmpresa.Text = TraerEmpresa(idEmpresaActual);

            ListarEmpresas();
        }

        private string TraerEmpresa(int id)
        {
            return empresaNego.TraerEmpresa(id);
        }

        protected void btnModalLocalidadGuardar_Click(object sender, EventArgs e)
        {
            Localidad localidad = new Localidad();

            localidad.Nombre = txtLocalidadNombreModal.Text;
            localidad.CodigoPostal = txtLocalidadCodigoPostalModal.Text;

            idLocalidadActual = localidadNego.GuardarLocalidad(localidad);

            ddlLocalidad.Items.Clear();
            ddlLocalidad.Text = TraerLocalidad(idLocalidadActual);

            ListarLocalidades();
        }
        private string TraerLocalidad(int id)
        {
            return localidadNego.TraerLocalidad(id);
        }

        protected void btnModalContactoGuardar_Click(object sender, EventArgs e)
        {
            Persona persona = new Persona();

            persona.Nombre = txtContactoNombreModal.Text;
            persona.Apellido = txtContactoApellidoModal.Text;
            persona.Telefono = txtContactoTelefonoModal.Text;
            persona.CorreoElectronico = txtContactoCorreoElectronicoModal.Text;

            idPersonaActual = personaNego.GuardarPersona(persona);

            ddlContacto.Items.Clear();
            ddlContacto.Text = TraerPersona(idPersonaActual);

            ListarPersonas();
        }
        private string TraerPersona(int id)
        {
            return personaNego.TraerPersona(id);
        }
    }
}