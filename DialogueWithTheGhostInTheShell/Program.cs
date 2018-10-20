using System;
using Dialogue_Lib.Dialogue;

namespace DialogueWithTheGhostInTheShell
{
    class Program
    {
        static void Main(string[] args)
        {
            //Dialogue fun
            DialogueBuilder.InitializeTestDialogueXML();
            Dialogue d = DialogueBuilder.ReadDialogueXML("test_dia.xml");
            RunDialogue(d);
        }

        static void RunDialogue(Dialogue d)
        {
            Messenger.CreateTheGhost(); // Create SpeechSynthesizer
            Messenger.InformUserOfExit();
            int node_id = 0; 
            while (node_id != -1) // -1 is exit node
                node_id = RunNode(d.Nodes[node_id]);
        }

        static int RunNode(DialogueNode n)
        {
            Messenger.DisplayNode(n);
            return GetUserInputForNextNode(n);
        }

        static int GetUserInputForNextNode(DialogueNode n)
        {
            char key = Console.ReadKey().KeyChar;

            // Escape at any time
            if (key == (char)ConsoleKey.Escape)
                return ValidateEscape(n);

            return ValidateNextNodeInput(key, n);
        }

        static int ValidateNextNodeInput(char key, DialogueNode n)
        {
            int next_node = -1;
            try
            {
                int index = int.Parse(key.ToString());
                // UNITY: replace the index with a variable sent from Unity UI button event -- and change exception handling
                next_node = n.Options[index - 1].DestinationNodeID;
            }
            catch (ArgumentOutOfRangeException)
            {
                Messenger.RangeException();
                return RunNode(n); //redisplay the current node
            }
            catch (FormatException)
            {
                Messenger.FormatException();
                return RunNode(n); //redisplay the current node
            }
            return next_node;
        }

        static int ValidateEscape(DialogueNode n)
        {
            // OUTPUT: Are you sure Y or N ?
            Messenger.EscapeKeyHit();

            char key = Console.ReadKey().KeyChar;
            if (key == 'y' || key == (char)ConsoleKey.Escape)
            {
                Messenger.PlayerWantsToLeave();
                return -1;
            }

            Messenger.PlayerWantsToStay();
            return RunNode(n); //redisplay the current node
        }
    }
}
