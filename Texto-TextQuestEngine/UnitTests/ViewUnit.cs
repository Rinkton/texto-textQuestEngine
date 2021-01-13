using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using View;

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
                Visualizer.getDescription(Constants.TestQuestFolderPath),
                Visualizer.getDescription(Constants.WithoutDescriptionPath),
                Visualizer.getDescription(Constants.WithoutVariantsPath)
            };

            Assert.Equal(expectedDescriptions, actualDescriptions);
        }
    }
}
