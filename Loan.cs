//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DemoWinformsBTL
{
    using System;
    using System.Collections.Generic;
    
    public partial class Loan
    {
        public int LoanID { get; set; }
        public Nullable<int> BookID { get; set; }
        public Nullable<int> ReaderID { get; set; }
        public System.DateTime LoanDate { get; set; }
        public System.DateTime DueDate { get; set; }
        public Nullable<System.DateTime> ReturnDate { get; set; }
    
        public virtual Book Book { get; set; }
        public virtual Reader Reader { get; set; }
    }
}
