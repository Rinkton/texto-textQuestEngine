using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace UnitTests
{
    public class ViewUnit
    {
        [Fact]
        public void GetDescriptionUnit()
        {
            string[] expectedDescriptions = new string[]
            {
                "#",
                null,
                "321"
            };

            string[] actualDescriptions = new string[]
            {
                View.Visualizer.getDescription(Constants.TestQuestFolderPath),
                View.Visualizer.getDescription(Constants.WithoutDescriptionPath),
                View.Visualizer.getDescription(Constants.WithoutVariantsPath)
            };

            Assert.Equal(expectedDescriptions, actualDescriptions);
        }

        [Fact]
        public void GetVariantsUnit()
        {
            string[][] expectedVariants = new string[][]
            {
                new string[] { "without description", "without variants", "without description shortcut" },
                new string[] { "1", "2" },
                new string[] { }
            };

            string[][] actualVariants = new string[][]
            {
                View.Visualizer.getVariants(Constants.TestQuestFolderPath),
                View.Visualizer.getVariants(Constants.WithoutDescriptionPath),
                View.Visualizer.getVariants(Constants.WithoutVariantsPath)
            };

            Assert.Equal(expectedVariants, actualVariants);
        }
    }
}
