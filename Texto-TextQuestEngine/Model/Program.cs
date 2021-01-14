using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    //TODO: Check of line break's validate, because line break may be diffirent, it dependences from editor of text
    //TODO: Split classes on smaller classes, it are so huge
    //TODO: Write samples
	//TODO: Fix up a bug, when shortcut link on a empty folder (and shortcuts don't work at all)
	//TODO: In variants user creator don't can to write "?"
    class Program
    {
        static void Main()
        {
            while (true)
            {
                Base.SendPathToVisualizer();

                //If there is no variants, then game is ended
                if (Base.GetVariantsCount() == 0)
                {
                    Controller.Input.WaitUserKey();
                    break;
                }

                string userInput = Controller.Input.GetUserInput();
                Errors.Error err = Base.ValidateUserInput(userInput);

                if (err.GetType() != new Errors.None().GetType())
                {
                    Base.Error = err;
                    continue;
                }
                else
                {
                    Base.Error = new Errors.None();
                }

                //userInput 100% is correct number, cuz it's been validated
                int userInputInt = Convert.ToInt32(userInput);
                string newPathString = Base.GetNewPath(userInputInt);
                Base.Path = new StringBuilder(newPathString);
            }
        }
    }
}
