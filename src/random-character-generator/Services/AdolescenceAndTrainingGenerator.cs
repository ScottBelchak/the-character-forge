﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using random_character_generator.Models;

namespace random_character_generator.Services
{
    public class AdolescenceAndTrainingGenerator
    {
        private readonly IDiceRoller Roll;
        /// <summary>
        /// Initializes a new instance of the AdolescenceAndTrainingGenerator class.
        /// </summary>
        /// <param name="roll"></param>
        public AdolescenceAndTrainingGenerator(IDiceRoller roll)
        {
            Roll = roll;
        }
        public IList<StoryElement> Generate(CharacterClass characterClass)
        {
            var result = new List<StoryElement>();

            result.Add(GenerateClassTraining(characterClass));
            result.Add(GenerateInfluentialAssociate());
            return result;
        }


        private StoryElement GenerateInfluentialAssociate()
        {
            int roll = Roll.d100();
            if (roll.IsBetween(1, 5))
                return new StoryElement("Influential Associate: The Hunter: This person was a lone wolf who nonetheless cautiously allowed you to become a member of her solitary pack. She taught you how to thrive on your own in spite of the many perils and natural dangers of your native environment.", "Child of Nature");
            if (roll.IsBetween(6, 10))
                return new StoryElement("Influential Associate: The Pariah: You met a disgraced exile, and found in his words and attitudes something that spoke to you. What once seemed true in your religion, society, or family began to appear false the more time you spent with this person, and you quickly learned not to trust everyone you meet—especially among those who would claim to be most deserving of it.", "Suspicious");
            if (roll.IsBetween(11, 15))
                return new StoryElement("Influential Associate: The Confidante: There was a person in your life to whom you could tell anything. She knows your deepest secrets and your emotional weaknesses and vulnerabilities just as you know hers. This person could be a valuable friend and a frightening enemy, so you make sure to never divulge her secrets or give her a reason to do so with yours.", "Trustworthy");
            if (roll.IsBetween(16, 20))
                return new StoryElement("Influential Associate: The Mentor: You had a mentor who taught you everything worth knowing about life. This could have been the person who taught you the heroic abilities you possess, or simply a kindred spirit who helped form your worldview.", "Mentored");
            if (roll.IsBetween(21, 25))
                return new StoryElement("Influential Associate: The Mercenary: With this person, there was always a cost. No deed was done making a trade for something of equal or greater value. Whether this individual’s actions tended toward good, evil, or pure balance, he was always fair in his dealings. You respected this trait and it influenced your own philosophy", "Mercenary");
            if (roll.IsBetween(26, 30))
            {
                StoryElement newStoryElement = new StoryElement("Influential Associate: The Lover: You had a romantic connection in your adolescent years, and this person deeply influenced your personality. Perhaps this was a first love, a casual partner you grew close to, or the one who got away. The experience bolstered your confidence in romantic interactions even though you often find your thoughts still straying toward that special someone from so long ago.", "Charming");
                newStoryElement.StoryFeats.Add("True Love");
                return newStoryElement;
            }
            if (roll.IsBetween(31, 35))
                return new StoryElement("Influential Associate: The Fool: One of your close associates was a clown who mocked propriety and custom, instead engaging in wild and somewhat random actions from time to time. After a while, you learned that there was simple wisdom to this foolery—a careless worldview that taught you how to cast off concern", "Unpredictable");
            if (roll.IsBetween(36, 40))
                return new StoryElement("Influential Associate: The Liege Lord: You became close with someone you were bound to serve, be it a minor lord or lady, master (in the case of a slave), prince or princess, king or queen. Though this person held power over you, she held you closer than a subject or servant. As a result, you’re used to dealing with and being close to power, and your name is known among the ranks of the privileged.", "Liege Lord");
            if (roll.IsBetween(41, 45))
                return new StoryElement("Influential Associate: The Relative: There is a relative you were especially close to. To you, this person was the meaning of family. He helped shepherd you into adulthood, teaching you everything you know about the world. You are bound to this person or his memory, and you strive to keep a promise, vow, or oath that you made to him.", "Oathbound");
            if (roll.IsBetween(46, 50))
                return new StoryElement("Influential Associate: The Boss: You once gained employment under an organized and powerful individual with farreaching influence. When the boss was present, everyone listened. This could have been a military commander, tribal chieftain, guild leader, or gang leader. From the boss, you learned how to make people listen, make them see reason, and keep them in line.", "Natural-Born Leader");
            if (roll.IsBetween(51, 55))
                return new StoryElement("Influential Associate: The Academic: One of your associates had such a lust for knowledge that she could never be satisfied with simple answers or obvious solutions. This desire for knowledge frequently exceeded her need for companionship, but you were the single exception. Through this association you developed a keen appreciation for numbers, geometry, logic, hard study, and problem solving.", "Mathmatical Prodigy");
            if (roll.IsBetween(56, 60))
                return new StoryElement("Influential Associate: The Criminal: One of your associates committed crimes regularly. He regaled you with many stories of daring robberies and break-ins—and perhaps even murders. You learned most of what you know of the criminal element from him, and he trusted you as a friend.", "Canter");
            if (roll.IsBetween(61, 65))
                return new StoryElement("Influential Associate: You were close to a person who claimed to see the future—perhaps an oracle, seer, prophet, or merely some festival charlatan. Whether they’re true or a trick, you’ve seen visions of distant places and of times that may come to pass. The seer’s influence either made you into an optimist with a drive to change the future or a fatalist resigned to accept it.", "Scholar Beyond the Great Beyond");
            if (roll.IsBetween(66, 70))
                return new StoryElement("Influential Associate: The Mystic: You were especially close to a holy person in your community who fundamentally changed your life by opening your eyes to the incredible powers that exist beyond the natural world. Regardless of whether you follow a faith, certain religious artifacts, rituals, and texts played a large part in making you the person you are.", "Child of the Temple");
            if (roll.IsBetween(71, 75))
            {
                StoryElement newStoryElement = new StoryElement("Influential Associate: The Dead One: One of your greatest influences was a sentient undead creature, such as a ghost, lich, grave knight, wraith, or vampire. You encountered it on several occasions and survived… mostly unscathed. Through this strange relationship you learned of its mortal life, giving you perspective on your own life.", "Deathtouched");
                newStoryElement.StoryFeats.Add("Glimpse Beyond");
                return newStoryElement;
            }
            if (roll.IsBetween(76, 80))
            {
                StoryElement newStoryElement = new StoryElement("Influential Associate: The Fiend: In your adolescent years, you dealt with or were possessed by a fiend who lent you raw power at a time of great need. This experience tainted your body and mind and changed your life. Some part of the demon remains inside you like an old friend, influencing you toward destructive ends.", "Possessed");
                newStoryElement.StoryFeats.Add("Damned");
                return newStoryElement;
            }
            if (roll.IsBetween(81, 85))
                return new StoryElement("Influential Associate: The Wanderer: You knew someone who traveled from place to place with the changing of the wind, such as a minstrel, convict, merchant, outcast, soldier, or sailor. This person brought you wondrous mementos and told you of all the places he had traveled and the people who lived there, inspiring a wanderlust within you", "Worldly");
            if (roll.IsBetween(86, 90))
                return new StoryElement("Influential Associate: The Champion: You were close to someone who excelled at athletic endeavors and tests of strength or skill. Through your friendship or rivalry, you developed the competitive spirit that continues to drive you in everything you do.", "Ambitious");
            if (roll.IsBetween(91, 95))
                return new StoryElement("Influential Associate: The Craftsperson: One of your major influences cherished perfection in every form of art. This person might have followed any path in life, from craftsperson to artist to assassin. From this person you developed a disciplined mind, a solitary focus, and the ability to create something useful and beautiful.", "Artisan");
            else
                return new StoryElement("Influential Associate: Well-Connected Friend: In your circle of disparate associates, there was someone everyone knew. This person collected friends like trophies, and she had contacts in every social or professional circle. Through this connection, you continue to meet and associate with a wide variety of people in every walk of life.", "Well Informed (regardless of race)");
        }
        private StoryElement GenerateClassTraining(CharacterClass characterClass)
        {
            int roll = Roll.d100();
            switch (characterClass)
            {
                case CharacterClass.Alchemist:
                    return Alchemist(roll);
                case CharacterClass.Barbarian:
                    return Barbarian(roll);
                case CharacterClass.Bard:
                    return Bard(roll);
                case CharacterClass.Cavalier:
                    return Cavalier(roll);
                case CharacterClass.Cleric:
                    return Cleric(roll);
                case CharacterClass.Druid:
                    return Druid(roll);
                case CharacterClass.Fighter:
                    return Fighter(roll);
                case CharacterClass.Gunslinger:
                    return Gunslinger(roll);
                case CharacterClass.Inquisitor:
                    return Inquisitor(roll);
                case CharacterClass.Magus:
                    return Magus(roll);
                case CharacterClass.Monk:
                    return Monk(roll);
                case CharacterClass.Oracle:
                    return Oracle(roll);
                case CharacterClass.Paladin:
                    return Paladin(roll);
                case CharacterClass.Ranger:
                    return Ranger(roll);
                case CharacterClass.Rogue:
                    return Rogue(roll);
                case CharacterClass.Sorcerer:
                    return Sorceror(roll);
                case CharacterClass.Summoner:
                    return Summoner(roll);
                case CharacterClass.Witch:
                    return Witch(roll);
                case CharacterClass.Wizard:
                    return Wizard(roll);
                default:
                    break;
            }
            return null;
        }

        private static StoryElement Alchemist(int roll)
        {
            if (roll.IsBetween(1, 10))
                return new StoryElement("Accidental Discovery: Your keen intellect has always been an asset in your studies of the alchemical arts, but along with your logic and rationale, you have a “sense” for alchemy. This intuition sometimes leads to discoveries through methods most of your peers would never have thought possible, but that you somehow know will work.", "Alchemical Intuition");
            if (roll.IsBetween(11, 20))
                return new StoryElement("Firebug: Although you’ve studied all aspects of the alchemist’s craft, your have a talent for fire. Fire has always been a seductive and powerful force that you have either embraced with glee or focused care. You are adept at exploiting a weakness to fire when you recognize it.", "Focused Burn");
            if (roll.IsBetween(21, 30))
                return new StoryElement("Wasn’t Strong Enough: You suffered something at an early age that made you feel powerless. Maybe a relative died from plague, a friend was crushed beneath rubble you were too weak to move, or some other horrible tragedy occurred. You turned to alchemy to transcend the limitations of your physical form. Your relentless dedication has made your bolstering abilities more persistent", "Endless Mutagen");
            if (roll.IsBetween(31, 40))
                return new StoryElement("Magic for the Uninclined: You were always interested in the arcane, but lacked the innate magic of sorcerers or the single-minded dedication possessed by wizards. As a disciple of science, the magic of faith was also closed to you. You dedicated yourself to alchemy, focusing on extracts that mimic the magic you once hoped to wield. That original interest in magic still grants you occasional rare insight into the workings of your formulae.", "Cross-Knowledge");
            if (roll.IsBetween(41, 50))
                return new StoryElement("Master Craftsman: The first time you saw air mix with the shapeless goo of a tanglefoot bag or shielded your eyes at the heatless light of a sunrod, you became ensnared by the wonders of alchemy. You’ve since labored to learn the secrets to crafting such items.", "Alchemical Adept");
            if (roll.IsBetween(51, 60))
                return new StoryElement("Physician: Alchemy was the natural outgrowth of your time spent learning the healer’s craft. Your first extracts were the accidental byproduct of making poultices and elixirs. Continuing your studies, you found the natural compassion you had as a healer mixing with an alchemist’s cold logic, forging you into a clinician unlike most others.", "Precise Treatment");
            if (roll.IsBetween(61, 70))
                return new StoryElement("Formulae Stickler: To you, alchemy is a delicate and complex symphony requiring multiple different elements to work together to produce the perfect result. Though others in your craft come up with ways to substitute certain ingredients when making bombs or mutagens, you disdain such practices, deeming them pollutions. To you, there is always a perfect ingredient and its addition makes your alchemy more potent.", "Meticulous Concoction");
            if (roll.IsBetween(71, 80))
                return new StoryElement("Nature’s Foe: You lost something or someone important to you through the cruel indifference of nature. Perhaps you watched someone get swallowed by a storm-tossed sea or witnessed a summer forest fire destroy your home and all of your possessions. No matter the impetus, the unpredictability of nature made you feel small and helpless. Your subsequent devotion to alchemy has been in no small part due to a desire to exert control over nature itself, a domineering intent palpable to all creatures of nature.", "Unnatural Revenge");
            if (roll.IsBetween(81, 90))
                return new StoryElement("To Recreate a Miracle: Your life or the life of someone you loved was saved by a magical elixir. Witnessing this instilled a sense of awe for the art of alchemy. Although your research has not yet been able to recreate the sheer potency of that draught long ago, your years questing to duplicate it have made you adept at brewing potions.", "Perfectionist's Brew");
            else
                return new StoryElement("Mad Alchemist: Rampant curiosity and a near fearlessness of the unknown drove you to experiment with the rudiments of alchemy. That curiosity has uncovered interesting alchemical secrets, at the cost of alchemical instability. Some consider your experiments mad.", "Unstable Mutagen");
        }
        private static StoryElement Barbarian(int roll)
        {
            if (roll.IsBetween(1, 10))
            {
                StoryElement newStoryElement = new StoryElement("Vengeance: When you were young, a great wrong was done to you, a loved one, your family, or your people. This experience tore you apart and reduced you to a being of primal emotions. Dreams of vengeance became your only promise of comfort.", "Axe to Grind");
                newStoryElement.StoryFeats.Add("Foeslayer");
                newStoryElement.StoryFeats.Add("Vengeance");
                return newStoryElement;
            }
            if (roll.IsBetween(11, 20))
            {
                StoryElement newStoryElement = new StoryElement("Champion of a God: At your coming-of-age ritual, your deity, totem, or patron spirit sparked your soul with a religious zeal. This entity might be a beast spirit, a warmongering god, a demon lord, or some other supernatural entity. In the name of this otherworldly force you become an unstoppable warrior—the bane of all your tribe’s foes.", "Inspired");
                newStoryElement.StoryFeats.Add("Champion");
                return newStoryElement;
            }
            if (roll.IsBetween(21, 30))
                return new StoryElement("Conquest: Upon coming of age, you went on your first raid, where you learned the thrill of violence and chaos and the satisfaction that came with the spoils of your victory. When your enemies dare to stand against you, your rage rekindles until you have conquered and subdued them.", "Killer");
            if (roll.IsBetween(31, 40))
            {
                StoryElement newStoryElement = new StoryElement("Hated Foe: In your formative years, you learned to despise a certain individual, tribe, kingdom, empire, race, or monster due to some slight it inflicted upon you or your people. This foe lurks ever close to your thoughts. So intense is your hatred that the mere thought of this foe can incite your rage.", "Reckless");
                newStoryElement.StoryFeats.Add("Foeslayer");
                return newStoryElement;
            }
            if (roll.IsBetween(41, 50))
                return new StoryElement("Personal Flaw: There is a part of yourself that you hate more than anything else. In your adolescence, you first realized this imperfection— to your lasting shame. This might be a gentle part of yourself you wish to eliminate or a brutal, prideful, greedy, or monstrous side you can’t control. Your rage is fueled by self-loathing, or by projecting this part of yourself onto a foe you wish to destroy.", "Axe to Grind");
            if (roll.IsBetween(51, 60))
                return new StoryElement("Hatred of Civilization: When you first encountered civilization in your youth, its weak and decadent people revolted you. Once, such people were free and strong, but rules and laws made them feeble. Your rage is the wild part— the pure part—of yourself that separates you from the craven ways of “civilized” people.", "Savage");
            if (roll.IsBetween(61, 70))
                return new StoryElement("Persecution: You grew up under the persecution of another power—perhaps a rival tribe, an expansionistic empire, or a tribe of violent monsters. Beaten and bloodied, your people barely survived the onslaught. But the beatings made you strong and taught you how to channel the pain into something useful. Since that time, the flame of rage has burned inside you, waiting to be released against your oppressors.", "Bullied");
            if (roll.IsBetween(71, 80))
                return new StoryElement("One of a Dying Breed: You grew up knowing that your people were slowly dying out—that your extinction was inevitable in the face of the changing world. In youthful vigor, you declared that your fire would not be snuffed without a fight. Your rage stems from the desperate desire to be remembered, to make a mark upon the world before the sun sets on your dwindling kind. When you rage, a single thought permeates your burning mind: If you’re going down, you’re taking everyone with you.", "Reactionary");
            if (roll.IsBetween(81, 90))
                return new StoryElement("Chaos Embraced: You grew up in wild lands where there were no laws except for those of nature—the laws of the predator and the prey. You searched for meaning in the world, in the gods, in the prayers of priests, in the patterns of the stars, but you found nothing. There is no true order to the natural universe except for that of raw and unbridled power. Chaos is the natural state of all things, and that’s how you like it.", "Unpredictable");
            else
            {
                StoryElement newStoryElement = new StoryElement("Bloodthirsty: The first time you spilled a deserving foe’s blood and watched the thing’s life ebb out onto the hard ground, you found yourself filled with a mad, euphoric ecstasy like none other. The memory of this visceral experience returns to you in every battle, like an insatiable addiction that can only be abated with further bloodshed.", "Bloodthirsty");
                newStoryElement.StoryFeats.Add("Innocent Blood");
                return newStoryElement;
            }
        }
        private static StoryElement Bard(int roll)
        {
            if (roll.IsBetween(1, 10))
                return new StoryElement("Celebrity: In your formative years, you saw a player or troupe of players perform before an enthralled audience. That’s when you decided that you wanted to be up on that stage performing for the adulation of the crowd.", "Charming", "Influence");
            if (roll.IsBetween(11, 20))
                return new StoryElement("Cultural Mandate: There has always been a revered storyteller in your culture. This could be an official skald, a royal minstrel, the washerman who spins parables and folk wisdom, or the old farmer who tells tall tales at the pub. Ever since you were young, your community has groomed you to fulfill this role.", "Fast Talker");
            if (roll.IsBetween(21, 30))
                return new StoryElement("Dabbler: Whether you grew up rich or poor, you refused to accept the limits imposed by your social class or means. In your youth, you determined to learn a little bit of all there was to know. You may not be the master of any one career, but the breadth of your experience is wide, textured, and diverse.", "Worldly");
            if (roll.IsBetween(31, 40))
            {
                StoryElement newStoryElement = new StoryElement("For Love: When you were young, you tried to express yourself to your beloved using song or poetry. Driven by desire, you refined your skill and learned to articulate raw emotion in story and song.", "Ear for Music");
                newStoryElement.StoryFeats.Add("True Love");
                return newStoryElement;
            }
            if (roll.IsBetween(41, 50))
                return new StoryElement("Gift: Someone gave you a special instrument or a collection of songs and stories at a time in your life when you needed them most. You have treasured this object above all other possessions, and it started you on a path to new songs and stories.", "Seeker");
            if (roll.IsBetween(51, 60))
                return new StoryElement("Ongoing Patron: When you were young, a person with money or power took an interest in your art and sponsored you. Most of what you created was dictated by the patron’s tastes, and you probably still work for this patron, who maintains a strong influence over your life.", "Oathbound");
            if (roll.IsBetween(61, 70))
                return new StoryElement("Spy: Someone once asked you to employ your artistic talents as an excuse to observe a person, steal an object, or retrieve a piece of information. Infiltrating various houses and estates in the guise of an actor, minstrel, or storyteller, you honed your art while being paid better than most other performers. You gain access to the Criminal social trait.", "Criminal");
            if (roll.IsBetween(71, 80))
                return new StoryElement("Troupe of Players: You were born into, helped found, or fell in with a troupe of traveling players. You spent your early years rambling from one place to another—from tavern to tavern, town to town, or even between countries. Long hours traveling gave you plenty of time to practice and hone your skill.", "World Traveller (Regardless of Race)");
            if (roll.IsBetween(81, 90))
            {
                StoryElement newStoryElement = new StoryElement("Virtuoso: One day, you picked up an instrument or told a tale, and your raw natural ability captivated everyone who saw you perform. Words and music have always come to you effortlessly, as naturally as breathing.", "Talented");
                newStoryElement.StoryFeats.Add("Magnum Opus");
                return newStoryElement;
            }
            else
                return new StoryElement("Worldshaker: Since childhood, you’ve observed the world around you and translated those observations into story and song. Your unique, unabashed vision resonated with the audience, revealing new perspectives as well as simple truths. You’re used to people quoting your words and looking up to you, though some authority figures deem you a rabble-rouser and troublemaker.", "Natural-Born Leader");
        }
        private static StoryElement Cavalier(int roll)
        {
            if (roll.IsBetween(1, 10))
                return new StoryElement("Tragedy and Loss: In your formative years, you experienced a significant tragedy that forged you into the person you’ve become.", "Grief-Filled");
            if (roll.IsBetween(11, 20))
                return new StoryElement("Faith: You embraced a religious faith at an early age and devoted your life to its ideals. You soon learned that it was not enough to follow and worship. Faiths need champions—people capable of defending the virtues, tenets, and precepts of the faith from those who would seek to corrupt, alter, or destroy it.", "Indomitable Faith");
            if (roll.IsBetween(21, 30))
            {
                StoryElement newStoryElement = new StoryElement("Champion of the People: You grew up among common people. You were close to these people and you witnessed their oppression, their suffering, and their helplessness. Someone needed to stand up and protect them, and that someone would be you.", "Militia Veteran");
                newStoryElement.StoryFeats.Add("Champion");
                newStoryElement.StoryFeats.Add("Town Tamer");
                return newStoryElement;
            }
            if (roll.IsBetween(31, 40))
                return new StoryElement("Squired: You were a young squire who served a very different kind of knight. This knight taught you more than the art of battle: she taught you to live by a strict code to guide your actions and your sword.", "Influnce", "Oathbound");
            if (roll.IsBetween(41, 50))
                return new StoryElement("Military Order: At the beginning of your career, you served with a company of mercenaries, rogues, and professional soldiers. The experience taught you how to work strategically with diverse groups.", "Tactician", "Worldly");
            if (roll.IsBetween(51, 60))
                return new StoryElement("Personal Code: In your early years, you made sense of the chaotic, dis orderly world you grew up in by formulating your own code of ethics and behavior. Though you are the ultimate arbiter and authority over this code, you do not break it, for without it your existence loses all meaning", "Principled");
            if (roll.IsBetween(61, 70))
                return new StoryElement("Equestrian: The first time you rode a horse, you discovered a kinship with it and knew you were born to ride, and the superior horsemanship you gained through your bond with the animal propelled you into the ranks of the cavaliers", "Beast Bond");
            if (roll.IsBetween(71, 80))
                return new StoryElement("Entitlement: You became a cavalier early in your career, not by personal action or effort but by family favor, connections, or promotion. You were given fine weapons, tactical training, a mount, and the edicts of your order. Now you must learn how to follow them.", "Rich Parents");
            if (roll.IsBetween(81, 90))
                return new StoryElement("Honor Bound: Long ago, a promise was made that you are bound to fulfill. This could be a vow you made in your youth, or one made by an ancient forebear. Regardless, you must follow a cavalier’s code despite any personal doubts or misgivings until you have fulfilled the terms of the oath.", "Oathbound");
            else
                return new StoryElement("Old Soldier: When you were young, you discovered an ancient chivalric oath sworn by knights of yore. Though the beautiful edicts of this oath seem to have been forgotten by the world, this old way fulfills you and gives you purpose.", "Inspired Faith");
        }
        private static StoryElement Cleric(int roll)
        {
            if (roll.IsBetween(1, 10))
                return new StoryElement("Angelic Encounter: A supernatural being, such as an angel or demon, appeared to you and proclaimed that you were destined to perform a great task in service to your god. You might have tried to deny it—and you even might still have doubts—but eventually you took up the mantle of a holy warrior and chose to meet this destiny head on, either to prove to yourself that you’re worthy of such a destiny or to show your supernatural messenger that you cannot be pigeon-holed so easily.", "Prophesied");
            if (roll.IsBetween(11, 20))
                return new StoryElement("Atonement: In your youth, you committed actions you are not proud of. Your deeds left dark stains upon your soul, ones so deep they might take a lifetime to wash away. When you hit rock-bottom—whether through greed, addiction, hedonism, or simply lack of good sense—you turned to faith, vowing to atone for all of the horrible acts you’ve committed.", "Oathbound");
            if (roll.IsBetween(21, 30))
                return new StoryElement("In your early life, you followed a different faith, a different god or powerful entity, or perhaps no faith at all. A representative of your current faith showed you the error of your ways and converted you, and you couldn’t be happier. You can only hope to do for others what this individual did for you.", "Inspired");
            if (roll.IsBetween(31, 40))
            {
                StoryElement newStoryElement = new StoryElement("Devoted: From your earliest memory, you’ve had a close relationship with your deity. This entity has been a constant presence in your life: your greatest comfort, best companion, truest love, or some combination of the three. You’ve never had to see or speak with your deity to know that he watches over you, and the beliefs and criticisms of others do not faze you—your faith is enough.", "Blessed");
                newStoryElement.StoryFeats.Add("Fearless Zeal");
                return newStoryElement;
            }
            if (roll.IsBetween(41, 50))
            {
                StoryElement newStoryElement = new StoryElement("Healed: As a child, you were afflicted with a terrible physical or mental illness or a debilitating wound that prevented you from functioning in society. A miracle worker touched your body and commanded you to be well, and—for perhaps the first time in your life—you were whole. Now you live your life in tribute to the deity whose divine healer restored you, and perhaps hope to bestow similar gifts unto deserving nonbelievers.", "Sacred Touch");
                newStoryElement.StoryFeats.Add("Battlefield Healer");
                return newStoryElement;
            }
            if (roll.IsBetween(51, 60))
            {
                StoryElement newStoryElement = new StoryElement("Reborn: You died or nearly died. In the midst of this experience, your mind came to a place of quiet where you witnessed your deity or its agents pulling your body and spirit back from the brink of death. Every day since has been a gift, and you strive to understand the reason you have been saved while countless others perish.", "Deathtouched");
                newStoryElement.StoryFeats.Add("Arisen");
                return newStoryElement;
            }
            if (roll.IsBetween(61, 70))
                return new StoryElement("Religious Colony: You grew up in a religious colony or settlement. This may have been a small village in the hinterlands or a kingdomsized theocracy devoted to a single religion. When you came of age, you decided to serve your god and country as a cleric, a choice that garnered respect, dignity, and honor among your people.", "Natural-Born Leader");
            if (roll.IsBetween(71, 80))
                return new StoryElement("Revelation: In your youth, a deity granted you visions or dreams that revealed startling truths. These visions might have been prophetic, deeply insightful, or filled with extraordinary solutions to problems that plagued you, your family, or your community. So powerful and compelling were the visions that you devoted your life to the deity.", "Worldly");
            if (roll.IsBetween(81, 90))
                return new StoryElement("Sanctuary: When you were young, you did a very wicked deed—or were accused of one— and fled to the only place that could shelter you from the law. You found sanctuary among the worshipers of a deity, and they took you in and protected you. In time, you joined the faithful to serve their cause in the world, though the shadow of your past sin still lurks beyond the church’s walls.", "Criminal");
            else
                return new StoryElement("Taken in by the Church: You spent your youth in a church or monastery serving as an acolyte or doing menial work on the grounds, either taken in as an orphan, sent there by your equally devout parents, or by taking on the faith of your own volition. The traditions and rituals of the religion served as your way of life throughout your adolescence, and you left that pious community with the skills to champion your faith in the world.", "Child of the Temple");
        }
        private static StoryElement Druid(int roll)
        {
            if (roll.IsBetween(1, 10))
                return new StoryElement("Lost in the Wild: You got lost in the wilderness and were forced to survive on your own. You may have wandered desert dunes, thick forest, or high mountains—or perhaps you were shipwrecked on a desert island. Young and vulnerable, you feared the natural dangers of the world at first, but acclimated to the natural way of life as you learned to tap into the primal power of the world.", "Resiliant");
            if (roll.IsBetween(11, 20))
                return new StoryElement("Fey Meeting: Walking in the woods, you met a fey creature, such as a brownie, elf, nymph, gnome, sprite, or treant. This magical being taught you how to tend the natural world in the gentle manner of the fey.", "Magical Knack");
            if (roll.IsBetween(21, 30))
                return new StoryElement("Spirit of Nature: Through a ritual, vision, or dream, you communed with a primordial spirit of nature. In the form of a majestic beast, this spirit charged you with preserving the natural world from those who would destroy it. You are instilled with the spirit of this creature—a small fragment of its power grows in you as you mature.", "Sacred Touch");
            if (roll.IsBetween(31, 40))
                return new StoryElement("Tree Tender: You learned to care for plants in your youth by tending a small garden, orchard, grove, or field. These plants flourished like no others. You’ve always understood plants better than people.", "Devotee of the Green");
            if (roll.IsBetween(41, 50))
                return new StoryElement("Druid Circle: You discovered, or were initiated into, a circle of druids that protects an expanse of wilderness. The druids taught you of their duty to nature and the powers that the natural world granted them. Soon you learned enough to join the circle as an initiate.", "Mentored");
            if (roll.IsBetween(51, 60))
                return new StoryElement("Civilized Outcast: For a time, you lived in an urban environment. But you soon discovered that social communities, bureaucracies, and laws made you feel constrained and unnatural. You left civilization and retreated into the wild at the first opportunity. You still retain the lessons, habits, and refinements of civilized behavior, but your heart belongs to nature.", "Civilized");
            if (roll.IsBetween(61, 70))
                return new StoryElement("Savage: You spent your formative years among a tribe or village far from civilization. The elders chose you as successor and taught you the lore of the elements and the animals.", "Savage");
            if (roll.IsBetween(71, 80))
            {
                StoryElement newStoryElement = new StoryElement("Raised by Beasts: You were reared in part by wild animals. Most of what you know you learned by observing these beasts, their natural instincts being unburdened by artifice or manipulation. Even though you possess a humanoid body, the beasts recognize you as one of their own.", "Animal Friend (gnome, take regardless of race)");
                newStoryElement.StoryFeats.Add("Feral Heart");
                return newStoryElement;
            }
            if (roll.IsBetween(81, 90))
                return new StoryElement("Avatar: Once you were an ordinary youth. But when the natural world needed saving, the land chose you as its champion, lending you as much power as you were able to control. You might not understand the reasons for your power, but you are one with nature and your will is the will of the world.", "Child of Nature");
            else
                return new StoryElement("Beastlord: Natural birds and beasts have always obeyed you. From your earliest years, you’ve possessed a gentleness or a power that allows you to communicate with animals as though you shared a common language. Perhaps you have fey blood or traces of lycanthrope ancestry", "Beast Bond");
        }
        private static StoryElement Fighter(int roll)
        {
            if (roll.IsBetween(1, 10))
                return new StoryElement("Adventure: Since you can remember, you sought to become a great warrior. Inspired by legends of the past or personal heroes of your civilization, you longed to wield steel and carve your way in the world.", "Seeker");
            if (roll.IsBetween(11, 20))
                return new StoryElement("Conscripted: You didn’t choose the military life so much as you were drafted into it. You have a non-military background and skill set. Who knows what course your life might have taken had you not been forced to take up arms?", "Worldly");
            if (roll.IsBetween(21, 30))
                return new StoryElement("Duty: You took up the sword because no one else would. When a great danger threatened your home, you stepped forth to meet the challenge, though you were only a youth with just the strength of your arm and steadfastness of your courage to see you through.", "Courageous");
            if (roll.IsBetween(31, 40))
            {
                StoryElement newStoryElement = new StoryElement("Gladiator: As an adolescent, you learned to fight and kill because your master made you, and if you had not learned, you would be dead. Killing was a way of life—a means of survival. At first you did it because you had to, but that soon changed when you heard the chorus of the crowd.", "Killer");
                newStoryElement.StoryFeats.Add("Champion");
                return newStoryElement;
            }
            if (roll.IsBetween(41, 50))
                return new StoryElement("Joined the Watch: Your village, town, city, or tribe needed new recruits for the volunteer watch patrol, and you joined up—whether for money, duty, peace, or power. This rudimentary training gave you an understanding of civilized justice and showed you how to wield a weapon with skill.", "Militia Veteran");
            if (roll.IsBetween(51, 60))
                return new StoryElement("Knighted: Your military path began when you were knighted or made a squire to a knight. Your family’s status could have influenced this event, or you might be a simple commoner rewarded with a title for a rare feat of courage", "Influence");
            if (roll.IsBetween(61, 70))
                return new StoryElement("Mercenary: Everyone needs to earn a living, and in your youth you were fast, strong, or tough enough to fight for pay. There are good causes and bad causes, but at the end of the day, it all comes down to money. Sometimes you got easy jobs, like guarding merchant caravans; other times the jobs are rough, like fighting in a rebel lord’s private army.", "Mercenary");
            if (roll.IsBetween(71, 80))
                return new StoryElement("On the Street: You spent adolescence in a seedy part of town. You learned to fight dirty and fight mean. Turns out you were good at it. Your skills drew the interest of gang and guild leaders, tavern keepers, and anyone else who needed hired muscle.", "Child of the Streets");
            if (roll.IsBetween(81, 90))
                return new StoryElement("Schooled: You learned to fight in a structured environment where you were exposed to a variety of weapons, armor, strategies, and tactics. You learned to fight as part of a unit, how to follow orders and how to command a squad.", "Tactician");
            else
                return new StoryElement("Survival: You spent some part of your life in the wild—in places that abide by the laws of nature rather than those of civilization. You survived by being stronger, faster, and more cunning than the predators. That meant you fought not for coin, honor, or principle, but for your very life.", "Resiliant");
        }
        private static StoryElement Gunslinger(int roll)
        {
            if (roll.IsBetween(1, 10))
                return new StoryElement("Any Fool Can Swing a Sword: Sometime during your youth, you came to the conclusion that most melee and ranged weapons are crude and primitive compared to firearms. It puzzles you that anyone with martial aptitude deigns to devote their skill to anything other than firearms. You disregard such “lesser” weapons and prefer the feel of your trusty firearm over any other tool of war.", "Reckless Contempt");
            if (roll.IsBetween(11, 20))
                return new StoryElement("Bucking Tradition: You come from a proud tradition of ancient arms and august codes of conduct like those followed by paladins, cavaliers, and samurai. Instead of following in the vaunted steps of your predecessors, though, you chose to learn the art of firearms to the shock and perhaps even anger of your family and peers. Your break with tradition fostered in you a nearly insurmountable will that fuels your identity as a gunslinger.", "Resolve of the Rejected");
            if (roll.IsBetween(21, 30))
                return new StoryElement("Custodian of the Future: Firearms are not just an effective implement for killing or a curious mechanical trinket; they are the next step in the technological development of your people. Your passion for the workings of your weapons has you constantly assembling and dismantling firearms to truly understand their mechanics. This ongoing dedication improves your ability to repair firearms and make them deadlier while in your skilled hands.", "Unblemished Barrel");
            if (roll.IsBetween(31, 40))
                return new StoryElement("Defining Moment: Guns are inexorably linked to a moment where your life dramatically changed. Perhaps you were so sickly as a child that you couldn’t turn a crossbow’s winch or bend a bow, but firearms showed you that you could still hunt and fight. Perhaps you picked up a firearm in a desperate moment to help a wounded gunslinger and knew that you had just taken your first step along the same path. A firearm at your side instills in you a sense of purpose and destiny that no one can take away.", "Black Powder Fortune");
            if (roll.IsBetween(41, 50))
                return new StoryElement("Look at What I Can Do: The lure of something new and showy drove you to first pick up a gun. Although several near mishaps taught you to respect the volatile weapon and the powder that powers it, you still enjoy doing trick shots and getting the oohs and aahs of a crowd", "Black Powder Bravado");
            if (roll.IsBetween(51, 60))
                return new StoryElement("Mechanical Savant: For you, the lure of firearms is not the effect they produce, but the science and mechanical process behind the effect. Your endless tinkering and perfectionism have made your own gun easier to upgrade.", "Just Like New");
            if (roll.IsBetween(61, 70))
                return new StoryElement("Black Powder Presence: You grew up belittled and even beaten for not being the biggest or the strongest of your compatriots, family, or race. With no burgeoning aptitude for magic, you looked for some other way to exceed those who found superiority in brute strength—and you found it in gunslinging.", "Larger Than Life");
            if (roll.IsBetween(71, 80))
                return new StoryElement("Sacred Charge: Your gunslinger training is more than just martial skill—it’s a calling. Perhaps you are part of an elite group of guards serving and defending a temple or faith. Conversely, you might come from a land where firearms represent the pinnacle of your society’s advancement or are the last vestige of those who came before. Your sense of higher purpose allows you to fight on and keep firing when winning seems impossible", "Never Stop Shooting");
            if (roll.IsBetween(81, 90))
                return new StoryElement("Shock and Awe: The sound and fury of gunfire is as potent a weapon as the pellets and bullets your weapon discharges. You live for the reflexive wince that others make when they jump at the sound of a firearm, and laugh heartily at the amazement you inspire in others with your cacophonous black-powder weapons", "Startling Report");
            else
                return new StoryElement("Some Things Are Stronger Than Magic: You grew up either oppressed by magic cruelly wielded or loathing the elitism of those who possessed such arcane or divine power. Searching for something nonmagical that relies on skill and practice led you to the study and wielding of firearms. You relish trumping pompous spellcasters with a quick draw and a keen eye.", "Black Powder Interjection");
        }
        private static StoryElement Inquisitor(int roll)
        {
            if (roll.IsBetween(1, 10))
                return new StoryElement("Bureaucracy’s Bane: You chose the inquisitor’s path because you have no taste for the petty rules and regulations that mire the leaders of your faith in inaction and inefficacy. You know that you are an instrument of your deity and that your directives do not require intercession by the less motivated.", "Focused Disciple");
            if (roll.IsBetween(11, 20))
            {
                StoryElement newStoryElement = new StoryElement("Chaplain: You learned long ago that in the heat of battle and under the pall of war, even the most devout can waiver in faith. You subsequently dedicated yourself to stewarding the faith of soldiers and allies in times of great conflict", "Battlefield Disciple");
                newStoryElement.StoryFeats.Add("Battlefield Healer");
                return newStoryElement;
            }
            if (roll.IsBetween(21, 30))
                return new StoryElement("Exemplar: You found early on that you lacked the logic or the vocabulary to communicate the virtues of faith—more precisely, your faith—to others. You decided that the best way to foster respect and appreciation for your god was not with words, but with action.", "Beacon of Faith");
            if (roll.IsBetween(31, 40))
                return new StoryElement("Failed Cleric: Your original training in divine magic was as a cleric, but your faith eventually distilled into you the ability to hear lies and see weaknesses in the “unfaithful.”", "Schooled Inquisitor");
            if (roll.IsBetween(41, 50))
            {
                StoryElement newStoryElement = new StoryElement("Faith-Bringer: You know that in order to bring the light of your deity to others, you must traverse hostile territories and face even more hostile inhabitants", "Emissary");
                newStoryElement.StoryFeats.Add("Fearless Zeal");
                return newStoryElement;
            }
            if (roll.IsBetween(51, 60))
                return new StoryElement("False Witness: You’ve seen innocent people suffer due to another’s lies. While these injustices made you feel powerless, they’ve also kindled a desire in you to punish those who regard truth so cheaply.", "Vigilant Battler");
            if (roll.IsBetween(61, 70))
                return new StoryElement("Few Left to Safeguard the Faith: You are the vanguard of your faith. Perhaps you are a pilgrim for a good deity in an unholy land, or the secret enforcer of a sect that operates in the shadows of the world. You are accustomed to working alone and with little guidance from the superiors of your church, trusting your own moral judgment to act on behalf of your god. This certainty acts as a defense against the magic of other, “lesser” deities.", "Disdainful Defender");
            if (roll.IsBetween(71, 80))
                return new StoryElement("Temple Detective: Your ability to sniff out falsehood and see weakness in others made you uniquely suited to guard the religious houses of your order.", "Truth's Agent");
            if (roll.IsBetween(81, 90))
                return new StoryElement("The Path of Righteous Rage: Your faith does not manifest in calm prayer or serene meditation. You achieve the transcendent feeling of the divine when you are in the throes of battle for your deity.", "Incredible Ire");
            else
                return new StoryElement("Zealot: Your devotion is fanatical and your powers are clearly proof of your connection with the divine. Although you know that other gods bestow similar powers upon their own disciples, you either revile or pity those of “lesser” faiths.", "Zealous Striker");
        }
        private static StoryElement Magus(int roll)
        {
            if (roll.IsBetween(1, 10))
                return new StoryElement("A Mage without Magic: Early in your arcane training, you were exposed to antimagic. The powerlessness you felt from all of your magic being stripped away left you feeling desperate and helpless. You vowed to never be that helpless child again, to be strong in such moments, putting you on the path of the magus.", "Dispelled Battler");
            if (roll.IsBetween(11, 20))
                return new StoryElement("Conflicting Legacy: You were born to a family or clan with two great pedigrees: one of magic and one of battle. Unable to choose either path for fear of alienating a mentor or parent, you sought to master both. Your dedication to the blending of martial and magical has been so intense that your martial prowess feeds your arcane power.", "Arcane Revitalization");
            if (roll.IsBetween(21, 30))
                return new StoryElement("Ready for Anything: For you, the path of the magus is not about the fluid blend of disparate fields of study or conquering an insurmountable challenge, but the art of preparation for any obstacle that comes your way. A dedicated and logical person, you hone the magus affinity for operating all manner of magical devices from blind luck to a refined procedure.", "Pragmatic Activator");
            if (roll.IsBetween(31, 40))
                return new StoryElement("Lost Teacher: Your magus training was interrupted when you lost your teacher through the displacement of your family, lack of funds to continue schooling, or the teacher’s unexpected death. Despite this hardship, the time you spent with your mentor had already sown the seeds of your training and you’ve been able to continue on your own in the time since—ceaselessly seeking, reading, and learning from any magical text you can find.", "Self-Taught Scholar");
            if (roll.IsBetween(41, 50))
                return new StoryElement("Promise Keeper: Your dreams of becoming a wizard were cut short by unfortunate circumstances, such as the death of your family or clan’s matriarch or patriarch, hostile invading forces, conscription in the army, and so on. This forced you to become a protector and stunted the growth of your studies. Though you have successfully blended the two disciplines, you still long for the unfulfilled potential of your career as a wizard.", "Cross-Disciplined");
            if (roll.IsBetween(51, 60))
                return new StoryElement("Shameful Secret: You come from either a proud military and martial background or a legacy of skilled wizards. When you developed an aptitude for two different powers viewed as incompatible by your family or teachers, it drove you to hide half of your abilities and to pretend full-blown competency with the other. Some of the tricks you used to perpetrate this deception have stayed with you to this day.", "Partial Protege");
            if (roll.IsBetween(61, 70))
                return new StoryElement("Spell Backfire: At some point during your magical training, you attempted to cast a spell and failed. But rather than being wasted, the arcane energy reabsorbed itself into your body, waiting to be reused in some other way. When the arcane energy exploded outward through your staff or some other instrument you wielded, you received your first glimpse of the ways that magic could be repurposed—a versatility you retain today", "Malleable Magic");
            if (roll.IsBetween(71, 80))
                return new StoryElement("Spell’s Edge: The first time you held a magic weapon and felt the thrum of arcane energy within, you knew that magic and melee were meant to be joined. Since that moment, magic weaponry has become symbolic of the most potent syntheses of your magus training, and your ability to create magical weapons and imbue mundane arms with magic still resonates with this focus.", "Bladed Magic");
            if (roll.IsBetween(81, 90))
                return new StoryElement("Vindication: You spent your formative years trying to convince combat instructors of the virtues of magic and arcane mentors of the importance of strength in arms, only to be mocked and exiled from both disciplines. Since then, you’ve wandered from master to master, honing your knowledge of both fields of study to show them all that not only have you achieved power, but you’ve also eclipsed all those who shunned you.", "Arcane Temper");
            else
                return new StoryElement("What If: You don’t know the meaning of impossible. Everyone around you thinks you have your head stuck in the clouds, but you continually strive to achieve things that have never been accomplished before—perhaps things that have never even been dreamed of. Bucking convention has brought numerous failures, but you’ve learned from your mistakes and are able to snatch victory over seemingly impossible odds.", "Inspired");
        }
        private static StoryElement Monk(int roll)
        {
            if (roll.IsBetween(1, 10))
                return new StoryElement("Bellicose Historian: What started as a scholar’s curiosity in exotic fighting styles bloomed into a fanatical desire not just to learn about martial arts, but to master them.", "Style Sage");
            if (roll.IsBetween(11, 20))
                return new StoryElement("Classically Schooled: Training from dawn to dusk to hone every inch of your body into a fighting instrument, you studied with scores of other students in an academy or school dedicated to one specific martial art.", "Simple Disciple");
            if (roll.IsBetween(21, 30))
                return new StoryElement("Elite Fighting Force: You learned your fighting skills as one of a highly trained group dedicated to a special purpose, such as guarding a temple or protecting a noble. Your training emphasized unobtrusive teamwork and unquestioned dedication to some higher purpose.", "Veiled Disciple");
            if (roll.IsBetween(31, 40))
                return new StoryElement("Tournament Champion: A shining example of your style or order, you’ve honed martial prowess through spirited and exciting competition.", "Martial Performer");
            if (roll.IsBetween(41, 50))
                return new StoryElement("Lineage Holder: You are the senior or sole student of a great master. You rose to prominence early and received secret training in an art that is rare and exotic. Having achieved a strong foundation in the physical and metaphysical elements of this martial art, you’ve been designated the lore keeper for its history and traditions, and must now find new student or students to train. You", "Martial Manuscript");
            if (roll.IsBetween(51, 60))
                return new StoryElement("Nature’s Disciple: Just as many great masters learned and crafted styles from the beauty and majesty of nature, your fighting style comes from time spent in the wild rather than from formal training. You have seen firsthand how the mantis hunts, how the tiger swipes, and how the crane beats its wings. Your observance of the natural world gave you the ability to extrapolate combat forms without traditional training.", "Nature's Mimic");
            if (roll.IsBetween(61, 70))
                return new StoryElement("Secret Student: Your teacher and fellow students grew up as part of a conquered people, forbidden to train at war and forced to conceal the fighting style as seemingly harmless dances and your weapons as mundane tools… until the day you all you could rise up against tyranny.", "Hidden Hand");
            if (roll.IsBetween(71, 80))
                return new StoryElement("Spirit Teacher: Your martial training is both physical and metaphysical in nature, allowing you to unlock a higher state of consciousness that allows you to draw on the wisdom and power of long-dead masters", "Spirit Sense");
            if (roll.IsBetween(81, 90))
                return new StoryElement("Unsuspecting Master: You were trained in martial arts through unorthodox methods such as seemingly menial tasks or training through conditioning exercises that promised the smallest scrap of food as a reward. Your nontraditional training makes you resourceful and clever.", "Surprise Weapon");
            else
                return new StoryElement("Wandering Savant: Although you’ve received some formal training in exotic combat, you decided to put your skills to the test and further your learning by wandering the wide world.", "Wanderer's Shroud");
        }
        private static StoryElement Oracle(int roll)
        {
            if (roll.IsBetween(1, 10))
            {
                StoryElement newStoryElement = new StoryElement("Battle: In your early years, a battle broke out near your home and you were embroiled in the fighting. At the end of the battle, you were the only one left standing, with scores of slain foes strewn at your feet.", "Veteran of Battle");
                newStoryElement.StoryFeats.Add("Battlefield Healer");
                return newStoryElement;
            }
            if (roll.IsBetween(11, 20))
                return new StoryElement("Bones: In your formative years, you were entombed or buried alive in a graveyard. For days, you lay within the grave until your terror strangely turned to comfort. Since your return, you’ve been a different person: part mortal and part ghost, in possession of the powers of the dead.", "Fearless Defiance");
            if (roll.IsBetween(21, 30))
                return new StoryElement("Flame: A great fire consumed you and laid waste to the environment around you. It might have devoured your family, friends, or an entire settlement, but you survived unburned as if the fire did not dare to touch you. Since that day, you’ve tamed fire as though it were a savage animal bent to your will.", "Flame-Touched");
            if (roll.IsBetween(31, 40))
                return new StoryElement("Heavens: The night sky’s mysteries have always enthralled you. But one night, while you gazed upon the stars, the perfect order of the universe revealed itself and you nearly went mad from the revelation. Since that night, you’ve possessed strange powers over the heavens.", "Starchild");
            if (roll.IsBetween(41, 50))
                return new StoryElement("Life: A terrible plague afflicted your homeland, killing thousands. You caught the disease, but instead of dying from it, you flourished. As you grew healthier, so did everyone you came into contact with.", "Sacred Touched");
            if (roll.IsBetween(51, 60))
                return new StoryElement("Lore: You were able to speak before any other child your age. Rather than stumble through the rudimentary syllables of language, you spoke in full sentences, reciting the greatest literature of many languages in story, song, and poem. Sometimes you spoke of events that had not yet come to pass, and the wise came to seek your counsel. Your gift came at a cost, however—though your knowledge is vast, your body and mind carry a curse.", "Scholar of the Great Beyond");
            if (roll.IsBetween(61, 70))
                return new StoryElement("Nature: You became separated from your family and lost in the untamed wilderness for many days, months, or years. The wilderness took its toll, but when you finally emerged from the wild, you were its master.", "Child of Nature");
            if (roll.IsBetween(71, 80))
                return new StoryElement("Stone: You were buried beneath the earth, possibly after an avalanche or earthquake. For 3 days the earth covered you, until at the end of the third day you emerged from the mountain unharmed but not unchanged", "Earth-Touched");
            if (roll.IsBetween(81, 90))
                return new StoryElement("Waves: You were swept beneath the surface of the water once. You should have drowned, but instead you washed up on shore after a long interval. You emerged from the depths afflicted with a strange condition but otherwise unharmed.", "Water-Touched");
            else
                return new StoryElement("Wind: In your early years, you were caught in a powerful storm that ravaged the countryside, destroying everything in its path. Bolts of lightning struck your body and thunder deafened your ears, but when you came to the storm’s tranquil center, the tempest ceased. Since then you’ve had power over storms, though you still bear the mark of the great storm you endured.", "Storm-Touched");
        }
        private static StoryElement Paladin(int roll)
        {
            if (roll.IsBetween(1, 10))
                return new StoryElement("Divine Calling: An otherworldly agent of law and good—such as an angel, empyreal lord, or perhaps some other celestial envoy of the gods—tasked you to be a divine champion. You accepted the calling (maybe grudgingly) because ultimately you realize that the laws of destiny and one’s divine calling cannot be denied. In return, that celestial agent watches over you and makes sure you can fully realize your destiny and meet the course that has been set for you by a higher power.", "Blessed");
            if (roll.IsBetween(11, 20))
                return new StoryElement("Dread Penance: You, or perhaps your family, owe a debt for some past wrongdoing or vice. Maybe you made deals with some unscrupulous loan sharks during a gambling binge or your not-so-distant ancestors were responsible for the persecution of a marginalized group of people. Whatever the offense, your past action hangs over your head and fills you with guilt. You’ve taken a solemn oath to make good on this past misdeed. Only then will you feel like your life is truly worthwhile.", "Oathbound");
            if (roll.IsBetween(21, 30))
                return new StoryElement("Holy Epiphany: Your faith and purpose came in a brilliant flash of insight. Maybe you suddenly realized that evil can be stopped only with vigilance and deliberate action, or maybe an epiphany showed you that the innocent need protection from corrupt forces for good to flourish in the world. Whatever the nature of your epiphany, it guides your actions and gives you insights others lack.", "Inspired");
            if (roll.IsBetween(31, 40))
                return new StoryElement("Zealous Devotion: Maybe your faith was not popular among those around you during your youth. Maybe you have strange or controversial views regarding your religion, and the other members of your congregation find your practices bizarre or insulting. Whatever the case, your faith is constantly being questioned regardless of your obviously pious nature, and such persecution only serves to embolden your zeal.", "Indomitable Faith");
            if (roll.IsBetween(41, 50))
            {
                StoryElement newStoryElement = new StoryElement("Moral Debt: The world and all things material are intrinsically corrupt. All creatures are born with a moral debt, and only by fighting evil, upholding law, and championing the common good can one be truly free of that corruption. You work every day to pay off this debt and move those around you to do the same.", "Principled");
                newStoryElement.StoryFeats.Add("Fearless Zeal");
                return newStoryElement;
            }
            if (roll.IsBetween(51, 60))
                return new StoryElement("Mark of Faith: You were born with the mark of your faith. Maybe at some point you rebelled against such branding, or it could be you’ve always accepted the mark as an indicator of your destiny. In either case, it was a harbinger of the paladin path.", "Birthmark");
            if (roll.IsBetween(61, 70))
                return new StoryElement("Righteous Mentor: A paladin of note and great honor took you under her wing and taught you many things. She taught you how to adhere to your oath with grace and dignity, and how the simple act of doing so was enough to earn the respect and devotions of others.", "Natural-Born Leader");
            if (roll.IsBetween(71, 80))
                return new StoryElement("Warrior of Truth: Early in your life, you learned that the philosophies of law and good not only create the best society but also reveal truths that would otherwise remain obscured. You are rarely clouded by pure dogma; instead you’re unafraid to question and create your own path toward truth, justice, and righteousness.", "Skeptic");
            if (roll.IsBetween(81, 90))
                return new StoryElement("Knight-Errant: You know that evil stalks the world, and only one who is dedicated to the spread of good can stop these vile forces. To make sure fiends and wrongdoers do not go unpunished, you adopted the code of the paladin in order to travel the land and eradicate the wicked. Your goal is the relentless pursuit to seek out evil and put it down.", "Seeker");
            else
                return new StoryElement("Terrible Secret: You know a terrible secret about an ancient evil that threatens your homeland or perhaps even the entire world. You have sworn to keep this secret quiet lest it gain power in the retelling, but you also must work to thwart the evil whenever possible. This at times contradictory path has led you many places in your travels, and the knowledge you have gleaned from your adventures continues to serve you well in your fight against the wicked.", "Scholar", "Great Beyond");
        }
        private static StoryElement Ranger(int roll)
        {
            if (roll.IsBetween(1, 10))
            {
                StoryElement newStoryElement = new StoryElement("An Eye for an Eye: The choice of your favored enemy was nothing more than simple vengeance. Perhaps you lost a loved one, family,  or even a whole community to the vicious rampaging of a ferocious beast, or saw your entire homeland swallowed up by monstrous hordes. No matter the reason, your drive to hunt down and destroy creatures of their kind won’t be sated so long as even one lives.", "Tireless Avenger");
                newStoryElement.StoryFeats.Add("Foeslayer");
                return newStoryElement;
            }
            if (roll.IsBetween(11, 20))
                return new StoryElement("Ancient Hatred: The history of your people is a saga of struggle against another race. Though common among elves and orcs or dwarves and giants, many different races can have such longstanding animosity. Your choice of a favored enemy was a simple outgrowth of this racial antipathy.", "Enemy");
            if (roll.IsBetween(21, 30))
                return new StoryElement("Big Game Hunter: Whether you sought out the thrill of hunting large prey or merely grew up in the shadows of creatures large enough to crush an entire village with a careless step, you have learned how to be quick and to size up weaknesses in those behemoths who seem to have none.", "Evasive Sting");
            if (roll.IsBetween(31, 40))
                return new StoryElement("Blood Cleansing: Either you have forsaken your kinsfolk or they have forsaken you. Maybe you grew up among a wicked or corrupt people who you needed to escape, or maybe they exiled you for being different. Whatever the case, your own kind are now your favored enemy, much to your continued chagrin or morbid amusement.", "Scarred Descendant");
            if (roll.IsBetween(41, 50))
            {
                StoryElement newStoryElement = new StoryElement("Bounty Hunter: You have always been good at finding and extracting people from their hidey-holes. Most likely you hunt humanoids of either your own subtype or of one common to your region.", "Easy Way", "Hard Way");
                newStoryElement.StoryFeats.Add("Town Tamer");
                return newStoryElement;
            }
            if (roll.IsBetween(51, 60))
                return new StoryElement("Detached Observer: You set yourself apart with a pall of cold logic that allows you to see weaknesses in members of your own race that you strive not to succumb to yourself. Most likely, you pick your own race as your dominant favored enemy, and you excel as a spy or assassin paid to capture enemies of your organization.", "Cold", "Calculating");
            if (roll.IsBetween(61, 70))
                return new StoryElement("Divine Purpose: Not all those who hear the voices of the gods can distill that echo into magical power like clerics or oracles. These whispers of belief encouraged you to track and hunt those creatures who pose the greatest threat to your faith. Perhaps you’re a good ranger who hunts the undead or devotes effort to slaying fiends, or you could choose to target good fey and celestials, emboldened by divine invective.", "Faith's Hunter");
            if (roll.IsBetween(71, 80))
                return new StoryElement("Nightmare Slayer: From an early age, you stood up against some of the most terrifying creatures imaginable, facing off against creatures most mortals only dream of in their wildest nightmares. Possibly hailing from lands besieged by dragons or plagued by the living dead, you are not only resistent to the fear such creatures normally engender, but you live to show your enemies the face of the unafraid.", "Fearless Defiance");
            if (roll.IsBetween(81, 90))
                return new StoryElement("Opportunist: You are an expert in creatures both common and exotic, particularly in terms of what valuable items you can harvest from their remains. The natural world exists for the benefit of those who know what to take, and you have learned how to scavenge pelts, toxins, and even rare spell components from your defeated foes. You might pick animals, magical beasts, or dragons as your dominant favored enemy—or humanoids if you’re a particularly grisly trophy collector.", "Harvester");
            else
                return new StoryElement("Survivalist: You were orphaned at a young age and left to fend for yourself in the wilds, or simply lived a life at the edge of society that required a constant scrabble for basic existence. You probably have animals or magical beasts (the edible ones) as your dominant favored enemy, and are adept at lying in wait and springing into action.", "Hunter's Knack");
        }
        private static StoryElement Rogue(int roll)
        {
            if (roll.IsBetween(1, 10))
                return new StoryElement("Gang War: Growing up in the backstreets of an urban jungle, you were forced to choose between surviving as a predator or suffering as prey. You affiliated with a guild, gang, or group of thieves and thugs, carrying out illicit missions to further their interests and sabotage those of rival gangs.", "Dirty Fighter");
            if (roll.IsBetween(11, 20))
            {
                StoryElement newStoryElement = new StoryElement("Greed: No matter how much or little you had growing up, it was never enough. You discovered a talent for lifting items and coin purses from others’ belts. The world always provided for you, and when you saw something you wanted, you learned to take it.", "Ambitious");
                newStoryElement.StoryFeats.Add("Thief of Legend");
                return newStoryElement;
            }
            if (roll.IsBetween(21, 30))
                return new StoryElement("Poverty: In your youth, you rarely had enough food to keep from starving. Poverty and hunger forced you to steal to survive, or to help your loved ones survive.", "Poverty-Stricken");
            if (roll.IsBetween(31, 40))
                return new StoryElement("Spy: You’ve always had an innocent expression and a silver tongue, so naturally you were recruited as a spy during your childhood. You could have come from any social class; you might have gathered information as an urchin on the streets or acted as servant to one lord while you reported to another.", "Fast Talker");
            if (roll.IsBetween(41, 50))
            {
                StoryElement newStoryElement = new StoryElement("The Kill: You killed someone when you were relatively young. You might have done it in selfdefense, in anger, or as part of an initiation ritual. And it was easier than you suspected. Afterward, some individuals or groups started paying you to kill for them, and you made a lucrative career of assassination.", "Killer");
                newStoryElement.StoryFeats.Add("Innocent Blood");
                return newStoryElement;
            }
            if (roll.IsBetween(51, 60))
                return new StoryElement("The Trained: Your early talent for feats of agility and acrobatics garnered you an experienced mentor. Impressed by your natural ability, this mentor taught you how to fight, dodge, and throw. He may have been a master thief, circus performer, fencing master, or swashbuckling pirate.", "Mentored");
            if (roll.IsBetween(61, 70))
                return new StoryElement("Outlawed: For reasons just or unjust, you became a fugitive at an early age. You have lived outside the light of society for some time, risking capture or punishment whenever you need to break the law again.", "Criminal");
            if (roll.IsBetween(71, 80))
                return new StoryElement("Thrill Seeker: As an adolescent, you and your friends took turns daring one another to take risks, each new challenge inspiring greater excitement. Since then, you’ve become an adrenaline junkie, performing dangerous tasks in order to chase that high.", "Acrobatic");
            if (roll.IsBetween(81, 90))
                return new StoryElement("Henchman: You’ve always worked for someone else. You do what you are told and in return you are appreciated by the boss, rewarded, and paid.", "Oathbound", "Child of the Streets");
            else
                return new StoryElement("Scout: Your natural ability turned into employment in an elite squad of stealthy infiltrators. You penetrate enemy lines, gather information, deliver coded messages, and sabotage enemy supplies. You likely work for a private individual or military order.", "Canter");
        }
        private static StoryElement Sorceror(int roll)
        {
            if (roll.IsBetween(1, 10))
                return new StoryElement("Awakened Moment: At some point, the dormant power within you awakened with a fright. It might have been the first time you came close to a dragon, celestial, or genie. Or the moment could have come at the grave of a great ancestor or in a lush and verdant glen. What slumbered in your blood has never quieted, and you frequently draw upon the inspiration of your awakening.", "Ascendant Recollection");
            if (roll.IsBetween(11, 20))
                return new StoryElement("Dreams of Something Different: The first hints of your exceptional nature came to you as fragments of remembered dreams or split-second visions. As these episodes increased in both frequency and clarity, they unlocked a power in your blood you didn’t know you had.", "Strength Foretold");
            if (roll.IsBetween(21, 30))
                return new StoryElement("Failed Wizard: Although your arcane aptitude was evident at an early age, you were pushed toward wizardry as the conduit for your magic. While you never mastered magic in this fashion, your time spent studying arcane tomes gave you obscure but often pertinent knowledge.", "Reluctant Apprentice");
            if (roll.IsBetween(31, 40))
                return new StoryElement("One of a Kind: You know that sorcerous power comes from the blood, but as far as you know, none of your ancestors possessed your gift. You keep searching for the reason for your magical powers, which has led you to greater proficiency with divinations and a keen interest in the workings of your bloodline.", "Knowledgeable Caster");
            if (roll.IsBetween(41, 50))
                return new StoryElement("Outcast: Driven away by your family and people, your arcane gifts have always inspired both fear and revulsion. You’ve become adept at spotting hostility in others who would despise you for your power.", "Intuition");
            if (roll.IsBetween(51, 60))
                return new StoryElement("Proud Heritage: You hail from a long line of prominent sorcerers with even more prominent ancestral features. Your acceptance of your bloodline brings with it a pride and imposing mien that becomes amplified among others.", "Imposing Scion");
            if (roll.IsBetween(61, 70))
                return new StoryElement("Shameful Heritage: The obvious hints of your heritage were a source of shame to your family. No matter the manifestation of your differences, being a pariah taught you to practice your arts in secret.", "Unseen But Not Undone");
            if (roll.IsBetween(71, 80))
                return new StoryElement("Too Lucky: You’ve always had a knack for getting out of trouble. This sense of preternatural good fortune led to your inquiries into magic and the discovery of your own sorcerous powers.", "Fate's Favored");
            if (roll.IsBetween(81, 90))
                return new StoryElement("Unharmed: At some point in your early life, you were exposed to something dangerous like a fall into stormy waters or a spell cast your way. But instead of dying, you survived entirely unscathed. This experience either first hinted at or confirmed that you were different, marking the first step on your path to sorcery.", "Unscathed");
            else
                return new StoryElement("Wild Talent: The magic in your blood was always as uncontrollable as it has powerful. You were forced to learn control at an early age, either out of fear that your powers might hurt someone or out of remorse once they had. This relentless vigilance and self-control gave you tremendous focus and arm you with strategic methods to redirect those wild energies coursing through you.", "Volatile Conduit");
        }
        private static StoryElement Summoner(int roll)
        {
            if (roll.IsBetween(1, 10))
                return new StoryElement("Abandoned: At some point early on, you were abandoned. This sense of loss always made you feel as though something were missing. The discovery of your eidolon and your subsequent mutual bond fostered in you the sense of companionship you’ve always longed for", "Greater Link");
            if (roll.IsBetween(11, 20))
                return new StoryElement("Caretaker: You met your eidolon or another outsider in a moment of danger. Wounded or lost, the creature crashed between worlds and ended up at your feet. In helping this panicked, otherworldly creature, you felt a link to it. You can still draw on the inspiration from that moment when dealing with others, outsider or not.", "Destined Diplomat");
            if (roll.IsBetween(21, 30))
                return new StoryElement("Forced to Confront Your Own Limits: The bond with your eidolon first manifested when you saw someone in danger and were unable to help. Your feeling of desperation and frustration at the limits of your own form attracted your eidolon—whether or not it was able to help you in that moment. This need to exceed your own limitations continues to manifest in the evolution of your eidolon.", "Desperate Speed");
            if (roll.IsBetween(31, 40))
                return new StoryElement("Imaginary Friends: As a child, you created imaginary playmates that you felt truly spoke to and heard you. These whispers were actually the wandering thoughts of outsiders trying to make contact, knowing that someday you would have an affinity with their kind. By the time you learned to summon your eidolon and other outsiders, these whispered fragments had turned themselves into an understanding of the language of outsiders.", "Unintentional Linguist");
            if (roll.IsBetween(41, 50))
                return new StoryElement("Monophobic: You were always terrified of being alone when you were younger, so you surrounded yourself with others. But it was establishing this link to your eidolon that ultimately allowed you to overcome this debilitating fear. Now, even when your eidolon is not with you, you know it’s never far away; conversely, when you have your true friend and companion with you, you are far better for it.", "Perpetual Companion");
            if (roll.IsBetween(51, 60))
                return new StoryElement("Outsider’s Lineage: You have the blood of outsiders in your veins. This lineage either laid dormant until your powers manifested or was a storied part of your family heritage. Regardless, your connection to the planes has always been potent. No matter what other subjects you studied, your understanding of planar matters has always seemed instinctive or innate rather than the product of memorization and study", "Planar Servant");
            if (roll.IsBetween(61, 70))
                return new StoryElement("Pick On Someone Your Own Size: When you were young, you or others you cared for were bullied by agents of an oppressive power. At some point, you stood up against one or many of the tyrants, feeling that somehow you were bigger, stronger and more resilient than you actually were. You later realized that this support was the first trace of your eidolon trying to make contact with you. You can still draw on that power today, making your aura strong and your presence powerful.", "Twinned Presence");
            if (roll.IsBetween(71, 80))
                return new StoryElement("Raising Gone Wrong: You lost someone important to you. Through means, luck, or simple pity, you had the chance to raise that person from the dead, but something went wrong with the spell and the raising did not occur… at least not as planned. Your lost friend or kin’s soul bonded with a powerful outsider on the other side of the veil and returned to you as your eidolon. Possessed of some of the memories and experiences of the life you spent together, your companion feels a stronger devotion than even most others of its kind", "Loyalty across Lifetimes");
            if (roll.IsBetween(81, 90))
                return new StoryElement("Saved by Another: Someone or something saved you from great danger. It might have been a family member who saved you from a precipitous fall or adventurers who saved you from a marauding monster. Your sense of gratitude fostered a strong sense of protectiveness, particularly when defending your allies or your eidolon.", "Dedicated Defender");
            else
                return new StoryElement("Stranger in Your Own Skin: You have felt awkward and uncomfortable your entire life, as if you were born into a body that wasn’t truly yours. Your quest to become what you’ve always felt you should be led you to your eidolon, in which you found what you see as your own idealized form. The link that you and your eidolon share allows you to escape some of the inherent limits of your form from time to time.", "Linked Surge");
        }
        private static StoryElement Witch(int roll)
        {
            if (roll.IsBetween(1, 10))
                return new StoryElement("Apprenticed: Your development was guided by a mortal or magical creature, such as a wisewoman, hag, dryad, elf, or pixie, who instructed you in the arts of spellcasting, potions, charms, and hexes.", "Hedge Magician");
            if (roll.IsBetween(11, 20))
                return new StoryElement("Desperate Accident: You lived an ordinary life until one day catastrophe struck and you called out desperately to any power that would come to your aid. The entity that gave you this power might be benevolent or sinister in nature, but ever since you called it, the being remains close to you.", "Reckless Combat");
            if (roll.IsBetween(21, 30))
                return new StoryElement("Forbidden Lore: In your youth, there was something you fervently desired—perhaps love, wealth, or revenge. But no matter how hard you tried, you couldn’t obtain that which you coveted. Only when you turned your eye to ancient tomes and ruins and experimented with strange powers beyond your comprehension were you able to get what you wanted.", "Dangerously Curious");
            if (roll.IsBetween(31, 40))
                return new StoryElement("Found Familiar: When you were young, you happened upon a strange animal with whom you forged an instant bond. It instructed you in casting spells and became your closest, most trusted companion.", "Animal Friend (regardless of race)");
            if (roll.IsBetween(41, 50))
                return new StoryElement("Gifted: You received your magical ability as a gift from a supernatural being, such as an angel, devil, god, ancient dragon, or powerful fey. This creature expects you to act on its behalf in exchange for the power it loaned you", "Magical Knack");
            if (roll.IsBetween(51, 60))
                return new StoryElement("Inborn Power: Many fey creatures are born with the innate ability to cast spells, and either because of having fey blood in your lineage or being born near fey lands you too were gifted this talent.", "Magical Lineage");
            if (roll.IsBetween(61, 70))
                return new StoryElement("Initiated: When you came of age, a coven of witches initiated you into their circle because you showed great promise. After your initiation ritual, you changed on a fundamental level", "Mentored");
            if (roll.IsBetween(71, 80))
                return new StoryElement("Invocation: When you reached adolescence, you wanted power and you wanted it immediately. You didn’t have the patience or tolerance to endure endless years of boring theory and formal magical training, so you offered up your body and soul in an invocation to an entity that would grant your desire.", "Oathbound");
            if (roll.IsBetween(81, 90))
                return new StoryElement("Possessed: For reasons you may never understand, an otherworldly entity took possession of you in your formative years. Since then, your mortal body has been the vessel for this mysterious power", "Possessed");
            else
                return new StoryElement("Unknown: The circumstances by which you gained your powers are confusing, even to you. You may have received them when you stepped into a enchanted land or touched a strange artifact, or perhaps you simply awoke one day with them. You strive to find the meaning of your powers, as they drive your life in unforeseen directions.", "Seeker");
        }
        private static StoryElement Wizard(int roll)
        {
            if (roll.IsBetween(1, 10))
                return new StoryElement("Brains over Brawn: You were bullied or excluded throughout your life because you lacked physical power and fighting prowess. To compensate, you turned to transmutation magic. Your practice and perseverance has granted you skill with spells of that school.", "Tenacious Shifting");
            if (roll.IsBetween(11, 20))
                return new StoryElement("Dangerous Intellect: At a young age, those around you, whether family or friends, realized that your intellect was more than mere precociousness. As your sense of curiosity became dangerous, those responsible for you pushed you into studying magic in the hopes that you would find infinite puzzles to solve.", "Tireless Logic");
            if (roll.IsBetween(21, 30))
                return new StoryElement("Fitting In: You hail from a long line of sorcerers or from a community known for its natural affinity for magic. Your manifestation of wizardly talent, as opposed to blood-based sorcery, caused you to hide those talents at a young age, and then to disguise them as sorcery to the best of your ability later. You still retain some tricks from this early misdirection.", "Shrouded Casting");
            if (roll.IsBetween(31, 40))
                return new StoryElement("Gifted Pride: Your affinity for magic has made you somewhat crass and arrogant, though some find your blunt disposition charming or worthy of respect. The air of superiority surrounding you is palpable and allows you to use you intellect to cow others at times when lesser individuals might barely get a word in.", "Bruising Intellect");
            if (roll.IsBetween(41, 50))
                return new StoryElement("Mortality’s Mirror: Your childhood innocence ended the moment you realized that someday you would die. This revelation may have come to you at the deathbed of a beloved relative, during a bloody siege against your homeland, or via some other eye-opening event. You have spent the rest of your life trying to master magic in order to change this most universal fate from stealing your last breaths away. You now have a keen eye for the magic of death and for discerning answers to ancient riddles.", "Greater Purpose");
            if (roll.IsBetween(51, 60))
                return new StoryElement("Righting a Wrong: In your youth, you witnessed an event that changed the fate of many or of a tragic few, such as a natural disaster (like a flood, hurricane, or fire) or simply a friend’s unfortunate accident during a childish game. You were burdened by the knowledge that magic— perhaps even a spell as simple as feather fall— could have changed the course of lives. You’ve dedicated yourself to magic in an effort to make sure that you are never subject to the capricious whims of fate again.", "Desperate Resolve");
            if (roll.IsBetween(61, 70))
                return new StoryElement("Storied Lineage: Your family name is synonymous with wizardry of the highest caliber. Magic was your destined path before you were even born, and both your family and those who know of your lineage have supported this notion your entire life, granting you an unwavering confidence in your talents. While the pursuit of arcane mastery is never easy, you are driven to live up to the expectations set forth for you.", "Resilient Caster");
            if (roll.IsBetween(71, 80))
            {
                StoryElement newStoryElement = new StoryElement("The Way Things Work: Magic came alive the first time you held a magic item. The notion of extraordinary magic resting within something as seemingly ordinary as a ring, amulet, or stoppered vial changed the way you viewed the world, and ever since you’ve possessed a sense of curiosity and awe for all magic items.", "Magic Crafter");
                newStoryElement.StoryFeats.Add("Eldritch Researcher");
                return newStoryElement;
            }
            if (roll.IsBetween(81, 90))
                return new StoryElement("Unpaid Debt: Someone saved your life at great cost. Whether through healing magic or basic heroism, your savior gave her life that you might live. Striving to repay this debt has led you to study magic, the only thing capable of making enough of a difference in the world to make you feel that you have earned the gift given to you. This sense of purpose has engendered an unshakable resolve in you", "Principled");
            else
                return new StoryElement("Unquenchable Hunger for Knowledge: For most wizards, magic is an end to which all studies strive, but not for you. For you, magic is a means to an end—and that end is knowledge. Your desire to know all of the secrets of the world requires the ability to cross continents in a blink, ride the winds, breathe water like a fish, and survive any kind of trap. Your unquenching quest for knowledge has made you ever ready for danger.", "Eldritch Delver");
        }
    }
}
