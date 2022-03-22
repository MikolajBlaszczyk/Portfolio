using Caliburn.Micro;
using DataAccess;
using GymAppUI.Helper;
using GymAppUI.Models;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace GymAppUI.ViewModels
{
    public class WorkoutViewModel : Screen, IWorkoutViewModel
    {
        public event EventHandler<WorkoutViewModel> _endOfWorkout;

       

        private BindableCollection<ExcerciseUIModel> excercise;
        private ExcerciseUIModel _selectedItem;
        private BindableCollection<ExcerciseTrainingModel> training;
        private ExcerciseTrainingModel selected;
        //prop
        public ExcerciseTrainingModel Selected
        {
            get { return selected; }
            set { selected = value; NotifyOfPropertyChange(() => Selected); NotifyOfPropertyChange(() => CurrentTraining); }
        }
        public BindableCollection<ExcerciseTrainingModel> CurrentTraining
        {
            get { return training; }
            set { training = value; NotifyOfPropertyChange(() => CurrentTraining); }
        }
        public ExcerciseUIModel SelectedItem
        {
            get { return _selectedItem; }
            set { _selectedItem = value; NotifyOfPropertyChange(() => SelectedItem); }
        }
        public BindableCollection<ExcerciseUIModel> Excercise
        {
            get { return excercise; }
            set { excercise = value; NotifyOfPropertyChange(() => Excercise); }
        }

        public IDBProcessor Processor { get; }
        public IConvertExcercise CollectionConverter { get; }
        public IListConverter ListConverter { get; }

        public WorkoutViewModel(IDBProcessor processor, IConvertExcercise collectionConverter, IListConverter listConverter)
        {
            Processor = processor;
            CollectionConverter = collectionConverter;
            ListConverter = listConverter;
        }

        public async Task OnInitilize()
        {
            training = new();
            Excercise = ListConverter.ConvertListE(await Processor.GetExcerciseName());
        }
        public void Add()
        {
            CurrentTraining.Add(new ExcerciseTrainingModel() { Name = SelectedItem.Name });
            Log.Logger.Information("Added Excercise");
        }
        public async Task Delete()
        {
            training.Clear();
            SelectedItem = null;
            var id = await Processor.GetWorkoutID();
            await Processor.DeleteWorkout(id.FirstOrDefault());
            _endOfWorkout?.Invoke(this, this);
            Log.Logger.Information("Workout canceled");
        }
        public void Finish()
        {
            Processor.InsertWorkoutWithExcercise(CollectionConverter.CollectionToList(CurrentTraining));
            CurrentTraining.Clear();
            _endOfWorkout?.Invoke(this, this);
            Log.Logger.Information("Workout finished");
        }


    }
}
