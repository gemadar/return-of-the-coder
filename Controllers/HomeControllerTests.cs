using Microsoft.AspNetCore.Mvc;
using return_of_the_coder.Controllers;
using return_of_the_coder.Models;
using Xunit;

namespace return_of_the_coder.Tests.Controllers
{
    public class HomeControllerTests
    {
        [Fact]
        public void ReturnOfTheCoder_Post_Returns_IndexView()
        {
            var controller = new HomeController();
            var personModel = new PersonModel
            {
                AgeOfDeath1 = 80,
                YearOfDeath1 = 2023,
                AgeOfDeath2 = 75,
                YearOfDeath2 = 2024
            };

            var result = controller.ReturnOfTheCoder(personModel) as ViewResult;

            Assert.NotNull(result);
            Assert.Equal("Index", result.ViewName);
        }

        [Theory]
        [InlineData(10, 12, 13, 17, 4.5f)]   //  Positive test
        [InlineData(0, 0, 0, 0, 0f)]   // Test with zero
        [InlineData(12, 10, 17, 13, -1f)]   // Negative test
        public void ReturnOfTheCoder_CalculatesYearSum(int ageOfDeath1, int yearOfDeath1, int ageOfDeath2, int yearOfDeath2, float expectedYearSum)
        {
            var controller = new HomeController();
            var personModel = new PersonModel
            {
                YearOfDeath1 = yearOfDeath1,
                AgeOfDeath1 = ageOfDeath1,
                YearOfDeath2 = yearOfDeath2,
                AgeOfDeath2 = ageOfDeath2
            };

            var result = controller.ReturnOfTheCoder(personModel) as ViewResult;

            Assert.NotNull(result);
            Assert.Equal("Index", result.ViewName);

            var yearSum = result.ViewData["YearSum"];
            Assert.IsType<float>(yearSum); 

            Assert.Equal(expectedYearSum, yearSum);
        }

        [Theory]
        [InlineData(12, 5)] // Positive test
        [InlineData(0, 0)] // Test with zero
        [InlineData(0, -1)] // Negative test
        public void Year_Returns_Correct_Result(int expectedResult, int input)
        {
            // Arrange
            var result = HomeController.Year(input);

            // Assert
            Assert.Equal(expectedResult, result);
        }
    }
}
