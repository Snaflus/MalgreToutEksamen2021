﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace MalgreTout.Models
{
    [Table("Opening_hour")]
    public partial class OpeningHour
    {
        [Key]
        [Column("Opening_ID")]
        public int OpeningId { get; set; }
        [Column("Location_ID")]
        public int LocationId { get; set; }
        [Column("Week_day")]
        [StringLength(30)]
        public string WeekDay { get; set; }
        [Column("Open_hours")]
        [StringLength(15)]
        public string OpenHours { get; set; }

        [ForeignKey(nameof(LocationId))]
        [InverseProperty(nameof(DistributionPoint.OpeningHours))]
        public virtual DistributionPoint Location { get; set; }
    }
}