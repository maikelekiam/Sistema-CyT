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

namespace CapaDominio	
{
	public partial class pr01ResultSet0
	{
		private int _idConvocatoria;
		public virtual int idConvocatoria
		{
			get
			{
				return this._idConvocatoria;
			}
			set
			{
				this._idConvocatoria = value;
			}
		}
		
		private string _nombre;
		public virtual string nombre
		{
			get
			{
				return this._nombre;
			}
			set
			{
				this._nombre = value;
			}
		}
		
		private int? _anio;
		public virtual int? anio
		{
			get
			{
				return this._anio;
			}
			set
			{
				this._anio = value;
			}
		}
		
		private int? _idFondo;
		public virtual int? idFondo
		{
			get
			{
				return this._idFondo;
			}
			set
			{
				this._idFondo = value;
			}
		}
		
		private int? _idTipoFinanciamiento;
		public virtual int? idTipoFinanciamiento
		{
			get
			{
				return this._idTipoFinanciamiento;
			}
			set
			{
				this._idTipoFinanciamiento = value;
			}
		}
		
		private int? _idTipoConvocatoria;
		public virtual int? idTipoConvocatoria
		{
			get
			{
				return this._idTipoConvocatoria;
			}
			set
			{
				this._idTipoConvocatoria = value;
			}
		}
		
		private DateTime? _fechaApertura;
		public virtual DateTime? fechaApertura
		{
			get
			{
				return this._fechaApertura;
			}
			set
			{
				this._fechaApertura = value;
			}
		}
		
		private DateTime? _fechaCierre;
		public virtual DateTime? fechaCierre
		{
			get
			{
				return this._fechaCierre;
			}
			set
			{
				this._fechaCierre = value;
			}
		}
		
		private bool? _abierta;
		public virtual bool? abierta
		{
			get
			{
				return this._abierta;
			}
			set
			{
				this._abierta = value;
			}
		}
		
		private bool? _activa;
		public virtual bool? activa
		{
			get
			{
				return this._activa;
			}
			set
			{
				this._activa = value;
			}
		}
		
	}
}
#pragma warning restore 1591
