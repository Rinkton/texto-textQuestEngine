using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controller
{
    /// <summary>
    /// Have responsible to act with what user is input
    /// </summary>
    public static class Input
    {
        public static string GetUserInput()
        {
            string userInput = Console.ReadLine();
            return userInput;
        }
    }
}
