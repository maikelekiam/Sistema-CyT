using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CapaDominio;
using CapaNegocio;
using System.Data;
using System.ComponentModel;

namespace Sistema_CyT
{
    public partial class EditarPersona : System.Web.UI.Page
    {
        PersonaNego personaNego = new PersonaNego();
        LocalidadNego localidadNego = new LocalidadNego();

        static int id;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack) return;

            LlenarListaPersonas(); //SIRVE PARA EL DROPDOWNLIST DE PERSONAS
            LlenarListaLocalidades(); //SIRVE PARA EL DROP DOWN LIST
        }
        //Muestra en el DROPDOWNLIST las LOCALIDADES
        private void LlenarListaLocalidades()
        {
            ddlLocalidad.DataSource = localidadNego.MostrarLocalidades().ToList();
            ddlLocalidad.DataValueField = "nombre";
            ddlLocalidad.DataBind();
        }

        protected void btnActualizarPersona_Click(object sender, EventArgs e)
        {
            if ((txtNombre.Text != "") && (txtApellido.Text != ""))
            {
                ActualizarPersona();
                Response.Redirect("ListarPersonas.aspx");
            }
        }
        private void ActualizarPersona()
        {
            Persona persona = new Persona();

            persona.IdPersona = id;
            persona.Nombre = txtNombre.Text;
            persona.Apellido = txtApellido.Text;
            persona.TipoDocumento = ddlTipoDocumento.SelectedValue.ToString();
            persona.Documento = txtDocumento.Text;
            persona.Telefono = txtTelefono.Text;
            persona.CorreoElectronico = txtCorreoElectronico.Text;
            persona.Observaciones = txtObservaciones.Text;
            persona.Domicilio = txtDomicilio.Text;

            if (ddlLocalidad.SelectedValue != "-1")
            {
                persona.Localidad = localidadNego.TraerLocalidadIdSegunItem(ddlLocalidad.SelectedItem.ToString());
            }

            personaNego.ActualizarPersona(persona);
        }

        protected void ddlPersonas_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlPersonas.SelectedValue != "-1")
            {
                //OBTENGO EL ID DEL FONDO SELECCIONADO DESDE EL DROPDOWNLIST
                id = Convert.ToInt32(ddlPersonas.SelectedValue.ToString());

                Persona persona = personaNego.ObtenerPersona(id);

                txtNombre.Text = persona.Nombre;
                txtApellido.Text = persona.Apellido;
                ddlTipoDocumento.Text = persona.TipoDocumento;
                txtDocumento.Text = persona.Documento;
                txtTelefono.Text = persona.Telefono;
                txtCorreoElectronico.Text = persona.CorreoElectronico;
                txtObservaciones.Text = persona.Observaciones;
                txtDomicilio.Text = persona.Domicilio;

                if (persona.Localidad > 0)
                {
                    ddlLocalidad.Text = localidadNego.TraerLocalidad(persona.Localidad.Value);
                }
                else
                {
                    ddlLocalidad.Text = "-1";
                }
            }
            else
            {
                txtNombre.Text = "";
                txtApellido.Text = "";
                ddlTipoDocumento.Text = "";
                txtDocumento.Text = "";
                txtTelefono.Text = "";
                txtCorreoElectronico.Text = "";
                txtObservaciones.Text = "";
                ddlLocalidad.Text = "-1";
            }
        }

        public void LlenarListaPersonas()
        {
            ddlPersonas.DataSource = personaNego.MostrarPersonas().ToList();
            IList<Persona> nombreCompleto = personaNego.MostrarPersonas().Select(p => new Persona() { Nombre = p.Apellido + "," + p.Nombre, IdPersona = p.IdPersona }).OrderBy(c => c.IdPersona).ToList();
            ddlPersonas.DataSource = nombreCompleto;
            ddlPersonas.DataValueField = "idPersona";
            ddlPersonas.DataBind();
        }
    }
}