﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CapaDominio;
using CapaNegocio;
using System.Globalization;
using System.Windows.Forms;

namespace Sistema_CyT
{
    public partial class EditarProyectoCofecyt : System.Web.UI.Page
    {
        LocalidadNego localidadNego = new LocalidadNego();
        PersonaNego personaNego = new PersonaNego();
        FondoNego fondoNego = new FondoNego();
        ConvocatoriaNego convocatoriaNego = new ConvocatoriaNego();
        TipoProyectoNego tipoProyectoNego = new TipoProyectoNego();
        TematicaNego tematicaNego = new TematicaNego();
        SectorNego sectorNego = new SectorNego();

        ProyectoCofecytNego proyectoCofecytNego = new ProyectoCofecytNego();
        UdtUvtNego udtUvtNego = new UdtUvtNego();
        TipoEstadoCofecytNego tipoEstadoCofecytNego = new TipoEstadoCofecytNego();

        public static int idLocalidadActual = 0;
        public static int idPersonaActual = 0;
        public static int idConvocatoriaSeleccionada = 1;
        public static int idFondoSeleccionado = 1;

        public static int idProyectoCofecytActual;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack) return;

            LlenarChoiceConvocatorias();

            LlenarListaLocalidadesCofecyt();
            LlenarListaSectoresCofecyt();
            LlenarListaTematicasCofecyt();
            LlenarListaUdtUvts();
            LlenarListaDirectores();
            LlenarListaContactoBeneficiarios();
            LlenarListaTipoEstadoCofecyt();

        }

        private void LlenarListaTipoEstadoCofecyt() //Baja por Rescincion, En proceso de baja, 2da intimacion...
        {
            ddlEstadoCofecyt.DataSource = tipoEstadoCofecytNego.MostrarTipoEstadoCofecyts().ToList();
            ddlEstadoCofecyt.DataValueField = "nombre";
            ddlEstadoCofecyt.DataValueField = "idTipoEstadoCofecyt";
            ddlEstadoCofecyt.DataBind();
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
        //Muestra en el DROPDOWNLIST las UDT UVT
        private void LlenarListaUdtUvts()
        {
            ddlUvt.DataSource = udtUvtNego.MostrarUdtUvts().ToList();
            ddlUvt.DataValueField = "nombre";
            ddlUvt.DataBind();
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
        //Muestra en el DROPDOWNLIST de COFECYT las LOCALIDADES
        private void LlenarListaLocalidadesCofecyt()
        {
            ddlLocalidadCofecyt.DataSource = localidadNego.MostrarLocalidades().ToList();
            ddlLocalidadCofecyt.DataValueField = "nombre";
            ddlLocalidadCofecyt.DataBind();
        }
        private void LlenarChoiceConvocatorias()
        {
            Fondo fon = fondoNego.ObtenerFondoSegunNombre("COFECyT");

            ddlConvocatoriaChoice.DataSource = convocatoriaNego.MostrarConvocatorias().Where(c => c.IdFondo == fon.IdFondo).Where(c => c.Activa == true).OrderBy(c => c.Nombre).ToList();
            ddlConvocatoriaChoice.DataValueField = "IdConvocatoria";
            ddlConvocatoriaChoice.DataTextField = "nombre";
            ddlConvocatoriaChoice.DataBind();
        }

        protected void ddlConvocatoriaChoice_SelectedIndexChanged(object sender, EventArgs e)
        {
            idConvocatoriaSeleccionada = Convert.ToInt32(ddlConvocatoriaChoice.SelectedValue.ToString());

            ddlProyectoChoice.DataSource = proyectoCofecytNego.ListarChoiceProyectoCofecyts(idConvocatoriaSeleccionada).ToList();
            ddlProyectoChoice.DataTextField = "titulo";
            ddlProyectoChoice.DataValueField = "idProyectoCofecyt";
            ddlProyectoChoice.DataBind();

            //aca habria que cargar el 1er proyecto
            if (ddlProyectoChoice.SelectedValue != "")
            {
                idProyectoCofecytActual = Convert.ToInt32(ddlProyectoChoice.SelectedValue);

                ProyectoCofecyt proyectoCofecyt = proyectoCofecytNego.ObtenerProyectoCofecyt(idProyectoCofecytActual);

                if (proyectoCofecyt == null)
                {
                    LimpiarFormularioCofecyt();
                    return;
                }
                else
                {
                    txtTituloCofecyt.Text = proyectoCofecyt.Titulo;
                    txtObjetivosCofecyt.Text = proyectoCofecyt.Objetivos;
                    txtDescripcionCofecyt.Text = proyectoCofecyt.Descripcion;
                    //txtFiltroProyecto.Text = Convert.ToString(proyectoCofecyt.IdLocalidad);
                    txtDestinatariosCofecyt.Text = proyectoCofecyt.Destinatarios;

                    if (proyectoCofecyt.IdLocalidad == null) { ddlLocalidadCofecyt.Text = "-1"; }
                    else { ddlLocalidadCofecyt.Text = localidadNego.TraerLocalidad(Convert.ToInt32(proyectoCofecyt.IdLocalidad)); }

                    if (proyectoCofecyt.IdSector == null) { ddlSectorCofecyt.Text = "-1"; }
                    else { ddlSectorCofecyt.Text = sectorNego.TraerSector(Convert.ToInt32(proyectoCofecyt.IdSector)); }

                    if (proyectoCofecyt.IdTematica == null) { ddlTematicaCofecyt.Text = "-1"; }
                    else { ddlTematicaCofecyt.Text = tematicaNego.TraerTematica(Convert.ToInt32(proyectoCofecyt.IdTematica)); }

                    txtNumeroExpedienteCopadeCofecyt.Text = proyectoCofecyt.NumeroEspedienteCopade;
                    txtNumeroConvenio.Text = proyectoCofecyt.NumeroConvenio;
                    txtNumeroExpedienteDga.Text = proyectoCofecyt.NumeroExpedienteDga;

                    if (proyectoCofecyt.IdUdtUvt == null) { ddlUvt.Text = "-1"; }
                    else { ddlUvt.Text = udtUvtNego.TraerUdtUvt(Convert.ToInt32(proyectoCofecyt.IdUdtUvt)); }

                    if (proyectoCofecyt.IdDirector == null) { ddlDirector.Text = "-1"; }
                    else { ddlDirector.Text = personaNego.TraerPersona(Convert.ToInt32(proyectoCofecyt.IdDirector)); }

                    if (proyectoCofecyt.FechaPresentacion == null) { txtFechaPresentacion.Text = ""; }
                    else { txtFechaPresentacion.Text = Convert.ToDateTime(proyectoCofecyt.FechaPresentacion).ToShortDateString(); };

                    if (proyectoCofecyt.FechaFinalizacion == null) { txtFechaFinalizacion.Text = ""; }
                    else { txtFechaFinalizacion.Text = Convert.ToDateTime(proyectoCofecyt.FechaFinalizacion).ToShortDateString(); };

                    if (proyectoCofecyt.UltimaEvaluacionTecnica == null) { txtUltimaEvaluacionTecnica.Text = ""; }
                    else { txtUltimaEvaluacionTecnica.Text = Convert.ToDateTime(proyectoCofecyt.UltimaEvaluacionTecnica).ToShortDateString(); };

                    //txtFechaPresentacion.Text = Convert.ToDateTime(proyectoCofecyt.FechaPresentacion).ToShortDateString();
                    //txtFechaFinalizacion.Text = Convert.ToDateTime(proyectoCofecyt.FechaFinalizacion).ToShortDateString();
                    //txtUltimaEvaluacionTecnica.Text = Convert.ToDateTime(proyectoCofecyt.UltimaEvaluacionTecnica).ToShortDateString();

                    txtDuracionEstimada.Text = Convert.ToString(proyectoCofecyt.DuracionEstimada);
                    txtDuracionEstimadaIfaa.Text = Convert.ToString(proyectoCofecyt.DuracionEstimadaIfaa);
                    txtBeneficiarios.Text = proyectoCofecyt.Beneficiarios;
                    txtEntidadesIntervinientes.Text = proyectoCofecyt.EntidadesIntervinientes;
                    //ddlEstadoCofecyt.Text = tipoEstadoCofecytNego.TraerTipoEstadoCofecyt(Convert.ToInt32(proyectoCofecyt.IdTipoEstadoCofecyt));

                    if (proyectoCofecyt.IdTipoEstadoCofecyt == null) { ddlEstadoCofecyt.Text = "-1"; }
                    else { ddlEstadoCofecyt.Text = Convert.ToString(proyectoCofecyt.IdTipoEstadoCofecyt); }

                    if (proyectoCofecyt.IdContactoBeneficiario == null) { ddlContactoBeneficiario.Text = "-1"; }
                    else { ddlContactoBeneficiario.Text = personaNego.TraerPersona(Convert.ToInt32(proyectoCofecyt.IdContactoBeneficiario)); }

                    txtObservacionesCofecyt.Text = proyectoCofecyt.Observaciones;
                    txtMontoSolicitadoCofecyt.Text = Convert.ToString(proyectoCofecyt.MontoSolicitadoCofecyt);
                    txtMontoContraparteCofecyt.Text = Convert.ToString(proyectoCofecyt.MontoContraparteCofecyt);
                    txtMontoTotalCofecyt.Text = Convert.ToString(proyectoCofecyt.MontoTotalCofecyt);
                    txtMontoTotalDgaCofecyt.Text = Convert.ToString(proyectoCofecyt.MontoTotalDgaCofecyt);
                    txtMontoDevolucionCofecyt.Text = Convert.ToString(proyectoCofecyt.MontoDevolucionCofecyt);
                    txtMontoRescindidoCofecyt.Text = Convert.ToString(proyectoCofecyt.MontoRescindidoCofecyt);
                }
            }
        }

        protected void btnActualizarProyecto_Click(object sender, EventArgs e)
        {
            if (
                //ddlLocalidadCofecyt.SelectedValue != "-1"
                //&& ddlContactoBeneficiario.SelectedValue != "-1"
                //&& ddlDirector.SelectedValue != "-1"
                //&& ddlEstadoCofecyt.SelectedValue != "-1"
                //&& ddlSectorCofecyt.SelectedValue != "-1"
                //&& ddlTematicaCofecyt.SelectedValue != "-1"
                //&& ddlUvt.SelectedValue != "-1"
                    txtTituloCofecyt.Text != ""
                    )
            {
                ActualizarProyectoCofecyt();

                Response.Redirect("EditarProyectoCofecyt.aspx");
            }
            else
            {
                // Mostrar aviso de completar todos los datos
            }
        }
        public void ActualizarProyectoCofecyt()
        {
            ProyectoCofecyt proyectoCofecyt = new ProyectoCofecyt();

            proyectoCofecyt.IdProyectoCofecyt = idProyectoCofecytActual;
            proyectoCofecyt.IdConvocatoria = idConvocatoriaSeleccionada;

            proyectoCofecyt.Titulo = txtTituloCofecyt.Text;
            proyectoCofecyt.Objetivos = txtObjetivosCofecyt.Text;
            proyectoCofecyt.Descripcion = txtDescripcionCofecyt.Text;
            proyectoCofecyt.Destinatarios = txtDestinatariosCofecyt.Text;

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

            proyectoCofecyt.NumeroEspedienteCopade = txtNumeroExpedienteCopadeCofecyt.Text;
            proyectoCofecyt.NumeroConvenio = txtNumeroConvenio.Text;
            proyectoCofecyt.NumeroExpedienteDga = txtNumeroExpedienteDga.Text;


            if (txtFechaPresentacion.Text == "") { proyectoCofecyt.FechaPresentacion = null; }
            else { proyectoCofecyt.FechaPresentacion = DateTime.ParseExact(txtFechaPresentacion.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture); }

            if (txtFechaFinalizacion.Text == "") { proyectoCofecyt.FechaFinalizacion = null; }
            else { proyectoCofecyt.FechaFinalizacion = DateTime.ParseExact(txtFechaFinalizacion.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture); };

            if (txtUltimaEvaluacionTecnica.Text == "") { proyectoCofecyt.UltimaEvaluacionTecnica = null; }
            else { proyectoCofecyt.UltimaEvaluacionTecnica = DateTime.ParseExact(txtUltimaEvaluacionTecnica.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture); };

            if (txtDuracionEstimada.Text == "") { proyectoCofecyt.DuracionEstimada = null; }
            else { proyectoCofecyt.DuracionEstimada = Int32.Parse(txtDuracionEstimada.Text); }

            if (txtDuracionEstimadaIfaa.Text == "") { proyectoCofecyt.DuracionEstimadaIfaa = null; }
            else { proyectoCofecyt.DuracionEstimadaIfaa = Int32.Parse(txtDuracionEstimadaIfaa.Text); }

            proyectoCofecyt.Beneficiarios = txtBeneficiarios.Text;
            proyectoCofecyt.EntidadesIntervinientes = txtEntidadesIntervinientes.Text;

            proyectoCofecyt.Observaciones = txtObservacionesCofecyt.Text;

            //proyectoCofecyt.IdConvocatoria = Convert.ToInt32(ddlConvocatoriaChoice.SelectedValue);

            if (txtMontoSolicitadoCofecyt.Text == "") { proyectoCofecyt.MontoSolicitadoCofecyt = null; }
            else { proyectoCofecyt.MontoSolicitadoCofecyt = Convert.ToDecimal(txtMontoSolicitadoCofecyt.Text); }

            if (txtMontoContraparteCofecyt.Text == "") { proyectoCofecyt.MontoContraparteCofecyt = null; }
            else { proyectoCofecyt.MontoContraparteCofecyt = Convert.ToDecimal(txtMontoContraparteCofecyt.Text); }

            if (txtMontoTotalCofecyt.Text == "") { proyectoCofecyt.MontoTotalCofecyt = null; }
            else { proyectoCofecyt.MontoTotalCofecyt = Convert.ToDecimal(txtMontoTotalCofecyt.Text); }

            if (txtMontoTotalDgaCofecyt.Text == "") { proyectoCofecyt.MontoTotalDgaCofecyt = null; }
            else { proyectoCofecyt.MontoTotalDgaCofecyt = Convert.ToDecimal(txtMontoTotalDgaCofecyt.Text); }

            if (txtMontoDevolucionCofecyt.Text == "") { proyectoCofecyt.MontoDevolucionCofecyt = null; }
            else { proyectoCofecyt.MontoDevolucionCofecyt = Convert.ToDecimal(txtMontoDevolucionCofecyt.Text); }

            if (txtMontoRescindidoCofecyt.Text == "") { proyectoCofecyt.MontoRescindidoCofecyt = null; }
            else { proyectoCofecyt.MontoRescindidoCofecyt = Convert.ToDecimal(txtMontoRescindidoCofecyt.Text); }

            //Actualizo el proyecto cofecyt
            proyectoCofecytNego.ActualizarProyectoCofecyt(proyectoCofecyt);
        }
        private void LimpiarFormularioCofecyt()
        {
            txtTituloCofecyt.Text = null;
            txtObjetivosCofecyt.Text = null;
            txtDescripcionCofecyt.Text = null;
            txtDestinatariosCofecyt.Text = null;
            ddlLocalidadCofecyt.SelectedIndex = 0;
            ddlSectorCofecyt.SelectedIndex = 0;
            ddlTematicaCofecyt.SelectedIndex = 0;
            txtNumeroExpedienteCopadeCofecyt.Text = null;
            txtNumeroConvenio.Text = null;
            txtNumeroExpedienteDga.Text = null;
            ddlUvt.SelectedIndex = 0;
            ddlDirector.SelectedIndex = 0;
            txtFechaPresentacion.Text = null;
            txtFechaFinalizacion.Text = null;
            txtUltimaEvaluacionTecnica.Text = null;
            txtDuracionEstimada.Text = null;
            txtDuracionEstimadaIfaa.Text = null;
            txtBeneficiarios.Text = null;
            txtEntidadesIntervinientes.Text = null;
            //ddlEstadoCofecyt.Text = tipoEstadoCofecytNego.TraerTipoEstadoCofecyt(Convert.ToInt32(proyectoCofecyt.IdTipoEstadoCofecyt));
            ddlEstadoCofecyt.SelectedIndex = 0;
            ddlContactoBeneficiario.SelectedIndex = 0;
            txtObservacionesCofecyt.Text = null; ;
            txtMontoSolicitadoCofecyt.Text = null;
            txtMontoContraparteCofecyt.Text = null;
            txtMontoTotalCofecyt.Text = null;
            txtMontoTotalDgaCofecyt.Text = null;
            txtMontoDevolucionCofecyt.Text = null;
            txtMontoRescindidoCofecyt.Text = null;
        }

        protected void ddlProyectoChoice_SelectedIndexChanged(object sender, EventArgs e)
        {
            idProyectoCofecytActual = Convert.ToInt32(ddlProyectoChoice.SelectedValue.ToString());

            ProyectoCofecyt proyectoCofecyt = proyectoCofecytNego.ObtenerProyectoCofecyt(idProyectoCofecytActual);

            if (proyectoCofecyt == null)
            {
                LimpiarFormularioCofecyt();
                return;
            }
            else
            {
                txtTituloCofecyt.Text = proyectoCofecyt.Titulo;
                txtObjetivosCofecyt.Text = proyectoCofecyt.Objetivos;
                txtDescripcionCofecyt.Text = proyectoCofecyt.Descripcion;
                txtDestinatariosCofecyt.Text = proyectoCofecyt.Destinatarios;

                if (proyectoCofecyt.IdLocalidad == null) { ddlLocalidadCofecyt.Text = "-1"; }
                else { ddlLocalidadCofecyt.Text = localidadNego.TraerLocalidad(Convert.ToInt32(proyectoCofecyt.IdLocalidad)); }

                if (proyectoCofecyt.IdSector == null) { ddlSectorCofecyt.Text = "-1"; }
                else { ddlSectorCofecyt.Text = sectorNego.TraerSector(Convert.ToInt32(proyectoCofecyt.IdSector)); }

                if (proyectoCofecyt.IdTematica == null) { ddlTematicaCofecyt.Text = "-1"; }
                else { ddlTematicaCofecyt.Text = tematicaNego.TraerTematica(Convert.ToInt32(proyectoCofecyt.IdTematica)); }

                txtNumeroExpedienteCopadeCofecyt.Text = proyectoCofecyt.NumeroEspedienteCopade;
                txtNumeroConvenio.Text = proyectoCofecyt.NumeroConvenio;
                txtNumeroExpedienteDga.Text = proyectoCofecyt.NumeroExpedienteDga;

                if (proyectoCofecyt.IdUdtUvt == null) { ddlUvt.Text = "-1"; }
                else { ddlUvt.Text = udtUvtNego.TraerUdtUvt(Convert.ToInt32(proyectoCofecyt.IdUdtUvt)); }

                if (proyectoCofecyt.IdDirector == null) { ddlDirector.Text = "-1"; }
                else { ddlDirector.Text = personaNego.TraerPersona(Convert.ToInt32(proyectoCofecyt.IdDirector)); }



                if (proyectoCofecyt.FechaPresentacion == null) { txtFechaPresentacion.Text = ""; }
                else { txtFechaPresentacion.Text = Convert.ToDateTime(proyectoCofecyt.FechaPresentacion).ToShortDateString(); };

                if (proyectoCofecyt.FechaFinalizacion == null) { txtFechaFinalizacion.Text = ""; }
                else { txtFechaFinalizacion.Text = Convert.ToDateTime(proyectoCofecyt.FechaFinalizacion).ToShortDateString(); };

                if (proyectoCofecyt.UltimaEvaluacionTecnica == null) { txtUltimaEvaluacionTecnica.Text = ""; }
                else { txtUltimaEvaluacionTecnica.Text = Convert.ToDateTime(proyectoCofecyt.UltimaEvaluacionTecnica).ToShortDateString(); };

                txtDuracionEstimada.Text = Convert.ToString(proyectoCofecyt.DuracionEstimada);
                txtDuracionEstimadaIfaa.Text = Convert.ToString(proyectoCofecyt.DuracionEstimadaIfaa);
                txtBeneficiarios.Text = proyectoCofecyt.Beneficiarios;
                txtEntidadesIntervinientes.Text = proyectoCofecyt.EntidadesIntervinientes;
                //ddlEstadoCofecyt.Text = tipoEstadoCofecytNego.TraerTipoEstadoCofecyt(Convert.ToInt32(proyectoCofecyt.IdTipoEstadoCofecyt));

                if (proyectoCofecyt.IdTipoEstadoCofecyt == null) { ddlEstadoCofecyt.Text = "-1"; }
                else { ddlEstadoCofecyt.Text = Convert.ToString(proyectoCofecyt.IdTipoEstadoCofecyt); }

                if (proyectoCofecyt.IdContactoBeneficiario == null) { ddlContactoBeneficiario.Text = "-1"; }
                else { ddlContactoBeneficiario.Text = personaNego.TraerPersona(Convert.ToInt32(proyectoCofecyt.IdContactoBeneficiario)); }

                txtObservacionesCofecyt.Text = proyectoCofecyt.Observaciones;
                txtMontoSolicitadoCofecyt.Text = Convert.ToString(proyectoCofecyt.MontoSolicitadoCofecyt);
                txtMontoContraparteCofecyt.Text = Convert.ToString(proyectoCofecyt.MontoContraparteCofecyt);
                txtMontoTotalCofecyt.Text = Convert.ToString(proyectoCofecyt.MontoTotalCofecyt);
                txtMontoTotalDgaCofecyt.Text = Convert.ToString(proyectoCofecyt.MontoTotalDgaCofecyt);
                txtMontoDevolucionCofecyt.Text = Convert.ToString(proyectoCofecyt.MontoDevolucionCofecyt);
                txtMontoRescindidoCofecyt.Text = Convert.ToString(proyectoCofecyt.MontoRescindidoCofecyt);
            }
        }
        protected void btnModalLocalidadGuardar_Click(object sender, EventArgs e)
        {
            Localidad localidad = new Localidad();

            localidad.Nombre = txtNombreCofecyt.Text;
            localidad.CodigoPostal = txtCodigoPostalCofecyt.Text;

            idLocalidadActual = localidadNego.GuardarLocalidad(localidad);

            ddlLocalidadCofecyt.Items.Clear();
            ddlLocalidadCofecyt.Text = TraerLocalidad(idLocalidadActual);
            LlenarListaLocalidadesCofecyt();
        }
        private string TraerLocalidad(int id)
        {
            return localidadNego.TraerLocalidad(id);
        }
    }
}