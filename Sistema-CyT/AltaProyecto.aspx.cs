using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI;
using CapaDominio;
using CapaNegocio;

namespace Sistema_CyT
{
    public partial class AltaProyecto : System.Web.UI.Page
    {
        LocalidadNego localidadNego = new LocalidadNego();
        PersonaNego personaNego = new PersonaNego();
        EmpresaNego empresaNego = new EmpresaNego();
        ConvocatoriaNego convocatoriaNego = new ConvocatoriaNego();
        FondoNego fondoNego = new FondoNego();
        TipoProyectoNego tipoProyectoNego = new TipoProyectoNego();

        TematicaNego tematicaNego = new TematicaNego();
        SectorNego sectorNego = new SectorNego();

        ProyectoNego proyectoNego = new ProyectoNego();
        TipoEstadoNego tipoEstadoNego = new TipoEstadoNego();

        static int idProyectoActual = 1;
        static int idEmpresaActual = 1;
        static int idLocalidadActual = 1;
        static int idPersonaActual = 1;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack) return;

            PanelInformacion.Visible = false;
            PanelInformacionAdicionalProyecto.Visible = false;

            LlenarListaPersonas(); //SIRVE PARA EL DROP DOWN LIST
            LlenarListaEmpresas(); // SIRVE PARA EL DROP DOWN LIST
            LlenarListaTipoEstados(); // SIRVE PARA EL DROP DOWN LIST
            LlenarListaTipoProyectos(); // SIRVE PARA EL DROP DOWN LIST
            LlenarListaFondoChoice();

            LlenarListaLocalidades(); //SIRVE PARA EL DROP DOWN LIST
            LlenarListaSectores();
            LlenarListaTematicas();

            //txtFechaInicioModal.Text = Convert.ToString(DateTime.Today.ToShortDateString());
            //txtFechaFinalModal.Text = Convert.ToString(DateTime.Today.ToShortDateString());

            btnGuardarProyecto.Visible = false;
        }

        //Muestra en el DROPDOWNLIST los FONDOS
        private void LlenarListaFondoChoice()
        {
            ddlFondoChoice.DataSource = fondoNego.MostrarFondos().ToList();
            ddlFondoChoice.DataValueField = "idFondo";
            ddlFondoChoice.DataBind();
        }

        //Muestra en el DROPDOWNLIST las CONVOCATORIAS
        private void LlenarListaConvocatorias()
        {
            ddlConvocatoria.DataSource = convocatoriaNego.MostrarConvocatorias().OrderBy(c => c.Nombre).ToList();
            ddlConvocatoria.DataValueField = "IdConvocatoria";
            ddlConvocatoria.DataBind();
        }

        //Muestra en el DROPDOWNLIST las LOCALIDADES
        private void LlenarListaLocalidades()
        {
            ddlLocalidad.DataSource = localidadNego.MostrarLocalidades().ToList();
            ddlLocalidad.DataValueField = "nombre";
            ddlLocalidad.DataBind();
        }

        //Muestra en el DROPDOWNLIST los SECTORES
        private void LlenarListaSectores()
        {
            ddlSector.DataSource = sectorNego.MostrarSectores().ToList();
            ddlSector.DataValueField = "nombre";
            ddlSector.DataBind();
        }
        //Muestra en el DROPDOWNLIST las TEMATICAS
        private void LlenarListaTematicas()
        {
            ddlTematica.DataSource = tematicaNego.MostrarTematicas().ToList();
            ddlTematica.DataValueField = "nombre";
            ddlTematica.DataBind();
        }

        //Muestra en el DROPDOWNLIST el tipo de Proyecto (Idea Proyecto / Proyecto)
        private void LlenarListaTipoProyectos()
        {
            ddlTipoProyecto.DataSource = tipoProyectoNego.MostrarTipoProyectos().ToList();
            ddlTipoProyecto.DataValueField = "nombre";
            ddlTipoProyecto.DataBind();
        }

        //Muestra en el DROPDOWNLIST los Tipos de Estado (del Proyecto Simple)
        private void LlenarListaTipoEstados()
        {
            ddlTipoEstado.DataSource = tipoEstadoNego.MostrarTipoEstados().ToList();
            ddlTipoEstado.DataValueField = "nombre";
            ddlTipoEstado.DataBind();
        }

        //Muestra en el DROPDOWNLIST las EMPRESAS
        private void LlenarListaEmpresas()
        {
            ddlEmpresa.DataSource = empresaNego.MostrarEmpresas().ToList();
            ddlEmpresa.DataValueField = "nombre";
            ddlEmpresa.DataBind();
        }

        //Muestra en el DROPDOWNLIST las PERSONAS
        private void LlenarListaPersonas()
        {
            ddlContacto.DataSource = personaNego.MostrarPersonas().OrderBy(c => c.Nombre).ToList();
            IList<Persona> nombreCompleto = personaNego.MostrarPersonas().Select(p => new Persona() { Nombre = p.Apellido + "," + p.Nombre, IdPersona = p.IdPersona }).OrderBy(c => c.IdPersona).ToList();
            ddlContacto.DataSource = nombreCompleto;
            ddlContacto.DataValueField = "nombre";
            ddlContacto.DataBind();
        }

        protected void btnGuardarProyecto_Click(object sender, EventArgs e)
        {
            if (
                ddlConvocatoria.SelectedValue != "-1"
                && txtCodigoInterno.Text != ""
                && txtNombre.Text != ""
                //&& ddlLocalidad.SelectedValue != "-1"
                && ddlContacto.SelectedValue != "-1"
                && ddlTipoEstado.SelectedValue != "-1"
                && ddlTipoProyecto.SelectedValue != "-1"
                )
            {
                GuardarProyecto();

                Response.Redirect("MostrarProyecto.aspx");
            }
            else
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Correct", "alert('Complete los campos: NOMBRE, REFERENTE, CODIGO INTERNO, TIPO DE PROYECTO, ESTADO.')", true);

            }
        }

        private void GuardarProyecto()
        {
            Proyecto proyecto = new Proyecto();

            proyecto.IdConvocatoria = Int32.Parse(ddlConvocatoria.SelectedValue);
            proyecto.CodigoInterno = txtCodigoInterno.Text;
            proyecto.NumeroExpediente = txtNumeroExp.Text;
            proyecto.Nombre = txtNombre.Text;
            proyecto.Objetivos = txtObjetivos.Text;
            proyecto.Descripcion = txtDescripcion.Text;
            proyecto.Destinatarios = txtDestinatarios.Text;
            proyecto.Observaciones = txtObservaciones.Text;

            if (txtMontoSolicitado.Text == "") { proyecto.MontoSolicitado = null; }
            else { proyecto.MontoSolicitado = Convert.ToDecimal(txtMontoSolicitado.Text); }

            if (txtMontoContraparte.Text == "") { proyecto.MontoContraparte = null; }
            else { proyecto.MontoContraparte = Convert.ToDecimal(txtMontoContraparte.Text); }

            if (txtMontoTotal.Text == "") { proyecto.MontoTotal = null; }
            else { proyecto.MontoTotal = Convert.ToDecimal(txtMontoTotal.Text); }

            //PARA EL REFERENTE
            if (ddlContacto.SelectedValue == "-1") { proyecto.IdPersona = null; }
            else
            {
                string cadena = ddlContacto.SelectedItem.ToString();
                string[] separadas;
                separadas = cadena.Split(',');
                string itemApellido = separadas[0];
                string itemNombre = separadas[1];
                proyecto.IdPersona = personaNego.TraerPersonaIdSegunItem(itemApellido, itemNombre);
            }

            //PARA EMPRESA
            if (ddlEmpresa.SelectedValue == "-1") { proyecto.IdEmpresa = null; }
            else { proyecto.IdEmpresa = empresaNego.TraerEmpresaIdSegunItem(ddlEmpresa.SelectedItem.ToString()); }

            //PARA SECTOR
            if (ddlSector.SelectedValue == "-1") { proyecto.IdSector = null; }
            else { proyecto.IdSector = sectorNego.TraerSectorIdSegunItem(ddlSector.SelectedItem.ToString()); }

            //PARA TEMATICA
            if (ddlTematica.SelectedValue == "-1") { proyecto.IdTematica = null; }
            else { proyecto.IdTematica = tematicaNego.TraerTematicaIdSegunItem(ddlTematica.SelectedItem.ToString()); }

            //PARA TIPO ESTADO
            if (ddlTipoEstado.SelectedValue == "-1") { proyecto.IdTipoEstado = null; }
            else { proyecto.IdTipoEstado = tipoEstadoNego.TraerTipoEstadoIdSegunItem(ddlTipoEstado.SelectedItem.ToString()); }

            //PARA LOCALIDAD
            if (ddlLocalidad.SelectedValue == "-1") { proyecto.IdLocalidad = null; }
            else { proyecto.IdLocalidad = localidadNego.TraerLocalidadIdSegunItem(ddlLocalidad.SelectedItem.ToString()); }

            //PARA TIPO PROYECTO
            if (ddlTipoProyecto.SelectedValue == "-1") { proyecto.IdTipoProyecto = null; }
            else { proyecto.IdTipoProyecto = tipoProyectoNego.TraerTipoProyectoIdSegunItem(ddlTipoProyecto.SelectedItem.ToString()); }

            int idProyecto = proyectoNego.GuardarProyecto(proyecto);

            //DESPUES GUARDO LA LISTA DE ETAPAS DEL PROYECTO ACTUAL
            idProyectoActual = idProyecto;

            ListarProyectos.codigoInternoProyectoSeleccionado = proyecto.CodigoInterno;
            ListarProyectos.idConvocatoriaSeleccionada = proyecto.IdConvocatoria;
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

            LlenarListaEmpresas();
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

            LlenarListaLocalidades();
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

            LlenarListaPersonas();
        }
        private string TraerPersona(int id)
        {
            return personaNego.TraerPersona(id);
        }

        protected void ddlContacto_SelectedIndexChanged(object sender, EventArgs e)
        {
            idPersonaActual = ddlContacto.SelectedIndex;
        }

        protected void ddlEmpresa_SelectedIndexChanged(object sender, EventArgs e)
        {
            idEmpresaActual = ddlEmpresa.SelectedIndex;
        }

        protected void ddlFondoChoice_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlFondoChoice.SelectedValue != "-1")
            {
                btnGuardarProyecto.Visible = true;

                LlenarChoiceConvocatorias(Convert.ToInt32(ddlFondoChoice.SelectedValue));

                if (fondoNego.ObtenerFondo(Convert.ToInt32(ddlFondoChoice.SelectedValue)).Nombre.ToUpper() == "COFECYT")
                {
                    //la puse recien
                    Response.Redirect("AltaProyectoCofecyt.aspx");
                }

                PanelInformacion.Visible = true;
                PanelInformacionAdicionalProyecto.Visible = true;
            }
            else
            {
                Response.Redirect("AltaProyecto.aspx");
            }
        }
        private void LlenarChoiceConvocatorias(int id)
        {
            ddlConvocatoria.DataSource = convocatoriaNego.ListarChoiceConvocatorias(id);
            ddlConvocatoria.DataTextField = "nombre";
            ddlConvocatoria.DataValueField = "idConvocatoria";
            ddlConvocatoria.DataBind();
        }
    }
}