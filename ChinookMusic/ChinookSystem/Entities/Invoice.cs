﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ChinookSystem.Entities
{
    [Index("CustomerId", Name = "IFK_InvoicesCustomerId")]
    public partial class Invoice
    {
        public Invoice()
        {
            InvoiceLines = new HashSet<InvoiceLine>();
        }

        [Key]
        public int InvoiceId { get; set; }
        public int CustomerId { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime InvoiceDate { get; set; }
        [StringLength(70)]
        public string BillingAddress { get; set; }
        [StringLength(40)]
        public string BillingCity { get; set; }
        [StringLength(40)]
        public string BillingState { get; set; }
        [StringLength(40)]
        public string BillingCountry { get; set; }
        [StringLength(10)]
        public string BillingPostalCode { get; set; }
        [Column(TypeName = "numeric(10, 2)")]
        public decimal Total { get; set; }

        [ForeignKey("CustomerId")]
        [InverseProperty("Invoices")]
        public virtual Customer Customer { get; set; }
        [InverseProperty("Invoice")]
        public virtual ICollection<InvoiceLine> InvoiceLines { get; set; }
    }
}