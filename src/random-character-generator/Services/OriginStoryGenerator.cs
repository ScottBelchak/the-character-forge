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

            result.CircumstancesOfBirth = GenerateCircumstanceOfBirth(race);
            result.ChildhoodEvents = GenerateChildhoodEvents(race);

            return result;
        }
        private IEnumerable<StoryElement> GenerateChildhoodEvents(Race race)
        {
            IList<StoryElement> result = new List<StoryElement>();

            int roll = Roll.d100();

            if (roll.IsBetween(1, 5))
                result.Add(new StoryElement("Academy Training: You attended a private academy where you studied a number of skills and gained training in your current profession. Whether you were a brilliant student or a dropout, the university environment was your home for a good portion of your formative years", "Focused Mind"));
            else if (roll.IsBetween(6, 10))
                result.Add(new StoryElement("Betrayal: A friend or family member whom you trusted more than anyone else betrayed you. You have never fully trusted anyone since and prefer to rely on your own abilities rather than place your trust in others", "Suspicious"));
            else if (roll.IsBetween(11, 15))
                result.Add(new StoryElement("Bullied: In your early life, you were a victim—easy prey for those stronger or cleverer than yourself. They beat you when they could, using you for their sport. This abuse nursed a powerful flame of vengeance.", "Bullied"));
            else if (roll.IsBetween(16, 20))
            {
                StoryElement newStoryElement = new StoryElement("Competition Champion: You distinguished yourself at an early age when you won a competition. This might have been a martial contest of arms, a showing of apprentice magicians, high stakes gambling, or something mundane like an eating championship", "Influence");
                newStoryElement.StoryFeats.Add("Champion");
                result.Add(newStoryElement);
            }
            else if (roll.IsBetween(21, 25))
            {
                StoryElement newStoryElement = new StoryElement("Death in the Family: You were profoundly affected by the death of the relative closest to you—a parent, grandparent, favorite sibling, aunt, uncle, or cousin. This death affected you profoundly, and you’ve never been able to let go of it.", "Reactionary");
                newStoryElement.StoryFeats.Add("Deny the Reaper");
                result.Add(newStoryElement);
            }
            else if (roll.IsBetween(26, 30))
            {
                StoryElement newStoryElement = new StoryElement("Died: You died, or came so close to death that you walked the boundary between the realms of the living and the dead. Having passed from life’s domain once, you have a unique perspective on life, perhaps even a greater appreciation for it—or maybe your experience caused you to reject all trivial things, focusing only on matters of true import.", "Fearless Defiance");
                newStoryElement.StoryFeats.Add("Arisen");
                result.Add(newStoryElement);
            }
            else if (roll.IsBetween(31, 35))
                result.Add(new StoryElement("Fall of a Major Power: In your early years, an old power with far-reaching influence fell into decline. This could have been an empire, a major organization or gang, or a person such as a benevolent king or evil dictator. Your early memories were founded in a world where this great power affected your region for good or ill.", "Worldly"));
            else if (roll.IsBetween(36, 40))
                result.Add(new StoryElement("Fell in with a Bad Crowd: In your youth, you ran with a brutal, evil, or sadistic crowd. You might have belonged to a gang, a thieves’ guild, or some other nefarious organization. It was easy to cave in to pressure and do whatever they told you to do, and your outlook is colored by moral ambiguity", "Child of the Streets"));
            else if (roll.IsBetween(41, 46))
            {
                StoryElement newStoryElement = new StoryElement("First Kill: You’ve had blood on your hands since your youth, when you first took the life of another creature. Whether this act repulsed you or gave you pleasure, it was a formative experience.", "Killer");
                newStoryElement.StoryFeats.Add("Innocent Blood");
                result.Add(newStoryElement);
            }
            else if (roll.IsBetween(46, 50))
            {
                StoryElement newStoryElement = new StoryElement("Troubled First Love: Your first love was everything you imagined it would be. That is, until you were separated from your beloved. This may have been the result of distance, changing perspectives, death, or differences in class or family. Some have said this made you jaded—you think it has granted you insight on how the world really works.", "Worldly");
                newStoryElement.AdditionalInformation = "d12 relationship";
                result.Add(newStoryElement);
            }

            else if (roll.IsBetween(51, 55))
            {
                StoryElement newStoryElement = new StoryElement("Imprisoned: Your criminal record began when you were young. You were imprisoned, punished, and possibly displayed in public as a criminal. Whether or not you committed the crime, the experience has stayed with you.", "Criminal");
                newStoryElement.StoryFeats.Add("Liberator");
                result.Add(newStoryElement);
            }
            else if (roll.IsBetween(56, 60))
                result.Add(new StoryElement("Inheritance: A great sum of wealth or property was bequeathed to you at an early age, providing you with extraordinary means. Daily costs of living have ceased to concern you, and you’ve learned that there is little that money cannot buy.", "Rich Parents"));
            else if (roll.IsBetween(61, 65))
            {
                StoryElement newStoryElement = new StoryElement("Kidnapped: You were kidnapped at some point in your childhood. The kidnappers might have been pirates, slavers, thieves looking for ransom, a powerful guild seeking to blackmail your parents, a cult, and so on else. Before you were released, were ransomed, or escaped, you picked up on various aspects of the criminal underworld.", "Canter");
                newStoryElement.StoryFeats.Add("Liberator");
                result.Add(newStoryElement);
            }
            else if (roll.IsBetween(66, 70))
                result.Add(new StoryElement("Magical Gift: When you were a child, you found, stole, or were given a magic item that gave you an extraordinary ability. You may have used this item for mischief, crime, or good. Since that time, magic items have always held a special fascination for you.", "Magical Talent"));
            else if (roll.IsBetween(71, 75))
            {
                StoryElement newStoryElement = new StoryElement("Major Disaster: You witnessed—and survived—a major disaster in your childhood years, such as a great fire, flood, earthquake, volcano, or storm. It obliterated the settlement where you lived, whether a small village, large city, or entire island.", "Resilient");
                newStoryElement.StoryFeats.Add("Unforgotten");
                result.Add(newStoryElement);
            }
            else if (roll.IsBetween(76, 80))
                result.Add(new StoryElement("Mentorship/Patronage: A mentor or patron took an interest in your development and volunteered to train or sponsor you. This creature’s motives might not be entirely clear, but without its influence you would not be who you are.", "Mentored"));
            else if (roll.IsBetween(81, 85))
                result.Add(new StoryElement("Met a Fantastic Creature: When you were only a child, you made contact with a magical creature, such as a dragon, unicorn, genie, pixie, or similar creature. You learned a powerful lesson or a magic trick from that creature. This meeting changed your life and made you different from the other children.", "Gifted Adept"));
            else if (roll.IsBetween(86, 90))
                result.Add(new StoryElement("Ordinary Childhood: Your childhood was fairly ordinary, with no major blessing or catastrophe—a stark contrast to an adventuring life. You lived your life in anticipation of growing up so you could affect the dull backdrop upon which your mundane life was painted. Now that you’ve grown, it’s easy to miss those tranquil days where nothing ever seemed to happen.", "Ordinary"));
            else if (roll.IsBetween(91, 95))
            {
                StoryElement newStoryElement = new StoryElement("Raiders: A horde of raiders attacked your settlement and killed several of your people. This could have been a tribe of brutal humanoids or the conquering army of a civilized nation. As a result, you harbor deep resentment toward a particular faction, race, or country.", "Axe to Grind");
                newStoryElement.StoryFeats.Add("Foeslayer");
                newStoryElement.StoryFeats.Add("Vengeance");
                result.Add(newStoryElement);
            }
            else
            {
                StoryElement newStoryElement = new StoryElement("The War: You grew up against the backdrop of a major military conflict that affected much of your childhood world. You became accustomed to a short food supply, living in occupied territory, and moving from place to place. Several of the people you knew in your childhood were lost in the war, including members of your family.", "Vagabond Child");
                newStoryElement.StoryFeats.Add("Reaper");
                result.Add(newStoryElement);
            }
            return result;
        }
        private StoryElement Relationship(int roll)
        {
            throw new NotImplementedException();
        }
        private StoryElement GenerateParentsProfession(int roll) //ask for the roll in case of poverty
        {
            if (roll.IsBetween(1, 5))
                return new StoryElement("Parents Profession: Slaves", "Life of Toil");
            else if (roll.IsBetween(6, 25))
                return new StoryElement("Parents Profession: Serfs/Peasants", "Poverty-Stricken");
            else if (roll.IsBetween(26, 30))
                return new StoryElement("Parents Profession: Entertainers", "Talented");
            else if (roll.IsBetween(31, 34))
                return new StoryElement("Parents Profession: Soldiers", "Tactician");
            else if (roll.IsBetween(35, 37))
                return new StoryElement("Parents Profession: Sailors", "Worldly");
            else if (roll.IsBetween(38, 40))
                return new StoryElement("Parents Profession: Thieves", "Child of the Streets");
            else if (roll.IsBetween(41, 55))
                return new StoryElement("Parents Profession: Yeomen", "Savanna Child");
            else if (roll.IsBetween(56, 70))
                return new StoryElement("Parents Profession: Tradespeople", "Artisan", "Life of Toil");
            else if (roll.IsBetween(71, 85))
                return new StoryElement("Parents Profession: Artisans", "Artisan");
            else if (roll.IsBetween(86, 95))
                return new StoryElement("Parents Profession: Merchants", "Merchant");
            else
                return new StoryElement("Parents Profession: Clergy of Cultists", "Child of the Temple");
        }
        private IList<StoryElement> GenerateCircumstanceOfBirth(Race race)
        {
            int roll = Roll.d100();
            if (roll.IsBetween(1, 40))
                return new List<StoryElement>() 
                { 
                    new StoryElement("Lower-Class Birth: You were born among peasants or slum denizens. You grew up working the land around a village or manor, practicing a rudimentary trade, or begging in a settlement.", "Poverty-Stricken"),
                    GenerateParentsProfession(Roll.d20() + Roll.d20())
                };
            else if (roll.IsBetween(41, 65))
                return new List<StoryElement>() 
                { 
                    new StoryElement("Middle-Class Birth: You were born to the middle class, which includes merchants, artisans, and tradespeople. You likely grew up in a good-sized settlement, and one of your parents is likely associated with a guild or other trade organization. As a free person, you don’t experience the bondage of serfdom or peasantry, but you also lack the privilege of the nobility.", "Artisan", "Merchant") ,
                    GenerateParentsProfession(Roll.d100())
                };
            else if (roll.IsBetween(66, 70))
                return new List<StoryElement>() 
                {
                    new StoryElement("Noble Birth: You were born to privilege among the nobility. Unless one of your parents is the regent, your family serves a higher-ranked noble but lesser nobles serve your family in turn.", "Influence", "Rich Parents") ,
                    GetNobility(race)
                };
            else if (roll.IsBetween(71, 72))
                return new List<StoryElement>() 
                { 
                    new StoryElement("Adopted Outside Your Race: You were not raised by your birth family and grew up in a family of a different race than your own."),
                    GetAdopted(race)
                };
            else if (roll.IsBetween(73, 77))
            {
                return new List<StoryElement>() 
                { 
                    new StoryElement("You were not raised by your birth family, but taken in by another family within your race or culture."),
                    GenerateParentsProfession(Roll.d100()),
                    GenerateParentsProfession(Roll.d100())
                };
            }
            else if (roll.IsBetween(78, 81))
            {
                return new List<StoryElement>()
                    {
                        new StoryElement("Bastard Born: Your parents had a tryst that resulted in your birth out of wedlock. You know one of your parents, but the other remains unknown or a distant presence at best.", "Bastard", "Shamed")
                    ,GenerateParentsProfession(Roll.d100())

                    };
            }
            else if (roll == 82)
            {
                return new List<StoryElement>()
                    {
                        new StoryElement("Blessed Birth: When you were born, you were blessed by a being of great power such as an angel, azata, or genie. This blessing has protected you from certain peril or marked you as special to some deity.","Blessed","Birthmark")
                    ,GenerateParentsProfession(Roll.d100())
                    };
            }
            else if (roll.IsBetween(83, 84))
            {
                return new List<StoryElement>()
                    {
                        new StoryElement("Your birth was caused by violent, unwilling means. You have one parent, and the other likely remains unknown.","Axe to Grind","Bastard")
                    ,GenerateParentsProfession(Roll.d100())
                    };
            }
            else if (roll == 85)
            {
                return new List<StoryElement>()
                    {
                        new StoryElement("Born out of Time: You were born in a different era, either the distant past or the far future. Some event has displaced you from your time, and the ways and customs of the present seem strange and alien to you.","Scholar of the Great Beyond")
                    ,GenerateParentsProfession(Roll.d100())
                    };
            }
            else if (roll.IsBetween(86, 87))
            {
                return new List<StoryElement>()
                    {
                        new StoryElement("Born into Bondage: You were born into slavery or servitude. Your parents are likely slaves or servants, or you were sold into slavery as an infant.","Life of Toil") 
                    ,GenerateParentsProfession(Roll.d100())
                    };
            }
            else if (roll == 88)
            {
                var background = new StoryElement("Cursed Birth: When you were born, a powerful fiendish entity tainted your blood in some way and cursed you as an agent of dark prophecy.", "Fiend Blood");
                background.StoryFeats.Add("Accursed");
                return new List<StoryElement>()
                    {
                        background
                    ,GenerateParentsProfession(Roll.d100())
                    };
            }
            else if (roll.IsBetween(89, 90))
            {
                StoryElement newStoryElement = new StoryElement("Dishonored Family: You were born into a family that once was honored among your society but has since fallen into disgrace. Now your family name is loathed and maligned by those who know it, putting you on your guard.", "Reactionary", "");
                newStoryElement.StoryFeats.Add("Lost Legacy");
                newStoryElement.StoryFeats.Add("Redemption");
                return new List<StoryElement>()
                    {
                        newStoryElement
                    ,GenerateParentsProfession(Roll.d100())
                    };
            }
            else if (roll.IsBetween(91, 92))
            {
                return new List<StoryElement>()
                    {
                        new StoryElement("Heir to a Legacy: You are the heir to a family with an old name and a distinguished past. Your family might be wealthy or middle class, but your name itself is worth twice your fortunes.","Influence","Rich Parents")
                    ,GenerateParentsProfession(Roll.d100())
                    };
            }
            else if (roll.IsBetween(93, 94))
            {
                StoryElement newStoryElement = new StoryElement("Left to Die: When you were born you were left to die, but by some twist of circumstance you survived.", "Courageous", "Savage");
                newStoryElement.StoryFeats.Add("Arisen");
                return new List<StoryElement>()
                    {
                        newStoryElement
                    ,GenerateParentsProfession(Roll.d100())
                    };
            }
            else if (roll == 95)
            {
                StoryElement newStoryElement = new StoryElement("A deity has marked you. That mark can be on your body or your soul. ", "Birthmark", "Sacred Touch");
                newStoryElement.StoryFeats.Add("Prophet");
                return new List<StoryElement>()
                    {
                        newStoryElement
                    ,GenerateParentsProfession(Roll.d100())
                    };
            }
            else if (roll == 96)
            {
                StoryElement newStoryElement = new StoryElement("Energy Infused: During your birth you were exposed to potent source of divine energy.", "Sacred Conduit", "Sacred Touch");
                return new List<StoryElement>()
                    {
                        newStoryElement,
                        GenerateParentsProfession(Roll.d100())
                    };
            }
            else if (roll == 97)
            {
                return new List<StoryElement>()
                    {
               new StoryElement("Progeny of Power: You were born during a particularly powerful conjunction or in some other time of power.", "Charming", "Sacred Touch")
                    ,GenerateParentsProfession(Roll.d100())
                    };
            }
            else if (roll == 98)
            {
                return new List<StoryElement>()
                    {
               new StoryElement("Prophesied: Your birth was foretold, as recently as during the last generation to as far back as thousands of years ago", "Prophesized")
                    ,GenerateParentsProfession(Roll.d100())
                    };
            }
            else if (roll == 99)
            {
                StoryElement newStoryElement = new StoryElement("Reincarnated: You have been reborn in many cycles, and may be reborn in many more until you accomplish the ultimate task for which you are destined.", "Reincarnated");
                newStoryElement.StoryFeats.Add("Artisan");
                newStoryElement.StoryFeats.Add("Forgotten Past");
                return new List<StoryElement>()
                    {
                        newStoryElement
                    ,GenerateParentsProfession(Roll.d100())
                    };
            }
            else
            {
                return new List<StoryElement>()
                    {
                        new StoryElement("The sages, priests, or wizards of your society decreed your birth an omen of a coming age or event—perhaps you are an omen of promise, perhaps one of dark times ahead.", "Omen")
                    ,GenerateParentsProfession(Roll.d100())
                    };
            }
        }

        private StoryElement GetAdopted(Race race)
        {
            int roll = Roll.d100();
            if (roll.IsBetween(1, 5))
                return new StoryElement("Adopted by Dragons: For its own purposes, a dragon raised you as its own. You have learned the language and history, wisdom, power, and might of dragonkind.", "Blood of Dragons", "Magical Knack");
            else if (roll.IsBetween(6, 10))
                return new StoryElement("Adopted by the Fey: Your adoptive parents were fey creatures such as korreds, pixies, or a dryad.", "Charming", "Magical Knack");
            else if (roll.IsBetween(11, 13))
            {
                var result = new StoryElement("Raised Among the Dead: Your adoptive parent is a nonliving creature, such as a spectre, ghost, lich, or vampire. You were likely raised in empty ruined halls, among tombs and crypts, by a creature that feeds on life. What its purpose was for raising you, none can say.", "Deathtouched", "Magical Knack");
                result.StoryFeats.Add("Glimpse Beyond");
                return result;
            }
            else if (roll.IsBetween(14, 19))
                return new StoryElement("Raised by Angels: Angels attended your birth and took you to live with them in the heavens. These cosmic beings expanded your view to encompass not just the world but the larger universe. You know that wherever you go, your angelic parents watch over you.", "Blessed");
            else if (roll.IsBetween(20, 25))
            {
                var result = new StoryElement("Raised by Beasts: When you were separated from your biological parents, you were found and raised by wild beasts. Your ways are the ways of the wild, and along with your advanced survival instincts you’ve adopted the natural habits of a specific beast.", "Resilient");
                result.StoryFeats.Add("Feral Heart");
                return result;
            }
            else if (roll.IsBetween(26, 70))
                return new StoryElement("Raised by Civilized Humanoids: You were raised by a community of civilized humanoids of a race different from your own (chosen by your GM). Your attitudes, beliefs, and values reflect that race, although characteristics of your true nature frequently emerge.");
            else if (roll.IsBetween(71, 95))
                return new StoryElement("Raised by Savage Humanoids: You were raised by savage humanoids such as orcs, kobolds, gnolls, troglodytes, or lizardfolk. As a result, your values, customs, and traditions are those of your adoptive parents, though characteristics of your true nature frequently emerge.", "Savage");
            else
            {
                var result = new StoryElement("Fiend Raised: You were separated from your natural parents and raised by a fiend who taught you the cruelty and malice of the gods and worked to fashion you into its own mortal instrument to corrupt innocent souls", "Fiend Bloodline");
                result.StoryFeats.Add("Damned");
                return result;
            }
        }
        private StoryElement GetNobility(Race race)
        {
            if (race == Race.HalfOrc)
                return null;
            int roll = Roll.d100();

            if (roll.IsBetween(1, 60))
                return new StoryElement("Gentry: You are the child of a minor lord, lady, or noble with an income, hereditary land such as a manor, and titles. You likely grew up in a manor and your parents were paid tribute by peasants. Your parents serve a higher baron, count, or duke.");
            else if (roll.IsBetween(61, 78))
                return new StoryElement("Knight: You are the child of a knight, a noble with estates, titles, and lands who serves a lord. Your family has sworn an oath of fealty to a liege—such as a baron, count, or duke—and commits to military service in his or her name. As the child of a knight, you may serve as a squire to another knight while pursuing your own path to knighthood.");
            else if (roll.IsBetween(79, 85))
                return new StoryElement("Baron: You are the child of a baron or baroness, a noble responsible for a land encompassing several smaller manors that pay tribute. Your parents receive orders directly from the monarch, and you’re expected to attend the royal court. You are entitled to hereditary estates, titles, and land.");
            else if (roll.IsBetween(86, 91))
                return new StoryElement("Count: You are the noble child of a count or countess. Your family members receive hereditary titles, land, and estates, and are among the most wealthy nobles in your domain. Knights and minor lords pay tribute to your family, and your parents attend directly to the monarch. You’re expected to attend the royal court.");
            else if (roll.IsBetween(92, 96))
                return new StoryElement("Duke: You are the child of a duke or duchess, the most powerful noble in the realm apart from the royal family. Your parents attend directly to the monarch and have the highest place at court. Your lands, titles, and estates are significant, and many lords and knights serve under your parents’ command.");
            else if (roll.IsBetween(97, 99))
                return new StoryElement("Minor Prince: You are the child of a prince or princess, and part of the royal family. You aren’t the next in succession, but your power and wealth are grand indeed.");
            else
                return new StoryElement("Regent: You are a prince or princess, the son or daughter of the monarch. You owe fealty directly to your parents, and to no one else. Few command the power and wealth you do, and your presence inspires great respect, if not total awe, among those who kneel before the crown.");
        }
        private StoryElement GenerateHomeland(Race race)
        {
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
                        return ElvenHomeland(Roll.d100(), Race.HalfElf);
                    else if (roll.IsBetween(26, 75))
                        return HumanHomeland(Roll.d100(), Race.HalfElf);
                    else if (roll.IsBetween(76, 95))
                        return new StoryElement("Forest", "Log Roller");
                    else
                        return NewUnusualHomeland();
                case Race.HalfOrc:
                    if (roll.IsBetween(1, 25))
                        return new StoryElement("Subterranean", "Scrapper", "Surface Stranger");
                    else if (roll.IsBetween(26, 60))
                        return new StoryElement("Orc Settlement", "Scrapper");
                    else if (roll.IsBetween(61, 75))
                        return HumanHomeland(Roll.d100(), Race.HalfOrc);
                    else
                        return NewUnusualHomeland();
                case Race.Halfling:
                    if (roll.IsBetween(1, 50))
                        return new StoryElement("Halfling Settlement", "Civilized", "Well-informed");
                    else if (roll.IsBetween(51, 80))
                        return new StoryElement("Human Settlement", "Child of the Streets", "Well-informed");
                    else if (roll.IsBetween(81, 95))
                        return new StoryElement("Traveling Band or Caravan", "Friend in Every Town");
                    else
                        return NewUnusualHomeland();
                case Race.Human:
                    return HumanHomeland(roll);
                default:
                    break;
            }
            return null;
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
                        parents = new StoryElement("Both of your parents are dead", "Orphaned");
                    break;
                case Race.Elf:
                    if (roll.IsBetween(1, 79))
                        parents = new StoryElement("Both your parents are still alive");
                    else if (roll.IsBetween(80, 87))
                        parents = new StoryElement("Only your father is alive");
                    else if (roll.IsBetween(88, 95))
                        parents = new StoryElement("Only your mother is alive");
                    else
                        parents = new StoryElement("Both of your parents are dead", "Orphaned");
                    break;
                case Race.Gnome:
                    if (roll.IsBetween(1, 90))
                        parents = new StoryElement("Both your parents are still alive");
                    else if (roll.IsBetween(91, 93))
                        parents = new StoryElement("Only your father is alive");
                    else if (roll.IsBetween(94, 96))
                        parents = new StoryElement("Only your mother is alive");
                    else
                        parents = new StoryElement("Both of your parents are dead", "Orphaned");
                    break;
                case Race.HalfElf:
                    if (roll.IsBetween(1, 20))
                        parents = new StoryElement("Both your parents are still alive");
                    else if (roll.IsBetween(21, 55))
                        parents = new StoryElement("Only your father is alive");
                    else if (roll.IsBetween(56, 90))
                        parents = new StoryElement("Only your mother is alive");
                    else
                        parents = new StoryElement("Both of your parents are dead", "Orphaned");
                    break;
                case Race.HalfOrc:
                    if (roll.IsBetween(1, 10))
                        parents = new StoryElement("Both your parents are still alive");
                    else if (roll.IsBetween(11, 35))
                        parents = new StoryElement("Only your father is alive");
                    else if (roll.IsBetween(36, 60))
                        parents = new StoryElement("Only your mother is alive");
                    else
                        parents = new StoryElement("Both of your parents are dead", "Orphaned");
                    break;
                case Race.Halfling:
                    if (roll.IsBetween(1, 70))
                        parents = new StoryElement("Both your parents are still alive");
                    else if (roll.IsBetween(71, 80))
                        parents = new StoryElement("Only your father is alive");
                    else if (roll.IsBetween(81, 90))
                        parents = new StoryElement("Only your mother is alive");
                    else
                        parents = new StoryElement("Both of your parents are dead", "Orphaned");
                    break;
                case Race.Human:
                    if (roll.IsBetween(1, 50))
                        parents = new StoryElement("Both your parents are still alive");
                    else if (roll.IsBetween(41, 70))
                        parents = new StoryElement("Only your father is alive");
                    else if (roll.IsBetween(71, 90))
                        parents = new StoryElement("Only your mother is alive");
                    else
                        parents = new StoryElement("Both of your parents are dead", "Orphaned");
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
                    if (roll.IsBetween(1, 60))
                    {
                        var numberOfSiblings = Roll.d6() + 1;
                        siblings = new Siblings(String.Format("You have {0} orc siblings", numberOfSiblings), numberOfSiblings > 1 ? "Kin Guardian" : null);
                        for (int i = 0; i < numberOfSiblings; i++)
                            siblings.SiblingList.Add(GenerateSibling());
                    }
                    else if (roll.IsBetween(61, 70))
                    {
                        var numberOfSiblings = Roll.d4();
                        siblings = new Siblings(String.Format("You have {0} human siblings", numberOfSiblings), numberOfSiblings > 1 ? "Kin Guardian" : null);
                        for (int i = 0; i < numberOfSiblings; i++)
                            siblings.SiblingList.Add(GenerateSibling());
                    }
                    else if (roll.IsBetween(71, 80))
                    {
                        var numberOfSiblings = 1;
                        siblings = new Siblings(String.Format("You have {0} half orc sibling", numberOfSiblings), numberOfSiblings > 1 ? "Kin Guardian" : null);
                        siblings.SiblingList.Add(GenerateSibling());
                    }
                    else
                        siblings = new Siblings("You have no siblings");
                    break;
                case Race.Halfling:
                    if (roll.IsBetween(1, 30))
                    {
                        var numberOfSiblings = Roll.d2();
                        siblings = new Siblings(String.Format("You have {0} siblings", numberOfSiblings), numberOfSiblings > 1 ? "Kin Guardian" : null);
                        for (int i = 0; i < numberOfSiblings; i++)
                            siblings.SiblingList.Add(GenerateSibling());
                    }
                    else if (roll.IsBetween(31, 90))
                    {
                        var numberOfSiblings = Roll.d4() + 1;
                        siblings = new Siblings(String.Format("You have {0} siblings", numberOfSiblings), "Kin Guardian");
                        for (int i = 0; i < numberOfSiblings; i++)
                            siblings.SiblingList.Add(GenerateSibling());
                    }
                    else
                        siblings = new Siblings("You have no siblings");
                    break;
                case Race.Human:
                    if (roll.IsBetween(1, 40))
                    {
                        var numberOfSiblings = Roll.d2();
                        siblings = new Siblings(String.Format("You have {0} siblings", numberOfSiblings), numberOfSiblings > 1 ? "Kin Guardian" : null);
                        for (int i = 0; i < numberOfSiblings; i++)
                            siblings.SiblingList.Add(GenerateSibling());
                    }
                    else if (roll.IsBetween(41, 70))
                    {
                        var numberOfSiblings = Roll.d2();
                        var numberOfHalfSiblings = Roll.d2();
                        siblings = new Siblings(String.Format("You have {0} human siblings and {1} half-siblings", numberOfSiblings, numberOfHalfSiblings), "Kin Guardian");
                        for (int i = 0; i < numberOfSiblings; i++)
                            siblings.SiblingList.Add(GenerateSibling());
                        for (int i = 0; i < numberOfHalfSiblings; i++)
                            siblings.SiblingList.Add(GenerateSibling(raceOverride: Roll.d100() < 50 ? "half-elf" : "half-orc"));
                    }
                    else if (roll.IsBetween(71, 90))
                    {
                        var numberOfSiblings = Roll.d4();
                        siblings = new Siblings(String.Format("You have {0} siblings", numberOfSiblings), "Kin Guardian");
                        for (int i = 0; i < numberOfSiblings; i++)
                            siblings.SiblingList.Add(GenerateSibling());
                    }
                    else
                        siblings = new Siblings("You have no siblings");
                    break;
                default:
                    break;
            }
            return siblings;
        }

        private Sibling GenerateSibling(bool isAdopted = false, string raceOverride = null)
        {
            var result = new Sibling()
            {
                Name = NameGenerator.GetRandomName(),
                Gender = Roll.d100() > 50 ? "Brother" : "Sister",
                IsAdopted = isAdopted,
                Race = raceOverride
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

        private StoryElement HumanHomeland(int roll, Race race = Race.Human)
        {
            if (roll.IsBetween(1, 50))
                return new StoryElement("Town of Village", "Milita Veteran");
            else if (roll.IsBetween(51, 85))
            {
                if (race == Race.HalfElf)
                    return new StoryElement("City or Metropolis", "Civilized", "Failed Apprentice");
                else if (race == Race.HalfOrc)
                    return new StoryElement("City or Metropolis", "Brute", "Vagabond Child");
                else
                    return new StoryElement("City or Metropolis", "Civilized", "Vagabond Child");
            }
            else if (roll.IsBetween(86, 95))
            {
                return new StoryElement("Frontier", "Frontier-Forged");
            }
            else
                return NewUnusualHomeland();
        }
        private StoryElement ElvenHomeland(int roll, Race race = Race.Elf)
        {
            if (roll.IsBetween(1, 60))
                return new StoryElement("Forest", "Log Roller");
            else if (roll.IsBetween(61, 80))
            {
                if (race == Race.HalfElf)
                    return new StoryElement("Non-Elven City or Metropolis", "Civilized", "Failed Apprentice");
                else
                    return new StoryElement("Non-Elven City or Metropolis", "Civilized", "Forlorn");
            }
            else if (roll.IsBetween(81, 95))
            {
                if (race == Race.HalfElf)
                    return new StoryElement("Non-Elven Town or Village", "Failed Apprentice");
                else
                    return new StoryElement("Non-Elven Town or Village", "Forlorn");
            }
            else
                if (race == Race.HalfElf)
                    return NewUnusualHomeland("Elven Reflexes");
                else
                    return NewUnusualHomeland("Forlorn");
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