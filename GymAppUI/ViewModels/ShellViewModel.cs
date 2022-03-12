using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymAppUI.ViewModels
{
    class ShellViewModel:Conductor<object>
    {
        public event EventHandler newWorkoutEvent;

        WorkoutViewModel _workoutView;
 

        private bool canAdd = true;
        private bool CanWorkout = false;

        public bool CanWorkoutbtn
        {
            get { return CanWorkout; }
            set { CanWorkout = value;NotifyOfPropertyChange(() => CanWorkoutbtn); }
        }
        public bool CanAddbtn
        {
            get { return canAdd; }
            set { canAdd = value;NotifyOfPropertyChange(()=>CanAddbtn); }
        }



        public ShellViewModel(WorkoutViewModel workoutView)
        {
            _workoutView = workoutView;
            

            Wireup();
        }

        private void Wireup()
        {
            newWorkoutEvent += ShellViewModel_NewWorkoutEvent;
            _workoutView._endOfWorkout += _workoutView__endOfWorkout;
        }

        private void _workoutView__endOfWorkout(object sender, WorkoutViewModel e)
        {
            Homebtn();
            CanAddbtn = true;
            CanWorkoutbtn = false;
        }

        private void ShellViewModel_NewWorkoutEvent(object sender, EventArgs e)
        {
            CanAddbtn = false;
            CanWorkoutbtn = true;
            Workoutbtn();
        }



        public void Homebtn()
        {
            ActiveItem = null;
        }

        public void Addbtn()
        {
            var view = new AddViewModel(newWorkoutEvent);
            ActivateItemAsync(view);
        }

        public void Historybtn()
        {
            var view = new HistoryViewModel();
            ActivateItemAsync(view);
        }

        public void Workoutbtn()
        {    
            ActivateItemAsync(_workoutView);
        }
    }
}
