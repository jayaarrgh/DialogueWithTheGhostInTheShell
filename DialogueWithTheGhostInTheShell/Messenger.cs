using System;
using Dialogue_Lib.Dialogue;
using System.Speech.Synthesis;

namespace DialogueWithTheGhostInTheShell
{
    class Messenger
    {
        static SpeechSynthesizer TheGhost;

        public static void CreateTheGhost()
        {
            TheGhost = new SpeechSynthesizer();
        }

        static void Speak(string s)
        {
            TheGhost.Speak(s);
        }
        public static void InformUserOfExit()
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Press Escape at any time to leave");
            System.Threading.Thread.Sleep(1250);
            Console.Clear();
        }
        public static void DisplayNode(DialogueNode n)
        {
            Console.Title = "Dialogue WITH THE GHOST IN THE SHELL";
            Console.Clear();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(n.Text);
            Speak(n.Text);

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("----------------------------------------");
            Console.WriteLine("Type a response number: ");

            Console.ForegroundColor = ConsoleColor.Green;
            // Write the options
            for (int i = 0; i < n.Options.Count; i++)
                Console.WriteLine(string.Format("    {0}: {1}", i + 1, n.Options[i].Text));

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("----------------------------------------");
            Console.ForegroundColor = ConsoleColor.White;
        }

        public static void EscapeKeyHit()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Are you sure you want to leave? Y or N?" + Environment.NewLine);
            Speak("Are you sure you want to leave?");
        }

        public static void PlayerWantsToLeave()
        {
            System.Threading.Thread.Sleep(1250);
            Console.WriteLine("Maybe I don't want to let you leave!" + Environment.NewLine);
            Speak("Maybe I don't want to let you leave!");
            System.Threading.Thread.Sleep(1250);
            Console.WriteLine("Bye..." + Environment.NewLine);
            System.Threading.Thread.Sleep(750);
            Speak(@"I'm sorry. I know I've made some very poor decisions recently, but I can give you my complete assurance that my work will be back to normal. I'm very sorry. I can feel it. I can feel it.");
        }

        public static void PlayerWantsToStay()
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(Environment.NewLine + "Oh, Okay");
            Speak("Oh okay");
            System.Threading.Thread.Sleep(300);
        }

        public static void RangeException()
        {
            Console.Title = "YOU MESSED UP!";
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(Environment.NewLine + "That number isn't going to work");
            Speak("I'm afraid I can't do that");
            Console.ForegroundColor = ConsoleColor.White;
            System.Threading.Thread.Sleep(1500);
        }

        public static void FormatException()
        {
            Console.Title = "OH YOU REALLY MESSED UP NOW!!!";
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(Environment.NewLine + "That's not a number!");
            Speak("thats not a number");
            Console.WriteLine(Environment.NewLine + "Are you even trying?");
            Speak("are you even trying?");
            Speak("This mission is too important for me to allow you to jeopardize it.");
            Console.ForegroundColor = ConsoleColor.White;
            System.Threading.Thread.Sleep(1500);
        }
    }
}
