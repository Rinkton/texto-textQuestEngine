using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Common;

namespace UnitTests
{
    public class CommonUnit
    {
        [Fact]
        public void GetVariantsUnit()
        {
            string[][] expectedVariants = new string[][]
            {
                new string[] { "without description", "without variants", "1 shortcut" },
                new string[] { "1", "2" },
                new string[] { }
            };

            string[][] actualVariants = new string[][]
            {
                IOFunctions.GetVariants(Constants.TestQuestFolderPath),
                IOFunctions.GetVariants(Constants.WithoutDescriptionPath),
                IOFunctions.GetVariants(Constants.WithoutVariantsPath)
            };

            Assert.Equal(expectedVariants, actualVariants);
        }
    }
}
