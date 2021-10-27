using FeedbackReport.DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace FeedbackReport.DAL.Data
{
    public class DalContext : DbContext
    {
        public DalContext(DbContextOptions<DalContext> context) : base(context) { }
        public virtual DbSet<Competency> Competencies { get; set; }
    }


}
