using Feedback360Pl.DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace Feedback360Pl.DAL.Data
{
    public class DalContext : DbContext
    {
        public DalContext(DbContextOptions<DalContext> context) : base(context) { }
        public virtual DbSet<Competency> Competencies { get; set; }
    }


}
