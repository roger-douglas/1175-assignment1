using static System.Console;
using System;

namespace Rogerio.Assignment1.src.core
{
    class CharPrinterApp
    {
        readonly CharLoader charLoader;

        public CharPrinterApp()
        {
            // Helper class used to map each character
            charLoader = new CharLoader();
        }

        /// <summary>
        /// Core method responsible to validate and print the content
        /// </summary>
        /// <param name="input"></param>
        public void RunApp(string input)
        {
            try
            {
                CharMap[] charsMap = charLoader.LoadChars(input);

                WriteExcitingSentences();
                Write("\n\n");
                for (int i = 0; i < 7; i++)
                {
                    WriteFirstInitial(charsMap, i);
                    WriteNextInitials(charsMap, i);
                }
                Write("\n\n");

            }
            catch (Exception e)
            {
                WriteLine(e.Message);
            }

            Write("Press a key...");
            ReadKey();
        }

        /// <summary>
        /// Execute the input from the console
        /// </summary>
        public void ReadFromConsole()
        {
            Clear();
            WriteLine("Do you want to try? (Y)es");
            string answer = ReadLine().Trim().ToUpper();

            if (answer.Equals("Y"))
            {
                WriteLine(String.Format("Enter your initials ({0} chars maximum):", CharLoader.MAX_CHARS));
                answer = ReadLine().Trim();
                RunApp(answer);
            }
        }

        /// <summary>
        /// Requirement #1 - Write two sentences using escape for double quotations
        /// </summary>
        private void WriteExcitingSentences()
        {
            WriteLine(String.Empty);
            WriteLine("I am exciting about coding while snow outside.");
            WriteLine("I am a Java Developer, but I still enjoy learning new things because \"Practice Makes Perfect\".");
        }

        /// <summary>
        /// Requirement #3 - Write only the first initia using Write method
        /// </summary>
        /// <param name="charsMap">Array of drawn chars</param>
        /// <param name="line">Line position</param>
        private void WriteFirstInitial(CharMap[] charsMap, int line)
        {
            if (charsMap.Length == 1)
                Write(String.Format("{0}\n", charsMap[0].Map[line]));
            else
                Write(String.Format("{0}\t", charsMap[0].Map[line]));
        }

        /// <summary>
        /// Requirement #3 - It ignores the first initial and print the subsequent initials if exist
        /// </summary>
        /// <param name="charsMap">Array of drawn chars</param>
        /// <param name="line">Line position</param>
        private void WriteNextInitials(CharMap[] charsMap, int line)
        {
            if (charsMap.Length > 1)
            {
                string buffer = String.Empty;
                string[] charMap = new string[charsMap.Length - 1];

                for (int i = 1; i < charsMap.Length; i++)
                {
                    buffer += "{" + (i - 1) + "}\t";
                    charMap[i - 1] = charsMap[i].Map[line];
                }

                WriteLine(String.Format(buffer.Substring(0, buffer.Length - 1), charMap));
            }
        }
    }
}
