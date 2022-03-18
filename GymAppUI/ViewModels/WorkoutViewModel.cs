using Caliburn.Micro;
using DataAccess;
using GymAppUI.Helper;
using GymAppUI.Models;
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

        public ExcerciseTrainingModel Selected
        {
            get { return selected; }
            set { selected = value; NotifyOfPropertyChange(() => Selected); NotifyOfPropertyChange(() => ThisTraining); }
        }
        public BindableCollection<ExcerciseTrainingModel> ThisTraining
        {
            get { return training; }
            set { training = value; NotifyOfPropertyChange(() => ThisTraining); }
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

        public WorkoutViewModel(IDBProcessor processor)
        {
            Processor = processor;



            //Excercise = converter.ConvertListE(pull.PullExcerciseNames());

        }

        public async Task OnInitilize()
        {
            ListConverter converter = new ListConverter();
            training = new BindableCollection<ExcerciseTrainingModel>();
            Excercise = converter.ConvertListE(await Processor.GetExcerciseName());
        }

        public void Add()
        {
            ThisTraining.Add(new ExcerciseTrainingModel() { Name = SelectedItem.Name }); ;
        }

        public void Delete()
        {
            training.Clear();
            SelectedItem = null;
            Processor.DeleteWorkout(Processor.GetWorkoutID());
            //dataFlow.DeletingWorkout(DataSql.GetLastWorkoutID());

            _endOfWorkout?.Invoke(this, this);
        }

        public void Finish()
        {


            ConvertExcercise convert = new ConvertExcercise();
            Processor.InsertWorkoutWithExcercise(convert.CollectionToList(ThisTraining));
            //flow.TransferingEntireWorkout(convert.CollectionToList(ThisTraining));

            ThisTraining.Clear();
            _endOfWorkout?.Invoke(this, this);
        }


    }
}
