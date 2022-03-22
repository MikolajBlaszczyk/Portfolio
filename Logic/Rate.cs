using Logic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    public class Rate
    {
        public int RateWorkout(List<Workout> workout, List<Workout> previousWorkout)
        {
            var match = HowManyMatch(workout, previousWorkout);
            int counter = 0;
            int positive = 0;
            foreach (var workoutPrev in match)
            {
                foreach (var workoutNow in workout)
                {
                    if (workoutPrev.Name == workoutNow.Name)
                    {
                        counter++;
                        if (CheckProgress(workoutNow, workoutPrev) is true) ;
                        {
                            positive++;
                        }
                    }
                }
            }
            return GetStars(positive, counter);
        }

        public bool CheckProgress(Workout first, Workout second)
        {
            if (first.Weight >= second.Weight)
            {
                return true;
            }
            else
            {
                return true;
            }
        }
        public List<Workout> HowManyMatch(List<Workout> first, List<Workout> second)
        {
            var output = second.Where(x => first.Any(z => z.Name == x.Name)).ToList();
            return output;
        }
        public int GetStars(int positive, int count)
        {
            int output = (positive * 100 / count);
            if (output < 30)
            {
                return 1;
            }
            else if (output < 60)
            {
                return 2;
            }
            else
            {
                return 3;
            }
        }
    }
}
