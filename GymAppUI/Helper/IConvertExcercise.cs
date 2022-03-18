using Caliburn.Micro;
using DataAccess;
using GymAppUI.Models;
using System.Collections.Generic;

namespace GymAppUI.Helper
{
    public interface IConvertExcercise
    {
        List<ExcerciseModel> CollectionToList(BindableCollection<ExcerciseTrainingModel> input);
    }
}