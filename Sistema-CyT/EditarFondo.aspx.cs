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
    public partial class EditarFondo : System.Web.UI.Page
    {
        FondoNego fondoNego = new FondoNego();
        OrigenNego origenNego = new OrigenNego();
        IEnumerable<Fondo> listaFondos;
        static int id;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                CargarListaFondos();
                LlenarListaOrigenes();
                LlenarGrillaFondos();
            }
        }

        private void LlenarGrillaFondos()
        {
            dgvFondo.Columns[0].Visible = true;
            dgvFondo.Columns[1].Visible = true;
            dgvFondo.Columns[2].Visible = true;
            dgvFondo.Columns[3].Visible = true;
            dgvFondo.Columns[4].Visible = true;

            dgvFondo.DataSource = fondoNego.MostrarFondos().ToList();
            dgvFondo.DataBind();

            dgvFondo.Columns[0].Visible = false;
            dgvFondo.Columns[4].Visible = false;
        }

        private void LlenarListaOrigenes()
        {
            ddlOrigen.DataSource = origenNego.MostrarOrigenes().ToList();
            ddlOrigen.DataValueField = "idOrigen";
            ddlOrigen.DataBind();
        }

        private void CargarListaFondos()
        {
            listaFondos = fondoNego.MostrarFondos();

            ddlActualizarFondo.DataSource = listaFondos.ToList();
            ddlActualizarFondo.DataTextField = "nombre";
            ddlActualizarFondo.DataValueField = "idFondo";
            ddlActualizarFondo.DataBind();
        }

        protected void btnActualizarFondo_Click(object sender, EventArgs e)
        {
            if ((txtNombre.Text != "") && (txtDecripcion.Text != ""))
            {
                ActualizarFondo();
                Response.Redirect("ListarFondos.aspx");
            }
        }

        private void ActualizarFondo()
        {
            Fondo fondo = new Fondo();

            fondo.IdFondo = id;
            fondo.Nombre = txtNombre.Text;
            fondo.Descripcion = txtDecripcion.Text;
            fondo.IdOrigen = Convert.ToInt32(ddlOrigen.Text);

            if (chkActivo.Checked) { fondo.Activo = true; }
            else if (!chkActivo.Checked) { fondo.Activo = false; }

            fondoNego.ActualizarFondo(fondo);

            txtNombre.Text = "";
            txtDecripcion.Text = "";
            LlenarGrillaFondos();
        }

        protected void ddlActualizarFondo_SelectedIndexChanged(object sender, EventArgs e)
        {
            //OBTENGO EL ID DEL FONDO SELECCIONADO DESDE EL DROPDOWNLIST
            id = Convert.ToInt32(ddlActualizarFondo.SelectedValue.ToString());

            Fondo fondo = fondoNego.ObtenerFondo(id);

            txtNombre.Text = fondo.Nombre.ToString();
            txtDecripcion.Text = fondo.Descripcion.ToString();
            ddlOrigen.Text = Convert.ToString(fondo.IdOrigen);

            if (fondo.Activo.Value == true)
            {
                chkActivo.Checked = true;
            }
            else if (fondo.Activo.Value == false)
            {
                chkActivo.Checked = false;
            }
        }

        protected void btnModalOrigenGuardar_Click(object sender, EventArgs e)
        {
            Origen origen = new Origen();

            origen.Nombre = txtOrigenModal.Text;

            int idOrigenActual = origenNego.GuardarOrigen(origen);

            ddlOrigen.Items.Clear();

            LlenarListaOrigenes();

            ddlOrigen.Text = Convert.ToString(idOrigenActual);
        }
    }
}