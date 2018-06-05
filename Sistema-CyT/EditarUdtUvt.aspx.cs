using System;
using System.Collections.Generic;
using System.Linq;
using CapaDominio;
using CapaNegocio;

namespace Sistema_CyT
{
    public partial class EditarUdt : System.Web.UI.Page
    {
        UdtUvtNego udtUvtNego = new UdtUvtNego();
        LocalidadNego localidadNego = new LocalidadNego();
        PersonaNego personaNego = new PersonaNego();

        public static int id;

        public static int idUdtUvtSeleccionada;
        public static int idReferenteTecnicoActual;
        public static int idDirectorGerenteActual;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack) return;

            ListarListaUdtUvts(); //SIRVE EL DROP DOWN LIST
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
        private void ListarListaUdtUvts()
        {
            ddlUdtUvt.DataSource = udtUvtNego.MostrarUdtUvts().ToList();
            ddlUdtUvt.DataValueField = "idUdtUvt";
            ddlUdtUvt.DataBind();
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


        protected void btnActualizar_Click(object sender, EventArgs e)
        {
            if (txtNombre.Text != "")
            {
                ActualizarUdtUvt();
                Response.Redirect("ListarUdtUvts.aspx");
            }
            else
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Correct", "alert('Complete el campo: NOMBRE.')", true);
            }
        }
        private void ActualizarUdtUvt()
        {
            UdtUvt udtUvt = new UdtUvt();

            udtUvt.IdUdtUvt = id;

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
            udtUvtNego.ActualizarUdtUvt(udtUvt);
        }

        protected void ddlUdtUvt_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlUdtUvt.SelectedValue != "-1")
            {
                //OBTENGO EL ID SELECCIONADO DESDE EL DROPDOWNLIST
                id = Convert.ToInt32(ddlUdtUvt.SelectedValue.ToString());

                UdtUvt udtUvt = udtUvtNego.ObtenerUdtUvt(id);

                txtNombre.Text = udtUvt.Nombre;
                txtTelefono.Text = udtUvt.Telefono;
                txtCorreoElectronico.Text = udtUvt.CorreoElectronico;
                txtObservaciones.Text = udtUvt.Observaciones;
                txtDomicilio.Text = udtUvt.Domicilio;

                if (udtUvt.Tipo == "UDT") { ddlTipo.Text = "0"; }
                else if (udtUvt.Tipo == "UVT") { ddlTipo.Text = "1"; }
                else if (udtUvt.Tipo == "UDT / UVT") { ddlTipo.Text = "2"; }

                if (udtUvt.IdLocalidad > 0)
                {
                    ddlLocalidad.Text = localidadNego.TraerLocalidad(udtUvt.IdLocalidad.Value);
                }
                else
                {
                    ddlLocalidad.Text = "-1";
                }

                if (udtUvt.ReferenteTecnico == null) { ddlReferenteTecnico.Text = "-1"; }
                else { ddlReferenteTecnico.Text = personaNego.TraerPersona(udtUvt.ReferenteTecnico.Value); }

                if (udtUvt.DirectorGerente == null) { ddlDirectorGerente.Text = "-1"; }
                else { ddlDirectorGerente.Text = personaNego.TraerPersona(udtUvt.DirectorGerente.Value); }
            }
            else
            {
                txtNombre.Text = "";
                txtTelefono.Text = "";
                txtCorreoElectronico.Text = "";
                txtObservaciones.Text = "";
                ddlLocalidad.Text = "-1";
                ddlReferenteTecnico.Text = "-1";
                ddlDirectorGerente.Text = "-1";
                ddlTipo.Text = "-1";
            }
        }

        protected void ddlReferenteTecnico_SelectedIndexChanged(object sender, EventArgs e)
        {
            idReferenteTecnicoActual = ddlReferenteTecnico.SelectedIndex;
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

        protected void ddlDirectorGerente_SelectedIndexChanged(object sender, EventArgs e)
        {
            idDirectorGerenteActual = ddlDirectorGerente.SelectedIndex;
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