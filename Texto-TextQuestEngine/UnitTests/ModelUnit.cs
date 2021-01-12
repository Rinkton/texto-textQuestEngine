using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace UnitTests
{
    public class ModelUnit
    {
        [Fact]
        public void ValidateUserInputUnit()
        {
            // Arrange

            // Act
            bool allIsOK = true;

            #region check correct variants
            string[] testValuesCorrect = new string[] { "1", "2" };

            foreach (string value in testValuesCorrect)
            {
                if (Model.Base.ValidateUserInput(value).GetType() == new Model.Errors.InvalidUserInput().GetType())
                {
                    allIsOK = false;
                }
            }
            #endregion

            #region check incorrect variants
            string[] testValuesIncorrect = new string[] { "abc", "1a", "a1", "0", "3", "100" };

            foreach (string value in testValuesIncorrect)
            {
                if (Model.Base.ValidateUserInput(value).GetType() == new Model.Errors.None().GetType())
                {
                    allIsOK = false;
                }
            }
            #endregion

            // Assert
            Assert.True(allIsOK);
        }
    }
}
