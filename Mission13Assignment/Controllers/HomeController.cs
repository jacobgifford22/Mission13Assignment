using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Mission13Assignment.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;


namespace Mission13Assignment.Controllers
{
    public class HomeController : Controller
    {
        private IBowlingLeagueRepository _repo { get; set; }

        public HomeController(IBowlingLeagueRepository temp)
        {
            _repo = temp;
        }

        public IActionResult Index(string teamName, int teamId)
        {
            List<Team> teams = _repo.Teams.ToList();

            List<Bowler> bowlers = _repo.Bowlers
                .Where(x => x.TeamID == teamId || teamName == null)
                .OrderBy(x => x.TeamID)
                .ToList();

            ViewBag.Team = teamName;

            return View(bowlers);
        }

        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.Teams = _repo.Teams.ToList();

            return View("BowlerForm");
        }

        [HttpPost]
        public IActionResult Create(Bowler b)
        {
            if (ModelState.IsValid)
            { 
                _repo.CreateBowler(b);

                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.Teams = _repo.Teams.ToList();

                return View("BowlerForm", b);
            }
        }

        [HttpGet]
        public IActionResult Edit(int bowlerid)
        {
            ViewBag.Teams = _repo.Teams.ToList();
            
            Bowler bowler = _repo.Bowlers.Single(x => x.BowlerID == bowlerid);
            
            return View("BowlerForm", bowler);
        }

        [HttpPost]
        public IActionResult Edit(Bowler b)
        {
            if (ModelState.IsValid)
            {
                _repo.SaveBowler(b);

                return RedirectToAction("Index");
            }
            else
            {
                return RedirectToAction("Edit", new { bowlerid = b.BowlerID });
            }
        }

        [HttpGet]
        public IActionResult Delete(int bowlerid)
        {
            var bowler = _repo.Bowlers.Single(x => x.BowlerID == bowlerid);

            return View(bowler);
        }

        [HttpPost]
        public IActionResult Delete(Bowler b)
        {
            _repo.DeleteBowler(b);

            return RedirectToAction("Index");
        }

    }
}
