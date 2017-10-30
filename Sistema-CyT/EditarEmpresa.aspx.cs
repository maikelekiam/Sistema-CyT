using System;
using System.Linq;
using CapaDominio;
using CapaNegocio;

namespace Sistema_CyT
{
    public partial class EditarEmpresa : System.Web.UI.Page
    {
        EmpresaNego empresaNego = new EmpresaNego();
        LocalidadNego localidadNego = new LocalidadNego();

        public static int id;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack) return;

            ListarListaEmpresas(); //SIRVE PARA LA GRILLA
            LlenarListaLocalidades(); //SIRVE PARA EL DROP DOWN LIST
        }
        //Muestra en el DROPDOWNLIST las LOCALIDADES
        private void LlenarListaLocalidades()
        {
            ddlLocalidad.DataSource = localidadNego.MostrarLocalidades().ToList();
            ddlLocalidad.DataValueField = "nombre";
            ddlLocalidad.DataBind();
        }
        //Muestra los datos de las personas en la GRILLA
        private void ListarListaEmpresas()
        {
            ddlEmpresas.DataSource = empresaNego.MostrarEmpresas().ToList();
            ddlEmpresas.DataValueField = "idEmpresa";
            ddlEmpresas.DataBind();
        }

        protected void ddlPersonas_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlEmpresas.SelectedValue != "-1")
            {
                //OBTENGO EL ID DE LA EMPRESA SELECCIONADA DESDE EL DROPDOWNLIST
                id = Convert.ToInt32(ddlEmpresas.SelectedValue.ToString());

                Empresa empresa = empresaNego.ObtenerEmpresa(id);

                txtNombre.Text = empresa.Nombre;
                txtTelefono.Text = empresa.Telefono;
                txtCorreoElectronico.Text = empresa.CorreoElectronico;
                txtObservaciones.Text = empresa.Observaciones;
                txtDomicilio.Text = empresa.Domicilio;

                if (empresa.IdLocalidad > 0)
                {
                    ddlLocalidad.Text = localidadNego.TraerLocalidad(empresa.IdLocalidad.Value);
                }
                else
                {
                    ddlLocalidad.Text = "-1";
                }
            }
            else
            {
                txtNombre.Text = "";
                txtTelefono.Text = "";
                txtCorreoElectronico.Text = "";
                txtObservaciones.Text = "";
                ddlLocalidad.Text = "-1";
            }
        }

        protected void btnActualizarEmpresa_Click(object sender, EventArgs e)
        {
            if (txtNombre.Text != "") 
            {
                ActualizarEmpresa();
                Response.Redirect("ListarEmpresas.aspx");
            }
        }
        private void ActualizarEmpresa()
        {
            Empresa empresa = new Empresa();

            empresa.IdEmpresa = id;
            empresa.Nombre = txtNombre.Text;
            empresa.Telefono = txtTelefono.Text;
            empresa.CorreoElectronico = txtCorreoElectronico.Text;
            empresa.Observaciones = txtObservaciones.Text;
            empresa.Domicilio = txtDomicilio.Text;

            if (ddlLocalidad.SelectedValue != "-1")
            {
                empresa.IdLocalidad = localidadNego.TraerLocalidadIdSegunItem(ddlLocalidad.SelectedItem.ToString());
            }

            empresaNego.ActualizarEmpresa(empresa);
        }
    }
}