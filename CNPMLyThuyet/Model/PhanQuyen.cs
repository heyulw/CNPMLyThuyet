//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CNPMLyThuyet.Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class PhanQuyen
    {
        public Nullable<int> STT { get; set; }
        public string MaPB { get; set; }
        public string MaCN { get; set; }
    
        public virtual ChucNang ChucNang { get; set; }
        public virtual PhongBan PhongBan { get; set; }
    }
}
