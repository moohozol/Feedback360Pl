using Feedback360Pl.DAL.Data;
using Feedback360Pl.DAL.InterfacesRepos;
using Feedback360Pl.DAL.Models;
using Microsoft.Extensions.Logging;

namespace Feedback360Pl.Models.ModelsRepos
{
    public class CompetencyRepo : GenericRepo<Competency>, ICompetencyRepo
    {
        public CompetencyRepo(DalContext context, ILogger logger) : base(context, logger) { }

        //public override async Task<IEnumerable<Competency>> GetAllAsync()
        //{
        //    try
        //    {
        //        return (await dbSet.ToListAsync()).OrderBy(a => a.Value);
        //    }
        //    catch (Exception ex)
        //    {
        //        logger.LogError(ex, "{Repo} GetAll function error", typeof(CompetencyRepo));
        //        return new List<Competency>();
        //    }
        //}
    }
}
