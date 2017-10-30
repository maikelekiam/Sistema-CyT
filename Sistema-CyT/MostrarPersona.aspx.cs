using System;
using CapaDominio;
using CapaNegocio;

namespace Sistema_CyT
{
    public partial class MostrarPersona : System.Web.UI.Page
    {
        PersonaNego personaNego = new PersonaNego();
        LocalidadNego localidadNego = new LocalidadNego();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack) return;

            MostrarPersonaSeleccionada();
        }
        public void MostrarPersonaSeleccionada()
        {
            Persona persona = new Persona();

            persona = personaNego.ObtenerPersona(ListarPersonas.idPersonaSeleccionada);

            txtNombre.Text = persona.Nombre;
            txtApellido.Text = persona.Apellido;
            txtTipoDocumento.Text = persona.TipoDocumento;
            txtDocumento.Text = persona.Documento;
            txtTelefono.Text = persona.Telefono;
            txtCorreoElectronico.Text = persona.CorreoElectronico;
            txtObservaciones.Text = persona.Observaciones;
            txtDomicilio.Text = persona.Domicilio;

            if (persona.Localidad > 0)
            {
                txtLocalidad.Text = localidadNego.TraerLocalidad(Convert.ToInt32(persona.Localidad.Value));
            }
            else
            {
                txtLocalidad.Text = "";
            }


            //txtLocalidad.Text = localidadNego.TraerLocalidad(Convert.ToInt32(persona.Localidad.Value));
        }
    }
}