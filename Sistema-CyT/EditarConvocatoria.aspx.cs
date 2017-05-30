﻿using System;
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
    public partial class EditarConvocatoria : System.Web.UI.Page
    {
        private ConvocatoriaNego convocatoriaNego = new ConvocatoriaNego();
        private FondoNego fondoNego = new FondoNego();
        private TipoFinanciamientoNego tipoFinanciamientoNego = new TipoFinanciamientoNego();
        private TipoConvocatoriaNego tipoConvocatoriaNego = new TipoConvocatoriaNego();
        private ModalidadNego modalidadNego = new ModalidadNego();

        IEnumerable<Convocatorium> listaConvocatorias;

        static int id;

        static List<Modalidad> listaConvocatoriaModalidades = new List<Modalidad>();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                CargarListaConvocatorias();
                LlenarListaFondos();
                LlenarListaTipofinanciamiento();
                LlenarListaTipoConvocatoria();
                LlenarGrillaModalidades();
            }
        }

        private void CargarListaConvocatorias()
        {
            listaConvocatorias = convocatoriaNego.MostrarConvocatorias();

            ddlActualizarConvocatoria.DataSource = listaConvocatorias.ToList();
            ddlActualizarConvocatoria.DataTextField = "nombre";
            ddlActualizarConvocatoria.DataValueField = "idConvocatoria";
            ddlActualizarConvocatoria.DataBind();
        }
        private void LlenarListaFondos()
        {
            ddlFondo.DataSource = fondoNego.MostrarFondos().ToList();
            ddlFondo.DataValueField = "idFondo";
            ddlFondo.DataBind();
        }
        private void LlenarListaTipofinanciamiento()
        {
            ddlTipoFinanciamiento.DataSource = tipoFinanciamientoNego.MostrarTipoFinanciamientoes().ToList();
            ddlTipoFinanciamiento.DataValueField = "idTipoFinanciamiento";
            ddlTipoFinanciamiento.DataBind();
        }
        private void LlenarListaTipoConvocatoria()
        {
            ddlTipoConvocatoria.DataSource = tipoConvocatoriaNego.MostrarTipoConvocatorias().ToList();
            ddlTipoConvocatoria.DataValueField = "idTipoConvocatoria";
            ddlTipoConvocatoria.DataBind();
        }

        private void LlenarGrillaModalidades()
        {
            dgvModalidades.DataSource = listaConvocatoriaModalidades;
            dgvModalidades.DataBind();
        }

        protected void btnActualizarConvocatoria_Click(object sender, EventArgs e)
        {
            



        }

        protected void ddlActualizarConvocatoria_SelectedIndexChanged(object sender, EventArgs e)
        {
            id = Convert.ToInt32(ddlActualizarConvocatoria.SelectedValue.ToString());

            Convocatorium convocatoria = convocatoriaNego.ObtenerConvocatoria(id);

            txtNombre.Text = convocatoria.Nombre.ToString();
            txtDescripcion.Text = convocatoria.Descripcion.ToString();
            txtObjetivo.Text = convocatoria.Objetivo.ToString();
            txtAnio.Text = convocatoria.Anio.ToString();
            ddlFondo.Text = Convert.ToString(convocatoria.IdFondo);
            ddlTipoConvocatoria.Text = Convert.ToString(convocatoria.IdTipoConvocatoria);
            ddlTipoFinanciamiento.Text = Convert.ToString(convocatoria.IdTipoFinanciamiento);
            txtFechaApertura.Text = Convert.ToDateTime(convocatoria.FechaApertura).ToShortDateString();
            txtFechaCierre.Text = Convert.ToDateTime(convocatoria.FechaCierre).ToShortDateString();

            if (convocatoria.Abierta.Value == true)
            {
                chkAbierta.Checked = true;
            }
            else if (convocatoria.Abierta.Value == false)
            {
                chkAbierta.Checked = false;
            }

            //AHORA TENGO QUE TRAER UNA LISTA DE MODALIDADES SEGUN EL IdConvocatoriaActual




        }
    }
}