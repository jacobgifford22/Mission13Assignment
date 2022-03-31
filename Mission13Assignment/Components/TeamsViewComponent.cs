using Microsoft.AspNetCore.Mvc;
using Mission13Assignment.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mission13Assignment.Components
{
    public class TeamsViewComponent : ViewComponent
    {
        private IBowlingLeagueRepository _repo { get; set; }

        public TeamsViewComponent(IBowlingLeagueRepository temp)
        {
            _repo = temp;
        }

        public IViewComponentResult Invoke()
        {
            var teams = _repo.Teams
                .OrderBy(x => x.TeamName)
                .ToList();
            
            return View(teams);
        }
    }
}
