using DataAccess;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DataAccess
{
    public interface IDBProcessor
    {
        Task DeleteExcercise(int id);
        Task DeleteWorkout(int id);
        Task<List<ExcerciseNameModel>> GetExcerciseName();
        Task<List<WorkoutModel>> GetWorkout();
        Task<List<WorkoutModel>> GetWorkoutByID(int id);
        Task<List<int>> GetWorkoutID();
        Task InsertWorkout(DateTime date, string name);
        Task InsertWorkoutWithExcercise(List<ExcerciseModel> input);
    }
}