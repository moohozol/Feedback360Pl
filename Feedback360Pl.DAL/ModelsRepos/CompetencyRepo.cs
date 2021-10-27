using FeedbackReport.DAL.Data;
using FeedbackReport.DAL.InterfacesRepos;
using FeedbackReport.DAL.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using System;

namespace FeedbackReport.Models.ModelsRepos
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
