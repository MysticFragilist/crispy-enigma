using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace McDoCalendarCreator
{
    public class Shell
    {
        public OutlookScraper outlookScraper;
        public Shell()
        {
            WelcomeMenu();

            string red = string.Empty;
            do
            {

                Console.Write(" > ");
                red = Console.ReadLine();

                switch (red)
                {
                    case Command.Start:
                        Console.WriteLine("Starting the server...");
                        outlookScraper = new OutlookScraper();
                        break;
                    case Command.Stop:
                        Console.WriteLine("Stopping the server...");
                        outlookScraper = null;
                        break;
                    case Command.Help:
                        HelpMenu();
                        break;
                    case Command.List:
                        break;
                }
            }
            while (red != "quit");
        }

        private void WelcomeMenu()
        {
            Console.WriteLine("Bienvenue à l'outils d'analyse Mc Donald's pour la création d'un calendrier dynamique sur Outlook.");
        }

        private void HelpMenu()
        {
            Console.WriteLine(Command.Start + " - Start the server");
            Console.WriteLine(Command.Stop + " - Stop the server");
            Console.WriteLine(Command.List + " - List accounts");
            Console.WriteLine(Command.Help + " - Show this help page");
            Console.WriteLine(Command.Quit + " - Quit");
        }


        private static class Command
        {
            public const string Start = "start";
            public const string Stop = "stop";
            public const string List = "list";
            public const string Help = "help";
            public const string Quit = "quit";
        }
    }
}
