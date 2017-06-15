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

        static List<Etapa> listaEtapas = new List<Etapa>();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack) return;

            MostrarLocalidad(); //SIRVE PARA EL DROP DOWN LIST
            MostrarPersona(); //SIRVE PARA EL DROP DOWN LIST
            MostrarEmpresa(); // SIRVE PARA EL DROP DOWN LIST
            MostrarConvocatoria(); // SIRVE PARA EL DROP DOWN LIST
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

            etapaNego.GuardarEtapa(item);

            listaEtapas.Add(item);

            LlenarGrillaModalidades();
        }

        private void LlenarGrillaModalidades()
        {
            dgvEtapas.DataSource = listaEtapas;
            dgvEtapas.DataBind();
        }
        
        private void GuardarProyecto()
        {
            Proyecto proyecto = new Proyecto();

            proyecto.Nombre = txtNombre.Text;
            proyecto.NumeroExpediente = txtNumeroExp.Text;



        }






    }
}