using FeedbackReport.DAL.Data;
using FeedbackReport.DAL.InterfacesRepos;
using FeedbackReport.Models.ModelsRepos;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FeedbackReport.xUnitTest.DAL
{
    // https://ahsanshares.wordpress.com/2019/11/11/xunit-testing-in-ef-core-using-inmemory-database/
    public class TestHelper
    {
        internal DalContext dalContext { get; }
        public TestHelper()
        {
            var builder = new DbContextOptionsBuilder<DalContext>();
            builder.UseInMemoryDatabase(databaseName: "DalInMemory");
            var dbContextOptions = builder.Options;
            dalContext = new DalContext(dbContextOptions);
            dalContext.Database.EnsureDeleted();
            dalContext.Database.EnsureCreated();
        }
    }
}
