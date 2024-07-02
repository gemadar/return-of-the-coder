using Microsoft.AspNetCore.Mvc;
using return_of_the_coder.Models;

namespace return_of_the_coder.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult ReturnOfTheCoder(PersonModel person)
        {
            // Calculate birth year of these 2 persons
            int person1 = person.YearOfDeath1 - person.AgeOfDeath1;
            int person2 = person.YearOfDeath2 - person.AgeOfDeath2;

            // Check if the sum is below 0
            int sum = person1 + person2;
            var res = sum < 0 ? -1 : (Year(person1) + Year(person2)) / 2f;

            ViewBag.YearSum = res;

            return View("Index");
        }

        public static int Year(int n)
        {
            // Check 0 values
            if (n <= 0)
                return 0;

            int sum = 0;
            int prev1 = 0;
            int prev2 = 1;

            // Calculate Death of The Year
            for (int i = 0; i <= n; i++)
            {
                sum += prev1;

                int current = prev1 + prev2;
                prev1 = prev2;
                prev2 = current;
            }

            return sum;
        }
 
    }
}
