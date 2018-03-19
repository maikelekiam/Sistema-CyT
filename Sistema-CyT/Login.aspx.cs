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
    public partial class Login : System.Web.UI.Page
    {
        UsuarioNego usuarioNego = new UsuarioNego();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnlogin_Click(object sender, EventArgs e)
        {
            Usuario usuario = ValidateUserDetail(txtuserid.Text, txtpassword.Text);
            if (usuario != null)
            {
                Session["userlogin"] = txtuserid.Text;

                Session["userid"] = Convert.ToString(usuario.IdUsuario);

                Session["usergrupo"] = Convert.ToString(usuario.Grupo);

                Session["usermail"] = Convert.ToString(usuario.Mail);

                Response.Redirect("Default.aspx");
            }
            else
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Correct", "alert('Usuario/Contraseña incorrecta.')", true);
            }
        }

        public Usuario ValidateUserDetail(string username, string password)
        {
            return usuarioNego.ObtenerUsuario(username, password);
        }
    }
}