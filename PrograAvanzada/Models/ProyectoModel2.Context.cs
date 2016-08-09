﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace PrograAvanzada.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class db_admin_proyectosEntities1 : DbContext
    {
        public db_admin_proyectosEntities1()
            : base("name=db_admin_proyectosEntities1")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<C__MigrationHistory> C__MigrationHistory { get; set; }
        public virtual DbSet<AspNetRoles> AspNetRoles { get; set; }
        public virtual DbSet<AspNetUserClaims> AspNetUserClaims { get; set; }
        public virtual DbSet<AspNetUserLogins> AspNetUserLogins { get; set; }
        public virtual DbSet<AspNetUsers> AspNetUsers { get; set; }
        public virtual DbSet<comentario_por_tarea> comentario_por_tarea { get; set; }
        public virtual DbSet<comentarios_foro> comentarios_foro { get; set; }
        public virtual DbSet<estado> estado { get; set; }
        public virtual DbSet<foro> foro { get; set; }
        public virtual DbSet<historico_tarea> historico_tarea { get; set; }
        public virtual DbSet<proyecto> proyecto { get; set; }
        public virtual DbSet<tarea> tarea { get; set; }
        public virtual DbSet<usuarios_por_proyecto> usuarios_por_proyecto { get; set; }
        public virtual DbSet<AspNetUserRoles> AspNetUserRoles { get; set; }
    
        public virtual int sp_asignar_rol(string userId, string roleId)
        {
            var userIdParameter = userId != null ?
                new ObjectParameter("UserId", userId) :
                new ObjectParameter("UserId", typeof(string));
    
            var roleIdParameter = roleId != null ?
                new ObjectParameter("RoleId", roleId) :
                new ObjectParameter("RoleId", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_asignar_rol", userIdParameter, roleIdParameter);
        }
    
        public virtual int sp_cambio_rol_reporte(string email, string rol)
        {
            var emailParameter = email != null ?
                new ObjectParameter("email", email) :
                new ObjectParameter("email", typeof(string));
    
            var rolParameter = rol != null ?
                new ObjectParameter("rol", rol) :
                new ObjectParameter("rol", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_cambio_rol_reporte", emailParameter, rolParameter);
        }
    
        public virtual int sp_registrar_usuario_rol_reporte(string email, string rol)
        {
            var emailParameter = email != null ?
                new ObjectParameter("email", email) :
                new ObjectParameter("email", typeof(string));
    
            var rolParameter = rol != null ?
                new ObjectParameter("rol", rol) :
                new ObjectParameter("rol", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_registrar_usuario_rol_reporte", emailParameter, rolParameter);
        }
    
        public virtual int SP_UsuarioProyecto(string cod_usuario, Nullable<int> cod_proyecto)
        {
            var cod_usuarioParameter = cod_usuario != null ?
                new ObjectParameter("cod_usuario", cod_usuario) :
                new ObjectParameter("cod_usuario", typeof(string));
    
            var cod_proyectoParameter = cod_proyecto.HasValue ?
                new ObjectParameter("cod_proyecto", cod_proyecto) :
                new ObjectParameter("cod_proyecto", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("SP_UsuarioProyecto", cod_usuarioParameter, cod_proyectoParameter);
        }
    
        public virtual int SP_Registro_Histrorico_Tarea(Nullable<int> cod_tarea, string cod_usuarioProyecto, string observacion, Nullable<System.DateTime> fecha_cambio)
        {
            var cod_tareaParameter = cod_tarea.HasValue ?
                new ObjectParameter("cod_tarea", cod_tarea) :
                new ObjectParameter("cod_tarea", typeof(int));
    
            var cod_usuarioProyectoParameter = cod_usuarioProyecto != null ?
                new ObjectParameter("cod_usuarioProyecto", cod_usuarioProyecto) :
                new ObjectParameter("cod_usuarioProyecto", typeof(string));
    
            var observacionParameter = observacion != null ?
                new ObjectParameter("observacion", observacion) :
                new ObjectParameter("observacion", typeof(string));
    
            var fecha_cambioParameter = fecha_cambio.HasValue ?
                new ObjectParameter("fecha_cambio", fecha_cambio) :
                new ObjectParameter("fecha_cambio", typeof(System.DateTime));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("SP_Registro_Histrorico_Tarea", cod_tareaParameter, cod_usuarioProyectoParameter, observacionParameter, fecha_cambioParameter);
        }
    }
}
