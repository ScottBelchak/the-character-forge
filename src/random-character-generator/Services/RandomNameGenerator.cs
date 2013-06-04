using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Raven.Client;

namespace random_character_generator.Services
{
    public interface IRandomNameGenerator
    {
        string GetRandomName();
    }
    public class RandomNameGenerator : IRandomNameGenerator
    {
        private readonly Random Random;
        private readonly IDocumentSession Session;
        /// <summary>
        /// Initializes a new instance of the RandomNameGenerator class.
        /// </summary>
        /// <param name="session"></param>
        public RandomNameGenerator(IDocumentSession session, Random random)
        {
            Random = random;
            Session = session;
        }


        #region IRandomNameGenerator Members

        public string GetRandomName()
        {
            int nameCount = Session.Query<Name>().Count();
            return Session.Query<Name>().Skip(Random.Next(0, nameCount)).Take(1).First().FirstName;
        }

        #endregion
    }
}