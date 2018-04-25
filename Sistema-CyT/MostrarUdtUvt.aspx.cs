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
    public partial class MostrarUdtUvt : System.Web.UI.Page
    {
        UdtUvtNego udtUvtNego = new UdtUvtNego();
        LocalidadNego localidadNego = new LocalidadNego();
        PersonaNego personaNego = new PersonaNego();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack) return;

            MostrarUdtUvtSeleccionada();
        }
        public void MostrarUdtUvtSeleccionada()
        {
            UdtUvt udtUvt = new UdtUvt();

            udtUvt = udtUvtNego.ObtenerUdtUvt(ListarUdts.idUdtUvtSeleccionada);

            txtTipo.Text = udtUvt.Tipo;
            txtNombre.Text = udtUvt.Nombre;

            //traer los datos del Referente

            //traer los datos del Director

            txtTelefono.Text = udtUvt.Telefono;
            txtCorreoElectronico.Text = udtUvt.CorreoElectronico;
            txtObservaciones.Text = udtUvt.Observaciones;
            txtDomicilio.Text = udtUvt.Domicilio;

            if (udtUvt.IdLocalidad > 0)
            {
                txtLocalidad.Text = localidadNego.TraerLocalidad(udtUvt.IdLocalidad.Value);
            }
            else
            {
                txtLocalidad.Text = "";
            }
        }
    }
}