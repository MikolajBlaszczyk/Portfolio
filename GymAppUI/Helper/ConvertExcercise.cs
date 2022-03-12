using BuisnessLogic.Models;
using Caliburn.Micro;
using GymAppUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymAppUI.Helper
{
    public class ConvertExcercise
    {
        public List<ExcerciseModel> CollectionToList(BindableCollection<ExcerciseTrainingModel> input)
        {
            List<ExcerciseModel> output = new List<ExcerciseModel>();
            
            foreach (var item in input)
            {
                output.Add(new ExcerciseModel() { ExcerciseName=item.Name, ExcerciseCount=item.Count,ExcerciseWeight= item.Weight });
            }

            return output;
        }       

    }
}
