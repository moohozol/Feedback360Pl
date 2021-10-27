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
    public class ExampleRepo : GenericRepo<ExampleModel>, IModelRepo
    {
        public ExampleRepo(DalContext context, ILogger logger) : base(context, logger) { }

        public override async Task<IEnumerable<ExampleModel>> GetAllAsync()
        {
            try
            {
                return (await dbSet.ToListAsync()).OrderBy(a => a.Value);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "{Repo} All function error", typeof(ExampleRepo));
                return new List<ExampleModel>();
            }
        }
    }
}
