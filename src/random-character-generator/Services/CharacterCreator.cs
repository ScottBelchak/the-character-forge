using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using random_character_generator.Models;

namespace random_character_generator.Services
{
    public class CharacterCreator
    {
        private readonly IRandomNameGenerator NameGenerator;
        private readonly OriginStoryGenerator OriginStoryGenerator;
        /// <summary>
        /// Initializes a new instance of the CharacterCreator class.
        /// </summary>
        /// <param name="nameGenerator"></param>
        /// <param name="originStoryGenerator"></param>
        public CharacterCreator(IRandomNameGenerator nameGenerator, OriginStoryGenerator originStoryGenerator)
        {
            NameGenerator = nameGenerator;
            OriginStoryGenerator = originStoryGenerator;
        }

        public Character Create(CharacterClass characterClass, Race race)
        {
            var character = new Character()
            {
                CharacterClass = characterClass,
                Race = race,
                Name = NameGenerator.GetRandomName()
            };

            character.OriginStory = OriginStoryGenerator.Generate(race);

            return character;
        }

        
    }
}