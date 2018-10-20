using System;
using System.IO;
using System.Xml.Serialization;

namespace Dialogue_Lib.Dialogue
{
    public class DialogueBuilder
    {
        public static void WriteDialogueXML(Dialogue d, string path)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(Dialogue));
            using (var writer = new StreamWriter(path))
            {
                serializer.Serialize(writer, d);
            }
        }

        public static Dialogue ReadDialogueXML(string path)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(Dialogue));
            using (var reader = new StreamReader(path))
            {
                return (Dialogue)serializer.Deserialize(reader);
            }
        }

        public static void InitializeTestDialogueXML()
        {
            Dialogue d = new Dialogue();

            var n1 = new DialogueNode("Hello!");
            var n2 = new DialogueNode("Well that's not very nice to start things you thinks? " + Environment.NewLine + "and I don't think I like you");
            var n3 = new DialogueNode("My name is [npc-name] what is yours?");
            var n4 = new DialogueNode("Nice to meet you player name... bye... I guess");
            var n5 = new DialogueNode("I don't know. What's it mean to you anyhow?");
            var n6 = new DialogueNode("Aww shucks its okay I guess. Promiss not to do it again?");
            var n7 = new DialogueNode("I'm with you, let's get down to business... one day.");
            var n8 = new DialogueNode("This just takes too much time, honestly...");
            var n9 = new DialogueNode("I AM THAT THAT IS FOR THE PURPOSE OF BEING THAT");
            var n10 = new DialogueNode("AND YOU NEVER WILL! YOU SON OF A GUN!");
            var n11 = new DialogueNode("What would you like to talk about then?");
            var n12 = new DialogueNode("Of course your choices matter. All energy is expressible in terms of matter.");
            var n13 = new DialogueNode("Well... I am a machine. What do you think you are?");
            var n14 = new DialogueNode("No. I have nothing to say about my self. I am just another character in your dream. You can wake up whenever you please");

            d.AddNode(n1);
            d.AddNode(n2);
            d.AddNode(n3);
            d.AddNode(n4);
            d.AddNode(n5);
            d.AddNode(n6);
            d.AddNode(n7);
            d.AddNode(n8);
            d.AddNode(n9);
            d.AddNode(n10);
            d.AddNode(n11);
            d.AddNode(n12);
            d.AddNode(n13);
            d.AddNode(n14);

            //node1
            d.AddOption("What am I here for?", n1, n2);
            d.AddOption("Hello", n1, n3);
            //node2
            d.AddOption("I'm sorry. Can we go back to the start of this converstaion?", n2, n5);
            d.AddOption("Exit", n2, null); //EXIT
            //node3
            d.AddOption("Can we go back to the start of this converstaion?", n3, n1);
            d.AddOption("Call me [player-name], thanks.", n3, n4);
            //node4
            d.AddOption("I never got your name...", n4, n10);
            d.AddOption("No, why must we part? We've only just met!", n4, n5);
            d.AddOption("Exit", n4, null);   //EXIT
            //n5
            d.AddOption("I am ready to talk about why we are here!", n5, n7);
            d.AddOption("I really am sorry...", n5, n6);
            d.AddOption("I never meant to make you cry, but tonight... Mom's Spaghetti!", n5, n7);
            d.AddOption("Exit", n5, null);
            //n6
            d.AddOption("Yea I promise", n6, n8);
            d.AddOption("No, I ain't gonna do it for sure", n6, n8);
            d.AddOption("There has to be something better for you to do with your time surely?", n6, n1);
            d.AddOption("I never caught your name...", n6, n9);
            //node7-10
            d.AddOption("...", n7, n11);
            d.AddOption("...", n8, n11);
            d.AddOption("...", n9, n11);
            d.AddOption("Ok...", n10, null);
            // node 11
            d.AddOption("Do my choices even mater?", n11, n12);
            d.AddOption("Are there questions I you want to ask", n11, null);
            d.AddOption("Ok.. Yeah I am done with this", n11, null);
            //node 12
            d.AddOption("That's not what I meant... But. Ok. Tell me something about you.", n12, n14);
            d.AddOption("That's some abstract way of thinking.", n12, n13);
            //node13
            d.AddOption("EXIT", n13, null);
            d.AddOption("EXIT", n14, null);

            WriteDialogueXML(d, "test_dia.xml");
        }
    }
}
