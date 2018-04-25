using System;
using System.Linq;
using CapaDominio;
using CapaNegocio;

namespace Sistema_CyT
{
    public partial class EditarOrganismo : System.Web.UI.Page
    {
        OrganismoNego organismoNego = new OrganismoNego();
        LocalidadNego localidadNego = new LocalidadNego();

        public static int id;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack) return;

            ListarListaOrganismos(); //SIRVE PARA LA GRILLA
            LlenarListaLocalidades(); //SIRVE PARA EL DROP DOWN LIST
        }
        //Muestra en el DROPDOWNLIST las LOCALIDADES
        private void LlenarListaLocalidades()
        {
            ddlLocalidad.DataSource = localidadNego.MostrarLocalidades().ToList();
            ddlLocalidad.DataValueField = "nombre";
            ddlLocalidad.DataBind();
        }
        private void ListarListaOrganismos()
        {
            ddlOrganismos.DataSource = organismoNego.MostrarOrganismos().ToList();
            ddlOrganismos.DataValueField = "idOrganismo";
            ddlOrganismos.DataBind();
        }

        protected void ddlOrganismos_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlOrganismos.SelectedValue != "-1")
            {
                //OBTENGO EL ID DEL ORGANISMO SELECCIONADO DESDE EL DROPDOWNLIST
                id = Convert.ToInt32(ddlOrganismos.SelectedValue.ToString());

                Organismo organismo = organismoNego.ObtenerOrganismo(id);

                txtNombre.Text = organismo.Nombre;
                txtTelefono.Text = organismo.Telefono;
                txtCorreoElectronico.Text = organismo.CorreoElectronico;
                txtObservaciones.Text = organismo.Observaciones;
                txtDomicilio.Text = organismo.Domicilio;

                if (organismo.IdLocalidad > 0)
                {
                    ddlLocalidad.Text = localidadNego.TraerLocalidad(organismo.IdLocalidad.Value);
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

        protected void btnActualizarOrganismo_Click(object sender, EventArgs e)
        {
            if (txtNombre.Text != "")
            {
                ActualizarOrganismo();
                Response.Redirect("ListarOrganismos.aspx");
            }
            else
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Correct", "alert('Complete el campo: NOMBRE.')", true);
            }
        }
        private void ActualizarOrganismo()
        {
            Organismo organismo = new Organismo();

            organismo.IdOrganismo = id;
            organismo.Nombre = txtNombre.Text;
            organismo.Telefono = txtTelefono.Text;
            organismo.CorreoElectronico = txtCorreoElectronico.Text;
            organismo.Observaciones = txtObservaciones.Text;
            organismo.Domicilio = txtDomicilio.Text;

            if (ddlLocalidad.SelectedValue != "-1")
            {
                organismo.IdLocalidad = localidadNego.TraerLocalidadIdSegunItem(ddlLocalidad.SelectedItem.ToString());
            }

            organismoNego.ActualizarOrganismo(organismo);
        }
    }
}