using System;
using System.Collections.Generic;
using System.Text;

namespace Cobra.Tree
{
    public class BSTask : CobraTreeNode<BSTask>
    {
        public string Name;
        public bool Negated;
        public bool Wildcard;

        private bool _Complete;
        public bool Complete
        {
            get { return _Complete; }
            set
            {
                // if this task is complete, then all child tasks must also be complete
                if (value)
                {
                    foreach (BSTask bstask in Children)
                    {
                        bstask.Complete = true;
                    }
                }

                _Complete = value;
            }
        }

        public BSTask(string Name)
        {
            this.Name = Name;
            this.Negated = false;
            this.Wildcard = false;
            Complete = false;
        }

        public BSTask(string Name, bool negated)
        {
            this.Name = Name;
            this.Negated = negated;
            this.Wildcard = false;
            Complete = false;
        }

        public BSTask(string Name, bool negated, bool wildcarded)
        {
            this.Name = Name;
            this.Negated = negated;
            this.Wildcard = wildcarded;
            Complete = false;
        }

    }
}