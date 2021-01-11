using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Errors
{
    public abstract class Error
    {
        /// <summary>
        /// Text, which will displayed by View
        /// </summary>
        public string Text = "Error is not defined";
    }
}
