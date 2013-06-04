using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using random_character_generator.Models;

namespace random_character_generator.Services
{
    public static class Extensions
    {
        public static bool IsBetween(this int obj, int low, int high)
        {
            return obj >= low && obj <= high;
        }
    }
    public class OriginStoryGenerator : OriginStory
    {
        private readonly IRandomNameGenerator NameGenerator;
        private readonly IDiceRoller Roll;
        /// <summary>
        /// Initializes a new instance of the OriginStoryGenerator class.
        /// </summary>
        /// <param name="nameGenerator"></param>
        public OriginStoryGenerator(IRandomNameGenerator nameGenerator, IDiceRoller roller)
        {
            Roll = roller;
            NameGenerator = nameGenerator;
        }

        public OriginStory Generate(Race race)
        {
            OriginStory result = new OriginStory();

            result.Homeland = GenerateHomeland(race);
            result.Parents = GenerateParents(race);
            result.Siblings = GenerateSiblings(race);
            return result;
        }
        private StoryElement GenerateHomeland(Race race)
        {
            StoryElement homeland = null;
            int roll = Roll.d100();
            switch (race)
            {
                case Race.Dwarf:
                    if (roll.IsBetween(1, 40))
                        return new StoryElement("Hills or Mountains", "Highlander", "Goldsniffer");
                    else if (roll.IsBetween(41, 80))
                        return new StoryElement("Underground", "Surface Stranger", "Tunnel Fighter");
                    else if (roll.IsBetween(81, 87))
                        return new StoryElement("Non-Dwarven Town or Village", "Brewmaster", "Militia Veteran");
                    else if (roll.IsBetween(88, 95))
                        return new StoryElement("Non-Dwarven City or Metropolis", "Brewmaster", "Vagabond Child");
                    else
                        return NewUnusualHomeland();
                case Race.Elf:
                    return ElvenHomeland(roll);
                case Race.Gnome:
                    if (roll.IsBetween(1, 30))
                        return new StoryElement("Forest", "Log Roller");
                    else if (roll.IsBetween(31, 65))
                        return new StoryElement("Non-Gnome Town or Village", "Animal Friend");
                    else if (roll.IsBetween(66, 95))
                        return new StoryElement("Non-Gnome City or Metropolis", "Rapscallion");
                    else
                        return NewUnusualHomeland();
                case Race.HalfElf:
                    if (roll.IsBetween(1, 25))
                        return ElvenHomeland(Roll.d100(), true);
                    else if (roll.IsBetween(26, 75))
                        return HumanHomeland(Roll.d100(), true);
                    else if (roll.IsBetween(76, 95))
                        return new StoryElement("Forest", "Log Roller");
                    else 
                        return NewUnusualHomeland();
                case Race.HalfOrc:
                    break;
                case Race.Halfling:
                    break;
                case Race.Human:
                    break;
                default:
                    break;
            }
            return homeland;
        }

        private StoryElement HumanHomeland(int p1, bool p2)
        {
            return new StoryElement("Human");
        }
        private StoryElement ElvenHomeland(int roll, bool isHalfElf = false)
        {
            if (roll.IsBetween(1, 60))
                return new StoryElement("Forest", "Log Roller");
            else if (roll.IsBetween(61, 80))
            {
                if (isHalfElf)
                    return new StoryElement("Non-Elven City or Metropolis", "Civilized", "Failed Apprentice");
                else
                    return new StoryElement("Non-Elven City or Metropolis", "Civilized", "Forlorn");
            }
            else if (roll.IsBetween(81, 95))
            {
                if (isHalfElf)
                    return new StoryElement("Non-Elven Town or Village", "Failed Apprentice");
                else
                    return new StoryElement("Non-Elven Town or Village", "Forlorn");
            }
            else
                if (isHalfElf)
                    return NewUnusualHomeland("Elven Reflexes");
                else
                    return NewUnusualHomeland("Forlorn");
        }
        private StoryElement GenerateParents(Race race)
        {
            StoryElement parents = null;
            int roll = Roll.d100();
            switch (race)
            {
                case Race.Dwarf:
                    if (roll.IsBetween(1, 60))
                        parents = new StoryElement("Both your parents are still alive");
                    else if (roll.IsBetween(61, 73))
                        parents = new StoryElement("Only your father is alive");
                    else if (roll.IsBetween(74, 86))
                        parents = new StoryElement("Only your mother is alive");
                    else
                        parents = new StoryElement("Both of your parents are dead", "Orphaned social");
                    break;
                case Race.Elf:
                    if (roll.IsBetween(1, 79))
                        parents = new StoryElement("Both your parents are still alive");
                    else if (roll.IsBetween(80, 87))
                        parents = new StoryElement("Only your father is alive");
                    else if (roll.IsBetween(88, 95))
                        parents = new StoryElement("Only your mother is alive");
                    else
                        parents = new StoryElement("Both of your parents are dead", "Orphaned social");
                    break;
                case Race.Gnome:
                    if (roll.IsBetween(1, 90))
                        parents = new StoryElement("Both your parents are still alive");
                    else if (roll.IsBetween(91, 93))
                        parents = new StoryElement("Only your father is alive");
                    else if (roll.IsBetween(94, 96))
                        parents = new StoryElement("Only your mother is alive");
                    else
                        parents = new StoryElement("Both of your parents are dead", "Orphaned social");
                    break;
                case Race.HalfElf:
                     if (roll.IsBetween(1, 20))
                        parents = new StoryElement("Both your parents are still alive");
                    else if (roll.IsBetween(21, 55))
                        parents = new StoryElement("Only your father is alive");
                    else if (roll.IsBetween(56, 90))
                        parents = new StoryElement("Only your mother is alive");
                    else
                        parents = new StoryElement("Both of your parents are dead", "Orphaned social");
                    break;
                case Race.HalfOrc:
                    break;
                case Race.Halfling:
                    break;
                case Race.Human:
                    break;
                default:
                    break;
            }


            return parents;
        }

        private Siblings GenerateSiblings(Race race)
        {
            Siblings siblings = null;
            int roll = Roll.d100();
            switch (race)
            {
                case Race.Dwarf:
                    if (roll.IsBetween(1, 80))
                    {
                        var numberOfSiblings = new Random().Next(1, 4);
                        siblings = new Siblings(String.Format("You have {0} biological siblings", numberOfSiblings), numberOfSiblings > 1 ? "Kin Guardian" : null);
                        for (int i = 0; i < numberOfSiblings; i++)
                            siblings.SiblingList.Add(GenerateSibling());
                    }
                    else if (roll.IsBetween(81, 90))
                    {
                        var numberOfSiblings = new Random().Next(1, 4) + 1;
                        siblings = new Siblings(String.Format("You have {0} biological siblings", numberOfSiblings), "Kin Guardian");
                        for (int i = 0; i < numberOfSiblings; i++)
                            siblings.SiblingList.Add(GenerateSibling());
                    }
                    else if (roll.IsBetween(91, 95))
                    {
                        var numberOfBioligicalSiblings = Roll.d3() - 1;
                        var numberOfAdoptedSiblings = Roll.d3() - 1;
                        siblings = new Siblings(String.Format("You have {0} biological siblings and {1} adopted siblings.", numberOfBioligicalSiblings, numberOfAdoptedSiblings), "Kin Guardian");
                        for (int i = 0; i < numberOfBioligicalSiblings; i++)
                            siblings.SiblingList.Add(GenerateSibling());
                        for (int i = 0; i < numberOfAdoptedSiblings; i++)
                            siblings.SiblingList.Add(GenerateSibling(true));
                    }
                    else
                        siblings = new Siblings("You have no siblings");
                    break;
                case Race.Elf:
                    if (roll.IsBetween(1, 80))
                    {
                        var numberOfSiblings = Roll.d2();
                        siblings = new Siblings(String.Format("You have {0} biological siblings", numberOfSiblings), numberOfSiblings > 1 ? "Kin Guardian" : null);
                        for (int i = 0; i < numberOfSiblings; i++)
                            siblings.SiblingList.Add(GenerateSibling());
                    }
                    else if (roll.IsBetween(81, 85))
                    {
                        var numberOfSiblings = Roll.d4() + 1;
                        siblings = new Siblings(String.Format("You have {0} biological siblings", numberOfSiblings), "Kin Guardian");
                        for (int i = 0; i < numberOfSiblings; i++)
                            siblings.SiblingList.Add(GenerateSibling());
                    }
                    else if (roll.IsBetween(86, 90))
                    {
                        var numberOfBioligicalSiblings = Roll.d4() + 1;
                        siblings = new Siblings(String.Format("You have {0} biological siblings. {1} of these siblings are half-elves, adopted, or a mix of the two (your choice).", numberOfBioligicalSiblings, Roll.d3() - 1), "Kin Guardian");
                        for (int i = 0; i < numberOfBioligicalSiblings; i++)
                            siblings.SiblingList.Add(GenerateSibling());
                    }
                    else
                        siblings = new Siblings("You have no siblings");
                    break;
                case Race.Gnome:
                    if (roll.IsBetween(1, 50))
                    {
                        var numberOfSiblings = Roll.d4();
                        siblings = new Siblings(String.Format("You have {0} biological siblings", numberOfSiblings), numberOfSiblings > 1 ? "Kin Guardian" : null);
                        for (int i = 0; i < numberOfSiblings; i++)
                            siblings.SiblingList.Add(GenerateSibling());
                    }
                    else if (roll.IsBetween(51, 60))
                    {
                        var numberOfSiblings = Roll.d4() - 1;
                        siblings = new Siblings(String.Format("You have {0} biological siblings and one adopted sibling", numberOfSiblings), "Kin Guardian");
                        for (int i = 0; i < numberOfSiblings; i++)
                            siblings.SiblingList.Add(GenerateSibling());

                        siblings.SiblingList.Add(GenerateSibling(true));
                    }
                    else
                        siblings = new Siblings("You have no siblings");
                    break;
                case Race.HalfElf:
                    if (roll.IsBetween(1, 20))
                    {
                        var numberOfSiblings = Roll.d2();
                        siblings = new Siblings(String.Format("You have {0} half-siblings (either human or elf, your choice)", numberOfSiblings), numberOfSiblings > 1 ? "Kin Guardian" : null);
                        for (int i = 0; i < numberOfSiblings; i++)
                            siblings.SiblingList.Add(GenerateSibling());
                    }
                    else if (roll.IsBetween(21, 30))
                    {
                        var numberOfSiblings = 1;
                        siblings = new Siblings(String.Format("One half-elf sibling", numberOfSiblings), "Kin Bond");
                        for (int i = 0; i < numberOfSiblings; i++)
                            siblings.SiblingList.Add(GenerateSibling());
                    }
                    else
                        siblings = new Siblings("You have no siblings");
                    break;
                case Race.HalfOrc:
                    break;
                case Race.Halfling:
                    break;
                case Race.Human:
                    break;
                default:
                    break;
            }
            return siblings;
        }

        private Sibling GenerateSibling(bool isAdopted = false)
        {
            var result = new Sibling()
            {
                Name = NameGenerator.GetRandomName(),
                Gender = Roll.d100() > 50 ? "Brother" : "Sister",
                IsAdopted = isAdopted
            };
            int olderRoll = Roll.d100();
            if (olderRoll.IsBetween(1, 48))
                result.IsYounger = true;
            else if (olderRoll.IsBetween(49, 96))
                result.IsYounger = false;
            if (isAdopted)
                result.Race = GetRandomAdoptedSiblingRace();
            return result;
        }

        private string GetRandomAdoptedSiblingRace()
        {
            int roll = Roll.d100();
            if (roll == 1) return "Aasimar";
            else if (roll == 2) return "Catfolk";
            else if (roll == 3 || roll == 4) return "Changeling";
            else if (roll == 5) return "Dhampir";
            else if (roll == 6) return "Duergar";
            else if (roll.IsBetween(7, 16)) return "Dwarf";
            else if (roll.IsBetween(17, 26)) return "Elf";
            else if (roll == 27) return "Fetchling";
            else if (roll == 28) return "Gillman";
            else if (roll.IsBetween(29, 38)) return "Gnome";
            else if (roll == 39) return "Goblin";
            else if (roll == 40) return "Grippli";
            else if (roll.IsBetween(41, 50)) return "Half-Elf";
            else if (roll.IsBetween(51, 60)) return "Half-Orc";
            else if (roll.IsBetween(61, 70)) return "Halfling";
            else if (roll == 71) return "Hobgoblin";
            else if (roll.IsBetween(72, 81)) return "Human";
            else if (roll == 82) return "Ifrit";
            else if (roll == 83) return "Kitsune";
            else if (roll == 84) return "Kobold";
            else if (roll == 85) return "Merfolk";
            else if (roll == 86) return "Nagaji";
            else if (roll == 87) return "Orc";
            else if (roll == 88) return "Oread";
            else if (roll == 89) return "Ratfolk";
            else if (roll == 90) return "Samsaran";
            else if (roll == 91) return "Strix";
            else if (roll == 92) return "Suli";
            else if (roll == 92) return "Svirfneblin";
            else if (roll == 94) return "Sylph";
            else if (roll == 95) return "Tengu";
            else if (roll == 96) return "Tiefling";
            else if (roll == 97) return "Undine";
            else if (roll == 98) return "Vanara";
            else if (roll == 99) return "Ifrit";
            else return "Ifrit";
        }




        private StoryElement NewUnusualHomeland(string additionalTrait = null)
        {
            int roll = Roll.d100();
            if (roll.IsBetween(1, 10)) return new StoryElement("Subterranean", "Surface", additionalTrait);
            else if (roll.IsBetween(11, 25)) return new StoryElement("Mountains", "Highlander", additionalTrait);
            else if (roll.IsBetween(26, 40)) return new StoryElement("Plains", "Savanna Child", additionalTrait);
            else if (roll.IsBetween(41, 50)) return new StoryElement("Town or Village", "Militia Veteran", additionalTrait);
            else if (roll.IsBetween(51, 60)) return new StoryElement("City or Metropolis", "Civilized", "Vagabond Child", additionalTrait);
            else if (roll.IsBetween(61, 70)) return new StoryElement("Forest", "Log Roller", additionalTrait);
            else if (roll.IsBetween(71, 80)) return new StoryElement("River, Swamp, or Wetlands", "River Rat", additionalTrait);
            else if (roll.IsBetween(81, 85)) return new StoryElement("Desert", "Desert Child", additionalTrait);
            else if (roll.IsBetween(86, 90)) return new StoryElement("Sea", "Sea-Souled", additionalTrait);
            else if (roll.IsBetween(91, 95)) return new StoryElement("Tundra", "Tundra Child", additionalTrait);
            else return new StoryElement("Another Plane", "Scholar of the Great Beyond", additionalTrait);
        }
    }
}