using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mission13Assignment.Models
{
    public interface IBowlingLeagueRepository
    {
        IQueryable<Bowler> Bowlers { get; }

        IQueryable<Team> Teams { get; }

        public void SaveBowler(Bowler b);

        public void CreateBowler(Bowler b);

        public void DeleteBowler(Bowler b);
    }
}
