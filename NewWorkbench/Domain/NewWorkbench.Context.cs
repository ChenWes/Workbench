﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace NewWorkbench.Domain
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class NewDBEntities : DbContext
    {
        public NewDBEntities()
            : base("name=NewDBEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<SYS_USER> SYS_USER { get; set; }
        public virtual DbSet<SYS_CODE> SYS_CODE { get; set; }
        public virtual DbSet<SYS_CODE_AREA> SYS_CODE_AREA { get; set; }
        public virtual DbSet<SYS_DEPARTMENT> SYS_DEPARTMENT { get; set; }
        public virtual DbSet<SYS_LOG> SYS_LOG { get; set; }
        public virtual DbSet<SYS_MODULE> SYS_MODULE { get; set; }
        public virtual DbSet<SYS_PERMISSION> SYS_PERMISSION { get; set; }
        public virtual DbSet<SYS_POST> SYS_POST { get; set; }
        public virtual DbSet<SYS_POST_DEPARTMENT> SYS_POST_DEPARTMENT { get; set; }
        public virtual DbSet<SYS_POST_USER> SYS_POST_USER { get; set; }
        public virtual DbSet<SYS_ROLE> SYS_ROLE { get; set; }
        public virtual DbSet<SYS_ROLE_PERMISSION> SYS_ROLE_PERMISSION { get; set; }
        public virtual DbSet<SYS_SYSTEM> SYS_SYSTEM { get; set; }
        public virtual DbSet<SYS_USER_DEPARTMENT> SYS_USER_DEPARTMENT { get; set; }
        public virtual DbSet<SYS_USER_PERMISSION> SYS_USER_PERMISSION { get; set; }
        public virtual DbSet<SYS_USER_ROLE> SYS_USER_ROLE { get; set; }
        public virtual DbSet<SYS_USERINFO> SYS_USERINFO { get; set; }
    }
}
