﻿#pragma warning disable 1591
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by the ContextGenerator.ttinclude code generation file.
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
	public partial class ModeloDeDominio : OpenAccessContext, IModeloDeDominioUnitOfWork
	{
		private static string connectionStringName = @"Conn";
			
		private static BackendConfiguration backend = GetBackendConfiguration();
				
		private static MetadataSource metadataSource = XmlMetadataSource.FromAssemblyResource("EntitiesModel.rlinq");
		
		public ModeloDeDominio()
			:base(connectionStringName, backend, metadataSource)
		{ }
		
		public ModeloDeDominio(string connection)
			:base(connection, backend, metadataSource)
		{ }
		
		public ModeloDeDominio(BackendConfiguration backendConfiguration)
			:base(connectionStringName, backendConfiguration, metadataSource)
		{ }
			
		public ModeloDeDominio(string connection, MetadataSource metadataSource)
			:base(connection, backend, metadataSource)
		{ }
		
		public ModeloDeDominio(string connection, BackendConfiguration backendConfiguration, MetadataSource metadataSource)
			:base(connection, backendConfiguration, metadataSource)
		{ }
			
		public IQueryable<Usuario> Usuarios 
		{
			get
			{
				return this.GetAll<Usuario>();
			}
		}
		
		public IQueryable<TipoFinanciamiento> TipoFinanciamientos 
		{
			get
			{
				return this.GetAll<TipoFinanciamiento>();
			}
		}
		
		public IQueryable<TipoEstadoEtapa> TipoEstadoEtapas 
		{
			get
			{
				return this.GetAll<TipoEstadoEtapa>();
			}
		}
		
		public IQueryable<TipoEstado> TipoEstados 
		{
			get
			{
				return this.GetAll<TipoEstado>();
			}
		}
		
		public IQueryable<TipoConvocatorium> TipoConvocatoria 
		{
			get
			{
				return this.GetAll<TipoConvocatorium>();
			}
		}
		
		public IQueryable<TipoAuditorium> TipoAuditoria 
		{
			get
			{
				return this.GetAll<TipoAuditorium>();
			}
		}
		
		public IQueryable<Proyecto> Proyectos 
		{
			get
			{
				return this.GetAll<Proyecto>();
			}
		}
		
		public IQueryable<Persona> Personas 
		{
			get
			{
				return this.GetAll<Persona>();
			}
		}
		
		public IQueryable<Origen> Origens 
		{
			get
			{
				return this.GetAll<Origen>();
			}
		}
		
		public IQueryable<Organismo> Organismos 
		{
			get
			{
				return this.GetAll<Organismo>();
			}
		}
		
		public IQueryable<Modalidad> Modalidads 
		{
			get
			{
				return this.GetAll<Modalidad>();
			}
		}
		
		public IQueryable<Localidad> Localidads 
		{
			get
			{
				return this.GetAll<Localidad>();
			}
		}
		
		public IQueryable<Fondo> Fondos 
		{
			get
			{
				return this.GetAll<Fondo>();
			}
		}
		
		public IQueryable<Etapa> Etapas 
		{
			get
			{
				return this.GetAll<Etapa>();
			}
		}
		
		public IQueryable<Empresa> Empresas 
		{
			get
			{
				return this.GetAll<Empresa>();
			}
		}
		
		public IQueryable<Desembolso> Desembolsos 
		{
			get
			{
				return this.GetAll<Desembolso>();
			}
		}
		
		public IQueryable<Convocatorium> Convocatoria 
		{
			get
			{
				return this.GetAll<Convocatorium>();
			}
		}
		
		public IQueryable<Auditorium> Auditoria 
		{
			get
			{
				return this.GetAll<Auditorium>();
			}
		}
		
		public IQueryable<Actuacion> Actuacions 
		{
			get
			{
				return this.GetAll<Actuacion>();
			}
		}
		
		public IQueryable<TipoProyecto> TipoProyectos 
		{
			get
			{
				return this.GetAll<TipoProyecto>();
			}
		}
		
		public IQueryable<ViaComunicacion> ViaComunicacions 
		{
			get
			{
				return this.GetAll<ViaComunicacion>();
			}
		}
		
		public IQueryable<ActuacionPersona> ActuacionPersonas 
		{
			get
			{
				return this.GetAll<ActuacionPersona>();
			}
		}
		
		public IQueryable<UdtUvt> UdtUvts 
		{
			get
			{
				return this.GetAll<UdtUvt>();
			}
		}
		
		public IQueryable<TipoEstadoCofecyt> TipoEstadoCofecyts 
		{
			get
			{
				return this.GetAll<TipoEstadoCofecyt>();
			}
		}
		
		public IQueryable<ProyectoCofecyt> ProyectoCofecyts 
		{
			get
			{
				return this.GetAll<ProyectoCofecyt>();
			}
		}
		
		public IQueryable<Tematica> Tematicas 
		{
			get
			{
				return this.GetAll<Tematica>();
			}
		}
		
		public IQueryable<Sector> Sectors 
		{
			get
			{
				return this.GetAll<Sector>();
			}
		}
		
		public IQueryable<EtapaCofecyt> EtapaCofecyts 
		{
			get
			{
				return this.GetAll<EtapaCofecyt>();
			}
		}
		
		public IQueryable<ActividadCofecyt> ActividadCofecyts 
		{
			get
			{
				return this.GetAll<ActividadCofecyt>();
			}
		}
		
		public IQueryable<ActuacionProyectoCofecyt> ActuacionProyectoCofecyts 
		{
			get
			{
				return this.GetAll<ActuacionProyectoCofecyt>();
			}
		}
		
		public IQueryable<Actividad> Actividads 
		{
			get
			{
				return this.GetAll<Actividad>();
			}
		}
		
		public IEnumerable<pr01ResultSet0> Pr01(int? id)
		{
			int returnValue;
			return Pr01(id, out returnValue);
		}
		
		public IEnumerable<pr01ResultSet0> Pr01(int? id, out int returnValue)
		{
			OAParameter parameterReturnValue = new OAParameter();
		    parameterReturnValue.Direction = ParameterDirection.ReturnValue;
		    parameterReturnValue.ParameterName = "parameterReturnValue";
		
			OAParameter parameterId = new OAParameter();
			parameterId.ParameterName = "id";
			if(id.HasValue)
			{
				parameterId.Value = id.Value;
			}
			else
			{
				parameterId.DbType = DbType.Int32;
				parameterId.Value = DBNull.Value;
			}

			IEnumerable<pr01ResultSet0> queryResult = this.ExecuteQuery<pr01ResultSet0>("[dbo].[pr01]", CommandType.StoredProcedure, parameterId, parameterReturnValue);
		
			returnValue = parameterReturnValue.Value == DBNull.Value 
				? -1
				: (int)parameterReturnValue.Value;
		
			return queryResult;
		}
		
		public IEnumerable<pr02ResultSet0> Pr02(int? id)
		{
			int returnValue;
			return Pr02(id, out returnValue);
		}
		
		public IEnumerable<pr02ResultSet0> Pr02(int? id, out int returnValue)
		{
			OAParameter parameterReturnValue = new OAParameter();
		    parameterReturnValue.Direction = ParameterDirection.ReturnValue;
		    parameterReturnValue.ParameterName = "parameterReturnValue";
		
			OAParameter parameterId = new OAParameter();
			parameterId.ParameterName = "id";
			if(id.HasValue)
			{
				parameterId.Value = id.Value;
			}
			else
			{
				parameterId.DbType = DbType.Int32;
				parameterId.Value = DBNull.Value;
			}

			IEnumerable<pr02ResultSet0> queryResult = this.ExecuteQuery<pr02ResultSet0>("[dbo].[pr02]", CommandType.StoredProcedure, parameterId, parameterReturnValue);
		
			returnValue = parameterReturnValue.Value == DBNull.Value 
				? -1
				: (int)parameterReturnValue.Value;
		
			return queryResult;
		}
		
		public IEnumerable<pr03ResultSet02> Pr03(int? id)
		{
			int returnValue;
			return Pr03(id, out returnValue);
		}
		
		public IEnumerable<pr03ResultSet02> Pr03(int? id, out int returnValue)
		{
			OAParameter parameterReturnValue = new OAParameter();
		    parameterReturnValue.Direction = ParameterDirection.ReturnValue;
		    parameterReturnValue.ParameterName = "parameterReturnValue";
		
			OAParameter parameterId = new OAParameter();
			parameterId.ParameterName = "id";
			if(id.HasValue)
			{
				parameterId.Value = id.Value;
			}
			else
			{
				parameterId.DbType = DbType.Int32;
				parameterId.Value = DBNull.Value;
			}

			IEnumerable<pr03ResultSet02> queryResult = this.ExecuteQuery<pr03ResultSet02>("[dbo].[pr03]", CommandType.StoredProcedure, parameterId, parameterReturnValue);
		
			returnValue = parameterReturnValue.Value == DBNull.Value 
				? -1
				: (int)parameterReturnValue.Value;
		
			return queryResult;
		}
		
		public static BackendConfiguration GetBackendConfiguration()
		{
			BackendConfiguration backend = new BackendConfiguration();
			backend.Backend = "MsSql";
			backend.ProviderName = "System.Data.SqlClient";
		
			CustomizeBackendConfiguration(ref backend);
		
			return backend;
		}
		
		/// <summary>
		/// Allows you to customize the BackendConfiguration of ModeloDeDominio.
		/// </summary>
		/// <param name="config">The BackendConfiguration of ModeloDeDominio.</param>
		static partial void CustomizeBackendConfiguration(ref BackendConfiguration config);
		
	}
	
	public interface IModeloDeDominioUnitOfWork : IUnitOfWork
	{
		IQueryable<Usuario> Usuarios
		{
			get;
		}
		IQueryable<TipoFinanciamiento> TipoFinanciamientos
		{
			get;
		}
		IQueryable<TipoEstadoEtapa> TipoEstadoEtapas
		{
			get;
		}
		IQueryable<TipoEstado> TipoEstados
		{
			get;
		}
		IQueryable<TipoConvocatorium> TipoConvocatoria
		{
			get;
		}
		IQueryable<TipoAuditorium> TipoAuditoria
		{
			get;
		}
		IQueryable<Proyecto> Proyectos
		{
			get;
		}
		IQueryable<Persona> Personas
		{
			get;
		}
		IQueryable<Origen> Origens
		{
			get;
		}
		IQueryable<Organismo> Organismos
		{
			get;
		}
		IQueryable<Modalidad> Modalidads
		{
			get;
		}
		IQueryable<Localidad> Localidads
		{
			get;
		}
		IQueryable<Fondo> Fondos
		{
			get;
		}
		IQueryable<Etapa> Etapas
		{
			get;
		}
		IQueryable<Empresa> Empresas
		{
			get;
		}
		IQueryable<Desembolso> Desembolsos
		{
			get;
		}
		IQueryable<Convocatorium> Convocatoria
		{
			get;
		}
		IQueryable<Auditorium> Auditoria
		{
			get;
		}
		IQueryable<Actuacion> Actuacions
		{
			get;
		}
		IQueryable<TipoProyecto> TipoProyectos
		{
			get;
		}
		IQueryable<ViaComunicacion> ViaComunicacions
		{
			get;
		}
		IQueryable<ActuacionPersona> ActuacionPersonas
		{
			get;
		}
		IQueryable<UdtUvt> UdtUvts
		{
			get;
		}
		IQueryable<TipoEstadoCofecyt> TipoEstadoCofecyts
		{
			get;
		}
		IQueryable<ProyectoCofecyt> ProyectoCofecyts
		{
			get;
		}
		IQueryable<Tematica> Tematicas
		{
			get;
		}
		IQueryable<Sector> Sectors
		{
			get;
		}
		IQueryable<EtapaCofecyt> EtapaCofecyts
		{
			get;
		}
		IQueryable<ActividadCofecyt> ActividadCofecyts
		{
			get;
		}
		IQueryable<ActuacionProyectoCofecyt> ActuacionProyectoCofecyts
		{
			get;
		}
		IQueryable<Actividad> Actividads
		{
			get;
		}
		IEnumerable<pr01ResultSet0> Pr01(int? id);
		IEnumerable<pr01ResultSet0> Pr01(int? id, out int returnValue);
		IEnumerable<pr02ResultSet0> Pr02(int? id);
		IEnumerable<pr02ResultSet0> Pr02(int? id, out int returnValue);
		IEnumerable<pr03ResultSet02> Pr03(int? id);
		IEnumerable<pr03ResultSet02> Pr03(int? id, out int returnValue);
	}
}
#pragma warning restore 1591
