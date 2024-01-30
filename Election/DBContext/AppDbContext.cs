using Election.Class;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Election.DBContext
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options) { }
        public DbSet<State> States { get; set; }
        public DbSet<Party> Parties { get; set; }
        public DbSet<Candidate> Candidates { get; set; }
        public DbSet<Voter> Voters { get; set; }
        public DbSet<Vote> Votes { get; set; }
        public DbSet<ElectionResult> ElectionResults { get; set; }
    }
}
