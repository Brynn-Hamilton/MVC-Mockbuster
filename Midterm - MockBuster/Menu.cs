using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace Midterm___MockBuster
{
    public class Menu
    {
        public int SelectedIndex;
        public string[] Options;
        public string Prompt;
        public System.ConsoleColor PromptColor;

        public Menu(string prompt, string[] options, ConsoleColor promptColor = ConsoleColor.White)
        {
            //Console.WriteLine("Please select the level of user access:");
            Prompt = prompt;
            Options = options;
            SelectedIndex = 0;
            PromptColor = promptColor;
        }

        private void DisplayOptions()
        {
            ForegroundColor = PromptColor;
            Console.WriteLine(Prompt);
            ResetColor();
            for(int i = 0; i < Options.Length; i++)
            {
                string currentOptions = Options[i];
         
                if (i == SelectedIndex)
                {
                    ForegroundColor = ConsoleColor.Black;
                    BackgroundColor = ConsoleColor.White;
                }
                else
                {
                    ForegroundColor = ConsoleColor.White;
                    BackgroundColor = ConsoleColor.Black;
                }
                Console.WriteLine($"<< { currentOptions} >>");
            }
            ResetColor();
        }

        public int Run()
        {
            ConsoleKey keyPressed;
            do
            {
                Clear();
                DisplayOptions();
                ConsoleKeyInfo keyinfo = ReadKey(true);
                keyPressed = keyinfo.Key;

                if(keyPressed == ConsoleKey.UpArrow)
                {
                    SelectedIndex--;
                    if(SelectedIndex == -1)
                    {
                        SelectedIndex = Options.Length - 1;
                    }
                }
                else if(keyPressed == ConsoleKey.DownArrow)
                {
                    SelectedIndex++;
                    if (SelectedIndex == Options.Length)
                    {
                        SelectedIndex = 0;
                    }
                }

            } while (keyPressed != ConsoleKey.Enter);

            return SelectedIndex;
        }
    }
}
