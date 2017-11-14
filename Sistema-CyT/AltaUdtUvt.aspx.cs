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
    public partial class AltaUdt : System.Web.UI.Page
    {
        UdtUvtNego udtUvtNego = new UdtUvtNego();
        LocalidadNego localidadNego = new LocalidadNego();
        PersonaNego personaNego = new PersonaNego();

        public static int idUdtUvtSeleccionada;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack) return;

            ListarUdtUvts(); //SIRVE PARA LA GRILLA
            ListarReferenteTecnicos();
            ListarDirectorGerentes();
            LlenarListaLocalidades(); //SIRVE PARA EL DROP DOWN LIST

        }
        private void LlenarListaLocalidades()
        {
            ddlLocalidad.DataSource = localidadNego.MostrarLocalidades().ToList();
            ddlLocalidad.DataValueField = "nombre";
            ddlLocalidad.DataBind();
        }

        //Muestra los datos de las UDT/UVTs en la GRILLA
        private void ListarUdtUvts()
        {
            dgvUdtUvt.DataSource = udtUvtNego.MostrarUdtUvts().ToList();
            dgvUdtUvt.DataBind();

            dgvUdtUvt.Columns[0].Visible = false;
        }

        private void ListarReferenteTecnicos()
        {
            ddlReferenteTecnico.DataSource = personaNego.MostrarPersonas().OrderBy(c => c.Nombre).ToList();
            IList<Persona> nombreCompleto = personaNego.MostrarPersonas().Select(p => new Persona() { Nombre = p.Apellido + "," + p.Nombre, IdPersona = p.IdPersona }).OrderBy(c => c.IdPersona).ToList();
            ddlReferenteTecnico.DataSource = nombreCompleto;
            ddlReferenteTecnico.DataValueField = "nombre";
            ddlReferenteTecnico.DataBind();
        }
        private void ListarDirectorGerentes()
        {
            ddlDirectorGerente.DataSource = personaNego.MostrarPersonas().OrderBy(c => c.Nombre).ToList();
            IList<Persona> nombreCompleto = personaNego.MostrarPersonas().Select(p => new Persona() { Nombre = p.Apellido + "," + p.Nombre, IdPersona = p.IdPersona }).OrderBy(c => c.IdPersona).ToList();
            ddlDirectorGerente.DataSource = nombreCompleto;
            ddlDirectorGerente.DataValueField = "nombre";
            ddlDirectorGerente.DataBind();
        }






        protected void btnGuardarUdtUvt_Click(object sender, EventArgs e)
        {
            if (txtNombre.Text != "")
            {
                GuardarUdtUvt();
                ListarUdtUvts();
                Response.Redirect("ListarUdtUvts.aspx");
            }
            else
            {
                //NO SE PUEDE GUARDAR LOS DATOS
            }
        }
        private void GuardarUdtUvt()
        {
            UdtUvt udtUvt = new UdtUvt();

            udtUvt.Nombre = txtNombre.Text;
            udtUvt.Telefono = txtTelefono.Text;
            udtUvt.CorreoElectronico = txtCorreoElectronico.Text;
            udtUvt.Domicilio = txtDomicilio.Text;
            udtUvt.Observaciones = txtObservaciones.Text;
            //udtUvt.ReferenteTecnico = Int32.Parse(ddlReferenteTecnico.SelectedValue);
            //udtUvt.DirectorGerente = Int32.Parse(ddlDirectorGerente.SelectedValue);
            udtUvt.Tipo = ddlTipo.SelectedItem.ToString();

            if (ddlLocalidad.SelectedValue != "-1")
            {
                udtUvt.IdLocalidad = localidadNego.TraerLocalidadIdSegunItem(ddlLocalidad.SelectedItem.ToString());
            }

            string cadena = ddlReferenteTecnico.SelectedItem.ToString();
            string[] separadas;
            separadas = cadena.Split(',');
            string itemApellido = separadas[0];
            string itemNombre = separadas[1];
            udtUvt.ReferenteTecnico = personaNego.TraerPersonaIdSegunItem(itemApellido, itemNombre);

            cadena = ddlDirectorGerente.SelectedItem.ToString();
            separadas = cadena.Split(',');
            itemApellido = separadas[0];
            itemNombre = separadas[1];
            udtUvt.DirectorGerente = personaNego.TraerPersonaIdSegunItem(itemApellido, itemNombre);

            udtUvtNego.GuardarUdtUvt(udtUvt);
        }

        protected void dgvUdtUvt_RowCommand(object sender, GridViewCommandEventArgs e)
        {

        }

        protected void ddlReferenteTecnico_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void ddlDirectorGerente_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}