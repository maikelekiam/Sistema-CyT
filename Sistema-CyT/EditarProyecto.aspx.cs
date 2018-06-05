using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;
using CapaDominio;
using CapaNegocio;
using System.Globalization;

namespace Sistema_CyT
{
    public partial class EditarProyecto : System.Web.UI.Page
    {
        LocalidadNego localidadNego = new LocalidadNego();
        PersonaNego personaNego = new PersonaNego();
        EmpresaNego empresaNego = new EmpresaNego();
        FondoNego fondoNego = new FondoNego();
        ConvocatoriaNego convocatoriaNego = new ConvocatoriaNego();
        EtapaNego etapaNego = new EtapaNego();
        ProyectoNego proyectoNego = new ProyectoNego();
        TipoEstadoNego tipoEstadoNego = new TipoEstadoNego();
        TipoProyectoNego tipoProyectoNego = new TipoProyectoNego();
        TematicaNego tematicaNego = new TematicaNego();
        SectorNego sectorNego = new SectorNego();

        List<pr02ResultSet0> listaProyectosFiltrados = new List<pr02ResultSet0>();

        public static int idProyectoActual;
        public static int idEmpresaActual = 0;
        public static int idLocalidadActual = 0;
        public static int idPersonaActual = 0;
        public static int idConvocatoriaSeleccionada = 1;
        public static int idFondoSeleccionado = 1;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack) return;

            PanelInformacion.Visible = false;
            btnActualizarProyecto.Visible = false;

            MostrarLocalidad(); //SIRVE PARA EL DROP DOWN LIST
            MostrarPersona(); //SIRVE PARA EL DROP DOWN LIST
            MostrarEmpresa(); // SIRVE PARA EL DROP DOWN LIST
            MostrarConvocatoria(); // SIRVE PARA EL DROP DOWN LIST
            LlenarListaTipoEstados(); // SIRVE PARA EL DROP DOWN LIST
            LimpiarFormulario();
            LlenarListaFondoChoice();
            LlenarListaTipoProyectos(); // SIRVE PARA EL DROP DOWN LIST

            LlenarListaSectores();
            LlenarListaTematicas();
        }

        //Muestra en el DROPDOWNLIST los SECTORES
        private void LlenarListaSectores()
        {
            ddlSector.DataSource = sectorNego.MostrarSectores().ToList();
            ddlSector.DataValueField = "nombre";
            ddlSector.DataBind();
        }
        //Muestra en el DROPDOWNLIST las TEMATICAS
        private void LlenarListaTematicas()
        {
            ddlTematica.DataSource = tematicaNego.MostrarTematicas().ToList();
            ddlTematica.DataValueField = "nombre";
            ddlTematica.DataBind();
        }
        private void LlenarListaTipoProyectos()
        {
            ddlTipoProyecto.DataSource = tipoProyectoNego.MostrarTipoProyectos().ToList();
            ddlTipoProyecto.DataValueField = "nombre";
            ddlTipoProyecto.DataBind();
        }
        private void LlenarListaFondoChoice()
        {
            ddlFondoChoice.DataSource = fondoNego.MostrarFondos().ToList();
            ddlFondoChoice.DataValueField = "idFondo";
            ddlFondoChoice.DataBind();
        }

        //Muestra en el DROPDOWNLIST los Tipos de Estado
        private void LlenarListaTipoEstados()
        {
            ddlTipoEstado.DataSource = tipoEstadoNego.MostrarTipoEstados().ToList();
            ddlTipoEstado.DataValueField = "nombre";
            ddlTipoEstado.DataBind();
        }

        //Muestra en el DROPDOWNLIST las CONVOCATORIAS
        private void MostrarConvocatoria()
        {
            ddlConvocatoria.DataSource = convocatoriaNego.MostrarConvocatorias().OrderBy(c => c.Nombre).ToList();
            ddlConvocatoria.DataValueField = "IdConvocatoria";
            ddlConvocatoria.DataBind();
        }

        //Muestra en el DROPDOWNLIST las LOCALIDADES
        private void MostrarLocalidad()
        {
            ddlLocalidad.DataSource = localidadNego.MostrarLocalidades().ToList();
            ddlLocalidad.DataValueField = "nombre";
            ddlLocalidad.DataBind();
        }

        //Muestra en el DROPDOWNLIST las EMPRESAS
        private void MostrarEmpresa()
        {
            ddlEmpresa.DataSource = empresaNego.MostrarEmpresas().OrderBy(c => c.Nombre).ToList();
            ddlEmpresa.DataValueField = "nombre";
            ddlEmpresa.DataBind();
        }

        //Muestra en el DROPDOWNLIST las PERSONAS
        private void MostrarPersona()
        {
            ddlContacto.DataSource = personaNego.MostrarPersonas().ToList();
            IList<Persona> nombreCompleto = personaNego.MostrarPersonas().Select(p => new Persona() { Nombre = p.Apellido + "," + p.Nombre, IdPersona = p.IdPersona }).OrderBy(c => c.IdPersona).ToList();
            ddlContacto.DataSource = nombreCompleto;
            ddlContacto.DataValueField = "nombre";
            ddlContacto.DataBind();
        }




        //PRIMERO ELIJO EL FONDO
        protected void ddlFondoChoice_SelectedIndexChanged(object sender, EventArgs e)
        {
            LimpiarFormulario();

            if (ddlFondoChoice.SelectedValue != "-1")
            {
                idFondoSeleccionado = Convert.ToInt32(ddlFondoChoice.SelectedValue);

                LlenarChoiceConvocatorias(idFondoSeleccionado);

                if (fondoNego.ObtenerFondo(Convert.ToInt32(ddlFondoChoice.SelectedValue)).Nombre.ToUpper() == "COFECYT")
                {
                    //la puse recien
                    Response.Redirect("EditarProyectoCofecyt.aspx");
                }
                else
                {
                    PanelInformacion.Visible = true;
                    btnActualizarProyecto.Visible = true;
                }
            }
            else
            {
                Response.Redirect("EditarProyecto.aspx");
            }
        }

        private void LlenarChoiceConvocatorias(int id)
        {
            ddlConvocatoriaChoice.DataSource = convocatoriaNego.ListarChoiceConvocatorias(id);
            ddlConvocatoriaChoice.DataTextField = "nombre";
            ddlConvocatoriaChoice.DataValueField = "idConvocatoria";
            ddlConvocatoriaChoice.DataBind();

            if (ddlConvocatoriaChoice.SelectedValue != "")
            {
                idConvocatoriaSeleccionada = Convert.ToInt32(ddlConvocatoriaChoice.SelectedValue);

                ddlProyectoChoice.DataSource = proyectoNego.ListarChoiceProyectos(idConvocatoriaSeleccionada).ToList();
                ddlProyectoChoice.DataTextField = "nombre";
                ddlProyectoChoice.DataValueField = "idProyecto";
                ddlProyectoChoice.DataBind();

                //aca habria que cargar el 1er proyecto filtrado automaticamente

                //1ro hay que averiguar si existe al menos 1 proyecto o la lista viene vacia

                if (ddlProyectoChoice.SelectedValue != "")
                {
                    idProyectoActual = Convert.ToInt32(ddlProyectoChoice.SelectedValue);

                    Proyecto proyecto = proyectoNego.ObtenerProyecto(idProyectoActual);

                    if (proyecto == null)
                    {
                        LimpiarFormulario();

                        return;
                    }
                    else
                    {
                        txtNombre.Text = proyecto.Nombre.ToString();
                        txtNumeroExp.Text = proyecto.NumeroExpediente.ToString();
                        txtCodigoInterno.Text = proyecto.CodigoInterno.ToString();

                        txtDestinatarios.Text = proyecto.Destinatarios;
                        txtObjetivos.Text = proyecto.Objetivos;

                        ddlConvocatoria.Text = Convert.ToString(proyecto.IdConvocatoria);
                        txtMontoSolicitado.Text = Convert.ToString(proyecto.MontoSolicitado);
                        txtMontoContraparte.Text = Convert.ToString(proyecto.MontoContraparte);
                        txtMontoTotal.Text = Convert.ToString(proyecto.MontoTotal);
                        txtDescripcion.Text = proyecto.Descripcion.ToString();
                        txtObservaciones.Text = proyecto.Observaciones.ToString();

                        //ddlContacto.Text = personaNego.TraerPersona(proyecto.IdPersona.Value);

                        if (proyecto.IdEmpresa == null) { ddlEmpresa.Text = "-1"; }
                        else { ddlEmpresa.Text = empresaNego.TraerEmpresa(proyecto.IdEmpresa.Value); }

                        if (proyecto.IdSector == null) { ddlSector.Text = "-1"; }
                        else { ddlSector.Text = sectorNego.TraerSector(proyecto.IdSector.Value); }

                        if (proyecto.IdTematica == null) { ddlTematica.Text = "-1"; }
                        else { ddlTematica.Text = tematicaNego.TraerTematica(proyecto.IdTematica.Value); }

                        if (proyecto.IdPersona == null) { ddlContacto.Text = "-1"; }
                        else { ddlContacto.Text = personaNego.TraerPersona(proyecto.IdPersona.Value); }

                        if (proyecto.IdLocalidad == null) { ddlLocalidad.Text = "-1"; }
                        else { ddlLocalidad.Text = localidadNego.TraerLocalidad(proyecto.IdLocalidad.Value); }

                        if (proyecto.IdTipoEstado == null) { ddlTipoEstado.Text = "-1"; }
                        else { ddlTipoEstado.Text = tipoEstadoNego.TraerTipoEstado(proyecto.IdTipoEstado.Value); }

                        if (proyecto.IdTipoProyecto == null) { ddlTipoProyecto.Text = "-1"; }
                        else { ddlTipoProyecto.Text = tipoProyectoNego.TraerTipoProyecto(proyecto.IdTipoProyecto.Value); }

                        //ddlLocalidad.Text = localidadNego.TraerLocalidad(proyecto.IdLocalidad.Value);
                        //ddlTipoEstado.Text = tipoEstadoNego.TraerTipoEstado(proyecto.IdTipoEstado.Value);
                        //ddlTipoProyecto.Text = tipoProyectoNego.TraerTipoProyecto(proyecto.IdTipoProyecto.Value);

                        //AHORA TENGO QUE TRAER UNA LISTA DE ETAPAS SEGUN EL IdProyectoActual

                        //fin rutina para cargar el 1er proyecto
                    }
                }
                else
                {
                    LimpiarFormulario();
                }

            }
            else
            {
                ddlProyectoChoice.DataSource = listaProyectosFiltrados.ToList();
                ddlProyectoChoice.DataBind();
            }
        }

        protected void ddlConvocatoriaChoice_SelectedIndexChanged(object sender, EventArgs e)
        {
            LimpiarFormulario();

            idConvocatoriaSeleccionada = Convert.ToInt32(ddlConvocatoriaChoice.SelectedValue.ToString());

            if (fondoNego.ObtenerFondo(Convert.ToInt32(ddlFondoChoice.SelectedValue)).Nombre.ToUpper() == "COFECYT")
            {
                //la puse recien
                Response.Redirect("EditarProyectoCofecyt.aspx");
            }
            else
            {
                ddlProyectoChoice.DataSource = proyectoNego.ListarChoiceProyectos(idConvocatoriaSeleccionada).ToList();
                ddlProyectoChoice.DataTextField = "nombre";
                ddlProyectoChoice.DataBind();

                //aca habria que cargar el 1er proyecto
                if (ddlProyectoChoice.SelectedValue != "")
                {
                    idProyectoActual = Convert.ToInt32(ddlProyectoChoice.SelectedValue);

                    Proyecto proyecto = proyectoNego.ObtenerProyecto(idProyectoActual);

                    if (proyecto == null)
                    {
                        LimpiarFormulario();
                        return;
                    }

                    txtNombre.Text = proyecto.Nombre.ToString();
                    txtNumeroExp.Text = proyecto.NumeroExpediente.ToString();
                    txtCodigoInterno.Text = proyecto.CodigoInterno.ToString();

                    txtObjetivos.Text = proyecto.Objetivos;
                    txtDestinatarios.Text = proyecto.Destinatarios;
                    //ddlSector.Text = sectorNego.TraerSector(proyecto.IdSector.Value);
                    //ddlTematica.Text = tematicaNego.TraerTematica(proyecto.IdTematica.Value);


                    ddlConvocatoria.Text = Convert.ToString(proyecto.IdConvocatoria);
                    txtMontoSolicitado.Text = Convert.ToString(proyecto.MontoSolicitado);
                    txtMontoContraparte.Text = Convert.ToString(proyecto.MontoContraparte);
                    txtMontoTotal.Text = Convert.ToString(proyecto.MontoTotal);
                    txtDescripcion.Text = proyecto.Descripcion.ToString();
                    txtObservaciones.Text = proyecto.Observaciones.ToString();

                    //ddlContacto.Text = personaNego.TraerPersona(proyecto.IdPersona.Value);

                    //if (proyecto.IdEmpresa == null)
                    //{
                    //    ddlEmpresa.Text = "-1";
                    //}
                    //else
                    //{
                    //    ddlEmpresa.Text = empresaNego.TraerEmpresa(proyecto.IdEmpresa.Value);
                    //}

                    //ddlLocalidad.Text = localidadNego.TraerLocalidad(proyecto.IdLocalidad.Value);
                    //ddlTipoEstado.Text = tipoEstadoNego.TraerTipoEstado(proyecto.IdTipoEstado.Value);
                    //ddlTipoProyecto.Text = tipoProyectoNego.TraerTipoProyecto(proyecto.IdTipoProyecto.Value);


                    if (proyecto.IdEmpresa == null) { ddlEmpresa.Text = "-1"; }
                    else { ddlEmpresa.Text = empresaNego.TraerEmpresa(proyecto.IdEmpresa.Value); }

                    if (proyecto.IdSector == null) { ddlSector.Text = "-1"; }
                    else { ddlSector.Text = sectorNego.TraerSector(proyecto.IdSector.Value); }

                    if (proyecto.IdTematica == null) { ddlTematica.Text = "-1"; }
                    else { ddlTematica.Text = tematicaNego.TraerTematica(proyecto.IdTematica.Value); }

                    if (proyecto.IdPersona == null) { ddlContacto.Text = "-1"; }
                    else { ddlContacto.Text = personaNego.TraerPersona(proyecto.IdPersona.Value); }

                    if (proyecto.IdLocalidad == null) { ddlLocalidad.Text = "-1"; }
                    else { ddlLocalidad.Text = localidadNego.TraerLocalidad(proyecto.IdLocalidad.Value); }

                    if (proyecto.IdTipoEstado == null) { ddlTipoEstado.Text = "-1"; }
                    else { ddlTipoEstado.Text = tipoEstadoNego.TraerTipoEstado(proyecto.IdTipoEstado.Value); }

                    if (proyecto.IdTipoProyecto == null) { ddlTipoProyecto.Text = "-1"; }
                    else { ddlTipoProyecto.Text = tipoProyectoNego.TraerTipoProyecto(proyecto.IdTipoProyecto.Value); }

                    //AHORA TENGO QUE TRAER UNA LISTA DE ETAPAS SEGUN EL IdProyectoActual

                    //fin rutina para cargar el 1er proyecto
                }
                else
                {
                    LimpiarFormulario();
                }
            }
        }


        protected void ddlProyectoChoice_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (fondoNego.ObtenerFondo(Convert.ToInt32(ddlFondoChoice.SelectedValue)).Nombre.ToUpper() == "COFECYT")
            {
                //la puse recien
                Response.Redirect("EditarProyectoCofecyt.aspx");

            }
            else
            {
                idProyectoActual = Convert.ToInt32(ddlProyectoChoice.SelectedValue.ToString());

                Proyecto proyecto = proyectoNego.ObtenerProyecto(idProyectoActual);

                if (proyecto == null)
                {
                    LimpiarFormulario();
                    return;
                }

                txtNombre.Text = proyecto.Nombre.ToString();
                txtNumeroExp.Text = proyecto.NumeroExpediente.ToString();
                txtCodigoInterno.Text = proyecto.CodigoInterno.ToString();
                txtObjetivos.Text = proyecto.Objetivos;
                txtDestinatarios.Text = proyecto.Destinatarios;

                ddlConvocatoria.Text = Convert.ToString(proyecto.IdConvocatoria);
                txtMontoSolicitado.Text = Convert.ToString(proyecto.MontoSolicitado);
                txtMontoContraparte.Text = Convert.ToString(proyecto.MontoContraparte);
                txtMontoTotal.Text = Convert.ToString(proyecto.MontoTotal);
                txtDescripcion.Text = proyecto.Descripcion.ToString();
                txtObservaciones.Text = proyecto.Observaciones.ToString();

                if (proyecto.IdSector == null) { ddlSector.Text = "-1"; }
                else { ddlSector.Text = sectorNego.TraerSector(proyecto.IdSector.Value); }

                if (proyecto.IdTematica == null) { ddlTematica.Text = "-1"; }
                else { ddlTematica.Text = tematicaNego.TraerTematica(proyecto.IdTematica.Value); }

                if (proyecto.IdPersona == null) { ddlContacto.Text = "-1"; }
                else { ddlContacto.Text = personaNego.TraerPersona(proyecto.IdPersona.Value); }

                if (proyecto.IdEmpresa == null) { ddlEmpresa.Text = "-1"; }
                else { ddlEmpresa.Text = empresaNego.TraerEmpresa(proyecto.IdEmpresa.Value); }

                if (proyecto.IdLocalidad == null) { ddlLocalidad.Text = "-1"; }
                else { ddlLocalidad.Text = localidadNego.TraerLocalidad(proyecto.IdLocalidad.Value); }

                if (proyecto.IdTipoEstado == null) { ddlTipoEstado.Text = "-1"; }
                else { ddlTipoEstado.Text = tipoEstadoNego.TraerTipoEstado(proyecto.IdTipoEstado.Value); }

                if (proyecto.IdTipoProyecto == null) { ddlTipoProyecto.Text = "-1"; }
                else { ddlTipoProyecto.Text = tipoProyectoNego.TraerTipoProyecto(proyecto.IdTipoProyecto.Value); }

                //AHORA TENGO QUE TRAER UNA LISTA DE ETAPAS SEGUN EL IdProyectoActual
            }
        }

        protected void btnModalContactoGuardar_Click(object sender, EventArgs e)
        {
            Persona persona = new Persona();

            persona.Nombre = txtContactoNombreModal.Text;
            persona.Apellido = txtContactoApellidoModal.Text;
            persona.Telefono = txtContactoTelefonoModal.Text;
            persona.CorreoElectronico = txtContactoCorreoElectronicoModal.Text;

            idPersonaActual = personaNego.GuardarPersona(persona);

            ddlContacto.Items.Clear();
            ddlContacto.Text = TraerPersona(idPersonaActual);
            MostrarPersona();
        }
        private string TraerPersona(int id)
        {
            return personaNego.TraerPersona(id);
        }

        protected void btnModalEmpresaGuardar_Click(object sender, EventArgs e)
        {
            Empresa empresa = new Empresa();

            empresa.Nombre = txtEmpresaNombreModal.Text;
            empresa.Telefono = txtEmpresaTelefonoModal.Text;
            empresa.CorreoElectronico = txtEmpresaCorreoElectronicoModal.Text;

            idEmpresaActual = empresaNego.GuardarEmpresa(empresa);

            ddlEmpresa.Items.Clear();
            ddlEmpresa.Text = TraerEmpresa(idEmpresaActual);
            MostrarEmpresa();
        }

        private string TraerEmpresa(int id)
        {
            return empresaNego.TraerEmpresa(id);
        }

        protected void btnModalLocalidadGuardar_Click(object sender, EventArgs e)
        {
            Localidad localidad = new Localidad();

            localidad.Nombre = txtLocalidadNombreModal.Text;
            localidad.CodigoPostal = txtLocalidadCodigoPostalModal.Text;

            idLocalidadActual = localidadNego.GuardarLocalidad(localidad);

            ddlLocalidad.Items.Clear();
            ddlLocalidad.Text = TraerLocalidad(idLocalidadActual);
            MostrarLocalidad();
        }
        private string TraerLocalidad(int id)
        {
            return localidadNego.TraerLocalidad(id);
        }

        protected void btnActualizarProyecto_Click(object sender, EventArgs e)
        {
            if (
                txtCodigoInterno.Text != ""
                && ddlTipoEstado.SelectedValue != "-1"
                && ddlConvocatoria.SelectedValue != "-1"
                && txtNombre.Text != ""
                && ddlContacto.SelectedValue != "-1"
                && ddlTipoProyecto.SelectedValue != "-1"
                )
            {
                ActualizarProyecto();
                ListarProyectos.codigoInternoProyectoSeleccionado = txtCodigoInterno.Text; //ojo
                ListarProyectos.idConvocatoriaSeleccionada = Convert.ToInt32(ddlConvocatoria.Text);//ojo
                LimpiarFormulario();

                Response.Redirect("MostrarProyecto.aspx");
            }
            else
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Correct", "alert('Complete los campos: NOMBRE, REFERENTE, CODIGO INTERNO, TIPO DE PROYECTO, ESTADO  .')", true);
            }

        }
        private void ActualizarProyecto()
        {
            Proyecto proyecto = new Proyecto();

            proyecto.IdProyecto = idProyectoActual;

            proyecto.Nombre = txtNombre.Text;
            proyecto.NumeroExpediente = txtNumeroExp.Text;
            proyecto.CodigoInterno = txtCodigoInterno.Text;
            proyecto.Destinatarios = txtDestinatarios.Text;
            proyecto.Objetivos = txtObjetivos.Text;
            proyecto.IdConvocatoria = Int32.Parse(ddlConvocatoria.SelectedValue);

            if (txtMontoSolicitado.Text == "") { proyecto.MontoSolicitado = null; }
            else { proyecto.MontoSolicitado = Convert.ToDecimal(txtMontoSolicitado.Text); }

            if (txtMontoContraparte.Text == "") { proyecto.MontoContraparte = null; }
            else { proyecto.MontoContraparte = Convert.ToDecimal(txtMontoContraparte.Text); }

            if (txtMontoTotal.Text == "") { proyecto.MontoTotal = null; }
            else { proyecto.MontoTotal = Convert.ToDecimal(txtMontoTotal.Text); }

            //proyecto.MontoSolicitado = Convert.ToDecimal(txtMontoSolicitado.Text);
            //proyecto.MontoContraparte = Convert.ToDecimal(txtMontoContraparte.Text);
            //proyecto.MontoTotal = Convert.ToDecimal(txtMontoTotal.Text);


            proyecto.Descripcion = txtDescripcion.Text;
            proyecto.Observaciones = txtObservaciones.Text;

            //string cadena = ddlContacto.SelectedItem.ToString();
            //string[] separadas;
            //separadas = cadena.Split(',');
            //string itemApellido = separadas[0];
            //string itemNombre = separadas[1];
            //proyecto.IdPersona = personaNego.TraerPersonaIdSegunItem(itemApellido, itemNombre);

            //proyecto.IdSector = sectorNego.TraerSectorIdSegunItem(ddlSector.SelectedItem.ToString());
            //proyecto.IdTematica = tematicaNego.TraerTematicaIdSegunItem(ddlTematica.SelectedItem.ToString());
            //proyecto.IdEmpresa = empresaNego.TraerEmpresaIdSegunItem(ddlEmpresa.SelectedItem.ToString());
            //proyecto.IdLocalidad = localidadNego.TraerLocalidadIdSegunItem(ddlLocalidad.SelectedItem.ToString());
            //proyecto.IdTipoEstado = tipoEstadoNego.TraerTipoEstadoIdSegunItem(ddlTipoEstado.SelectedItem.ToString());
            //proyecto.IdTipoProyecto = tipoProyectoNego.TraerTipoProyectoIdSegunItem(ddlTipoProyecto.SelectedItem.ToString());

            //PARA EL REFERENTE
            if (ddlContacto.SelectedValue == "-1") { proyecto.IdPersona = null; }
            else
            {
                string cadena = ddlContacto.SelectedItem.ToString();
                string[] separadas;
                separadas = cadena.Split(',');
                string itemApellido = separadas[0];
                string itemNombre = separadas[1];
                proyecto.IdPersona = personaNego.TraerPersonaIdSegunItem(itemApellido, itemNombre);
            }

            //PARA EMPRESA
            if (ddlEmpresa.SelectedValue == "-1") { proyecto.IdEmpresa = null; }
            else { proyecto.IdEmpresa = empresaNego.TraerEmpresaIdSegunItem(ddlEmpresa.SelectedItem.ToString()); }

            //PARA SECTOR
            if (ddlSector.SelectedValue == "-1") { proyecto.IdSector = null; }
            else { proyecto.IdSector = sectorNego.TraerSectorIdSegunItem(ddlSector.SelectedItem.ToString()); }

            //PARA TEMATICA
            if (ddlTematica.SelectedValue == "-1") { proyecto.IdTematica = null; }
            else { proyecto.IdTematica = tematicaNego.TraerTematicaIdSegunItem(ddlTematica.SelectedItem.ToString()); }

            //PARA TIPO ESTADO
            if (ddlTipoEstado.SelectedValue == "-1") { proyecto.IdTipoEstado = null; }
            else { proyecto.IdTipoEstado = tipoEstadoNego.TraerTipoEstadoIdSegunItem(ddlTipoEstado.SelectedItem.ToString()); }

            //PARA LOCALIDAD
            if (ddlLocalidad.SelectedValue == "-1") { proyecto.IdLocalidad = null; }
            else { proyecto.IdLocalidad = localidadNego.TraerLocalidadIdSegunItem(ddlLocalidad.SelectedItem.ToString()); }

            //PARA TIPO PROYECTO
            if (ddlTipoProyecto.SelectedValue == "-1") { proyecto.IdTipoProyecto = null; }
            else { proyecto.IdTipoProyecto = tipoProyectoNego.TraerTipoProyectoIdSegunItem(ddlTipoProyecto.SelectedItem.ToString()); }

            proyectoNego.ActualizarProyecto(proyecto);

            //DESPUES GUARDO LA LISTA DE ETAPAS DEL PROYECTO ACTUAL
            //LimpiarFormulario();
        }

        private void LimpiarFormulario()
        {
            txtNombre.Text = null;
            txtNumeroExp.Text = null;
            txtCodigoInterno.Text = null;
            ddlConvocatoria.SelectedIndex = 0;
            txtMontoSolicitado.Text = null;
            txtMontoContraparte.Text = null;
            txtMontoTotal.Text = null;
            txtDescripcion.Text = null;
            txtObservaciones.Text = null;
            ddlContacto.SelectedIndex = 0;
            ddlEmpresa.SelectedIndex = 0;
            ddlLocalidad.SelectedIndex = 0;
            ddlTipoEstado.SelectedIndex = 0;
        }
    }
}