using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace random_character_generator.Models
{
    public class StoryElement
    {
        public string Element { get; set; }
        public string AdditionalInformation { get; set; }
        public IList<string> StoryFeats { get; set; }
        public List<Trait> UnlockedTraits { get; set; }
        /// <summary>
        /// Initializes a new instance of the StoryElement class.
        /// </summary>
        public StoryElement(string element, params string[] traits)
        {
            StoryFeats = new List<string>();
            Element = element;
            UnlockedTraits = new List<Trait>();
            foreach (string trait in traits)
                UnlockedTraits.Add(new Trait() { TraitName = trait });
        }
    }
}
