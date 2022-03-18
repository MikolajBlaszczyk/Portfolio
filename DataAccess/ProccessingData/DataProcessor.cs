using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{ 
    public class DataProcessor : IDBProcessor
    {
        private ISqlDataAccess _dataAccess;

        public DataProcessor(ISqlDataAccess dataAccess)
        {
            _dataAccess = dataAccess;
        }

        public async Task<List<WorkoutModel>> GetWorkout()
        {

            string cmd = "exec [dbo].[spGetAllWorkoutWithID]";
            var output = await _dataAccess.GetDataAsync<WorkoutModel, dynamic>(cmd, new { });
            return output;
        }
        public async Task<List<ExcerciseNameModel>> GetExcerciseName()
        {
            string cmd = "exec [dbo].[spExcercises_GetName]";
            var output =  await _dataAccess.GetDataAsync<ExcerciseNameModel, dynamic>(cmd, new { });

            return output;
        }
        public int GetWorkoutID()
        {
            string cmd = "exec [dbo].[spGetWorkoutID]";
            var output = _dataAccess.GetDataAsync<int, dynamic>(cmd, new { });
            return output.Result.FirstOrDefault();
        }
        public async Task DeleteExcercise(int id)
        {
            await _dataAccess.GiveDataAsync("exec [dbo].[spDeleteWorkoutExcercise] @WorkoutID", new { WorkoutID = id });
        }
        public async Task DeleteWorkout(int id)
        {
            await _dataAccess.GiveDataAsync("exec [dbo].[spDeleteWorkout] @WorkoutID", new { WorkoutID = id });
        }
        public async Task InsertWorkout(DateTime date, string name)
        {
            await _dataAccess.GiveDataAsync("exec [dbo].[spInsertWorkout] @WorkoutName, @WorkoutDate"
                , new { WorkoutName = name, WorkoutDate = date });
        }
        public async Task InsertWorkoutWithExcercise(List<ExcerciseModel> input)
        {
            int id = 2; // get last index
            foreach (var model in input)
            {
                await _dataAccess.GiveDataAsync(@"exec [dbo].[spInsertWorkoutExcercise] @WorkoutID,
                     @ExcerciseName, @ExcerciseCount, @ExcerciseWeight",
                      new
                      {
                          WorkoutID = id,
                          ExcerciseName = model.ExcerciseName,
                          ExcerciseCount = model.ExcerciseCount,
                          ExcerciseWeight = model.ExcerciseWeight
                      });
            }
        }
    }
}
