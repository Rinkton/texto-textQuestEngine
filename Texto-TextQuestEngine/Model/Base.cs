using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Model
{
    class Base
    {
        /// <summary>
        /// Path to directory, where located info about present step
        /// </summary>
        /// <remarks>
        /// Changes frequently
        /// </remarks>
        private static StringBuilder path = new StringBuilder("quest");

        private static Errors.Error error = new Errors.None();

        public static void SendPathToVisualizer()
        {
            View.Visualizer.Visualize(path.ToString(), error.Text);
        }

        public static Errors.Error ValidateUserInput(string userInput)
        {
            #region is numeric
            int userChoice; // It will converted to int userInput
            bool isNumeric = int.TryParse(userInput, out userChoice);

            if (!isNumeric)
            {
                return new Errors.InvalidUserInput();
            }
            #endregion

            #region user choice in correct range
            int variantsCount = getVariantsCount();

            if (variantsCount < userChoice || userChoice <= 0)
            {
                return new Errors.InvalidUserInput();
            }
            #endregion

            return new Errors.None();
        }

        private static int getVariantsCount()
        {
            return Directory.GetDirectories(path.ToString()).Length;
        }
    }
}
