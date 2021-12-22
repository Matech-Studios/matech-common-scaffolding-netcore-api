using System.Threading.Tasks;
using Matech.Common.Scaffolding.Core.RepositoryInterfaces;

namespace Matech.Common.Scaffolding.Core.UnitOfWorks
{
    public interface IUnitOfWork
    {
        ITestRepository TestRepository { get; }

        void Save();

        Task SaveAsync();
    }
}
