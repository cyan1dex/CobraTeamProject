using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cobra.SpellCheck
{
    public class SpellItem
    {
        public String ItemName { get; set; }
        public int EditDistance { get; set; }
        public int TwoGramDistance { get; set; }

        public SpellItem(string ItemName, int EditDistance,int TwoGramDistance)
        {
            this.ItemName = ItemName;
            this.EditDistance = EditDistance;
            this.TwoGramDistance = TwoGramDistance;
        }
    }
}
