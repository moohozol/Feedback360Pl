﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace FeedbackPGNiG.Models
{
    /* */
    //

    public partial class Behavior
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(2000)]
        public string Name { get; set; }
        [StringLength(100)]
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }
        public int CompetencyId { get; set; }

        [ForeignKey(nameof(CompetencyId))]
        [InverseProperty("Behavior")]
        public virtual Competency Competency { get; set; }
    }
}