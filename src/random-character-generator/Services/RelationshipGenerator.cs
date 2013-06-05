using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using random_character_generator.Models;

namespace random_character_generator.Services
{
    public class RelationshipGenerator
    {
        private readonly IDiceRoller Roll;
        public RelationshipGenerator(IDiceRoller roll)
        {
            Roll = roll;
        }
        public IList<StoryElement> Generate(bool hasTrueLove)
        {
            IList<StoryElement> result = new List<StoryElement>();
            result.Add(GenerateRomanticRelationship(hasTrueLove));
            return result;
        }
        private StoryElement GenerateRomanticRelationship(bool hasTrueLove)
        {
            int roll;
            if (hasTrueLove)
                roll = Roll.d12();
            else
                roll = Roll.d20();

            if (roll.IsBetween(1, 2))
                return new StoryElement("Romantic Relationship: One Significant Relationship: You had a true love once, but that time has passed.");

            if (roll.IsBetween(3, 6))
                return new StoryElement("Romantic Relationship: A Few Significant Relationships: You’ve tried to make deep connections with individuals on several occasions, but it’s never worked out.");

            if (roll.IsBetween(7, 9))
                return new StoryElement("Romantic Relationship: Several Significant Relationships: You’ve engaged in a number of partnerships, but for some reason or another your relationships always fail.");

            if (roll.IsBetween(10, 12))
                return new StoryElement("Romantic Relationship: Current Lover: You are currently involved in a romantic relationship. You gain access to the True Love story feat.");

            if (roll.IsBetween(13, 16))
                return new StoryElement("Romantic Relationship: Several Inconsequential Relationships: You have had many lovers but no long-lasting, meaningful relationships.");

            if (roll.IsBetween(17, 18))
                return new StoryElement("Romantic Relationship: Experience but No Substantial Relationships: You’ve had a fling or two, but have so far shied away from any ties or commitments.");
            else
                return new StoryElement("Romantic Relationship: No Experience: You have never experienced any kind of romantic connection whatsoever.");
        }
    }
}
