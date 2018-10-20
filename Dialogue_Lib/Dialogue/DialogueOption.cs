namespace Dialogue_Lib.Dialogue
{
    public class DialogueOption
    {
        public int DestinationNodeID { get; set; } = -1;
        public string Text { get; set; }

        public DialogueOption() { }

        public DialogueOption(string text, int dest)
        {
            Text = text;
            DestinationNodeID = dest;
        }
    }
}
