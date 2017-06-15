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
    public partial class AltaProyecto : System.Web.UI.Page
    {
        LocalidadNego localidadNego = new LocalidadNego();
        PersonaNego personaNego = new PersonaNego();
        EmpresaNego empresaNego = new EmpresaNego();
        ConvocatoriaNego convocatoriaNego = new ConvocatoriaNego();
        EtapaNego etapaNego = new EtapaNego();
        ProyectoNego proyectoNego = new ProyectoNego();
        static int idProyectoActual;

        static List<Etapa> listaEtapasTemporal = new List<Etapa>();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack) return;

            MostrarLocalidad(); //SIRVE PARA EL DROP DOWN LIST
            MostrarPersona(); //SIRVE PARA EL DROP DOWN LIST
            MostrarEmpresa(); // SIRVE PARA EL DROP DOWN LIST
            MostrarConvocatoria(); // SIRVE PARA EL DROP DOWN LIST

            txtFechaInicioModal.Text = Convert.ToString(DateTime.Today.ToShortDateString());
            txtFechaFinalModal.Text = Convert.ToString(DateTime.Today.ToShortDateString());

            listaEtapasTemporal.Clear();
        }

        //Muestra en el DROPDOWNLIST las LOCALIDADES
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
            ddlLocalidad.DataValueField = "IdLocalidad";
            ddlLocalidad.DataBind();
        }

        //Muestra en el DROPDOWNLIST las EMPRESAS
        private void MostrarEmpresa()
        {
            ddlEmpresa.DataSource = empresaNego.MostrarEmpresas().ToList();
            ddlEmpresa.DataValueField = "IdEmpresa";
            ddlEmpresa.DataBind();
        }

        //Muestra en el DROPDOWNLIST las PERSONAS
        private void MostrarPersona()
        {
            ddlContacto.DataSource = personaNego.MostrarPersonas().ToList();
            IList<Persona> nombreCompleto = personaNego.MostrarPersonas().Select(p => new Persona() { Nombre = p.Nombre + " " + p.Apellido, IdPersona = p.IdPersona }).OrderBy(c => c.IdPersona).ToList();
            ddlContacto.DataSource = nombreCompleto;
            ddlContacto.DataValueField = "IdPersona";
            ddlContacto.DataBind();
        }

        protected void btnGuardarProyecto_Click(object sender, EventArgs e)
        {
            GuardarProyecto();
        }

        protected void btnModalEtapaGuardar_Click(object sender, EventArgs e)
        {
            ModalEtapaGuardar();
        }

        private void ModalEtapaGuardar()
        {
            Etapa item = new Etapa();

            item.Nombre = txtNombreModal.Text;
            item.FechaInicio = Convert.ToDateTime(txtFechaInicioModal.Text);
            item.FechaFin = Convert.ToDateTime(txtFechaFinalModal.Text);
            item.Duracion = Int32.Parse(txtDuracionModal.Text);

            listaEtapasTemporal.Add(item);

            txtNombreModal.Text = null;
            txtDuracionModal.Text = null;
            txtFechaInicioModal.Text = Convert.ToString(DateTime.Today.ToShortDateString());
            txtFechaFinalModal.Text = Convert.ToString(DateTime.Today.ToShortDateString());

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
            proyecto.IdPersona = Int32.Parse(ddlContacto.SelectedValue);
            proyecto.IdEmpresa = Int32.Parse(ddlEmpresa.SelectedValue);
            proyecto.IdLocalidad = Int32.Parse(ddlLocalidad.SelectedValue);

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






    }
}