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
    
    public partial class SYS_POST_DEPARTMENT
    {
        public SYS_POST_DEPARTMENT()
        {
            this.SYS_POST_USER = new HashSet<SYS_POST_USER>();
        }
    
        public int ID { get; set; }
        public string FK_DEPARTMENT_ID { get; set; }
        public string FK_POST_ID { get; set; }
    
        public virtual SYS_DEPARTMENT SYS_DEPARTMENT { get; set; }
        public virtual SYS_POST SYS_POST { get; set; }
        public virtual ICollection<SYS_POST_USER> SYS_POST_USER { get; set; }
    }
}
