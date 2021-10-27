using FeedbackReport.DAL.Interfaces;
using System;

namespace FeedbackReport.DAL.Models
{
    public class BaseEntity : IBaseEntity
    {
        public int Id { get; set; } 
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime ModifiedAt { get; set; } = DateTime.Now;
    }
}
