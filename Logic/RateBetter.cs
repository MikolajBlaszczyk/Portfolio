using Logic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    public class RateBetter
    {
        public int RateWorkout(List<Workout> workout)
        {
            double weightLifted = WeightLifted(workout);
            int output = Rate(weightLifted);
            return output;
        }

        public int Rate(double weightLifted)
        {
            if (weightLifted > 1500)
            {
                return 3;
            }
            else if ( weightLifted > 1000)
            {
                return 2;
            }
            else
            {
                return 1;
            }
        }

        public double WeightLifted(List<Workout> workout)
        {
            double output=0;
            foreach (var excercise in workout)
            {
                output += excercise.Weight  * excercise.Count;
            }

            return output;
        }
    }
}
