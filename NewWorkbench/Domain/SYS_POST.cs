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
    
    public partial class SYS_POST
    {
        public SYS_POST()
        {
            this.SYS_POST_DEPARTMENT = new HashSet<SYS_POST_DEPARTMENT>();
        }
    
        public string ID { get; set; }
        public string POSTNAME { get; set; }
        public string POSTTYPE { get; set; }
        public string REMARK { get; set; }
        public Nullable<int> SHOWORDER { get; set; }
        public Nullable<int> CREATEUSERID { get; set; }
        public System.DateTime CREATEDATE { get; set; }
        public Nullable<System.DateTime> UPDATEDATE { get; set; }
        public string UPDATEUSER { get; set; }
    
        public virtual ICollection<SYS_POST_DEPARTMENT> SYS_POST_DEPARTMENT { get; set; }
    }
}
