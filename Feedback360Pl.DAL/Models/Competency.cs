using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Feedback360Pl.DAL.Models
{
    [Table("Competency")]
    public class Competency : BaseEntity
    {
        public Competency()
        {
            //Behavior = new HashSet<Behavior>();
        }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [StringLength(100)]
        public string Keywords { get; set; }

        //public virtual ICollection<Behavior> Behavior { get; set; }

    }
}
