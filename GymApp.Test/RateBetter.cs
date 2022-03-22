using Logic;
using Logic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace GymApp.Test
{
    public class RateBetterTest
    {
        RateBetter rate = new();

        [Fact]
        public void Rate()
        {
            List<Workout> workouts = new() 
            {
                new Workout { Name="Deadlift", Count=3, Series=3 , Weight=120},
                 new Workout { Name = "Deadlift", Count = 3, Series = 3, Weight = 120 },
                  new Workout { Name = "Deadlift", Count = 3, Series = 3, Weight = 120 }
            };

           var result = rate.RateWorkout(workouts);

            Assert.Equal("3", result.ToString());
        }
    }
}
