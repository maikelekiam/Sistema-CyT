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
    public partial class AltaOrganismo : System.Web.UI.Page
    {
        OrganismoNego organismoNego = new OrganismoNego();
        LocalidadNego localidadNego = new LocalidadNego();
        public static int idOrganismoSeleccionada;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack) return;

            ListarOrganismos(); //SIRVE PARA LA GRILLA
            LlenarListaLocalidades(); //SIRVE PARA EL DROP DOWN LIST
        }
        private void LlenarListaLocalidades()
        {
            ddlLocalidad.DataSource = localidadNego.MostrarLocalidades().ToList();
            ddlLocalidad.DataValueField = "nombre";
            ddlLocalidad.DataBind();
        }
        private void ListarOrganismos()
        {
            dgvOrganismo.DataSource = organismoNego.MostrarOrganismos().ToList();
            dgvOrganismo.DataBind();

            dgvOrganismo.Columns[0].Visible = false;
        }

        protected void btnGuardarOrganismo_Click(object sender, EventArgs e)
        {
            if (txtNombre.Text != "")
            {
                GuardarOrganismo();
                ListarOrganismos();
                Response.Redirect("ListarOrganismos.aspx");
            }
            else
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Correct", "alert('Complete el campo: NOMBRE.')", true);
            }
        }
        private void GuardarOrganismo()
        {
            Organismo organismo = new Organismo();

            organismo.Nombre = txtNombre.Text;
            organismo.Telefono = txtTelefono.Text;
            organismo.CorreoElectronico = txtCorreoElectronico.Text;
            organismo.Domicilio = txtDomicilio.Text;
            organismo.Observaciones = txtObservaciones.Text;

            if (ddlLocalidad.SelectedValue != "-1")
            {
                organismo.IdLocalidad = localidadNego.TraerLocalidadIdSegunItem(ddlLocalidad.SelectedItem.ToString());
            }

            organismoNego.GuardarOrganismo(organismo);
        }
    }
}