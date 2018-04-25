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
        FondoNego fondoNego = new FondoNego();
        TipoProyectoNego tipoProyectoNego = new TipoProyectoNego();
        UdtUvtNego udtUvtNego = new UdtUvtNego();

        TematicaNego tematicaNego = new TematicaNego();
        SectorNego sectorNego = new SectorNego();
        TipoEstadoEtapaNego tipoEstadoEtapaNego = new TipoEstadoEtapaNego();

        ProyectoNego proyectoNego = new ProyectoNego();
        EtapaNego etapaNego = new EtapaNego();
        TipoEstadoNego tipoEstadoNego = new TipoEstadoNego();

        ProyectoCofecytNego proyectoCofecytNego = new ProyectoCofecytNego();
        EtapaCofecytNego etapaCofecytNego = new EtapaCofecytNego();
        TipoEstadoCofecytNego tipoEstadoCofecytNego = new TipoEstadoCofecytNego();
        ActividadCofecytNego actividadCofecytNego = new ActividadCofecytNego();

        static int idProyectoActual = 1;
        static int idProyectoCofecytActual = 1;
        static int idEmpresaActual = 1;
        static int idLocalidadActual = 1;
        static int idPersonaActual = 1;

        static List<Etapa> listaEtapasTemporal = new List<Etapa>();
        static List<EtapaCofecyt> listaEtapaCofecytsTemporal = new List<EtapaCofecyt>();
        static List<ActividadCofecyt> listaActividadCofecytsTemporal = new List<ActividadCofecyt>();

        static int idEtapaCofecytUltima;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack) return;

            PanelInformacion.Visible = false;
            PanelCofecytFinanciamiento.Visible = false;
            PanelCofecytInformacion.Visible = false;
            PanelInformacionAdicionalProyecto.Visible = false;
            PanelMostrarEtapas.Visible = false;
            PanelMostrarEtapasCofecyt.Visible = false;

            LlenarListaPersonas(); //SIRVE PARA EL DROP DOWN LIST
            LlenarListaEmpresas(); // SIRVE PARA EL DROP DOWN LIST
            LlenarListaTipoEstados(); // SIRVE PARA EL DROP DOWN LIST
            LlenarListaTipoEstadoEtapas(); // SIRVE PARA EL DROP DOWN LIST
            LlenarListaTipoEstadoEtapasCofecyt(); // SIRVE PARA EL DROP DOWN LIST
            LlenarListaTipoProyectos(); // SIRVE PARA EL DROP DOWN LIST
            LlenarListaFondoChoice();

            LlenarListaLocalidades(); //SIRVE PARA EL DROP DOWN LIST
            LlenarListaLocalidadesCofecyt();
            LlenarListaSectores();
            LlenarListaSectoresCofecyt();
            LlenarListaTematicas();
            LlenarListaTematicasCofecyt();

            LlenarListaUdtUvts();
            LlenarListaDirectores();
            LlenarListaContactoBeneficiarios();
            LlenarListaTipoEstadoCofecyt();

            //txtFechaInicioModal.Text = Convert.ToString(DateTime.Today.ToShortDateString());
            //txtFechaFinalModal.Text = Convert.ToString(DateTime.Today.ToShortDateString());

            listaEtapasTemporal.Clear();
            listaEtapaCofecytsTemporal.Clear();
            listaActividadCofecytsTemporal.Clear();

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

        //Muestra en el DROPDOWNLIST los Tipos de Estado de la Etapa
        private void LlenarListaTipoEstadoEtapas()
        {
            ddlTipoEstadoEtapa.DataSource = tipoEstadoEtapaNego.MostrarTipoEstadoEtapas().ToList();
            ddlTipoEstadoEtapa.DataValueField = "nombre";
            ddlTipoEstadoEtapa.DataValueField = "idTipoEstadoEtapa";
            ddlTipoEstadoEtapa.DataBind();
        }
        private void LlenarListaTipoEstadoEtapasCofecyt()
        {
            ddlTipoEstadoEtapaCofecyt.DataSource = tipoEstadoEtapaNego.MostrarTipoEstadoEtapas().ToList();
            ddlTipoEstadoEtapaCofecyt.DataValueField = "nombre";
            ddlTipoEstadoEtapaCofecyt.DataValueField = "idTipoEstadoEtapa";
            ddlTipoEstadoEtapaCofecyt.DataBind();
        }
        private void LlenarListaTipoEstadoCofecyt()
        {
            ddlEstadoCofecyt.DataSource = tipoEstadoCofecytNego.MostrarTipoEstadoCofecyts().ToList();
            ddlEstadoCofecyt.DataValueField = "nombre";
            ddlEstadoCofecyt.DataValueField = "idTipoEstadoCofecyt";
            ddlEstadoCofecyt.DataBind();
        }

        //Muestra en el DROPDOWNLIST las LOCALIDADES
        private void LlenarListaLocalidades()
        {
            ddlLocalidad.DataSource = localidadNego.MostrarLocalidades().ToList();
            ddlLocalidad.DataValueField = "nombre";
            ddlLocalidad.DataBind();
        }
        //Muestra en el DROPDOWNLIST de COFECYT las LOCALIDADES
        private void LlenarListaLocalidadesCofecyt()
        {
            ddlLocalidadCofecyt.DataSource = localidadNego.MostrarLocalidades().ToList();
            ddlLocalidadCofecyt.DataValueField = "nombre";
            ddlLocalidadCofecyt.DataBind();
        }
        //Muestra en el DROPDOWNLIST de COFECYT los SECTORES
        private void LlenarListaSectoresCofecyt()
        {
            ddlSectorCofecyt.DataSource = sectorNego.MostrarSectores().ToList();
            ddlSectorCofecyt.DataValueField = "nombre";
            ddlSectorCofecyt.DataBind();
        }
        //Muestra en el DROPDOWNLIST de COFECYT las TEMATICAS
        private void LlenarListaTematicasCofecyt()
        {
            ddlTematicaCofecyt.DataSource = tematicaNego.MostrarTematicas().ToList();
            ddlTematicaCofecyt.DataValueField = "nombre";
            ddlTematicaCofecyt.DataBind();
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
        //Muestra en el DROPDOWNLIST las UDT UVT
        private void LlenarListaUdtUvts()
        {
            ddlUvt.DataSource = udtUvtNego.MostrarUdtUvts().ToList();
            ddlUvt.DataValueField = "nombre";
            ddlUvt.DataBind();
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
        //Muestra en el DROPDOWNLIST los DIRECTORES
        private void LlenarListaDirectores()
        {
            ddlDirector.DataSource = personaNego.MostrarPersonas().OrderBy(c => c.Nombre).ToList();
            IList<Persona> nombreCompleto = personaNego.MostrarPersonas().Select(p => new Persona() { Nombre = p.Apellido + "," + p.Nombre, IdPersona = p.IdPersona }).OrderBy(c => c.IdPersona).ToList();
            ddlDirector.DataSource = nombreCompleto;
            ddlDirector.DataValueField = "nombre";
            ddlDirector.DataBind();
        }
        //Muestra en el DROPDOWNLIST los CONTACTO BENEFICIARIOS
        private void LlenarListaContactoBeneficiarios()
        {
            ddlContactoBeneficiario.DataSource = personaNego.MostrarPersonas().OrderBy(c => c.Nombre).ToList();
            IList<Persona> nombreCompleto = personaNego.MostrarPersonas().Select(p => new Persona() { Nombre = p.Apellido + "," + p.Nombre, IdPersona = p.IdPersona }).OrderBy(c => c.IdPersona).ToList();
            ddlContactoBeneficiario.DataSource = nombreCompleto;
            ddlContactoBeneficiario.DataValueField = "nombre";
            ddlContactoBeneficiario.DataBind();
        }

        protected void btnGuardarProyecto_Click(object sender, EventArgs e)
        {
            if (fondoNego.ObtenerFondo(Convert.ToInt32(ddlFondoChoice.SelectedValue)).Nombre.ToUpper() == "COFECYT")
            {
                if (txtTituloCofecyt.Text != ""
                    && txtNumeroExpedienteCopadeCofecyt.Text != ""
                    )
                {
                    GuardarProyectoCofecyt();

                    Response.Redirect("ListarProyectos.aspx");
                }
                else
                {
                    // Mostrar aviso de completar todos los datos
                }
            }
            else
            {
                if (
                    ddlConvocatoria.SelectedValue != "-1"
                    && txtNumeroExp.Text != ""
                    && txtNombre.Text != ""
                    && ddlLocalidad.SelectedValue != "-1"
                    && ddlTipoEstado.SelectedValue != "-1"
                    && ddlTipoProyecto.SelectedValue != "-1"
                    )
                {
                    GuardarProyecto();

                    Response.Redirect("ListarProyectos.aspx");
                }
                else
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "Correct", "alert('Complete los campos: NOMBRE, EXPEDIENTE, LOCALIDAD, TIPO DE PROYECTO, ESTADO  .')", true);

                }
            }
        }


        //Para la etapa de un proyecto simple
        protected void btnModalEtapaGuardar_Click(object sender, EventArgs e)
        {
            ModalEtapaGuardar();
        }

        private void ModalEtapaGuardar()
        {
            Etapa etapa = new Etapa();

            etapa.Nombre = txtNombreModal.Text;
            etapa.FechaInicio = DateTime.ParseExact(txtFechaInicioModal.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);
            etapa.FechaFin = DateTime.ParseExact(txtFechaFinalModal.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);
            etapa.IdTipoEstadoEtapa = Convert.ToInt32(ddlTipoEstadoEtapa.SelectedValue);

            if (chkRendicion.Checked)
            {
                etapa.Rendicion = true;
            }
            else if (!chkRendicion.Checked)
            {
                etapa.Rendicion = false;
            }

            if (chkInforme.Checked)
            {
                etapa.Informe = true;
            }
            else if (!chkInforme.Checked)
            {
                etapa.Informe = false;
            }

            listaEtapasTemporal.Add(etapa);

            txtNombreModal.Text = null;
            txtFechaInicioModal.Text = null;
            txtFechaFinalModal.Text = null;

            chkInforme.Text = null;
            chkRendicion.Text = null;
            ddlTipoEstadoEtapa.Text = null;

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

            proyecto.IdConvocatoria = Int32.Parse(ddlConvocatoria.SelectedValue);
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

            foreach (Etapa item in listaEtapasTemporal)
            {
                Etapa etapa = new Etapa();

                etapa.IdProyecto = idProyectoActual;
                etapa.Nombre = item.Nombre.ToString();
                etapa.FechaInicio = Convert.ToDateTime(item.FechaInicio.ToString());
                etapa.FechaFin = Convert.ToDateTime(item.FechaFin.ToString());

                //etapa.IdTipoEstadoEtapa = tipoEstadoEtapaNego.TraerTipoEstadoEtapaIdSegunItem(ddlTipoEstadoEtapa.SelectedItem.ToString());
                etapa.IdTipoEstadoEtapa = item.IdTipoEstadoEtapa;

                if (chkRendicion.Checked) { etapa.Rendicion = true; }
                else if (!chkRendicion.Checked) { etapa.Rendicion = false; }

                if (chkInforme.Checked) { etapa.Informe = true; }
                else if (!chkInforme.Checked) { etapa.Informe = false; }

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

                    PanelInformacion.Visible = false;
                    PanelCofecytFinanciamiento.Visible = true;
                    PanelCofecytInformacion.Visible = true;
                    PanelInformacionAdicionalProyecto.Visible = false;
                    PanelMostrarEtapas.Visible = false;
                    PanelMostrarEtapasCofecyt.Visible = true;
                }
                else
                {
                    PanelInformacion.Visible = true;
                    PanelCofecytFinanciamiento.Visible = false;
                    PanelCofecytInformacion.Visible = false;
                    PanelInformacionAdicionalProyecto.Visible = true;
                    PanelMostrarEtapas.Visible = true;
                    PanelMostrarEtapasCofecyt.Visible = false;
                }
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

        protected void btnModalEtapaCofecytGuardar_Click(object sender, EventArgs e)
        {
            ModalEtapaCofecytGuardar();

            LlenarGrillaEtapasCofecyt();

            LlenarListaEtapasActividad();
        }

        protected void btnModalActividadCofecytGuardar_Click(object sender, EventArgs e)
        {
            ModalActividadCofecytGuardar();

            LlenarGrillaActividadesCofecyt();
        }

        //GUARDAR PROYECTO DE COFECYT
        public void GuardarProyectoCofecyt()
        {
            ProyectoCofecyt proyectoCofecyt = new ProyectoCofecyt();

            proyectoCofecyt.Titulo = txtTituloCofecyt.Text;
            proyectoCofecyt.Objetivos = txtObjetivosCofecyt.Text;
            proyectoCofecyt.Descripcion = txtDescripcionCofecyt.Text;
            proyectoCofecyt.Destinatarios = txtDestinatariosCofecyt.Text;

            proyectoCofecyt.NumeroEspedienteCopade = txtNumeroExpedienteCopadeCofecyt.Text;
            proyectoCofecyt.NumeroConvenio = txtNumeroConvenio.Text;
            proyectoCofecyt.NumeroExpedienteDga = txtNumeroExpedienteDga.Text;

            if (ddlLocalidadCofecyt.SelectedValue == "-1") { proyectoCofecyt.IdLocalidad = null; }
            else { proyectoCofecyt.IdLocalidad = localidadNego.TraerLocalidadIdSegunItem(ddlLocalidadCofecyt.SelectedItem.ToString()); }

            if (ddlSectorCofecyt.SelectedValue == "-1") { proyectoCofecyt.IdSector = null; }
            else { proyectoCofecyt.IdSector = sectorNego.TraerSectorIdSegunItem(ddlSectorCofecyt.SelectedItem.ToString()); }

            if (ddlTematicaCofecyt.SelectedValue == "-1") { proyectoCofecyt.IdTematica = null; }
            else { proyectoCofecyt.IdTematica = tematicaNego.TraerTematicaIdSegunItem(ddlTematicaCofecyt.SelectedItem.ToString()); }

            if (ddlUvt.SelectedValue == "-1") { proyectoCofecyt.UdtUvt = null; }
            else { proyectoCofecyt.IdUdtUvt = udtUvtNego.TraerUdtUvtIdSegunItem(ddlUvt.SelectedItem.ToString()); }

            if (ddlDirector.SelectedValue == "-1") { proyectoCofecyt.IdDirector = null; }
            else
            {
                //para DIRECTOR
                string cadena = ddlDirector.SelectedItem.ToString();
                string[] separadas;
                separadas = cadena.Split(',');
                string itemApellido = separadas[0];
                string itemNombre = separadas[1];
                proyectoCofecyt.IdDirector = personaNego.TraerPersonaIdSegunItem(itemApellido, itemNombre);
            }

            if (ddlEstadoCofecyt.SelectedValue == "-1") { proyectoCofecyt.IdTipoEstadoCofecyt = null; }
            else { proyectoCofecyt.IdTipoEstadoCofecyt = tipoEstadoCofecytNego.TraerTipoEstadoCofecytIdSegunItem(ddlEstadoCofecyt.SelectedItem.ToString()); }

            //para CONTACTO BENEFICIARIO
            if (ddlContactoBeneficiario.SelectedValue == "-1") { proyectoCofecyt.IdContactoBeneficiario = null; }
            else
            {
                string cadena = ddlContactoBeneficiario.SelectedItem.ToString();
                string[] separadas;
                separadas = cadena.Split(',');
                string itemApellido = separadas[0];
                string itemNombre = separadas[1];
                proyectoCofecyt.IdContactoBeneficiario = personaNego.TraerPersonaIdSegunItem(itemApellido, itemNombre);
            }

            proyectoCofecyt.FechaPresentacion = DateTime.ParseExact(txtFechaPresentacion.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);
            proyectoCofecyt.FechaFinalizacion = DateTime.ParseExact(txtFechaFinalizacion.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);
            proyectoCofecyt.UltimaEvaluacionTecnica = DateTime.ParseExact(txtUltimaEvaluacionTecnica.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);

            if (txtDuracionEstimada.Text == "") { proyectoCofecyt.DuracionEstimada = null; }
            else { proyectoCofecyt.DuracionEstimada = Convert.ToInt32(txtDuracionEstimada.Text); }

            if (txtDuracionEstimadaIfaa.Text == "") { proyectoCofecyt.DuracionEstimadaIfaa = null; }
            else { proyectoCofecyt.DuracionEstimadaIfaa = Convert.ToInt32(txtDuracionEstimadaIfaa.Text); }

            proyectoCofecyt.Beneficiarios = txtBeneficiarios.Text;
            proyectoCofecyt.EntidadesIntervinientes = txtEntidadesIntervinientes.Text;


            proyectoCofecyt.Observaciones = txtObservacionesCofecyt.Text;

            proyectoCofecyt.IdConvocatoria = Int32.Parse(ddlConvocatoria.SelectedValue);

            proyectoCofecyt.MontoSolicitadoCofecyt = Convert.ToDecimal(txtMontoSolicitadoCofecyt.Text);
            proyectoCofecyt.MontoContraparteCofecyt = Convert.ToDecimal(txtMontoContraparteCofecyt.Text);
            proyectoCofecyt.MontoTotalCofecyt = Convert.ToDecimal(txtMontoTotalCofecyt.Text);
            proyectoCofecyt.MontoTotalDgaCofecyt = Convert.ToDecimal(txtMontoTotalDgaCofecyt.Text);
            proyectoCofecyt.MontoDevolucionCofecyt = Convert.ToDecimal(txtMontoDevolucionCofecyt.Text);
            proyectoCofecyt.MontoRescindidoCofecyt = Convert.ToDecimal(txtMontoRescindidoCofecyt.Text);

            int idProyectoCofecyt = proyectoCofecytNego.GuardarProyectoCofecyt(proyectoCofecyt);

            //DESPUES GUARDO LA LISTA DE ETAPAS DEL PROYECTO COFECYT ACTUAL
            idProyectoCofecytActual = idProyectoCofecyt;

            foreach (EtapaCofecyt item in listaEtapaCofecytsTemporal)
            {
                EtapaCofecyt etapaCofecyt = new EtapaCofecyt();

                etapaCofecyt.IdProyectoCofecyt = idProyectoCofecytActual;
                etapaCofecyt.Nombre = item.Nombre.ToString();
                etapaCofecyt.FechaInicio = Convert.ToDateTime(item.FechaInicio.ToString());
                etapaCofecyt.FechaFin = Convert.ToDateTime(item.FechaFin.ToString());
                etapaCofecyt.IdTipoEstadoEtapa = item.IdTipoEstadoEtapa;
                etapaCofecyt.DuracionSegunUvt = item.DuracionSegunUvt;

                if (chkRendicionCofecyt.Checked) { etapaCofecyt.Rendicion = true; }
                else if (!chkRendicionCofecyt.Checked) { etapaCofecyt.Rendicion = false; }

                if (chkInformeCofecyt.Checked) { etapaCofecyt.Informe = true; }
                else if (!chkInformeCofecyt.Checked) { etapaCofecyt.Informe = false; }

                idEtapaCofecytUltima = etapaCofecytNego.GuardarEtapaCofecyt(etapaCofecyt);
            }

            //DESPUES GUARDO LA LISTA DE ACTIVIDADES DEL PROYECTO COFECYT ACTUAL
            foreach (ActividadCofecyt item2 in listaActividadCofecytsTemporal)
            {
                ActividadCofecyt actividadCofecyt = new ActividadCofecyt();

                actividadCofecyt.IdProyectoCofecyt = idProyectoCofecytActual;

                actividadCofecyt.IdEtapaCofecyt = idEtapaCofecytUltima - listaEtapaCofecytsTemporal.Count + item2.IdEtapaCofecyt;

                actividadCofecyt.Nombre = item2.Nombre;
                actividadCofecyt.Descripcion = item2.Descripcion;
                actividadCofecyt.ResultadosEsperados = item2.ResultadosEsperados;
                actividadCofecyt.Localizacion = item2.Localizacion;

                actividadCofecytNego.GuardarActividadCofecyt(actividadCofecyt);
            }
        }

        public void ModalEtapaCofecytGuardar()
        {
            EtapaCofecyt etapaCofecyt = new EtapaCofecyt();

            etapaCofecyt.IdProyectoCofecyt = idProyectoCofecytActual;
            etapaCofecyt.Nombre = txtNombreModalCofecyt.Text;
            etapaCofecyt.IdTipoEstadoEtapa = tipoEstadoEtapaNego.TraerTipoEstadoEtapaIdSegunItem(ddlTipoEstadoEtapaCofecyt.SelectedItem.ToString());
            etapaCofecyt.FechaInicio = DateTime.ParseExact(txtFechaInicioCofecyt.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);
            etapaCofecyt.FechaFin = DateTime.ParseExact(txtFechaFinCofecyt.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);
            etapaCofecyt.DuracionSegunUvt = txtDuracionSegunUvt.Text;

            if (chkRendicionCofecyt.Checked)
            {
                etapaCofecyt.Rendicion = true;
            }
            else if (!chkRendicionCofecyt.Checked)
            {
                etapaCofecyt.Rendicion = false;
            }

            if (chkInformeCofecyt.Checked)
            {
                etapaCofecyt.Informe = true;
            }
            else if (!chkInformeCofecyt.Checked)
            {
                etapaCofecyt.Informe = false;
            }

            listaEtapaCofecytsTemporal.Add(etapaCofecyt);
        }

        public void LlenarGrillaEtapasCofecyt()
        {
            dgvEtapasCofecyt.DataSource = listaEtapaCofecytsTemporal.ToList();
            dgvEtapasCofecyt.DataBind();
        }
        public void LlenarListaEtapasActividad() //dentro del modal actividad cofecyt
        {
            ddlEtapaActividad.DataSource = listaEtapaCofecytsTemporal.ToList();
            ddlEtapaActividad.DataBind();
        }

        public void ModalActividadCofecytGuardar()
        {
            ActividadCofecyt actividadCofecyt = new ActividadCofecyt();

            actividadCofecyt.IdProyectoCofecyt = idProyectoCofecytActual;
            actividadCofecyt.Nombre = txtNombreActividadCofecyt.Text;
            actividadCofecyt.Descripcion = txtDescripcionActividadCofecyt.Text;
            actividadCofecyt.ResultadosEsperados = txtResultadosEsperadosActividadCofecyt.Text;
            actividadCofecyt.Localizacion = txtLocalizacionActividadCofecyt.Text;

            actividadCofecyt.IdEtapaCofecyt = ddlEtapaActividad.SelectedIndex + 1;

            listaActividadCofecytsTemporal.Add(actividadCofecyt);
        }
        public void LlenarGrillaActividadesCofecyt()
        {
            //Hay que transformar el nombre de etapa que es un int y pasarlo a string

            dgvActividadesCofecyt.DataSource = listaActividadCofecytsTemporal.ToList().OrderBy(p => p.IdEtapaCofecyt);

            dgvActividadesCofecyt.DataBind();
        }
    }
}