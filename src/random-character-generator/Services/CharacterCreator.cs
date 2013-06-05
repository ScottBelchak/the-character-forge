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
        private readonly RelationshipGenerator RelationshipGenerator;
        private readonly AdolescenceAndTrainingGenerator TrainingGenerator;
        /// <summary>
        /// Initializes a new instance of the CharacterCreator class.
        /// </summary>
        /// <param name="nameGenerator"></param>
        /// <param name="originStoryGenerator"></param>
        public CharacterCreator(IRandomNameGenerator nameGenerator, OriginStoryGenerator originStoryGenerator, AdolescenceAndTrainingGenerator trainingGenerator, RelationshipGenerator relationshipGenerator)
        {
            RelationshipGenerator = relationshipGenerator;
            TrainingGenerator = trainingGenerator;
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
            character.AdolescenceAndTraining = TrainingGenerator.Generate(characterClass);
            character.Relationships = RelationshipGenerator.Generate(character.AllStoryElements.Any(x => x.AdditionalInformation == "d12 relationship" || x.StoryFeats.Contains("True Love")));
            return character;
        }

        
    }
}