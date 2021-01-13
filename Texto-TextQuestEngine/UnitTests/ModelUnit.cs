using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Model;

namespace UnitTests
{
    public class ModelUnit
    {
        [Fact]
        public void ValidateUserInputUnit()
        {
            Type[] expectedValues = new Type[]
            {
                new Model.Errors.None().GetType(),
                new Model.Errors.None().GetType(),
                new Model.Errors.InvalidUserInput().GetType(),
                new Model.Errors.InvalidUserInput().GetType(),
                new Model.Errors.InvalidUserInput().GetType(),
                new Model.Errors.InvalidUserInput().GetType(),
                new Model.Errors.None().GetType(),
                new Model.Errors.InvalidUserInput().GetType()
            };

            Type[] actualValues = new Type[]
            {
                Base.ValidateUserInput("1").GetType(),
                Base.ValidateUserInput("2").GetType(),
                Base.ValidateUserInput("abc").GetType(),
                Base.ValidateUserInput("1a").GetType(),
                Base.ValidateUserInput("a1").GetType(),
                Base.ValidateUserInput("0").GetType(),
                Base.ValidateUserInput("3").GetType(),
                Base.ValidateUserInput("100").GetType()
            };

            Assert.Equal(expectedValues, actualValues);
        }

        [Fact]
        public void GetNewPath()
        {
            string[] expectedNewPaths = new string[]
            {
                @"quest\without description",
                @"quest\without variants",
                @"quest\without description\1"
            };

            string[] actualNewPaths = new string[]
            {
                Base.GetNewPath(1),
                Base.GetNewPath(2),
                Base.GetNewPath(3)
            };

            Assert.Equal(expectedNewPaths, actualNewPaths);
        }
    }
}
