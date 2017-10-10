using Football.Business;
using Football.Web.Models;
using System.Web.Mvc;

namespace Football.Web.Controllers
{
    public class HomeController : Controller
    {
        private FootballService service = new FootballService();

        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Leagues()
        {
            var leagueTypes = service.GetLeagueTypes();
            var leagues = service.GetLeagues();
            var model = new LeaguesModel() { LeagueTypes = leagueTypes, Leagues = leagues };
            return View(model);
        }

        public ActionResult Matches(int leagueId)
        {
            var league = service.GetLeague(leagueId);
            league.GenerateStandings();
            return View(league);
        }

        [HttpPost]
        public ActionResult StartLeague(int leagueTypeId)
        {
            service.StartLeague(leagueTypeId);
            return RedirectToAction("Leagues");
        }

        [HttpPost]
        public ActionResult PlayRound(int leagueId)
        {
            var league = service.PlayRound(leagueId);
            return RedirectToAction("Matches", new { leagueId = leagueId });
        }

        //[HttpPost]
        //public ActionResult ViewScores(int leagueId)
        //{
        //    var league = service.
        //    return RedirectToAction("Matches", );
        //}
    }
}