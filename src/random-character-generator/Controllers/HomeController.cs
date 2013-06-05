using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using random_character_generator.Models;
using random_character_generator.Services;

namespace random_character_generator.Controllers
{
    public class HomeController : Controller
    {
        private readonly CharacterCreator creator;
        private readonly Random Random;
        /// <summary>
        /// Initializes a new instance of the HomeController class.
        /// </summary>
        /// <param name="creator"></param>
        public HomeController(CharacterCreator creator, Random random)
        {
            Random = random;
            this.creator = creator;
        }
        public ActionResult Index(Race? race = null, CharacterClass? characterClass = null)
        {
            if (!race.HasValue)
            {
                Array values = Enum.GetValues(typeof(Race));
                race = (Race)values.GetValue(Random.Next(values.Length));
            }
            if (!characterClass.HasValue)
            {
                Array values = Enum.GetValues(typeof(CharacterClass));
                characterClass = (CharacterClass)values.GetValue(Random.Next(values.Length));
            }

            Character result = creator.Create(characterClass.Value, race.Value);
            ViewBag.Title = String.Format("{0} - {1} {2}", result.Name, result.Race, result.CharacterClass);

            return View(result);
        }
    }
}
