using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    class Base
    {
        /// <summary>
        /// Path to directory, where located info about present step
        /// </summary>
        private static StringBuilder path = new StringBuilder("quest");

        private static Errors.Error error = new Errors.None();

        public static void SendPathToVisualizer()
        {
            View.Visualizer.Visualize(path.ToString(), error.Text);
        }
    }
}
