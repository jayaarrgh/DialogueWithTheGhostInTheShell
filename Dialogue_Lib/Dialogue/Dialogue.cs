using System;
using System.Collections.Generic;

namespace Dialogue_Lib.Dialogue
{
    public class Dialogue
    {
        //PROPERTIES
        public List<DialogueNode> Nodes { get; set; }

        //CONSTRUCTORS
        public Dialogue()
        {
            Nodes = new List<DialogueNode>();
        }

        //METHODS

        public void AddNode(DialogueNode node)
        {
            if (node == null) return;

            Nodes.Add(node);
            node.NodeID = Nodes.IndexOf(node);
        }

        public void AddOption(string text, DialogueNode node, DialogueNode dest)
        {
            if (!Nodes.Contains(dest))
                AddNode(dest);

            if (!Nodes.Contains(node))
                AddNode(node);

            DialogueOption opt;
            if (dest == null)
                opt = new DialogueOption(text, -1);
            else
                opt = new DialogueOption(text, dest.NodeID);

            node.Options.Add(opt);
        }
    }
}
