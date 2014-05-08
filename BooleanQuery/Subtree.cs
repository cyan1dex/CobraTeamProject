// This collection of non-binary tree data structures created by Dan Vanderboom.
// Critical Development blog: http://dvanderboom.wordpress.com
// Original Tree<T> blog article: http://dvanderboom.wordpress.com/2008/03/15/treet-implementing-a-non-binary-tree-in-c/

using System;
using System.Text;

namespace Cobra.Tree
{
    /// <summary>
    /// Represents a hierarchy of objects or data.  ComplexSubtree is an alias for CobraTree and CobraTreeNode.
    /// </summary>
    public class ComplexSubtree<T> : CobraTreeNode<T> where T : CobraTreeNode<T>
    {
        public ComplexSubtree() { }
    }
}