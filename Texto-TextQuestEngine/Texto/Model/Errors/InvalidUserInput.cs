using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Texto.Model.Errors
{
    class InvalidUserInput : Error
    {
        public InvalidUserInput()
        {
            Text = "There is must be an error text.";
        }
    }
}
