﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace BarcoSoftUtilidades.Data
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class BarcoSoftUtilidadesDB : DbContext
    {
        public BarcoSoftUtilidadesDB()
            : base("name=BarcoSoftUtilidadesDB")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Objeto> Objeto { get; set; }
        public virtual DbSet<Permiso> Permiso { get; set; }
        public virtual DbSet<Persona> Persona { get; set; }
        public virtual DbSet<Producto> Producto { get; set; }
        public virtual DbSet<Propietario> Propietario { get; set; }
        public virtual DbSet<Rol> Rol { get; set; }
        public virtual DbSet<TipoUsuario> TipoUsuario { get; set; }
        public virtual DbSet<Usuario> Usuario { get; set; }
        public virtual DbSet<UsuarioPorRol> UsuarioPorRol { get; set; }
        public virtual DbSet<Menu> Menu { get; set; }
        public virtual DbSet<MenuTipo> MenuTipo { get; set; }
        public virtual DbSet<ParametroGeneral> ParametroGeneral { get; set; }
        public virtual DbSet<ParametroTipo> ParametroTipo { get; set; }
    }
}
