using System;
using System.Collections.Generic;

namespace Rogerio.Assignment1
{
    class CharLoader
    {
        public static readonly int MAX_CHARS = 8;

        List<CharMap> listOfChars;

        public CharLoader()
        {
            InitCharMap();
        }

        /// <summary>
        /// Populate the list with chars and its respective draw
        /// </summary>
        private void InitCharMap()
        {
            listOfChars = new List<CharMap>
            {
                new CharMap('A', Chars.charA),
                new CharMap('B', Chars.charB),
                new CharMap('C', Chars.charC),
                new CharMap('D', Chars.charD),
                new CharMap('E', Chars.charE),
                new CharMap('F', Chars.charF),
                new CharMap('G', Chars.charG),
                new CharMap('H', Chars.charH),
                new CharMap('I', Chars.charI),
                new CharMap('J', Chars.charJ),
                new CharMap('K', Chars.charK),
                new CharMap('L', Chars.charL),
                new CharMap('M', Chars.charM),
                new CharMap('N', Chars.charN),
                new CharMap('O', Chars.charO),
                new CharMap('P', Chars.charP),
                new CharMap('Q', Chars.charQ),
                new CharMap('R', Chars.charR),
                new CharMap('S', Chars.charS),
                new CharMap('T', Chars.charT),
                new CharMap('U', Chars.charU),
                new CharMap('V', Chars.charV),
                new CharMap('X', Chars.charX),
                new CharMap('Z', Chars.charZ),
                new CharMap('W', Chars.charW),
                new CharMap('Y', Chars.charY)
            };
        }

        /// <summary>
        /// Validade and identify the input provided returning an array of chars mapped
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public CharMap[] LoadChars(string input)
        {
            ValidateInput(input);

            CharMap[] charsMap = new CharMap[input.Length];

            for (int i = 0; i < input.Length; i++)
            {
                charsMap[i] = listOfChars.Find(value => value.Letter.Equals(input.ToUpper().ToCharArray()[i]));

                if (charsMap[i] == null)
                {
                    throw new Exception(String.Format("Char {0} not found", input.ToUpper().ToCharArray()[i]));
                }
            }

            return charsMap;
        }

        /// <summary>
        /// Validate if the input is not empty and contains less chars then permited
        /// </summary>
        /// <param name="input">Initials</param>
        private void ValidateInput(string input)
        {
            if (input == null)
            {
                throw new Exception("Please, insert your initials");
            }
            else if (input.Length == 0)
            {
                throw new Exception("Please, add at least one initial");
            }
            else if (input.Length >= MAX_CHARS)
            {
                throw new Exception(String.Format("Please, add only {0} initials to print", MAX_CHARS));
            }
        }
    }

    class CharMap
    {
        public CharMap(char letter, string[] map)
        {
            this.Letter = letter;
            this.Map = map;
        }

        public string[] Map { get; set; }

        public char Letter { get; set; }
    }
}
