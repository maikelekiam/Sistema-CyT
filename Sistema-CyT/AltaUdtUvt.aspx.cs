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
        public static int idReferenteTecnicoActual;
        public static int idDirectorGerenteActual;

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
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Correct", "alert('Complete el campo: NOMBRE.')", true);
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

            //PARA EL REFERENTE
            if (ddlReferenteTecnico.SelectedValue == "-1")
            {
                udtUvt.ReferenteTecnico = null;
            }
            else
            {
                string cadena = ddlReferenteTecnico.SelectedItem.ToString();
                string[] separadas;
                separadas = cadena.Split(',');
                string itemApellido = separadas[0];
                string itemNombre = separadas[1];
                udtUvt.ReferenteTecnico = personaNego.TraerPersonaIdSegunItem(itemApellido, itemNombre);
            }

            //PARA EL DIRECTOR / GERENTE
            if (ddlDirectorGerente.SelectedValue == "-1")
            {
                udtUvt.DirectorGerente = null;
            }
            else
            {
                string cadena = ddlDirectorGerente.SelectedItem.ToString();
                string[] separadas;
                separadas = cadena.Split(',');
                string itemApellido = separadas[0];
                string itemNombre = separadas[1];
                udtUvt.DirectorGerente = personaNego.TraerPersonaIdSegunItem(itemApellido, itemNombre);
            }

            udtUvt.Tipo = ddlTipo.SelectedItem.ToString();

            if (ddlLocalidad.SelectedValue != "-1")
            {
                udtUvt.IdLocalidad = localidadNego.TraerLocalidadIdSegunItem(ddlLocalidad.SelectedItem.ToString());
            }
            udtUvtNego.GuardarUdtUvt(udtUvt);
        }
        protected void ddlReferenteTecnico_SelectedIndexChanged(object sender, EventArgs e)
        {
            idReferenteTecnicoActual = ddlReferenteTecnico.SelectedIndex;
        }
        protected void ddlDirectorGerente_SelectedIndexChanged(object sender, EventArgs e)
        {
            idDirectorGerenteActual = ddlDirectorGerente.SelectedIndex;
        }
        protected void btnModalReferenteTecnicoGuardar_Click(object sender, EventArgs e)
        {
            if (txtReferenteTecnicoNombreModal.Text != "" && txtReferenteTecnicoApellidoModal.Text != "")
            {
                Persona persona = new Persona();

                persona.Nombre = txtReferenteTecnicoNombreModal.Text;
                persona.Apellido = txtReferenteTecnicoApellidoModal.Text;
                persona.Telefono = txtReferenteTecnicoTelefonoModal.Text;
                persona.CorreoElectronico = txtReferenteTecnicoCorreoElectronicoModal.Text;

                int idPersonaActual = personaNego.GuardarPersona(persona);

                ddlReferenteTecnico.Items.Clear();
                ddlReferenteTecnico.Text = TraerPersona(idPersonaActual);

                ListarReferenteTecnicos();
                ListarDirectorGerentes();
            }
            else
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Correct", "alert('Complete los campos: NOMBRE, APELLIDO.')", true);
            }
        }
        protected void btnModalDirectorGerenteGuardar_Click(object sender, EventArgs e)
        {
            if (txtDirectorGerenteNombreModal.Text != "" && txtDirectorGerenteApellidoModal.Text != "")
            {
                Persona persona = new Persona();

                persona.Nombre = txtDirectorGerenteNombreModal.Text;
                persona.Apellido = txtDirectorGerenteApellidoModal.Text;
                persona.Telefono = txtDirectorGerenteTelefonoModal.Text;
                persona.CorreoElectronico = txtDirectorGerenteCorreoElectronicoModal.Text;

                int idPersonaActual = personaNego.GuardarPersona(persona);

                ddlDirectorGerente.Items.Clear();
                ddlDirectorGerente.Text = TraerPersona(idPersonaActual);

                ListarDirectorGerentes();
                ListarReferenteTecnicos();
            }
            else
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Correct", "alert('Complete los campos: NOMBRE, APELLIDO.')", true);
            }
        }
        private string TraerPersona(int id)
        {
            return personaNego.TraerPersona(id);
        }
    }
}