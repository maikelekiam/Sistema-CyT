﻿using System;
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

        public static int idPersonaSeleccionada;

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
        protected void dgvPersona_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow row = this.dgvPersona.SelectedRow;

            idPersonaSeleccionada = Convert.ToInt32(row.Cells[0].Text);

            Response.Redirect("ActuacionesPersona.aspx");
        }
    }
}