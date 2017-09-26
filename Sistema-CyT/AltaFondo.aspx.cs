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
    public partial class AltaFondo : System.Web.UI.Page
    {
        private FondoNego fondoNego = new FondoNego();
        private OrigenNego origenNego = new OrigenNego();
        public static int idOrigenActual=0;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                LlenarListaOrigenes();
                LlenarGrillaFondos();
            }
        }

        private void LlenarListaOrigenes()
        {
            ddlOrigen.DataSource = origenNego.MostrarOrigenes().ToList();
            ddlOrigen.DataValueField = "nombre";
            ddlOrigen.DataBind();
        }

        private void LlenarGrillaFondos()
        {
            dgvFondo.Columns[0].Visible = true;
            dgvFondo.Columns[1].Visible = true;
            dgvFondo.Columns[2].Visible = true;
            dgvFondo.Columns[3].Visible = true;
            dgvFondo.Columns[4].Visible = true;

            dgvFondo.DataSource = fondoNego.MostrarFondos().OrderBy(c => c.Nombre).ToList();
            dgvFondo.DataBind();

            dgvFondo.Columns[0].Visible = false;
            dgvFondo.Columns[4].Visible = false;
        }

        protected void btnGuardarFondo_Click(object sender, EventArgs e)
        {
            if ((txtNombre.Text != "") && (txtDecripcion.Text != ""))
            {
                GuardarFondo();
                LlenarGrillaFondos();
                Response.Redirect("ListarFondos.aspx");
            }
        }

        private void GuardarFondo()
        {
            Fondo fondo = new Fondo();

            fondo.Nombre = txtNombre.Text;
            fondo.Descripcion = txtDecripcion.Text;
            fondo.IdOrigen = origenNego.TraerOrigenIdSegunItem(ddlOrigen.SelectedItem.ToString());
            fondo.Activo = true;
            fondo.Telefono = txtTelefono.Text;
            fondo.Direccion = txtDireccion.Text;
            fondo.Contacto = txtContacto.Text;

            fondoNego.GuardarFondo(fondo);

            LlenarGrillaFondos();
        }

        private string TraerOrigenSegunIdFondo(int id)
        {
            return origenNego.TraerOrigenSegunIdFondo(id);
        }

        protected void btnModalOrigenGuardar_Click(object sender, EventArgs e)
        {
            Origen origen = new Origen();

            origen.Nombre = txtOrigenModal.Text;

            idOrigenActual = origenNego.GuardarOrigen(origen);

            ddlOrigen.Items.Clear();
            ddlOrigen.Text = TraerOrigen(idOrigenActual);
            LlenarListaOrigenes();
        }

        private string TraerOrigen(int id)
        {
            return origenNego.TraerOrigen(id);
        }
    }
}