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
    public partial class AgregarActividad : System.Web.UI.Page
    {

        public static List<int> listaDia = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25, 26, 27, 28, 29, 30, 31 };
        public static List<string> listaMes = new List<string> { "Enero", "Febrero", "Marzo", "Abril", "Mayo", "Junio", "Julio", "Agosto", "Setiembre", "Octubre", "Noviembre", "Diciembre" };
        public static List<int> listaAnio = new List<int>();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack) return;

            listaAnio.Clear();

            LlenarFechas();
        }

        private void LlenarFechas()
        {
            int anioHoy = DateTime.Now.Year;
            for (int i = 0; i < 100; i++) { listaAnio.Add(anioHoy - i); }

            ddlDia.DataSource = listaDia;
            ddlDia.DataBind();
            ddlMes.DataSource = listaMes;
            ddlMes.DataBind();

            ddlAnio.DataSource = listaAnio;
            ddlAnio.DataBind();
        }
    }
        
}