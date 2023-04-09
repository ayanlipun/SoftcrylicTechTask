using Microsoft.EntityFrameworkCore;
using SoftcrylicTech.Library.DataContext;

namespace SoftcrylicTech.Library.DataFactories.Interfaces
{
    public interface IContextFactory<TContext> where TContext : DbContext
    {
        TechConfContext CreateTechConfContext();
    }
}
