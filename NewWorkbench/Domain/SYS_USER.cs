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
    
    public partial class SYS_USER
    {
        public int ID { get; set; }
        public string NAME { get; set; }
        public string ACCOUNT { get; set; }
        public string PASSWORD { get; set; }
        public Nullable<int> ISCANLOGIN { get; set; }
        public Nullable<int> SHOWORDER1 { get; set; }
        public Nullable<int> SHOWORDER2 { get; set; }
        public string PINYIN1 { get; set; }
        public string PINYIN2 { get; set; }
        public string FACE_IMG { get; set; }
        public string LEVELS { get; set; }
        public string DPTID { get; set; }
        public string CREATEPER { get; set; }
        public Nullable<System.DateTime> CREATEDATE { get; set; }
        public string UPDATEUSER { get; set; }
        public Nullable<System.DateTime> UPDATEDATE { get; set; }
        public string LastLoginIP { get; set; }
    }
}
