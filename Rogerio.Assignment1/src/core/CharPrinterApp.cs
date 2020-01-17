using static System.Console;
using System;
using System.IO;

namespace Rogerio.Assignment1.src.core
{
    class CharPrinterApp
    {
        CharLoader charLoader;

        public CharPrinterApp()
        {
            Title = "Draw my Input";
        }

        public void InitializeCharLoader(int columns, int charLimit)
        {
            charLoader = new CharLoader
            {
                MaxCharsPerLine = columns,
                MaxChars = charLimit
            };
        }

        /// <summary>
        /// Core method responsible to validate and print the content
        /// </summary>
        /// <param name="input"></param>
        public void RunApp(string input)
        {
            string startupPath = Environment.CurrentDirectory;
            StreamWriter writer = new StreamWriter(startupPath + "/output.txt");

            try
            {
                CharMap[] charsMap = charLoader.LoadChars(input);
                CharMap[] charMapBlock;
                int sourceIndex = 0;
                int sourceSize = charsMap.Length;

                WriteLine();
                while(sourceSize > 0)
                {
                    charMapBlock = SetupBlockChar(ref sourceSize, ref sourceIndex, charsMap);
                    for (int i = 0; i < 7; i++)
                        WriteLines(charMapBlock, i, writer);

                    WriteLine();
                    writer.WriteLine();
                }
                WriteLine();
            }
            catch (Exception e)
            {
                WriteLine(e.Message);
            }
            finally
            {
                writer.Close();
            }

            Write("Press a key...");
            ReadKey();
        }

        /// <summary>
        /// Execute the input from the console
        /// </summary>
        public void ReadFromConsole()
        {
            SetupCharLoader();

            string input;
            do
            {
                Clear();
                WriteLine(String.Format("Enter your text ({0} characters maximum):", charLoader.MaxChars));
                input = ReadLine().Trim();
                RunApp(input);

                Clear();
                WriteLine("(E)xit / (S)etup");
                input = ReadLine().Trim();

                if (input.ToUpper().Equals("E"))
                    break;
                else if (input.ToUpper().Equals("S"))
                    SetupCharLoader();
            }
            while (true);
        }

        /// <summary>
        /// Initialize the CharLoader by setting up its limits
        /// </summary>
        private void SetupCharLoader()
        {
            string input;
            WriteLine("Limit of characters: ");
            input = ReadLine().Trim();
            int.TryParse(input, out int charLimit);

            WriteLine("Limit of columns: ");
            input = ReadLine().Trim();
            int.TryParse(input, out int columns);

            InitializeCharLoader(columns, charLimit);

            Clear();
        }

        /// <summary>
        /// Verify and create a buffer of blocks respecting the character limits per line
        /// </summary>
        /// <param name="sourceSize"></param>
        /// <param name="sourceIndex"></param>
        /// <param name="charsMap"></param>
        /// <returns></returns>
        private CharMap[] SetupBlockChar(ref int sourceSize, ref int sourceIndex, CharMap[] charsMap)
        {
            int destinationSize = FindSpaceToWrap(charsMap, sourceIndex + charLoader.MaxCharsPerLine);
            int buffersize = destinationSize - sourceIndex;
            CharMap[] charMapBlock = new CharMap[buffersize > 0 ? buffersize : 1];
            Array.Copy(charsMap, sourceIndex, charMapBlock, 0, charMapBlock.Length);

            sourceSize -= charMapBlock.Length;
            sourceIndex += charMapBlock.Length;

            return charMapBlock;
        }

        /// <summary>
        /// Find the space nearby and return the position where it was found
        /// </summary>
        /// <param name="charMap"></param>
        /// <param name="sourceIndex"></param>
        /// <returns></returns>
        private int FindSpaceToWrap(CharMap[] charMap, int sourceIndex)
        {
            int columnLimit = charLoader.MaxCharsPerLine;
            for (int i = sourceIndex; i >= 0 && sourceIndex < charMap.Length; i--)
            {
                if (columnLimit == 0)
                    return i + charLoader.MaxCharsPerLine;
                if (charMap[i].Map.Equals(Chars.charSpace))
                    return i + 1;

                columnLimit--;
            }

            return sourceIndex < charMap.Length ? sourceIndex : charMap.Length;
        }

        /// <summary>
        /// It writes all the lines
        /// </summary>
        /// <param name="charsMap">Array of drawn chars</param>
        /// <param name="line">Line position</param>
        private void WriteLines(CharMap[] charsMap, int line, StreamWriter writer)
        {
            string buffer = String.Empty;
            string[] charMap = new string[charsMap.Length];

            for (int i = 0; i < charsMap.Length; i++)
            {
                buffer += "{" + i + "}   ";
                charMap[i] = charsMap[i].Map[line];
            }

            string linePrinted = String.Format(buffer.Substring(0, buffer.Length - 3), charMap);
            WriteLine(linePrinted);
            writer.WriteLine(linePrinted);
        }
    }
}
