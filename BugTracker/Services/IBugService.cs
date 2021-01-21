using System.Collections.Generic;

namespace BugTracker.Services
{
    public interface IBugService
    {
        List<Bug> GetBugs();

        void AddBug(Bug newBug);
    }
}
