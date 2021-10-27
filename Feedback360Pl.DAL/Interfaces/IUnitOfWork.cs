using FeedbackReport.DAL.InterfacesRepos;
using System;
using System.Threading.Tasks;

// https://medium.com/c-sharp-progarmming/repository-pattern-and-unit-of-work-with-asp-net-core-5-60f5df3e9dea

namespace FeedbackReport.DAL.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        //IScaleRepo Scales { get; }
        Task<int> CompleteAsync();

    }
}
