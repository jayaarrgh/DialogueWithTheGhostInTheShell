using System.Collections.Generic;

namespace Dialogue_Lib.Dialogue
{
    public class DialogueNode
    {
        public int NodeID { get; set; } = -1;
        public List<DialogueOption> Options { get; set; }
        public string Text { get; set; }

        public DialogueNode()
        {
            Options = new List<DialogueOption>();
        }

        public DialogueNode(string text)
        {
            Text = text;
            Options = new List<DialogueOption>();
        }
    }
}