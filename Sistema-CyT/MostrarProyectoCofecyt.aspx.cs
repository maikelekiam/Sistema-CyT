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
    public partial class MostrarProyectoCofecyt : System.Web.UI.Page
    {
        ProyectoCofecytNego proyectoCofecytNego = new ProyectoCofecytNego();
        ConvocatoriaNego convocatoriaNego = new ConvocatoriaNego();
        EtapaCofecytNego etapaCofecytNego = new EtapaCofecytNego();
        ActividadCofecytNego actividadCofecytNego = new ActividadCofecytNego();
        PersonaNego personaNego = new PersonaNego();
        LocalidadNego localidadNego = new LocalidadNego();
        TematicaNego tematicaNego = new TematicaNego();
        SectorNego sectorNego = new SectorNego();
        UdtUvtNego udtUvtNego = new UdtUvtNego();
        TipoEstadoCofecytNego tipoEstadoCofecytNego = new TipoEstadoCofecytNego();

        public static List<EtapaCofecyt> listaTemporalEtapaCofecyts = new List<EtapaCofecyt>();
        public static List<ActividadCofecyt> listaTemporalActividadCofecyts = new List<ActividadCofecyt>();
        public static int idProyectoCofecytSeleccionado;
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack) return;

            ObtenerProyectoCofecyt();
        }
        private void ObtenerProyectoCofecyt()
        {

            string nom = ListarProyectos.numeroExpedienteProyectoSeleccionado;

            ProyectoCofecyt proyectoCofecyt = proyectoCofecytNego.ObtenerProyectoCofecytSegunNombreYConvocatoria(ListarProyectos.idConvocatoriaSeleccionada, ListarProyectos.numeroExpedienteProyectoSeleccionado);

            idProyectoCofecytSeleccionado = proyectoCofecyt.IdProyectoCofecyt;

            //lblNombreProyectoCofecyt.Text = "Proyecto: " + proyecto.Nombre.ToString();
            lblNombreProyectoCofecyt.Text = proyectoCofecyt.Titulo.ToString().ToUpper();


            txtConvocatoria.Text = convocatoriaNego.ObtenerConvocatoria(Convert.ToInt32(proyectoCofecyt.IdConvocatoria)).Nombre;
            txtTituloCofecyt.Text = proyectoCofecyt.Titulo;
            txtObjetivosCofecyt.Text = proyectoCofecyt.Objetivos;
            txtDescripcionCofecyt.Text = proyectoCofecyt.Descripcion;
            txtDestinatariosCofecyt.Text = proyectoCofecyt.Destinatarios;
            txtLocalidadCofecyt.Text = localidadNego.TraerLocalidad(Convert.ToInt32(proyectoCofecyt.IdLocalidad));
            txtSectorCofecyt.Text = sectorNego.TraerSector(Convert.ToInt32(proyectoCofecyt.IdSector));
            txtTematicaCofecyt.Text = tematicaNego.TraerTematica(Convert.ToInt32(proyectoCofecyt.IdTematica));
            txtNumeroExpedienteCopadeCofecyt.Text = proyectoCofecyt.NumeroEspedienteCopade;
            txtNumeroConvenio.Text = proyectoCofecyt.NumeroConvenio;
            txtNumeroExpedienteDga.Text = proyectoCofecyt.NumeroExpedienteDga;
            txtUvt.Text = udtUvtNego.TraerUdtUvt(Convert.ToInt32(proyectoCofecyt.IdUdtUvt));
            txtDirector.Text = personaNego.TraerPersona(Convert.ToInt32(proyectoCofecyt.IdDirector));
            txtFechaPresentacion.Text = Convert.ToDateTime(proyectoCofecyt.FechaPresentacion).ToShortDateString();
            txtFechaFinalizacion.Text = Convert.ToDateTime(proyectoCofecyt.FechaFinalizacion).ToShortDateString();
            txtUltimaEvaluacionTecnica.Text = Convert.ToDateTime(proyectoCofecyt.UltimaEvaluacionTecnica).ToShortDateString();
            txtDuracionEstimada.Text = Convert.ToString(proyectoCofecyt.DuracionEstimada);
            txtDuracionEstimadaIfaa.Text = Convert.ToString(proyectoCofecyt.DuracionEstimadaIfaa);
            txtBeneficiarios.Text = proyectoCofecyt.Beneficiarios;
            txtEntidadesIntervinientes.Text = proyectoCofecyt.EntidadesIntervinientes;
            txtEstadoCofecyt.Text = tipoEstadoCofecytNego.TraerTipoEstadoCofecyt(Convert.ToInt32(proyectoCofecyt.IdTipoEstadoCofecyt));
            txtContactoBeneficiario.Text = personaNego.TraerPersona(Convert.ToInt32(proyectoCofecyt.IdContactoBeneficiario));
            txtObservacionesCofecyt.Text = proyectoCofecyt.Observaciones;
            txtMontoSolicitadoCofecyt.Text = Convert.ToString(proyectoCofecyt.MontoSolicitadoCofecyt);
            txtMontoContraparteCofecyt.Text = Convert.ToString(proyectoCofecyt.MontoContraparteCofecyt);
            txtMontoTotalCofecyt.Text = Convert.ToString(proyectoCofecyt.MontoTotalCofecyt);
            txtMontoTotalDgaCofecyt.Text = Convert.ToString(proyectoCofecyt.MontoTotalDgaCofecyt);
            txtMontoDevolucionCofecyt.Text = Convert.ToString(proyectoCofecyt.MontoDevolucionCofecyt);
            txtMontoRescindidoCofecyt.Text = Convert.ToString(proyectoCofecyt.MontoRescindidoCofecyt);


            //AHORA TENGO QUE TRAER UNA LISTA DE ETAPAS SEGUN EL IdProyectoActual
            listaTemporalEtapaCofecyts = (List<EtapaCofecyt>)etapaCofecytNego.TraerEtapaCofecytsSegunIdProyecto(proyectoCofecyt.IdProyectoCofecyt).ToList();

            dgvEtapasCofecyt.Columns[0].Visible = true;
            dgvEtapasCofecyt.Columns[1].Visible = true;
            dgvEtapasCofecyt.Columns[2].Visible = true;
            dgvEtapasCofecyt.Columns[3].Visible = true;
            dgvEtapasCofecyt.Columns[4].Visible = true;
            dgvEtapasCofecyt.Columns[5].Visible = true;
            dgvEtapasCofecyt.Columns[6].Visible = true;

            dgvEtapasCofecyt.DataSource = listaTemporalEtapaCofecyts;
            dgvEtapasCofecyt.DataBind();

            //AHORA TENGO QUE TRAER UNA LISTA DE ACTIVIDADES SEGUN EL IdProyectoActual
            listaTemporalActividadCofecyts = (List<ActividadCofecyt>)actividadCofecytNego.TraerActividadCofecytsSegunIdProyecto(proyectoCofecyt.IdProyectoCofecyt).ToList();

            dgvActividadesCofecyt.Columns[0].Visible = true;
            dgvActividadesCofecyt.Columns[1].Visible = true;
            dgvActividadesCofecyt.Columns[2].Visible = true;
            dgvActividadesCofecyt.Columns[3].Visible = true;
            dgvActividadesCofecyt.Columns[4].Visible = true;

            dgvActividadesCofecyt.DataSource = listaTemporalActividadCofecyts.OrderBy(c=>c.IdEtapaCofecyt);
            dgvActividadesCofecyt.DataBind();


        }

        protected void btnActuaciones_Click(object sender, EventArgs e)
        {

        }
    }
}