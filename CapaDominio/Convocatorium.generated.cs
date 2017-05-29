#pragma warning disable 1591
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by the ClassGenerator.ttinclude code generation file.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
using System;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using System.Data.Common;
using System.Collections.Generic;
using Telerik.OpenAccess;
using Telerik.OpenAccess.Metadata;
using Telerik.OpenAccess.Data.Common;
using Telerik.OpenAccess.Metadata.Fluent;
using Telerik.OpenAccess.Metadata.Fluent.Advanced;
using CapaDominio;

namespace CapaDominio	
{
	public partial class Convocatorium
	{
		private int idConvocatoria;
		public virtual int IdConvocatoria
		{
			get
			{
				return this.idConvocatoria;
			}
			set
			{
				this.idConvocatoria = value;
			}
		}
		
		private string nombre;
		public virtual string Nombre
		{
			get
			{
				return this.nombre;
			}
			set
			{
				this.nombre = value;
			}
		}
		
		private string descripcion;
		public virtual string Descripcion
		{
			get
			{
				return this.descripcion;
			}
			set
			{
				this.descripcion = value;
			}
		}
		
		private string objetivo;
		public virtual string Objetivo
		{
			get
			{
				return this.objetivo;
			}
			set
			{
				this.objetivo = value;
			}
		}
		
		private int? anio;
		public virtual int? Anio
		{
			get
			{
				return this.anio;
			}
			set
			{
				this.anio = value;
			}
		}
		
		private int? idFondo;
		public virtual int? IdFondo
		{
			get
			{
				return this.idFondo;
			}
			set
			{
				this.idFondo = value;
			}
		}
		
		private int? idTipoFinanciamiento;
		public virtual int? IdTipoFinanciamiento
		{
			get
			{
				return this.idTipoFinanciamiento;
			}
			set
			{
				this.idTipoFinanciamiento = value;
			}
		}
		
		private int? idTipoConvocatoria;
		public virtual int? IdTipoConvocatoria
		{
			get
			{
				return this.idTipoConvocatoria;
			}
			set
			{
				this.idTipoConvocatoria = value;
			}
		}
		
		private DateTime? fechaApertura;
		public virtual DateTime? FechaApertura
		{
			get
			{
				return this.fechaApertura;
			}
			set
			{
				this.fechaApertura = value;
			}
		}
		
		private DateTime? fechaCierre;
		public virtual DateTime? FechaCierre
		{
			get
			{
				return this.fechaCierre;
			}
			set
			{
				this.fechaCierre = value;
			}
		}
		
		private bool? abierta;
		public virtual bool? Abierta
		{
			get
			{
				return this.abierta;
			}
			set
			{
				this.abierta = value;
			}
		}
		
		private bool? activa;
		public virtual bool? Activa
		{
			get
			{
				return this.activa;
			}
			set
			{
				this.activa = value;
			}
		}
		
		private Fondo fondo;
		public virtual Fondo Fondo
		{
			get
			{
				return this.fondo;
			}
			set
			{
				this.fondo = value;
			}
		}
		
		private TipoConvocatorium tipoConvocatorium;
		public virtual TipoConvocatorium TipoConvocatorium
		{
			get
			{
				return this.tipoConvocatorium;
			}
			set
			{
				this.tipoConvocatorium = value;
			}
		}
		
		private TipoFinanciamiento tipoFinanciamiento;
		public virtual TipoFinanciamiento TipoFinanciamiento
		{
			get
			{
				return this.tipoFinanciamiento;
			}
			set
			{
				this.tipoFinanciamiento = value;
			}
		}
		
		private IList<ListaConvocatoriaModalidad> listaConvocatoriaModalidads = new List<ListaConvocatoriaModalidad>();
		public virtual IList<ListaConvocatoriaModalidad> ListaConvocatoriaModalidads
		{
			get
			{
				return this.listaConvocatoriaModalidads;
			}
		}
		
	}
}
#pragma warning restore 1591
