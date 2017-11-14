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
    public partial class AltaEmpresa : System.Web.UI.Page
    {
        EmpresaNego empresaNego = new EmpresaNego();
        LocalidadNego localidadNego = new LocalidadNego();
        public static int idEmpresaSeleccionada;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack) return;

            ListarEmpresas(); //SIRVE PARA LA GRILLA
            LlenarListaLocalidades(); //SIRVE PARA EL DROP DOWN LIST
        }
        private void LlenarListaLocalidades()
        {
            ddlLocalidad.DataSource = localidadNego.MostrarLocalidades().ToList();
            ddlLocalidad.DataValueField = "nombre";
            ddlLocalidad.DataBind();
        }
        //Muestra los datos de las empresas en la GRILLA
        private void ListarEmpresas()
        {
            dgvEmpresa.DataSource = empresaNego.MostrarEmpresas().ToList();
            dgvEmpresa.DataBind();

            dgvEmpresa.Columns[0].Visible = false;
        }


        protected void btnGuardarEmpresa_Click(object sender, EventArgs e)
        {
            if (txtNombre.Text != "")
            {
                GuardarEmpresa();
                ListarEmpresas();
                Response.Redirect("ListarEmpresas.aspx");
            }
            else
            {
                //NO SE PUEDE GUARDAR LOS DATOS
            }
        }
        private void GuardarEmpresa()
        {
            Empresa empresa = new Empresa();

            empresa.Nombre = txtNombre.Text;
            empresa.Telefono = txtTelefono.Text;
            empresa.CorreoElectronico = txtCorreoElectronico.Text;
            empresa.Domicilio = txtDomicilio.Text;
            empresa.Observaciones = txtObservaciones.Text;

            if (ddlLocalidad.SelectedValue != "-1")
            {
                empresa.IdLocalidad = localidadNego.TraerLocalidadIdSegunItem(ddlLocalidad.SelectedItem.ToString());
            }

            empresaNego.GuardarEmpresa(empresa);
        }
        protected void dgvEmpresa_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            //Obtengo el indice de la fila seleccionada con el boton MOSTRAR
            GridViewRow row = (GridViewRow)(((Button)e.CommandSource).NamingContainer);
            int rIndex = row.RowIndex;

            //Obtengo el id de la EMPRESA seleccionada
            idEmpresaSeleccionada = Convert.ToInt32(dgvEmpresa.Rows[rIndex].Cells[0].Text);

            MostrarEmpresa();
        }
        private void MostrarEmpresa()
        {
            Response.Redirect("MostrarEmpresa.aspx");
        }
    }
}