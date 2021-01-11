﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    class Program
    {
        static void Main(string[] args)
        {
            Base.SendPathToVisualizer();
            string userInput = Controller.Input.GetUserInput();
            Base.ValidateUserInput(userInput);
        }
    }
}