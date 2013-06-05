using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace random_character_generator.Models
{
    public class Trait
    {
        public string TraitName { get; set; }
        public string Description { get; set; }
        public string SRDLink { get; set; }
        public string TraitHtml
        {
            get 
            {
                return String.Format("<strong>{0}</strong>", TraitName); 
            }
        }
    }
}
