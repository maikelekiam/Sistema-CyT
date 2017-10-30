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
    public partial class MostrarEmpresa : System.Web.UI.Page
    {
        EmpresaNego empresaNego = new EmpresaNego();
        LocalidadNego localidadNego = new LocalidadNego();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack) return;

            MostrarEmpresaSeleccionada();
        }
        public void MostrarEmpresaSeleccionada()
        {
            Empresa empresa = new Empresa();

            empresa = empresaNego.ObtenerEmpresa(ListarEmpresas.idEmpresaSeleccionada);

            txtNombre.Text = empresa.Nombre;
            txtTelefono.Text = empresa.Telefono;
            txtCorreoElectronico.Text = empresa.CorreoElectronico;
            txtObservaciones.Text = empresa.Observaciones;
            //txtDomicilio.Text = empresa.Domicilio;
            lbl01.Text = empresa.Domicilio;

            if (empresa.IdLocalidad > 0)
            {
                txtLocalidad.Text = localidadNego.TraerLocalidad(empresa.IdLocalidad.Value);
            }
            else
            {
                txtLocalidad.Text = "";
            }
        }
    }
}