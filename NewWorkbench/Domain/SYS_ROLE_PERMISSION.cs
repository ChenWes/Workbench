//------------------------------------------------------------------------------
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
    using System.Collections.Generic;
    
    public partial class SYS_ROLE_PERMISSION
    {
        public int ID { get; set; }
        public int ROLEID { get; set; }
        public int PERMISSIONID { get; set; }
    
        public virtual SYS_PERMISSION SYS_PERMISSION { get; set; }
        public virtual SYS_ROLE SYS_ROLE { get; set; }
    }
}
