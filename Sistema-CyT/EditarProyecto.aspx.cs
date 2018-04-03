using System;
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
    public partial class EditarProyecto : System.Web.UI.Page
    {
        LocalidadNego localidadNego = new LocalidadNego();
        PersonaNego personaNego = new PersonaNego();
        EmpresaNego empresaNego = new EmpresaNego();
        FondoNego fondoNego = new FondoNego();
        ConvocatoriaNego convocatoriaNego = new ConvocatoriaNego();
        EtapaNego etapaNego = new EtapaNego();
        ProyectoNego proyectoNego = new ProyectoNego();
        TipoEstadoNego tipoEstadoNego = new TipoEstadoNego();
        TipoEstadoEtapaNego tipoEstadoEtapaNego = new TipoEstadoEtapaNego();
        TipoProyectoNego tipoProyectoNego = new TipoProyectoNego();
        TematicaNego tematicaNego = new TematicaNego();
        SectorNego sectorNego = new SectorNego();

        ProyectoCofecytNego proyectoCofecytNego = new ProyectoCofecytNego();
        EtapaCofecytNego etapaCofecytNego = new EtapaCofecytNego();
        ActividadCofecytNego actividadCofecytNego = new ActividadCofecytNego();
        UdtUvtNego udtUvtNego = new UdtUvtNego();
        TipoEstadoCofecytNego tipoEstadoCofecytNego = new TipoEstadoCofecytNego();

        public static List<Etapa> listaTemporalEtapas = new List<Etapa>();
        public static List<Etapa> listaTemporalEtapasAgregado = new List<Etapa>();
        List<pr02ResultSet0> listaProyectosFiltrados = new List<pr02ResultSet0>();

        static List<EtapaCofecyt> listaEtapaCofecytsTemporal = new List<EtapaCofecyt>();
        static List<ActividadCofecyt> listaActividadCofecytsTemporal = new List<ActividadCofecyt>();
        static List<EtapaCofecyt> listaEtapaCofecytsTemporalAgregado = new List<EtapaCofecyt>();
        static List<ActividadCofecyt> listaActividadCofecytsTemporalAgregado = new List<ActividadCofecyt>();
        List<pr03ResultSet0> listaProyectoCofecytsFiltrados = new List<pr03ResultSet0>();



        public static int idProyectoActual;
        public static int idEtapaActual;
        public static int idEmpresaActual = 0;
        public static int idLocalidadActual = 0;
        public static int idPersonaActual = 0;
        public static int idConvocatoriaSeleccionada = 1;
        public static int idFondoSeleccionado = 1;

        public static int idProyectoCofecytActual;
        public static int idEtapaCofecytActual;
        public static int idActividadCofecytActual;

        static int idEtapaCofecytUltima;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack) return;

            PanelInformacion.Visible = false;
            PanelCofecytInformacion.Visible = false;
            PanelMostrarEtapas.Visible = false;
            PanelCofecytFinanciamiento.Visible = false;
            PanelMostrarEtapasCofecyt.Visible = false;



            MostrarLocalidad(); //SIRVE PARA EL DROP DOWN LIST
            MostrarPersona(); //SIRVE PARA EL DROP DOWN LIST
            MostrarEmpresa(); // SIRVE PARA EL DROP DOWN LIST
            MostrarConvocatoria(); // SIRVE PARA EL DROP DOWN LIST
            LlenarListaTipoEstados(); // SIRVE PARA EL DROP DOWN LIST
            LlenarListaTipoEstadoEtapas(); // SIRVE PARA EL DROP DOWN LIST
            LimpiarFormulario();
            LlenarListaFondoChoice();
            LlenarListaTipoProyectos(); // SIRVE PARA EL DROP DOWN LIST

            LlenarListaSectores();
            LlenarListaTematicas();


            LlenarListaTipoEstadoEtapasCofecyt(); // SIRVE PARA EL DROP DOWN LIST
            LlenarListaLocalidadesCofecyt();
            LlenarListaSectoresCofecyt();
            LlenarListaTematicasCofecyt();
            LlenarListaUdtUvts();
            LlenarListaDirectores();
            LlenarListaContactoBeneficiarios();
            LlenarListaTipoEstadoCofecyt();




        }
        private void LlenarListaTipoEstadoCofecyt()
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

        private void LlenarListaTipoEstadoEtapasCofecyt()
        {
            ddlTipoEstadoEtapaCofecyt.DataSource = tipoEstadoEtapaNego.MostrarTipoEstadoEtapas().ToList();
            ddlTipoEstadoEtapaCofecyt.DataValueField = "nombre";
            ddlTipoEstadoEtapaCofecyt.DataValueField = "idTipoEstadoEtapa";
            ddlTipoEstadoEtapaCofecyt.DataBind();
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
        private void LlenarListaTipoProyectos()
        {
            ddlTipoProyecto.DataSource = tipoProyectoNego.MostrarTipoProyectos().ToList();
            ddlTipoProyecto.DataValueField = "nombre";
            ddlTipoProyecto.DataBind();
        }
        private void LlenarListaFondoChoice()
        {
            ddlFondoChoice.DataSource = fondoNego.MostrarFondos().ToList();
            ddlFondoChoice.DataValueField = "idFondo";
            ddlFondoChoice.DataBind();
        }

        //Muestra en el DROPDOWNLIST los Tipos de Estado de la Etapa
        private void LlenarListaTipoEstadoEtapas()
        {
            ddlTipoEstadoEtapa.DataSource = tipoEstadoEtapaNego.MostrarTipoEstadoEtapas().ToList();
            ddlTipoEstadoEtapa.DataValueField = "nombre";
            ddlTipoEstadoEtapa.DataValueField = "idTipoEstadoEtapa";
            ddlTipoEstadoEtapa.DataBind();
        }
        //Muestra en el DROPDOWNLIST los Tipos de Estado
        private void LlenarListaTipoEstados()
        {
            ddlTipoEstado.DataSource = tipoEstadoNego.MostrarTipoEstados().ToList();
            ddlTipoEstado.DataValueField = "nombre";
            ddlTipoEstado.DataBind();
        }

        //Muestra en el DROPDOWNLIST las CONVOCATORIAS
        private void MostrarConvocatoria()
        {
            ddlConvocatoria.DataSource = convocatoriaNego.MostrarConvocatorias().OrderBy(c => c.Nombre).ToList();
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
            ddlEmpresa.DataSource = empresaNego.MostrarEmpresas().OrderBy(c => c.Nombre).ToList();
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




        //PRIMERO ELIJO EL FONDO
        protected void ddlFondoChoice_SelectedIndexChanged(object sender, EventArgs e)
        {
            LimpiarFormulario();
            LimpiarFormularioCofecyt();

            if (ddlFondoChoice.SelectedValue != "-1")
            {
                idFondoSeleccionado = Convert.ToInt32(ddlFondoChoice.SelectedValue);

                LlenarChoiceConvocatorias(idFondoSeleccionado);

                if (fondoNego.ObtenerFondo(Convert.ToInt32(ddlFondoChoice.SelectedValue)).Nombre.ToUpper() == "COFECYT")
                {
                    PanelInformacion.Visible = false;
                    PanelCofecytInformacion.Visible = true;
                    PanelMostrarEtapas.Visible = false;
                    PanelCofecytFinanciamiento.Visible = true;
                    PanelMostrarEtapasCofecyt.Visible = true;
                }
                else
                {
                    PanelInformacion.Visible = true;
                    PanelCofecytInformacion.Visible = false;
                    PanelMostrarEtapas.Visible = true;
                    PanelCofecytFinanciamiento.Visible = false;
                    PanelMostrarEtapasCofecyt.Visible = false;
                }
            }
            else
            {
                Response.Redirect("EditarProyecto.aspx");
            }
        }

        private void LlenarChoiceConvocatorias(int id)
        {
            ddlConvocatoriaChoice.DataSource = convocatoriaNego.ListarChoiceConvocatorias(id);
            ddlConvocatoriaChoice.DataTextField = "nombre";
            ddlConvocatoriaChoice.DataValueField = "idConvocatoria";
            ddlConvocatoriaChoice.DataBind();

            if (ddlConvocatoriaChoice.SelectedValue != "")
            {
                idConvocatoriaSeleccionada = Convert.ToInt32(ddlConvocatoriaChoice.SelectedValue);

                //RUTINAS PARA COFECYT
                if (fondoNego.ObtenerFondo(Convert.ToInt32(ddlFondoChoice.SelectedValue)).Nombre.ToUpper() == "COFECYT")
                {
                    //la puse recien
                    Response.Redirect("EditarProyectoCofecyt.aspx");


                    ddlProyectoChoice.DataSource = proyectoCofecytNego.ListarChoiceProyectoCofecyts(idConvocatoriaSeleccionada);
                    ddlProyectoChoice.DataTextField = "titulo";
                    ddlProyectoChoice.DataValueField = "idProyectoCofecyt";
                    ddlProyectoChoice.DataBind();

                    //listaProyectoCofecytsFiltrados = proyectoCofecytNego.ListarChoiceProyectoCofecyts(idConvocatoriaSeleccionada).ToList();

                    //aca habria que cargar el 1er proyecto filtrado automaticamente
                    listaEtapaCofecytsTemporal.Clear();
                    listaEtapaCofecytsTemporalAgregado.Clear();
                    listaActividadCofecytsTemporal.Clear();
                    listaActividadCofecytsTemporalAgregado.Clear();

                    dgvEtapasCofecyt.DataSource = listaEtapaCofecytsTemporal;
                    dgvEtapasCofecyt.DataBind();
                    dgvActividadesCofecyt.DataSource = listaActividadCofecytsTemporal;
                    dgvActividadesCofecyt.DataBind();

                    //1ro hay que averiguar si existe al menos 1 proyecto o la lista viene vacia
                    if (ddlProyectoChoice.SelectedValue != "")
                    {
                        idProyectoCofecytActual = Convert.ToInt32(ddlProyectoChoice.SelectedValue);

                        ProyectoCofecyt proyectoCofecyt = proyectoCofecytNego.ObtenerProyectoCofecyt(idProyectoCofecytActual);

                        if (proyectoCofecyt == null)
                        {
                            LimpiarFormularioCofecyt();
                            //return;
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


                            ////****INICIO RUTINA PARA TRABAJAR CON FORMATO FECHA
                            ////FECHA PRESENTACION
                            //string dia = Convert.ToString((proyectoCofecyt.FechaPresentacion).Value.Day);
                            //string mes = Convert.ToString((proyectoCofecyt.FechaPresentacion).Value.Month);
                            //string anio = Convert.ToString((proyectoCofecyt.FechaPresentacion).Value.Year);
                            //string t1 = "";
                            //string t2 = "";
                            //if ((proyectoCofecyt.FechaPresentacion).Value.Day < 10)
                            //{
                            //    t1 = "0";
                            //}
                            //if ((proyectoCofecyt.FechaPresentacion).Value.Month < 10)
                            //{
                            //    t2 = "0";
                            //}
                            //txtFechaPresentacion.Text = t2 + mes + "/" + t1 + dia + "/" + anio;

                            ////FECHA FINALIZACION
                            //dia = Convert.ToString((proyectoCofecyt.FechaFinalizacion).Value.Day);
                            //mes = Convert.ToString((proyectoCofecyt.FechaFinalizacion).Value.Month);
                            //anio = Convert.ToString((proyectoCofecyt.FechaFinalizacion).Value.Year);
                            //t1 = "";
                            //t2 = "";
                            //if ((proyectoCofecyt.FechaFinalizacion).Value.Day < 10)
                            //{
                            //    t1 = "0";
                            //}
                            //if ((proyectoCofecyt.FechaFinalizacion).Value.Month < 10)
                            //{
                            //    t2 = "0";
                            //}
                            //txtFechaFinalizacion.Text = t2 + mes + "/" + t1 + dia + "/" + anio;

                            ////FECHA ULTIMA EVALUACION TECNICA
                            //dia = Convert.ToString((proyectoCofecyt.UltimaEvaluacionTecnica).Value.Day);
                            //mes = Convert.ToString((proyectoCofecyt.UltimaEvaluacionTecnica).Value.Month);
                            //anio = Convert.ToString((proyectoCofecyt.UltimaEvaluacionTecnica).Value.Year);
                            //t1 = "";
                            //t2 = "";
                            //if ((proyectoCofecyt.UltimaEvaluacionTecnica).Value.Day < 10)
                            //{
                            //    t1 = "0";
                            //}
                            //if ((proyectoCofecyt.UltimaEvaluacionTecnica).Value.Month < 10)
                            //{
                            //    t2 = "0";
                            //}
                            //txtUltimaEvaluacionTecnica.Text = t2 + mes + "/" + t1 + dia + "/" + anio;

                            ////****FIN RUTINA FORMATO DE FECHA

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

                            //AHORA TENGO QUE TRAER UNA LISTA DE ETAPAS SEGUN EL IdProyectoActual
                            listaEtapaCofecytsTemporal = (List<EtapaCofecyt>)etapaCofecytNego.TraerEtapaCofecytsSegunIdProyecto(idProyectoCofecytActual).ToList();

                            dgvEtapasCofecyt.DataSource = listaEtapaCofecytsTemporal;
                            dgvEtapasCofecyt.DataBind();

                            listaActividadCofecytsTemporal = (List<ActividadCofecyt>)actividadCofecytNego.TraerActividadCofecytsSegunIdProyecto(idProyectoCofecytActual).ToList();

                            dgvActividadesCofecyt.DataSource = listaActividadCofecytsTemporal;
                            dgvActividadesCofecyt.DataBind();

                            LlenarListaEtapasActividad();
                        }
                    }
                    else
                    {
                        txtFiltroProyecto.Text = "SIN PROYECTOS";
                    }
                }
                else
                {
                    ddlProyectoChoice.DataSource = proyectoNego.ListarChoiceProyectos(idConvocatoriaSeleccionada).ToList();
                    ddlProyectoChoice.DataTextField = "nombre";
                    ddlProyectoChoice.DataValueField = "idProyecto";
                    ddlProyectoChoice.DataBind();

                    //aca habria que cargar el 1er proyecto filtrado automaticamente
                    listaTemporalEtapas.Clear();
                    listaTemporalEtapasAgregado.Clear();

                    //1ro hay que averiguar si existe al menos 1 proyecto o la lista viene vacia
                    if (ddlProyectoChoice.SelectedValue != "")
                    {
                        idProyectoActual = Convert.ToInt32(ddlProyectoChoice.SelectedValue);

                        Proyecto proyecto = proyectoNego.ObtenerProyecto(idProyectoActual);

                        if (proyecto == null)
                        {
                            LimpiarFormulario(); return;
                        }

                        txtNombre.Text = proyecto.Nombre.ToString();
                        txtNumeroExp.Text = proyecto.NumeroExpediente.ToString();

                        txtDestinatarios.Text = proyecto.Destinatarios;
                        txtObjetivos.Text = proyecto.Objetivos;

                        ddlConvocatoria.Text = Convert.ToString(proyecto.IdConvocatoria);
                        txtMontoSolicitado.Text = Convert.ToString(proyecto.MontoSolicitado);
                        txtMontoContraparte.Text = Convert.ToString(proyecto.MontoContraparte);
                        txtMontoTotal.Text = Convert.ToString(proyecto.MontoTotal);
                        txtDescripcion.Text = proyecto.Descripcion.ToString();
                        txtObservaciones.Text = proyecto.Observaciones.ToString();

                        //ddlContacto.Text = personaNego.TraerPersona(proyecto.IdPersona.Value);

                        if (proyecto.IdEmpresa == null) { ddlEmpresa.Text = "-1"; }
                        else { ddlEmpresa.Text = empresaNego.TraerEmpresa(proyecto.IdEmpresa.Value); }

                        if (proyecto.IdSector == null) { ddlSector.Text = "-1"; }
                        else { ddlSector.Text = sectorNego.TraerSector(proyecto.IdSector.Value); }

                        if (proyecto.IdTematica == null) { ddlTematica.Text = "-1"; }
                        else { ddlTematica.Text = tematicaNego.TraerTematica(proyecto.IdTematica.Value); }

                        if (proyecto.IdPersona == null) { ddlContacto.Text = "-1"; }
                        else { ddlContacto.Text = personaNego.TraerPersona(proyecto.IdPersona.Value); }

                        if (proyecto.IdLocalidad == null) { ddlLocalidad.Text = "-1"; }
                        else { ddlLocalidad.Text = localidadNego.TraerLocalidad(proyecto.IdLocalidad.Value); }

                        if (proyecto.IdTipoEstado == null) { ddlTipoEstado.Text = "-1"; }
                        else { ddlTipoEstado.Text = tipoEstadoNego.TraerTipoEstado(proyecto.IdTipoEstado.Value); }

                        if (proyecto.IdTipoProyecto == null) { ddlTipoProyecto.Text = "-1"; }
                        else { ddlTipoProyecto.Text = tipoProyectoNego.TraerTipoProyecto(proyecto.IdTipoProyecto.Value); }

                        //ddlLocalidad.Text = localidadNego.TraerLocalidad(proyecto.IdLocalidad.Value);
                        //ddlTipoEstado.Text = tipoEstadoNego.TraerTipoEstado(proyecto.IdTipoEstado.Value);
                        //ddlTipoProyecto.Text = tipoProyectoNego.TraerTipoProyecto(proyecto.IdTipoProyecto.Value);

                        //AHORA TENGO QUE TRAER UNA LISTA DE ETAPAS SEGUN EL IdProyectoActual
                        listaTemporalEtapas = (List<Etapa>)etapaNego.TraerEtapasSegunIdProyecto(idProyectoActual).ToList();

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

                        LlenarGrillaEtapas(); //no borrar esta linea!!!

                        //fin rutina para cargar el 1er proyecto
                    }
                    else
                    {
                        LimpiarFormulario();
                        LimpiarFormularioCofecyt();
                    }
                }
            }
            else
            {
                if (fondoNego.ObtenerFondo(Convert.ToInt32(ddlFondoChoice.SelectedValue)).Nombre.ToUpper() == "COFECYT")
                {
                    ddlProyectoChoice.DataSource = listaProyectoCofecytsFiltrados.ToList();
                    ddlProyectoChoice.DataBind();
                }
                else
                {
                    ddlProyectoChoice.DataSource = listaProyectosFiltrados.ToList();
                    ddlProyectoChoice.DataBind();
                }




                ddlProyectoChoice.DataSource = listaProyectosFiltrados.ToList();
                // REVISAR: aca tambien iria la lista de proyectos COFECYT
                ddlProyectoChoice.DataBind();
            }
        }

        protected void ddlConvocatoriaChoice_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Limpio la grilla de etapas y actividades TODAS
            listaTemporalEtapas.Clear();
            listaTemporalEtapasAgregado.Clear();
            listaEtapaCofecytsTemporal.Clear();
            listaEtapaCofecytsTemporalAgregado.Clear();
            listaActividadCofecytsTemporal.Clear();
            listaActividadCofecytsTemporalAgregado.Clear();

            dgvEtapas.DataSource = listaTemporalEtapas;
            dgvEtapas.DataBind();
            dgvEtapasCofecyt.DataSource = listaEtapaCofecytsTemporal;
            dgvEtapasCofecyt.DataBind();
            dgvActividadesCofecyt.DataSource = listaActividadCofecytsTemporal;
            dgvActividadesCofecyt.DataBind();

            LimpiarFormulario();
            LimpiarFormularioCofecyt();


            idConvocatoriaSeleccionada = Convert.ToInt32(ddlConvocatoriaChoice.SelectedValue.ToString());

            if (fondoNego.ObtenerFondo(Convert.ToInt32(ddlFondoChoice.SelectedValue)).Nombre.ToUpper() == "COFECYT")
            {
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


                        //****INICIO RUTINA PARA TRABAJAR CON FORMATO FECHA
                        //FECHA PRESENTACION
                        //string dia = Convert.ToString((proyectoCofecyt.FechaPresentacion).Value.Day);
                        //string mes = Convert.ToString((proyectoCofecyt.FechaPresentacion).Value.Month);
                        //string anio = Convert.ToString((proyectoCofecyt.FechaPresentacion).Value.Year);
                        //string t1 = "";
                        //string t2 = "";
                        //if ((proyectoCofecyt.FechaPresentacion).Value.Day < 10)
                        //{
                        //    t1 = "0";
                        //}
                        //if ((proyectoCofecyt.FechaPresentacion).Value.Month < 10)
                        //{
                        //    t2 = "0";
                        //}
                        //txtFechaPresentacion.Text = t2 + mes + "/" + t1 + dia + "/" + anio;

                        //FECHA FINALIZACION
                        //dia = Convert.ToString((proyectoCofecyt.FechaFinalizacion).Value.Day);
                        //mes = Convert.ToString((proyectoCofecyt.FechaFinalizacion).Value.Month);
                        //anio = Convert.ToString((proyectoCofecyt.FechaFinalizacion).Value.Year);
                        //t1 = "";
                        //t2 = "";
                        //if ((proyectoCofecyt.FechaFinalizacion).Value.Day < 10)
                        //{
                        //    t1 = "0";
                        //}
                        //if ((proyectoCofecyt.FechaFinalizacion).Value.Month < 10)
                        //{
                        //    t2 = "0";
                        //}
                        //txtFechaFinalizacion.Text = t2 + mes + "/" + t1 + dia + "/" + anio;

                        //FECHA ULTIMA EVALUACION TECNICA
                        //dia = Convert.ToString((proyectoCofecyt.UltimaEvaluacionTecnica).Value.Day);
                        //mes = Convert.ToString((proyectoCofecyt.UltimaEvaluacionTecnica).Value.Month);
                        //anio = Convert.ToString((proyectoCofecyt.UltimaEvaluacionTecnica).Value.Year);
                        //t1 = "";
                        //t2 = "";
                        //if ((proyectoCofecyt.UltimaEvaluacionTecnica).Value.Day < 10)
                        //{
                        //    t1 = "0";
                        //}
                        //if ((proyectoCofecyt.UltimaEvaluacionTecnica).Value.Month < 10)
                        //{
                        //    t2 = "0";
                        //}
                        //txtUltimaEvaluacionTecnica.Text = t2 + mes + "/" + t1 + dia + "/" + anio;

                        //****FIN RUTINA FORMATO DE FECHA


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


                        //txtTituloCofecyt.Text = proyectoCofecyt.Titulo;
                        //txtObjetivosCofecyt.Text = proyectoCofecyt.Objetivos;
                        //txtDescripcionCofecyt.Text = proyectoCofecyt.Descripcion;
                        //txtDestinatariosCofecyt.Text = proyectoCofecyt.Destinatarios;
                        //ddlLocalidadCofecyt.Text = localidadNego.TraerLocalidad(Convert.ToInt32(proyectoCofecyt.IdLocalidad));
                        //ddlSectorCofecyt.Text = sectorNego.TraerSector(Convert.ToInt32(proyectoCofecyt.IdSector));
                        //ddlTematicaCofecyt.Text = tematicaNego.TraerTematica(Convert.ToInt32(proyectoCofecyt.IdTematica));
                        //txtNumeroExpedienteCopadeCofecyt.Text = proyectoCofecyt.NumeroEspedienteCopade;
                        //txtNumeroConvenio.Text = proyectoCofecyt.NumeroConvenio;
                        //txtNumeroExpedienteDga.Text = proyectoCofecyt.NumeroExpedienteDga;
                        //ddlUvt.Text = udtUvtNego.TraerUdtUvt(Convert.ToInt32(proyectoCofecyt.IdUdtUvt));
                        //ddlDirector.Text = personaNego.TraerPersona(Convert.ToInt32(proyectoCofecyt.IdDirector));

                        ////****INICIO RUTINA PARA TRABAJAR CON FORMATO FECHA
                        ////FECHA PRESENTACION
                        //string dia = Convert.ToString((proyectoCofecyt.FechaPresentacion).Value.Day);
                        //string mes = Convert.ToString((proyectoCofecyt.FechaPresentacion).Value.Month);
                        //string anio = Convert.ToString((proyectoCofecyt.FechaPresentacion).Value.Year);
                        //string t1 = "";
                        //string t2 = "";
                        //if ((proyectoCofecyt.FechaPresentacion).Value.Day < 10)
                        //{
                        //    t1 = "0";
                        //}
                        //if ((proyectoCofecyt.FechaPresentacion).Value.Month < 10)
                        //{
                        //    t2 = "0";
                        //}
                        //txtFechaPresentacion.Text = t2 + mes + "/" + t1 + dia + "/" + anio;

                        ////FECHA FINALIZACION
                        //dia = Convert.ToString((proyectoCofecyt.FechaFinalizacion).Value.Day);
                        //mes = Convert.ToString((proyectoCofecyt.FechaFinalizacion).Value.Month);
                        //anio = Convert.ToString((proyectoCofecyt.FechaFinalizacion).Value.Year);
                        //t1 = "";
                        //t2 = "";
                        //if ((proyectoCofecyt.FechaFinalizacion).Value.Day < 10)
                        //{
                        //    t1 = "0";
                        //}
                        //if ((proyectoCofecyt.FechaFinalizacion).Value.Month < 10)
                        //{
                        //    t2 = "0";
                        //}
                        //txtFechaFinalizacion.Text = t2 + mes + "/" + t1 + dia + "/" + anio;

                        ////FECHA ULTIMA EVALUACION TECNICA
                        //dia = Convert.ToString((proyectoCofecyt.UltimaEvaluacionTecnica).Value.Day);
                        //mes = Convert.ToString((proyectoCofecyt.UltimaEvaluacionTecnica).Value.Month);
                        //anio = Convert.ToString((proyectoCofecyt.UltimaEvaluacionTecnica).Value.Year);
                        //t1 = "";
                        //t2 = "";
                        //if ((proyectoCofecyt.UltimaEvaluacionTecnica).Value.Day < 10)
                        //{
                        //    t1 = "0";
                        //}
                        //if ((proyectoCofecyt.UltimaEvaluacionTecnica).Value.Month < 10)
                        //{
                        //    t2 = "0";
                        //}
                        //txtUltimaEvaluacionTecnica.Text = t2 + mes + "/" + t1 + dia + "/" + anio;

                        ////****FIN RUTINA FORMATO DE FECHA







                        ////txtFechaPresentacion.Text = Convert.ToDateTime(proyectoCofecyt.FechaPresentacion).ToShortDateString();
                        ////txtFechaFinalizacion.Text = Convert.ToDateTime(proyectoCofecyt.FechaFinalizacion).ToShortDateString();
                        ////txtUltimaEvaluacionTecnica.Text = Convert.ToDateTime(proyectoCofecyt.UltimaEvaluacionTecnica).ToShortDateString();
                        //txtDuracionEstimada.Text = Convert.ToString(proyectoCofecyt.DuracionEstimada);
                        //txtDuracionEstimadaIfaa.Text = Convert.ToString(proyectoCofecyt.DuracionEstimadaIfaa);
                        //txtBeneficiarios.Text = proyectoCofecyt.Beneficiarios;
                        //txtEntidadesIntervinientes.Text = proyectoCofecyt.EntidadesIntervinientes;
                        ////ddlEstadoCofecyt.Text = tipoEstadoCofecytNego.TraerTipoEstadoCofecyt(Convert.ToInt32(proyectoCofecyt.IdTipoEstadoCofecyt));
                        //ddlEstadoCofecyt.Text = Convert.ToString(proyectoCofecyt.IdTipoEstadoCofecyt);
                        //ddlContactoBeneficiario.Text = personaNego.TraerPersona(Convert.ToInt32(proyectoCofecyt.IdContactoBeneficiario));
                        //txtObservacionesCofecyt.Text = proyectoCofecyt.Observaciones;
                        //txtMontoSolicitadoCofecyt.Text = Convert.ToString(proyectoCofecyt.MontoSolicitadoCofecyt);
                        //txtMontoContraparteCofecyt.Text = Convert.ToString(proyectoCofecyt.MontoContraparteCofecyt);
                        //txtMontoTotalCofecyt.Text = Convert.ToString(proyectoCofecyt.MontoTotalCofecyt);
                        //txtMontoTotalDgaCofecyt.Text = Convert.ToString(proyectoCofecyt.MontoTotalDgaCofecyt);
                        //txtMontoDevolucionCofecyt.Text = Convert.ToString(proyectoCofecyt.MontoDevolucionCofecyt);
                        //txtMontoRescindidoCofecyt.Text = Convert.ToString(proyectoCofecyt.MontoRescindidoCofecyt);

                        //AHORA TENGO QUE TRAER UNA LISTA DE ETAPAS SEGUN EL IdProyectoCofecytActual
                        //listaEtapaCofecytsTemporal = (List<EtapaCofecyt>)etapaCofecytNego.TraerEtapaCofecytsSegunIdProyecto(idProyectoActual).ToList();

                        //dgvEtapasCofecyt.DataSource = listaEtapaCofecytsTemporal;
                        //dgvEtapasCofecyt.DataBind();

                        listaEtapaCofecytsTemporal = (List<EtapaCofecyt>)etapaCofecytNego.TraerEtapaCofecytsSegunIdProyecto(idProyectoCofecytActual).ToList();

                        dgvEtapasCofecyt.DataSource = listaEtapaCofecytsTemporal;
                        dgvEtapasCofecyt.DataBind();

                        listaActividadCofecytsTemporal = (List<ActividadCofecyt>)actividadCofecytNego.TraerActividadCofecytsSegunIdProyecto(idProyectoCofecytActual).ToList();

                        dgvActividadesCofecyt.DataSource = listaActividadCofecytsTemporal;
                        dgvActividadesCofecyt.DataBind();

                        LlenarListaEtapasActividad();
                    }
                }









            }
            else
            {
                ddlProyectoChoice.DataSource = proyectoNego.ListarChoiceProyectos(idConvocatoriaSeleccionada).ToList();
                ddlProyectoChoice.DataTextField = "nombre";
                ddlProyectoChoice.DataBind();

                //aca habria que cargar el 1er proyecto
                if (ddlProyectoChoice.SelectedValue != "")
                {
                    idProyectoActual = Convert.ToInt32(ddlProyectoChoice.SelectedValue);

                    Proyecto proyecto = proyectoNego.ObtenerProyecto(idProyectoActual);

                    if (proyecto == null)
                    {
                        LimpiarFormulario();
                        return;
                    }

                    txtNombre.Text = proyecto.Nombre.ToString();
                    txtNumeroExp.Text = proyecto.NumeroExpediente.ToString();

                    txtObjetivos.Text = proyecto.Objetivos;
                    txtDestinatarios.Text = proyecto.Destinatarios;
                    //ddlSector.Text = sectorNego.TraerSector(proyecto.IdSector.Value);
                    //ddlTematica.Text = tematicaNego.TraerTematica(proyecto.IdTematica.Value);


                    ddlConvocatoria.Text = Convert.ToString(proyecto.IdConvocatoria);
                    txtMontoSolicitado.Text = Convert.ToString(proyecto.MontoSolicitado);
                    txtMontoContraparte.Text = Convert.ToString(proyecto.MontoContraparte);
                    txtMontoTotal.Text = Convert.ToString(proyecto.MontoTotal);
                    txtDescripcion.Text = proyecto.Descripcion.ToString();
                    txtObservaciones.Text = proyecto.Observaciones.ToString();

                    //ddlContacto.Text = personaNego.TraerPersona(proyecto.IdPersona.Value);

                    //if (proyecto.IdEmpresa == null)
                    //{
                    //    ddlEmpresa.Text = "-1";
                    //}
                    //else
                    //{
                    //    ddlEmpresa.Text = empresaNego.TraerEmpresa(proyecto.IdEmpresa.Value);
                    //}

                    //ddlLocalidad.Text = localidadNego.TraerLocalidad(proyecto.IdLocalidad.Value);
                    //ddlTipoEstado.Text = tipoEstadoNego.TraerTipoEstado(proyecto.IdTipoEstado.Value);
                    //ddlTipoProyecto.Text = tipoProyectoNego.TraerTipoProyecto(proyecto.IdTipoProyecto.Value);


                    if (proyecto.IdEmpresa == null) { ddlEmpresa.Text = "-1"; }
                    else { ddlEmpresa.Text = empresaNego.TraerEmpresa(proyecto.IdEmpresa.Value); }

                    if (proyecto.IdSector == null) { ddlSector.Text = "-1"; }
                    else { ddlSector.Text = sectorNego.TraerSector(proyecto.IdSector.Value); }

                    if (proyecto.IdTematica == null) { ddlTematica.Text = "-1"; }
                    else { ddlTematica.Text = tematicaNego.TraerTematica(proyecto.IdTematica.Value); }

                    if (proyecto.IdPersona == null) { ddlContacto.Text = "-1"; }
                    else { ddlContacto.Text = personaNego.TraerPersona(proyecto.IdPersona.Value); }

                    if (proyecto.IdLocalidad == null) { ddlLocalidad.Text = "-1"; }
                    else { ddlLocalidad.Text = localidadNego.TraerLocalidad(proyecto.IdLocalidad.Value); }

                    if (proyecto.IdTipoEstado == null) { ddlTipoEstado.Text = "-1"; }
                    else { ddlTipoEstado.Text = tipoEstadoNego.TraerTipoEstado(proyecto.IdTipoEstado.Value); }

                    if (proyecto.IdTipoProyecto == null) { ddlTipoProyecto.Text = "-1"; }
                    else { ddlTipoProyecto.Text = tipoProyectoNego.TraerTipoProyecto(proyecto.IdTipoProyecto.Value); }


                    //AHORA TENGO QUE TRAER UNA LISTA DE ETAPAS SEGUN EL IdProyectoActual
                    listaTemporalEtapas = (List<Etapa>)etapaNego.TraerEtapasSegunIdProyecto(idProyectoActual).ToList();

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

                    LlenarGrillaEtapas(); //no borrar esta linea!!!

                    //fin rutina para cargar el 1er proyecto
                }
                else
                {
                    LimpiarFormulario();
                    LimpiarFormularioCofecyt();
                }
            }
        }



        protected void ddlProyectoChoice_SelectedIndexChanged(object sender, EventArgs e)
        {
            listaTemporalEtapas.Clear();
            listaTemporalEtapasAgregado.Clear();

            listaEtapaCofecytsTemporal.Clear();
            listaEtapaCofecytsTemporalAgregado.Clear();
            listaActividadCofecytsTemporal.Clear();
            listaActividadCofecytsTemporalAgregado.Clear();

            if (fondoNego.ObtenerFondo(Convert.ToInt32(ddlFondoChoice.SelectedValue)).Nombre.ToUpper() == "COFECYT")
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


                    ////****INICIO RUTINA PARA TRABAJAR CON FORMATO FECHA
                    ////FECHA PRESENTACION
                    //string dia = Convert.ToString((proyectoCofecyt.FechaPresentacion).Value.Day);
                    //string mes = Convert.ToString((proyectoCofecyt.FechaPresentacion).Value.Month);
                    //string anio = Convert.ToString((proyectoCofecyt.FechaPresentacion).Value.Year);
                    //string t1 = "";
                    //string t2 = "";
                    //if ((proyectoCofecyt.FechaPresentacion).Value.Day < 10)
                    //{
                    //    t1 = "0";
                    //}
                    //if ((proyectoCofecyt.FechaPresentacion).Value.Month < 10)
                    //{
                    //    t2 = "0";
                    //}
                    //txtFechaPresentacion.Text = t2 + mes + "/" + t1 + dia + "/" + anio;

                    ////FECHA FINALIZACION
                    //dia = Convert.ToString((proyectoCofecyt.FechaFinalizacion).Value.Day);
                    //mes = Convert.ToString((proyectoCofecyt.FechaFinalizacion).Value.Month);
                    //anio = Convert.ToString((proyectoCofecyt.FechaFinalizacion).Value.Year);
                    //t1 = "";
                    //t2 = "";
                    //if ((proyectoCofecyt.FechaFinalizacion).Value.Day < 10)
                    //{
                    //    t1 = "0";
                    //}
                    //if ((proyectoCofecyt.FechaFinalizacion).Value.Month < 10)
                    //{
                    //    t2 = "0";
                    //}
                    //txtFechaFinalizacion.Text = t2 + mes + "/" + t1 + dia + "/" + anio;

                    ////FECHA ULTIMA EVALUACION TECNICA
                    //dia = Convert.ToString((proyectoCofecyt.UltimaEvaluacionTecnica).Value.Day);
                    //mes = Convert.ToString((proyectoCofecyt.UltimaEvaluacionTecnica).Value.Month);
                    //anio = Convert.ToString((proyectoCofecyt.UltimaEvaluacionTecnica).Value.Year);
                    //t1 = "";
                    //t2 = "";
                    //if ((proyectoCofecyt.UltimaEvaluacionTecnica).Value.Day < 10)
                    //{
                    //    t1 = "0";
                    //}
                    //if ((proyectoCofecyt.UltimaEvaluacionTecnica).Value.Month < 10)
                    //{
                    //    t2 = "0";
                    //}
                    //txtUltimaEvaluacionTecnica.Text = t2 + mes + "/" + t1 + dia + "/" + anio;

                    ////****FIN RUTINA FORMATO DE FECHA

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

                    //AHORA TENGO QUE TRAER UNA LISTA DE ETAPAS SEGUN EL IdProyectoActual
                    listaEtapaCofecytsTemporal = (List<EtapaCofecyt>)etapaCofecytNego.TraerEtapaCofecytsSegunIdProyecto(idProyectoCofecytActual).ToList();

                    dgvEtapasCofecyt.DataSource = listaEtapaCofecytsTemporal;
                    dgvEtapasCofecyt.DataBind();

                    listaActividadCofecytsTemporal = (List<ActividadCofecyt>)actividadCofecytNego.TraerActividadCofecytsSegunIdProyecto(idProyectoCofecytActual).ToList();

                    dgvActividadesCofecyt.DataSource = listaActividadCofecytsTemporal;
                    dgvActividadesCofecyt.DataBind();

                    LlenarListaEtapasActividad();

                    //txtTituloCofecyt.Text = proyectoCofecyt.Titulo;
                    //txtObjetivosCofecyt.Text = proyectoCofecyt.Objetivos;
                    //txtDescripcionCofecyt.Text = proyectoCofecyt.Descripcion;
                    //txtDestinatariosCofecyt.Text = proyectoCofecyt.Destinatarios;
                    //ddlLocalidadCofecyt.Text = localidadNego.TraerLocalidad(Convert.ToInt32(proyectoCofecyt.IdLocalidad));
                    //ddlSectorCofecyt.Text = sectorNego.TraerSector(Convert.ToInt32(proyectoCofecyt.IdSector));
                    //ddlTematicaCofecyt.Text = tematicaNego.TraerTematica(Convert.ToInt32(proyectoCofecyt.IdTematica));
                    //txtNumeroExpedienteCopadeCofecyt.Text = proyectoCofecyt.NumeroEspedienteCopade;
                    //txtNumeroConvenio.Text = proyectoCofecyt.NumeroConvenio;
                    //txtNumeroExpedienteDga.Text = proyectoCofecyt.NumeroExpedienteDga;
                    //ddlUvt.Text = udtUvtNego.TraerUdtUvt(Convert.ToInt32(proyectoCofecyt.IdUdtUvt));
                    //ddlDirector.Text = personaNego.TraerPersona(Convert.ToInt32(proyectoCofecyt.IdDirector));


                    ////****INICIO RUTINA PARA TRABAJAR CON FORMATO FECHA
                    ////FECHA PRESENTACION
                    //string dia = Convert.ToString((proyectoCofecyt.FechaPresentacion).Value.Day);
                    //string mes = Convert.ToString((proyectoCofecyt.FechaPresentacion).Value.Month);
                    //string anio = Convert.ToString((proyectoCofecyt.FechaPresentacion).Value.Year);
                    //string t1 = "";
                    //string t2 = "";
                    //if ((proyectoCofecyt.FechaPresentacion).Value.Day < 10)
                    //{
                    //    t1 = "0";
                    //}
                    //if ((proyectoCofecyt.FechaPresentacion).Value.Month < 10)
                    //{
                    //    t2 = "0";
                    //}
                    //txtFechaPresentacion.Text = t2 + mes + "/" + t1 + dia + "/" + anio;

                    ////FECHA FINALIZACION
                    //dia = Convert.ToString((proyectoCofecyt.FechaFinalizacion).Value.Day);
                    //mes = Convert.ToString((proyectoCofecyt.FechaFinalizacion).Value.Month);
                    //anio = Convert.ToString((proyectoCofecyt.FechaFinalizacion).Value.Year);
                    //t1 = "";
                    //t2 = "";
                    //if ((proyectoCofecyt.FechaFinalizacion).Value.Day < 10)
                    //{
                    //    t1 = "0";
                    //}
                    //if ((proyectoCofecyt.FechaFinalizacion).Value.Month < 10)
                    //{
                    //    t2 = "0";
                    //}
                    //txtFechaFinalizacion.Text = t2 + mes + "/" + t1 + dia + "/" + anio;

                    ////FECHA ULTIMA EVALUACION TECNICA
                    //dia = Convert.ToString((proyectoCofecyt.UltimaEvaluacionTecnica).Value.Day);
                    //mes = Convert.ToString((proyectoCofecyt.UltimaEvaluacionTecnica).Value.Month);
                    //anio = Convert.ToString((proyectoCofecyt.UltimaEvaluacionTecnica).Value.Year);
                    //t1 = "";
                    //t2 = "";
                    //if ((proyectoCofecyt.UltimaEvaluacionTecnica).Value.Day < 10)
                    //{
                    //    t1 = "0";
                    //}
                    //if ((proyectoCofecyt.UltimaEvaluacionTecnica).Value.Month < 10)
                    //{
                    //    t2 = "0";
                    //}
                    //txtUltimaEvaluacionTecnica.Text = t2 + mes + "/" + t1 + dia + "/" + anio;

                    ////****FIN RUTINA FORMATO DE FECHA



                    ////txtFechaPresentacion.Text = Convert.ToDateTime(proyectoCofecyt.FechaPresentacion).ToShortDateString();
                    ////txtFechaFinalizacion.Text = Convert.ToDateTime(proyectoCofecyt.FechaFinalizacion).ToShortDateString();
                    ////txtUltimaEvaluacionTecnica.Text = Convert.ToDateTime(proyectoCofecyt.UltimaEvaluacionTecnica).ToShortDateString();



                    //txtDuracionEstimada.Text = Convert.ToString(proyectoCofecyt.DuracionEstimada);
                    //txtDuracionEstimadaIfaa.Text = Convert.ToString(proyectoCofecyt.DuracionEstimadaIfaa);
                    //txtBeneficiarios.Text = proyectoCofecyt.Beneficiarios;
                    //txtEntidadesIntervinientes.Text = proyectoCofecyt.EntidadesIntervinientes;
                    ////ddlEstadoCofecyt.Text = tipoEstadoCofecytNego.TraerTipoEstadoCofecyt(Convert.ToInt32(proyectoCofecyt.IdTipoEstadoCofecyt));
                    //ddlEstadoCofecyt.Text = Convert.ToString(proyectoCofecyt.IdTipoEstadoCofecyt);
                    //ddlContactoBeneficiario.Text = personaNego.TraerPersona(Convert.ToInt32(proyectoCofecyt.IdContactoBeneficiario));
                    //txtObservacionesCofecyt.Text = proyectoCofecyt.Observaciones;
                    //txtMontoSolicitadoCofecyt.Text = Convert.ToString(proyectoCofecyt.MontoSolicitadoCofecyt);
                    //txtMontoContraparteCofecyt.Text = Convert.ToString(proyectoCofecyt.MontoContraparteCofecyt);
                    //txtMontoTotalCofecyt.Text = Convert.ToString(proyectoCofecyt.MontoTotalCofecyt);
                    //txtMontoTotalDgaCofecyt.Text = Convert.ToString(proyectoCofecyt.MontoTotalDgaCofecyt);
                    //txtMontoDevolucionCofecyt.Text = Convert.ToString(proyectoCofecyt.MontoDevolucionCofecyt);
                    //txtMontoRescindidoCofecyt.Text = Convert.ToString(proyectoCofecyt.MontoRescindidoCofecyt);

                    ////if (ddlLocalidadCofecyt.SelectedValue == "-1") { proyectoCofecyt.IdLocalidad = null; }
                    ////else { proyectoCofecyt.IdLocalidad = localidadNego.TraerLocalidadIdSegunItem(ddlLocalidadCofecyt.SelectedItem.ToString()); }

                    ////if (ddlSectorCofecyt.SelectedValue == "-1") { proyectoCofecyt.IdSector = null; }
                    ////else { proyectoCofecyt.IdSector = sectorNego.TraerSectorIdSegunItem(ddlSectorCofecyt.SelectedItem.ToString()); }

                    ////if (ddlTematicaCofecyt.SelectedValue == "-1") { proyectoCofecyt.IdTematica = null; }
                    ////else { proyectoCofecyt.IdTematica = tematicaNego.TraerTematicaIdSegunItem(ddlTematicaCofecyt.SelectedItem.ToString()); }

                    ////if (ddlUvt.SelectedValue == "-1") { proyectoCofecyt.UdtUvt = null; }
                    ////else { proyectoCofecyt.IdUdtUvt = udtUvtNego.TraerUdtUvtIdSegunItem(ddlUvt.SelectedItem.ToString()); }

                    ////if (ddlDirector.SelectedValue == "-1") { proyectoCofecyt.IdDirector = null; }
                    ////else
                    ////{
                    ////    //para DIRECTOR
                    ////    string cadena = ddlDirector.SelectedItem.ToString();
                    ////    string[] separadas;
                    ////    separadas = cadena.Split(',');
                    ////    string itemApellido = separadas[0];
                    ////    string itemNombre = separadas[1];
                    ////    proyectoCofecyt.IdDirector = personaNego.TraerPersonaIdSegunItem(itemApellido, itemNombre);
                    ////}

                    ////if (ddlEstadoCofecyt.SelectedValue == "-1") { proyectoCofecyt.IdTipoEstadoCofecyt = null; }
                    ////else { proyectoCofecyt.IdTipoEstadoCofecyt = tipoEstadoCofecytNego.TraerTipoEstadoCofecytIdSegunItem(ddlEstadoCofecyt.SelectedItem.ToString()); }

                    //////para CONTACTO BENEFICIARIO
                    ////if (ddlContactoBeneficiario.SelectedValue == "-1") { proyectoCofecyt.IdContactoBeneficiario = null; }
                    ////else
                    ////{
                    ////    string cadena = ddlContactoBeneficiario.SelectedItem.ToString();
                    ////    string[] separadas;
                    ////    separadas = cadena.Split(',');
                    ////    string itemApellido = separadas[0];
                    ////    string itemNombre = separadas[1];
                    ////    proyectoCofecyt.IdContactoBeneficiario = personaNego.TraerPersonaIdSegunItem(itemApellido, itemNombre);
                    ////}


                    ////AHORA TENGO QUE TRAER UNA LISTA DE ETAPAS SEGUN EL IdProyectoActual
                    //listaEtapaCofecytsTemporal = (List<EtapaCofecyt>)etapaCofecytNego.TraerEtapaCofecytsSegunIdProyecto(idProyectoCofecytActual).ToList();

                    //dgvEtapasCofecyt.DataSource = listaEtapaCofecytsTemporal;
                    //dgvEtapasCofecyt.DataBind();

                    //listaActividadCofecytsTemporal = (List<ActividadCofecyt>)actividadCofecytNego.TraerActividadCofecytsSegunIdProyecto(idProyectoCofecytActual).ToList();

                    //dgvActividadesCofecyt.DataSource = listaActividadCofecytsTemporal;
                    //dgvActividadesCofecyt.DataBind();
                }
            }
            else
            {
                idProyectoActual = Convert.ToInt32(ddlProyectoChoice.SelectedValue.ToString());

                Proyecto proyecto = proyectoNego.ObtenerProyecto(idProyectoActual);

                if (proyecto == null)
                {
                    LimpiarFormulario();
                    return;
                }

                txtNombre.Text = proyecto.Nombre.ToString();
                txtNumeroExp.Text = proyecto.NumeroExpediente.ToString();
                txtObjetivos.Text = proyecto.Objetivos;
                txtDestinatarios.Text = proyecto.Destinatarios;

                ddlConvocatoria.Text = Convert.ToString(proyecto.IdConvocatoria);
                txtMontoSolicitado.Text = Convert.ToString(proyecto.MontoSolicitado);
                txtMontoContraparte.Text = Convert.ToString(proyecto.MontoContraparte);
                txtMontoTotal.Text = Convert.ToString(proyecto.MontoTotal);
                txtDescripcion.Text = proyecto.Descripcion.ToString();
                txtObservaciones.Text = proyecto.Observaciones.ToString();

                if (proyecto.IdSector == null) { ddlSector.Text = "-1"; }
                else { ddlSector.Text = sectorNego.TraerSector(proyecto.IdSector.Value); }

                if (proyecto.IdTematica == null) { ddlTematica.Text = "-1"; }
                else { ddlTematica.Text = tematicaNego.TraerTematica(proyecto.IdTematica.Value); }

                if (proyecto.IdPersona == null) { ddlContacto.Text = "-1"; }
                else { ddlContacto.Text = personaNego.TraerPersona(proyecto.IdPersona.Value); }

                if (proyecto.IdEmpresa == null) { ddlEmpresa.Text = "-1"; }
                else { ddlEmpresa.Text = empresaNego.TraerEmpresa(proyecto.IdEmpresa.Value); }

                if (proyecto.IdLocalidad == null) { ddlLocalidad.Text = "-1"; }
                else { ddlLocalidad.Text = localidadNego.TraerLocalidad(proyecto.IdLocalidad.Value); }

                if (proyecto.IdTipoEstado == null) { ddlTipoEstado.Text = "-1"; }
                else { ddlTipoEstado.Text = tipoEstadoNego.TraerTipoEstado(proyecto.IdTipoEstado.Value); }

                if (proyecto.IdTipoProyecto == null) { ddlTipoProyecto.Text = "-1"; }
                else { ddlTipoProyecto.Text = tipoProyectoNego.TraerTipoProyecto(proyecto.IdTipoProyecto.Value); }

                //AHORA TENGO QUE TRAER UNA LISTA DE ETAPAS SEGUN EL IdProyectoActual
                listaTemporalEtapas = (List<Etapa>)etapaNego.TraerEtapasSegunIdProyecto(idProyectoActual).ToList();

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

                LlenarGrillaEtapas(); //no borrar esta linea!!!
            }
        }

        private void LlenarGrillaEtapas()
        {
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
            MostrarPersona();
        }
        private string TraerPersona(int id)
        {
            return personaNego.TraerPersona(id);
        }

        protected void btnModalEmpresaGuardar_Click(object sender, EventArgs e)
        {
            Empresa empresa = new Empresa();

            empresa.Nombre = txtEmpresaModal.Text;

            idEmpresaActual = empresaNego.GuardarEmpresa(empresa);

            ddlEmpresa.Items.Clear();
            ddlEmpresa.Text = TraerEmpresa(idEmpresaActual);
            MostrarEmpresa();
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
            MostrarLocalidad();
        }
        private string TraerLocalidad(int id)
        {
            return localidadNego.TraerLocalidad(id);
        }

        protected void btnModalEtapaGuardar_Click(object sender, EventArgs e)
        {
            Etapa item = new Etapa();

            item.IdProyecto = idProyectoActual;

            item.Nombre = txtNombreModal.Text;

            if (txtFechaInicioModal.Text == "") { item.FechaInicio = null; }
            else { item.FechaInicio = DateTime.ParseExact(txtFechaInicioModal.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture); }

            if (txtFechaFinalModal.Text == "") { item.FechaFin = null; }
            else { item.FechaFin = DateTime.ParseExact(txtFechaFinalModal.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture); }

            //item.FechaInicio = DateTime.ParseExact(txtFechaInicioModal.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);
            //item.FechaFin = DateTime.ParseExact(txtFechaFinalModal.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);
            item.IdTipoEstadoEtapa = Convert.ToInt32(ddlTipoEstadoEtapa.SelectedValue);

            if (chkRendicion.Checked)
            {
                item.Rendicion = true;
            }
            else if (!chkRendicion.Checked)
            {
                item.Rendicion = false;
            }

            if (chkInforme.Checked)
            {
                item.Informe = true;
            }
            else if (!chkInforme.Checked)
            {
                item.Informe = false;
            }


            txtNombreModal.Text = null;
            txtFechaInicioModal.Text = null;
            txtFechaFinalModal.Text = null;
            chkInforme.Text = null;
            chkRendicion.Text = null;
            ddlTipoEstadoEtapa.Text = null;

            listaTemporalEtapasAgregado.Add(item);
            listaTemporalEtapas.Add(item);

            dgvEtapas.DataSource = listaTemporalEtapas;
            dgvEtapas.DataBind();
        }






        protected void btnActualizarProyecto_Click(object sender, EventArgs e)
        {
            if (fondoNego.ObtenerFondo(Convert.ToInt32(ddlFondoChoice.SelectedValue)).Nombre.ToUpper() == "COFECYT")
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
                    ListarProyectos.numeroExpedienteProyectoSeleccionado = txtNumeroExpedienteCopadeCofecyt.Text;
                    ListarProyectos.idConvocatoriaSeleccionada = Convert.ToInt32(ddlConvocatoria.Text);
                    LimpiarFormularioCofecyt();

                    dgvEtapasCofecyt.DataSource = listaEtapaCofecytsTemporal;
                    dgvEtapasCofecyt.DataBind();

                    dgvActividadesCofecyt.DataSource = listaActividadCofecytsTemporal;
                    dgvActividadesCofecyt.DataBind();

                    listaEtapaCofecytsTemporal.Clear();
                    listaEtapaCofecytsTemporalAgregado.Clear();
                    listaActividadCofecytsTemporal.Clear();
                    listaActividadCofecytsTemporalAgregado.Clear();

                    //Response.Redirect("MostrarProyectoCofecyt.aspx");
                    Response.Redirect("EditarProyecto.aspx");
                }
                else
                {
                    // Mostrar aviso de completar todos los datos
                }
            }
            else
            {
                if (
                    //ddlLocalidad.SelectedValue != "-1"
                    //&& ddlTipoEstado.SelectedValue != "-1"
                    //&& ddlContacto.SelectedValue != "-1"
                    ddlConvocatoria.SelectedValue != "-1"
                    && txtNumeroExp.Text != ""
                    && txtNombre.Text != ""
                    //&& ddlTipoProyecto.SelectedValue != "-1"
                    //&& ddlSector.SelectedValue != "-1"
                    //&& ddlTematica.SelectedValue != "-1"
                    )
                {
                    ActualizarProyecto();
                    ListarProyectos.numeroExpedienteProyectoSeleccionado = txtNumeroExp.Text;
                    ListarProyectos.idConvocatoriaSeleccionada = Convert.ToInt32(ddlConvocatoria.Text);
                    LimpiarFormulario();

                    LlenarGrillaEtapas();

                    listaTemporalEtapas.Clear();
                    listaTemporalEtapasAgregado.Clear();

                    Response.Redirect("MostrarProyecto.aspx");
                }
                else
                {
                    // Mostrar aviso de completar todos los datos
                }
            }
        }
        private void ActualizarProyecto()
        {
            Proyecto proyecto = new Proyecto();

            proyecto.IdProyecto = idProyectoActual;

            proyecto.Nombre = txtNombre.Text;
            proyecto.NumeroExpediente = txtNumeroExp.Text;
            proyecto.Destinatarios = txtDestinatarios.Text;
            proyecto.Objetivos = txtObjetivos.Text;
            proyecto.IdConvocatoria = Int32.Parse(ddlConvocatoria.SelectedValue);
            proyecto.MontoSolicitado = Convert.ToDecimal(txtMontoSolicitado.Text);
            proyecto.MontoContraparte = Convert.ToDecimal(txtMontoContraparte.Text);
            proyecto.MontoTotal = Convert.ToDecimal(txtMontoTotal.Text);
            proyecto.Descripcion = txtDescripcion.Text;
            proyecto.Observaciones = txtObservaciones.Text;

            //string cadena = ddlContacto.SelectedItem.ToString();
            //string[] separadas;
            //separadas = cadena.Split(',');
            //string itemApellido = separadas[0];
            //string itemNombre = separadas[1];
            //proyecto.IdPersona = personaNego.TraerPersonaIdSegunItem(itemApellido, itemNombre);

            //proyecto.IdSector = sectorNego.TraerSectorIdSegunItem(ddlSector.SelectedItem.ToString());
            //proyecto.IdTematica = tematicaNego.TraerTematicaIdSegunItem(ddlTematica.SelectedItem.ToString());
            //proyecto.IdEmpresa = empresaNego.TraerEmpresaIdSegunItem(ddlEmpresa.SelectedItem.ToString());
            //proyecto.IdLocalidad = localidadNego.TraerLocalidadIdSegunItem(ddlLocalidad.SelectedItem.ToString());
            //proyecto.IdTipoEstado = tipoEstadoNego.TraerTipoEstadoIdSegunItem(ddlTipoEstado.SelectedItem.ToString());
            //proyecto.IdTipoProyecto = tipoProyectoNego.TraerTipoProyectoIdSegunItem(ddlTipoProyecto.SelectedItem.ToString());

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

            proyectoNego.ActualizarProyecto(proyecto);

            //DESPUES GUARDO LA LISTA DE ETAPAS DEL PROYECTO ACTUAL
            foreach (Etapa item in listaTemporalEtapas)
            {
                Etapa etapa = new Etapa();

                etapa.IdEtapa = item.IdEtapa;
                etapa.IdProyecto = idProyectoActual;
                etapa.Nombre = item.Nombre.ToString();

                if (item.FechaInicio == null) { etapa.FechaInicio = null; }
                else { etapa.FechaInicio = Convert.ToDateTime(item.FechaInicio.ToString()); }

                if (item.FechaFin == null) { etapa.FechaFin = null; }
                else { etapa.FechaFin = Convert.ToDateTime(item.FechaFin.ToString()); }

                //etapa.FechaInicio = Convert.ToDateTime(item.FechaInicio.ToString());
                //etapa.FechaFin = Convert.ToDateTime(item.FechaFin.ToString());

                etapa.IdTipoEstadoEtapa = item.IdTipoEstadoEtapa;

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

                etapaNego.ActualizarEtapa(etapa);
            }

            //LimpiarFormulario();
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



            //proyectoCofecyt.FechaPresentacion = DateTime.ParseExact(txtFechaPresentacion.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);
            //proyectoCofecyt.FechaFinalizacion = DateTime.ParseExact(txtFechaFinalizacion.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);
            //proyectoCofecyt.UltimaEvaluacionTecnica = DateTime.ParseExact(txtUltimaEvaluacionTecnica.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);


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

            //DESPUES GUARDO LA LISTA DE ETAPAS DEL PROYECTO COFECYT ACTUAL
            foreach (EtapaCofecyt item in listaEtapaCofecytsTemporal)
            {
                EtapaCofecyt etapaCofecyt = new EtapaCofecyt();

                etapaCofecyt.IdEtapaCofecyt = item.IdEtapaCofecyt;
                etapaCofecyt.IdProyectoCofecyt = idProyectoCofecytActual;
                etapaCofecyt.Nombre = item.Nombre.ToString();
                etapaCofecyt.FechaInicio = Convert.ToDateTime(item.FechaInicio.ToString());
                etapaCofecyt.FechaFin = Convert.ToDateTime(item.FechaFin.ToString());
                etapaCofecyt.IdTipoEstadoEtapa = item.IdTipoEstadoEtapa;
                etapaCofecyt.DuracionSegunUvt = item.DuracionSegunUvt;

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

                idEtapaCofecytUltima = etapaCofecytNego.ActualizarEtapaCofecyt(etapaCofecyt);
            }

            //DESPUES GUARDO LA LISTA DE ACTIVIDADES DEL PROYECTO COFECYT ACTUAL
            foreach (ActividadCofecyt item2 in listaActividadCofecytsTemporal)
            {
                ActividadCofecyt actividadCofecyt = new ActividadCofecyt();

                actividadCofecyt.IdActividadCofecyt = item2.IdActividadCofecyt;

                actividadCofecyt.IdProyectoCofecyt = idProyectoCofecytActual;

                actividadCofecyt.IdEtapaCofecyt = item2.IdEtapaCofecyt;

                actividadCofecyt.Nombre = item2.Nombre;
                actividadCofecyt.Descripcion = item2.Descripcion;
                actividadCofecyt.ResultadosEsperados = item2.ResultadosEsperados;
                actividadCofecyt.Localizacion = item2.Localizacion;

                actividadCofecytNego.ActualizarActividadCofecyt(actividadCofecyt);
            }
        }

        private void LimpiarFormulario()
        {
            txtNombre.Text = null;
            txtNumeroExp.Text = null;
            ddlConvocatoria.SelectedIndex = 0;
            txtMontoSolicitado.Text = null;
            txtMontoContraparte.Text = null;
            txtMontoTotal.Text = null;
            txtDescripcion.Text = null;
            txtObservaciones.Text = null;
            ddlContacto.SelectedIndex = 0;
            ddlEmpresa.SelectedIndex = 0;
            ddlLocalidad.SelectedIndex = 0;
            ddlTipoEstado.SelectedIndex = 0;
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


        protected void dgvEtapas_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {
            GridViewRow row = dgvEtapas.Rows[e.NewSelectedIndex];

            if (row.Cells[0].Text != "")
            {
                idEtapaActual = Convert.ToInt32(row.Cells[0].Text);

                Response.Redirect("EditarEtapa.aspx");
            }
            else
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Correct", "alert('DEBE ACTUALIZAR PARA CONTINUAR.')", true);

            }
        }

        protected void btnModalActividadCofecytGuardar_Click(object sender, EventArgs e)
        {
            ModalActividadCofecytGuardar();

            LlenarGrillaActividadesCofecyt();
        }

        protected void btnModalEtapaCofecytGuardar_Click(object sender, EventArgs e)
        {
            ModalEtapaCofecytGuardar();

            LlenarGrillaEtapasCofecyt();

            LlenarListaEtapasActividad();
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

            actividadCofecyt.IdEtapaCofecyt = listaEtapaCofecytsTemporal.ElementAt(ddlEtapaActividad.SelectedIndex).IdEtapaCofecyt;

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