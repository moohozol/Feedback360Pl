// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace WebApplication1.Models
{
    public partial class Competency
    {
        public Competency()
        {
            Behavior = new HashSet<Behavior>();
        }

        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(100)]
        public string Name { get; set; }
        [StringLength(100)]
        public string Keywords { get; set; }

        [InverseProperty("Competency")]
        public virtual ICollection<Behavior> Behavior { get; set; }
    }
}