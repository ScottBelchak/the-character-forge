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
        [Description("Instead of wielding magic as divine and arcane casters know it, alchemists master fiery concoctions and mutagens by studying formulae that unlock the secrets of reagent reactions. Though some alchemists use their discoveries and knowledge of rare and exotic components to benefit the world, others are not so scrupulous with their powerful potables. This event inspired you to study alchemy.")]
        Alchemist,
        [Description("Barbarians are fueled by an almost supernatural rage that helps them loose the volatile stores of adrenaline within their bodies. This rage stays with the barbarian throughout her life as an adventurer, and she learns to refine her fits of passionate anger only over time. Yet each barbarian’s rage is different and personal. It comes from the primal depths of her soul, and cannot be manufactured. Only a select few can channel that purest, deepest rage into overpowering combat prowess. This caused you to first experience your rage:")]
        Barbarian,
        [Description("Bards have a talent for song and story, and they come to their careers by developing this talent as they pick up on a smattering of other skills. This is the incident that brought you to that path.")]
        Bard,
        [Description("A cavalier is a mounted warrior who abides by some edict or code—even a personal code that may apply only to that cavalier. How exactly this pattern of moral judgments and personal beliefs came to be serves as the foundation of a cavalier’s call to duty. This is how you obtained the code that set you upon the cavalier’s path.")]
        Cavalier,
        [Description("Clerics are not merely people of religious faith—they are devoted servants who wield true divine power from their deities. The particular path that steers a cleric toward her faith can mean the difference between a demonworshiping cultist and a lawful harbinger of her deity’s blessed faith. The following background events outline some of the ways clerics f ind their faith. This is how you came to your faith.")]
        Cleric,
        [Description("Druids come by their primal power in various ways. One druid might receive her power from an elemental creature, and another might learn it from a beast or the fey. This is the event that caused you to come into your power.")]
        Druid,
        [Description("Those who become f ighters take up the sword for many reasons. Some fight for coin, others for duty, and others for survival. This is the event that led you to this profession.")]
        Fighter,
        [Description("Armed with dangerous, emergent technology and blessed with death-defying luck and skill, gunslingers are practically born to be legends. But for every gunslinger who rises to epic fame as a hero or villain, another has been left lifeless at the hands of the weapon she sought to master. Regardless of this destiny, however, no other class is so wedded and intrinsically linked to a single kind of weapon as the gunslinger. How she came to possess, learn, and master the unique power of firearms forms the backbone of every gunslinger’s current motivations. This is the event that caused you to choose the way of the gun.")]
        Gunslinger,
        [Description("Bolstering the ranks of both good and evil deities, inquisitors draw their power from unwavering convictions to the causes of their gods. Unlike clerics and oracles, however, inquisitors are less interested in the theological and metaphysical aspects of faith and belief than what they consider to be the harsh realities of defending that faith. This is the event that made you temper your faith with stern judgment.")]
        Inquisitor,
        [Description("The rare spellcasters known as magi dedicate themselves to the synthesis of two separate disciplines: sword and spell. This core of all magi can be embraced only with ambition and purpose. This is the event that drove you to blend martial powers and magical ability.")]
        Magus,
        [Description("Masters of the martial arts, monks are the pinnacle of discipline and perfection. Wielding strange arms and stranger fighting arts, monks are def ined by their training. Whether brought up as the protege of a grand master or self-taught through stolen glimpses into the windows of a secret school, a monk’s story is emblazoned in every step, cut, and strike he makes. This is the origin of your exotic training.")]
        Monk,
        [Description("Oracles do not choose their path. Rather, the oracle’s mystery chooses her in the midst of a climactic event that marks the oracle with an abiding curse. This is your mystery.")]
        Oracle,
        [Description("Champions of virtue and the rule of law, many paladins are called to their path at a young age. Some hear the whispers of celestial beings in their minds, while other are drawn down the path of the paladin by tragedy and a sincere desire to strike a blow to the evil that stalks the world. Paladins sometimes take on younger charges such as orphans or runaways during their journeys, and the seeds of goodness can be sowed into these impressionable youths to grow another knight on the quest for righteousness. This is the formative event that led you to become a paladin.")]
        Paladin,
        [Description("Rangers are the hunters of legend. Although known for their ability to master varying environments and their dangers, rangers often achieve this expertise through the dedicated pursuit of their quarry. Though such a target could be a lost or kidnapped friend or a forgotten ruin, more often a ranger’s target is a hated enemy, and no feature of the class lends itself better to the establishment of character than his favored enemy. While a professional headhunter might hone his skills to track down humans or other civilized folk, a ranger whose family was murdered by ravenous orcs likely has a different set of priorities while on the hunt. This is the formative event that led you to become a ranger.")]
        Ranger,
        [Description("The rogue’s path is one of cunning, quickness, skill, and stealth. One of the broadest character archetypes, the rogue is found among all walks of life—from highborn spies inf iltrating the courts of kings to common criminals making their livings preying on passersby in the alleys and streets. This is how you came to the profession.")]
        Rogue,
        [Description("Wielders of power on a seemingly impossible scale, sorcerers are conduits of the arcane energies inside them. These powers stem universally from the sorcerers’ distinctive bloodlines. Either linked to powerful scions of mystical power like angels, devils, or dragons or touched by the forces of destiny themselves, sorcerers prove that sometimes when magic is involved, either you have it or you don’t. This is the event that made you aware of the forces at work within your own blood.")]
        Sorcerer,
        [Description("Most, if not all, spellcasters can call to otherworldly creatures for aid. And though many learn to call increasingly powerful minions to assist them, none boast the same connection to these outsiders as summoners do. A summoner is defined by the bond formed with the single creature that acts as his eidolon. Protectors, steeds, and links to other worlds, eidolons are lifelong companions for their mortal masters. The choice to tie oneself to an eidolon and the circumstances leading to that choice form the foundation of any summoner’s character. This is what caused you to forge your otherworldly bond with your trusted companion.")]
        Summoner,
        [Description("Some witches make pacts for their power by choice. Many more discover it by accident or circumstance. This is the event that shaped your early life and sent you down the witch’s path.")]
        Witch,
        [Description("Perhaps no other class exemplif ies the acquisition of power through sheer focus and determination as well as the wizard. Neither touched by divine purpose nor blessed with magic in their blood, wizards must spend their entire lives studying the same texts, tomes, scrolls, and recitations to master the magical arts. Such a craft can be self-taught or instilled through instruction, learned in an academy or at the fringes of the world, but it can be mastered only through the most rigorous and regimented of study. This is how you came to study wizardry, and how that study forever shaped you.")]
        Wizard
    }
    public class Character
    {
        public CharacterClass CharacterClass { get; set; }
        public Race Race { get; set; }

        public OriginStory OriginStory { get; set; }
        public IList<StoryElement> AdolescenceAndTraining { get; set; }

        public IList<StoryElement> AllStoryElements
        {
            get
            {
                List<StoryElement> result = new List<StoryElement>();
                if (OriginStory != null)
                {
                    result.AddRange(OriginStory.ChildhoodEvents);
                    result.AddRange(OriginStory.CircumstancesOfBirth);
                    result.Add(OriginStory.Homeland);
                    result.Add(OriginStory.Parents);
                    result.Add(OriginStory.Siblings);
                }

                if (AdolescenceAndTraining != null)
                    result.AddRange(AdolescenceAndTraining);

                return result;
            }
        }
        public IList<StoryElement> Relationships { get; set; }
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