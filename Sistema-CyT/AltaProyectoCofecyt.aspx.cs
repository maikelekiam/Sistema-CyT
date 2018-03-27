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
    public partial class AltaProyectoCofecyt : System.Web.UI.Page
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

        ProyectoCofecytNego proyectoCofecytNego = new ProyectoCofecytNego();
        EtapaCofecytNego etapaCofecytNego = new EtapaCofecytNego();
        TipoEstadoCofecytNego tipoEstadoCofecytNego = new TipoEstadoCofecytNego();
        ActividadCofecytNego actividadCofecytNego = new ActividadCofecytNego();

        static int idProyectoCofecytActual = 1;

        static List<Etapa> listaEtapasTemporal = new List<Etapa>();
        static List<EtapaCofecyt> listaEtapaCofecytsTemporal = new List<EtapaCofecyt>();
        static List<ActividadCofecyt> listaActividadCofecytsTemporal = new List<ActividadCofecyt>();

        static int idEtapaCofecytUltima;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack) return;

            LlenarListaConvocatorias();

            LlenarListaTipoEstadoEtapasCofecyt(); // SIRVE PARA EL DROP DOWN LIST

            LlenarListaLocalidadesCofecyt();
            LlenarListaSectoresCofecyt();
            LlenarListaTematicasCofecyt();

            LlenarListaUdtUvts();
            LlenarListaDirectores();
            LlenarListaContactoBeneficiarios();
            LlenarListaTipoEstadoCofecyt();

            //txtFechaPresentacion.Text = Convert.ToString(DateTime.Today.ToShortDateString());
            //txtUltimaEvaluacionTecnica.Text = Convert.ToString(DateTime.Today.ToShortDateString());
            //txtFechaFinalizacion.Text = Convert.ToString(DateTime.Today.ToShortDateString());



            //txtFechaInicioModal.Text = Convert.ToString(DateTime.Today.ToShortDateString());
            //txtFechaFinalModal.Text = Convert.ToString(DateTime.Today.ToShortDateString());

            listaEtapasTemporal.Clear();
            listaEtapaCofecytsTemporal.Clear();
            listaActividadCofecytsTemporal.Clear();
        }

        //Muestra en el DROPDOWNLIST las CONVOCATORIAS
        private void LlenarListaConvocatorias()
        {
            Fondo fon = fondoNego.ObtenerFondoSegunNombre("COFECyT");

            ddlConvocatoria.DataSource = convocatoriaNego.MostrarConvocatorias().Where(c => c.IdFondo == fon.IdFondo).Where(c => c.Activa == true).OrderBy(c => c.Nombre).ToList();
            ddlConvocatoria.DataValueField = "IdConvocatoria";
            ddlConvocatoria.DataBind();
        }

        //Muestra en el DROPDOWNLIST los Tipos de Estado de la Etapa
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
        //Muestra en el DROPDOWNLIST las UDT UVT
        private void LlenarListaUdtUvts()
        {
            ddlUvt.DataSource = udtUvtNego.MostrarUdtUvts().ToList();
            ddlUvt.DataValueField = "nombre";
            ddlUvt.DataBind();
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

            if (txtFechaPresentacion.Text == "") { proyectoCofecyt.FechaPresentacion = null; }
            else { proyectoCofecyt.FechaPresentacion = DateTime.ParseExact(txtFechaPresentacion.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture); }

            if (txtFechaFinalizacion.Text == "") { proyectoCofecyt.FechaFinalizacion = null; }
            else { proyectoCofecyt.FechaFinalizacion = DateTime.ParseExact(txtFechaFinalizacion.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture); };

            if (txtUltimaEvaluacionTecnica.Text == "") { proyectoCofecyt.UltimaEvaluacionTecnica = null; }
            else { proyectoCofecyt.UltimaEvaluacionTecnica = DateTime.ParseExact(txtUltimaEvaluacionTecnica.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture); };



            //proyectoCofecyt.FechaPresentacion = DateTime.ParseExact(txtFechaPresentacion.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);
            //proyectoCofecyt.FechaFinalizacion = DateTime.ParseExact(txtFechaFinalizacion.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);
            //proyectoCofecyt.UltimaEvaluacionTecnica = DateTime.ParseExact(txtUltimaEvaluacionTecnica.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);

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
        public void LlenarListaEtapasActividad() //dentro del modal actividad cofecyt
        {
            ddlEtapaActividad.DataSource = listaEtapaCofecytsTemporal.ToList();
            ddlEtapaActividad.DataBind();
        }
        protected void btnGuardarProyecto_Click(object sender, EventArgs e)
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
    }
}