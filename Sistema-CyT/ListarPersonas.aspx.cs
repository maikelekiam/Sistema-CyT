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
    public partial class ListarPersonas : System.Web.UI.Page
    {
        PersonaNego personaNego = new PersonaNego();
        LocalidadNego localidadNego = new LocalidadNego();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack) return;

            MostrarGrillaPersonas(); //SIRVE PARA LA GRILLA
        }
        //Muestra los datos de las personas en la GRILLA
        private void MostrarGrillaPersonas()
        {
            dgvPersona.DataSource = personaNego.MostrarPersonas().ToList();
            dgvPersona.DataBind();

            dgvPersona.Columns[0].Visible = false;
        }

        protected void dgvPersona_RowCommand(object sender, GridViewCommandEventArgs e)
        {

        }
    }
}