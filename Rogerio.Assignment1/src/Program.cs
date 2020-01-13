/*
 * Programmer: Rogerio Floriano da Cunha (Roger)
 * Date: Winter 2020 - CSIS 1175-006
 * Purpose: Draw in the console letters that represent your initials. It can draw up to 8 letters per execution.
 */
using Rogerio.Assignment1.src.core;

namespace Rogerio.Assignment1
{
    class Program
    {
        static readonly CharPrinterApp charPrinterApp = new CharPrinterApp();

        // It invokes two methods of CharPrinterApp that contains the logic for printing chars
        static void Main(string[] args)
        {
            //  This method will start the process of identifying the input and drawing the chars on the console
            charPrinterApp.RunApp("rfc");

            // This is a plus. It will ask if you want to try yourself
            charPrinterApp.ReadFromConsole();
        }
    }

}
