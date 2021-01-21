using System.Collections.Generic;

namespace BugTracker.Services
{
    public class BugService : IBugService
    {
        private readonly List<Bug> Bugs = new List<Bug>();

        public void AddBug(Bug newBug)
        {
            newBug.Id = this.Bugs.Count + 1;
            this.Bugs.Add(newBug);
        }

        public List<Bug> GetBugs()
        {
            return this.Bugs;
        }
    }
}
