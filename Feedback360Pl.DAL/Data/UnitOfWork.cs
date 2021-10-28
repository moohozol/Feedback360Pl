using Feedback360Pl.DAL.Interfaces;
using Feedback360Pl.DAL.InterfacesRepos;
using Feedback360Pl.Models.ModelsRepos;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace Feedback360Pl.DAL.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        public readonly DalContext context;
        public readonly ILogger logger;

        public ICompetencyRepo Competencies { get; set; }

        public UnitOfWork(DalContext context, ILoggerFactory loggerFactory)
        {
            this.context = context;
            this.logger = loggerFactory.CreateLogger("logs");
            Competencies = new CompetencyRepo(context, logger);
        }


        public async Task<int> CompleteAsync()
        {
            return await context.SaveChangesAsync();
        }

        public void Dispose()
        {
            context.Dispose();
        }
    }
}
