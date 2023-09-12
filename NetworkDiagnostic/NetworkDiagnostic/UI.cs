// Author: Tymoshchuk Maksym
// Created On : 10.09.2023
// Last Modified On :
// Description: Users interface

namespace NetworkDiagnostic
{
    internal class UI
    {
        /// <summary>
        /// Print ping status in console.
        /// </summary>
        /// <param name="message">
        /// message for printing.
        /// </param>
        public static void PrintStatus(string message)
        {
            // символ новой строки
            char splitChar = (char)10;
            char tabChar = (char)9;

            string[] msgs = message.Split(splitChar);

            for (ushort i = 0; i < msgs.Count(); ++i)
            {
                if (!string.IsNullOrEmpty(msgs[i]))
                {
                    string[] parts = msgs[i].Split(tabChar);

                    for (ushort k = 0; k < parts.Count() - 1; ++k)
                    {
                        Console.Write($"{parts[k]}\t");
                    }

                    string status = parts[parts.Count() - 1];

                    if (status == "Success")
                    {
                        PrintChangedColor(ConsoleColor.Green, status);
                    }
                    else
                    {
                        PrintChangedColor(ConsoleColor.Red, status);
                    }
                }
            }
        }

        /// <summary>
        /// Change item color.
        /// </summary>
        /// <param name="color">
        /// Prefered color.
        /// </param>
        /// <param name="str">
        /// String for changing color.
        /// </param>
        private static void PrintChangedColor(ConsoleColor color, string str)
        {
            ConsoleColor def = Console.ForegroundColor;
            Console.ForegroundColor = color;
            Console.WriteLine(str);
            Console.ForegroundColor = def;
        }
    }
}
