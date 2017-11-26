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
    public partial class AltaPersona : System.Web.UI.Page
    {
        PersonaNego personaNego = new PersonaNego();
        LocalidadNego localidadNego = new LocalidadNego();
        public static int idPersonaSeleccionada;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack) return;

            ListarPersonas(); //SIRVE PARA LA GRILLA
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
        private void ListarPersonas()
        {
            dgvPersona.DataSource = personaNego.MostrarPersonas().ToList();
            dgvPersona.DataBind();

            dgvPersona.Columns[0].Visible = false;
        }

        protected void btnGuardarPersona_Click(object sender, EventArgs e)
        {
            if ((txtNombre.Text != "") && (txtApellido.Text != ""))
            {
                GuardarPersona();
                ListarPersonas();
                Response.Redirect("ListarPersonas.aspx");
            }
            else
            {
                //NO SE PUEDE GUARDAR LOS DATOS
            }
        }
        private void GuardarPersona()
        {
            Persona persona = new Persona();

            persona.Nombre = txtNombre.Text;
            persona.Apellido = txtApellido.Text;
            persona.TipoDocumento = ddlTipoDocumento.SelectedValue.ToString();
            persona.Documento = txtDocumento.Text;
            persona.Telefono = txtTelefono.Text;
            persona.CorreoElectronico = txtCorreoElectronico.Text;
            persona.Domicilio = txtDomicilio.Text;
            persona.Observaciones = txtObservaciones.Text;

            if (ddlLocalidad.SelectedValue != "-1" )
            {
                persona.Localidad = localidadNego.TraerLocalidadIdSegunItem(ddlLocalidad.SelectedItem.ToString());
            }

            personaNego.GuardarPersona(persona);
        }
    }
}