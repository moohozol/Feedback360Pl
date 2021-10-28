using Feedback360Pl.DAL.InterfacesRepos;
using System;
using System.Threading.Tasks;

// https://medium.com/c-sharp-progarmming/repository-pattern-and-unit-of-work-with-asp-net-core-5-60f5df3e9dea

namespace Feedback360Pl.DAL.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        ICompetencyRepo Competencies { get; set; }
        Task<int> CompleteAsync();

    }
}
