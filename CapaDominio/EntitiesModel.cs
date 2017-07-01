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
			
		public IQueryable<TipoFinanciamiento> TipoFinanciamientos 
		{
			get
			{
				return this.GetAll<TipoFinanciamiento>();
			}
		}
		
		public IQueryable<TipoConvocatorium> TipoConvocatoria 
		{
			get
			{
				return this.GetAll<TipoConvocatorium>();
			}
		}
		
		public IQueryable<Origen> Origens 
		{
			get
			{
				return this.GetAll<Origen>();
			}
		}
		
		public IQueryable<Modalidad> Modalidads 
		{
			get
			{
				return this.GetAll<Modalidad>();
			}
		}
		
		public IQueryable<Fondo> Fondos 
		{
			get
			{
				return this.GetAll<Fondo>();
			}
		}
		
		public IQueryable<Convocatorium> Convocatoria 
		{
			get
			{
				return this.GetAll<Convocatorium>();
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
		
		public IQueryable<Localidad> Localidads 
		{
			get
			{
				return this.GetAll<Localidad>();
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
		
		public IQueryable<Organismo> Organismos 
		{
			get
			{
				return this.GetAll<Organismo>();
			}
		}
		
		public IQueryable<Usuario> Usuarios 
		{
			get
			{
				return this.GetAll<Usuario>();
			}
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
		IQueryable<TipoFinanciamiento> TipoFinanciamientos
		{
			get;
		}
		IQueryable<TipoConvocatorium> TipoConvocatoria
		{
			get;
		}
		IQueryable<Origen> Origens
		{
			get;
		}
		IQueryable<Modalidad> Modalidads
		{
			get;
		}
		IQueryable<Fondo> Fondos
		{
			get;
		}
		IQueryable<Convocatorium> Convocatoria
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
		IQueryable<Localidad> Localidads
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
		IQueryable<Auditorium> Auditoria
		{
			get;
		}
		IQueryable<Actuacion> Actuacions
		{
			get;
		}
		IQueryable<Organismo> Organismos
		{
			get;
		}
		IQueryable<Usuario> Usuarios
		{
			get;
		}
	}
}
#pragma warning restore 1591
