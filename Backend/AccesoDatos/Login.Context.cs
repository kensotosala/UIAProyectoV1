﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace AccesoDatos
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class UsersVETEntities : DbContext
    {
        public UsersVETEntities()
            : base("name=UsersVETEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<TBUsuarios> TBUsuarios { get; set; }
    
        public virtual ObjectResult<string> SP_Login(string usuario, string contrasenha)
        {
            var usuarioParameter = usuario != null ?
                new ObjectParameter("Usuario", usuario) :
                new ObjectParameter("Usuario", typeof(string));
    
            var contrasenhaParameter = contrasenha != null ?
                new ObjectParameter("Contrasenha", contrasenha) :
                new ObjectParameter("Contrasenha", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<string>("SP_Login", usuarioParameter, contrasenhaParameter);
        }
    }
}
