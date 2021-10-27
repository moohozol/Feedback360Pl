using System;
using System.ComponentModel.DataAnnotations;

namespace FeedbackReport.DAL.Models
{
    public class ExampleModel : BaseEntity
    {
        [Range(minimum: -1, maximum: 10)]
        [Required]
        [Display(Name = "Wartość")]
        public double Value { get; set; } = 0.0;

        [StringLength(100)]
        [Required]
        [Display(Name = "Nazwa")]
        public string Name { get; set; } = string.Empty;

        [StringLength(1000)]
        [Display(Name = "Opis pozycji skali")]
        public string Description { get; set; } = string.Empty;
    }
}
