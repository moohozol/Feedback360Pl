using FeedbackReport.DAL.Interfaces;
using FeedbackReport.DAL.InterfacesRepos;
using FeedbackReport.Models.ModelsRepos;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace FeedbackReport.DAL.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        public readonly DalContext context;
        public readonly ILogger logger;

        //public IScaleRepo Scales { get; private set; }

        public UnitOfWork(DalContext context, ILoggerFactory loggerFactory)
        {
            this.context = context;
            this.logger = loggerFactory.CreateLogger("logs");
            // Scales = new ScaleRepo(context, logger);
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
