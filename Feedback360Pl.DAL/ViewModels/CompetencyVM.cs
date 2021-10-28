using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Feedback360Pl.DAL.ViewModels
{
    public class CompetencyVM
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        [Display(Name="Nazwa kompetencji")]
        public string Name { get; set; }

        [StringLength(100)]
        [Display(Name="Słowa kluczowe")]
        public string Keywords { get; set; }
    }
}
