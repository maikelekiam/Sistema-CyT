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
    public partial class MostrarOrganismo : System.Web.UI.Page
    {
        OrganismoNego organismoNego = new OrganismoNego();
        LocalidadNego localidadNego = new LocalidadNego();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack) return;

            MostrarOrganismoSeleccionada();
        }
        public void MostrarOrganismoSeleccionada()
        {
            Organismo organismo = new Organismo();

            organismo = organismoNego.ObtenerOrganismo(ListarOrganismos.idOrganismoSeleccionado);

            txtNombre.Text = organismo.Nombre;
            txtTelefono.Text = organismo.Telefono;
            txtCorreoElectronico.Text = organismo.CorreoElectronico;
            txtObservaciones.Text = organismo.Observaciones;
            txtDomicilio.Text = organismo.Domicilio;

            if (organismo.IdLocalidad > 0)
            {
                txtLocalidad.Text = localidadNego.TraerLocalidad(organismo.IdLocalidad.Value);
            }
            else
            {
                txtLocalidad.Text = "";
            }
        }
    }
}