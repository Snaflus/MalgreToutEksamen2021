﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace MalgreTout.Models
{
    [Table("Distribution_point")]
    public partial class DistributionPoint
    {
        //public DistributionPoint()
        //{
        //    Contactpeople = new HashSet<Contactperson>();
        //}

        [Key]
        [Column("Location_ID")]
        public int LocationId { get; set; }
        [Required]
        [StringLength(30)]
        public string Company { get; set; }
        [Required]
        [StringLength(30)]
        public string Address { get; set; }
        public int Zipcode { get; set; }

        [ForeignKey(nameof(Zipcode))]
        [InverseProperty("DistributionPoints")]
        public virtual Zipcode ZipcodeNavigation { get; set; }
        [InverseProperty("Location")]
        public virtual NoOfMagazine NoOfMagazine { get; set; }
        [InverseProperty("Location")]
        public virtual OpeningHour OpeningHour { get; set; }
        [InverseProperty(nameof(Contactperson.Location))]
        //public virtual ICollection<Contactperson> Contactpeople { get; set; }

        public virtual Contactperson ContactPerson { get; set; }
    }
}