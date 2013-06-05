using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace random_character_generator.Models
{
    public enum Race
    {
        [Description("Many dwarves come from industrious and tight-knit communities of like-minded individuals who work together to accomplish a common goal.")]
        Dwarf,
        [Description("Elves are often raised in insular elven communities, and the longevity of these people means that elven children often grow up with the help of a large social network.")]
        Elf,
        [Description("The capricious and carefree gnomes of the world are widespread and varied. They typically either form their own gnome communities or integrate themselves into other humanoid societies.")]
        Gnome,
        [Description("Born of two very different worlds, half-elves rarely have easy childhoods. Torn as half-elves are between disparate peoples, the presence of their families helps ensure they do not grow up totally alone, though orphaned half-elves have to create families of their own.")]
        HalfElf,
        [Description("Only rarely the result of a happy union between the humans and orcs that bring them into the world, halforcs are often regarded as monsters. This bleak reality makes those rare half-orcs, cherished as much as the young of any other race, even more extraordinary.")]
        HalfOrc,
        [Description("Social and amicable by nature, halflings fit equally well in both communities of humans and those of their wily kinsfolk. Prone to wanderlust, half lings can be found anywhere civilized humanoids settle.")] 
        Halfling,
        [Description("As diverse as they are widespread, humans tend to grow up in small or large societies of people with similar origins and histories, though individuals’ paths may run the gamut from idealized to tragic.")]
        Human
    }
    public enum CharacterClass
    {
        Alchemist,
        Barbarian,
        Bard,
        Cavalier,
        Cleric,
        Druid,
        Fighter,
        Gunslinger,
        Inquisitor,
        Magus,
        Monk,
        Oracle,
        Paladin,
        Ranger,
        Rogue,
        Sorcerer,
        Summoner,
        Witch,
        Wizard
    }
    public class Character
    {
        public CharacterClass CharacterClass { get; set; }
        public Race Race { get; set; }

        public OriginStory OriginStory { get; set; }
        public AdolescenceAndTraining AdolescenceAndTraining { get; set; }

        public string Name { get; set; }
    }

    public class OriginStory
    {
        public StoryElement Homeland { get; set; }
        public StoryElement Parents { get; set; }
        public Siblings Siblings { get; set; }

        public IList<StoryElement> CircumstancesOfBirth { get; set; }

        public IEnumerable<StoryElement> ChildhoodEvents { get; set; }
    }
    public class Siblings : StoryElement
    {
        /// <summary>
        /// Initializes a new instance of the Siblings class.
        /// </summary>
        public Siblings(string element, params string[] traits)
            : base(element, traits)
        {
            SiblingList = new List<Sibling>();
        }
        public IList<Sibling> SiblingList { get; set; }
    }
    public class Sibling
    {
        public bool IsAdopted { get; set; }
        public bool AreTwins { get; set; }
        public bool AreTriplets { get; set; }

        public bool IsYounger { get; set; }

        public string Name { get; set; }

        public string Gender { get; set; }

        public string Race { get; set; }
    }
    public class AdolescenceAndTraining
    {
        public StoryElement ClassBenefit { get; set; }
        public StoryElement InfluentialAssociate { get; set; }
    }
    public class MoralConflictRelationshipsAndResolutions
    {
        public StoryElement MajorConflict { get; set; }


    }
}