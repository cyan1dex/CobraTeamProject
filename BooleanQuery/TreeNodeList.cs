// This collection of non-binary tree data structures created by Dan Vanderboom.
// Critical Development blog: http://dvanderboom.wordpress.com
// Original Tree<T> blog article: http://dvanderboom.wordpress.com/2008/03/15/treet-implementing-a-non-binary-tree-in-c/

using System;
using System.Text;
using System.Collections.Generic;

namespace Cobra.Tree
{
    /// <summary>
    /// Contains a list of CobraTreeNode (or CobraTreeNode-derived) objects, with the capability of linking parents and children in both directions.
    /// </summary>
    public class CobraTreeNodeList<T> : List<CobraTreeNode<T>> where T : CobraTreeNode<T>
    {
        public T Parent;

        public CobraTreeNodeList(CobraTreeNode<T> Parent)
        {
            this.Parent = (T)Parent;
        }

        public T Add(T Node)
        {
            base.Add(Node);
            Node.Parent = Parent;
            return Node;
        }

        public override string ToString()
        {
            return "Count=" + Count.ToString();
        }
    }
}