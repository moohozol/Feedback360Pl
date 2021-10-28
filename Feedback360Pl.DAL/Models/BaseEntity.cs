using Feedback360Pl.DAL.Interfaces;
using System;

namespace Feedback360Pl.DAL.Models
{
    public class BaseEntity : IBaseEntity
    {
        public int Id { get; set; } 
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime ModifiedAt { get; set; } = DateTime.Now;
    }
}
