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
	public partial class ListaConvocatoriaModalidad
	{
		private int idModalidad;
		public virtual int IdModalidad
		{
			get
			{
				return this.idModalidad;
			}
			set
			{
				this.idModalidad = value;
			}
		}
		
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
		
	}
}
#pragma warning restore 1591
