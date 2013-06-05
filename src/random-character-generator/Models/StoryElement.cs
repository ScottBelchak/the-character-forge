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
        public string ElementHtml
        {
            get
            {
                string title = "";
                string description = Element;
                if (Element.Contains(":"))
                {
                    title = Element.Substring(0, Element.IndexOf(":") + 1);
                    description = Element.Replace(title, "");
                    return String.Format("<strong>{0}</strong>{1}", title, description);
                }
                else
                    return String.Format("<strong>{0}</strong>", Element);
            }
        }
        
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
