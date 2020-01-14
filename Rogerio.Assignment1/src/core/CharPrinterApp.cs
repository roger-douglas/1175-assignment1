using static System.Console;
using static Rogerio.Assignment1.CharLoader;
using System;

namespace Rogerio.Assignment1.src.core
{
    class CharPrinterApp
    {
        readonly CharLoader charLoader;

        public CharPrinterApp()
        {
            Title = "Draw my input";
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
                CharMap[] charMapBlock;
                int sourceIndex = 0;
                int sourceSize = charsMap.Length;

                WriteLine();
                for (int j = 0; j < MAX_CHARS_PER_LINE; j++)
                {
                    charMapBlock = SetupBlockChar(ref sourceSize, ref sourceIndex, charsMap);

                    for (int i = 0; i < 7; i++)
                        WriteLines(charMapBlock, i);

                    if (sourceSize < 0)
                        break;
                    else
                        sourceIndex += MAX_CHARS_PER_LINE;

                    WriteLine();
                }
                WriteLine();
            }
            catch (Exception e)
            {
                WriteLine(e.Message);
            }

            Write("Press a key...");
            ReadKey();
        }

        private CharMap[] SetupBlockChar(ref int sourceSize, ref int sourceIndex, CharMap[] charsMap)
        {
            int destinationSize = sourceSize < MAX_CHARS_PER_LINE ? sourceSize : MAX_CHARS_PER_LINE;
            CharMap[] charMapBlock = new CharMap[destinationSize];
            Array.Copy(charsMap, sourceIndex, charMapBlock, 0, destinationSize);
            sourceSize -= MAX_CHARS_PER_LINE;

            return charMapBlock;
        }

        /// <summary>
        /// Execute the input from the console
        /// </summary>
        public void ReadFromConsole()
        {
            string input;
            do
            {
                Clear();
                WriteLine(String.Format("Enter your text ({0} chars maximum):", CharLoader.MAX_CHARS));
                input = ReadLine().Trim();
                RunApp(input);

                Clear();
                WriteLine("(E)xit");
                input = ReadLine().Trim();

                if (input.ToUpper().Equals("E"))
                    break;
            }
            while (true);
        }

        /// <summary>
        /// It writes all the lines
        /// </summary>
        /// <param name="charsMap">Array of drawn chars</param>
        /// <param name="line">Line position</param>
        private void WriteLines(CharMap[] charsMap, int line)
        {
            if (charsMap.Length > 1)
            {
                string buffer = String.Empty;
                string[] charMap = new string[charsMap.Length];

                for (int i = 0; i < charsMap.Length; i++)
                {
                    buffer += "{" + i + "}   ";
                    charMap[i] = charsMap[i].Map[line];
                }

                WriteLine(String.Format(buffer.Substring(0, buffer.Length - 3), charMap));
            }
        }
    }
}
