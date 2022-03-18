using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymAppUI.ViewModels
{
    public class ShellViewModel : Conductor<object>, IShellViewModel
    {
        

        private readonly IWorkoutViewModel _workoutView;
        private readonly IAddViewModel _addView;
        private readonly IHistoryViewModel _historyView;

        private bool canAdd = true;
        private bool CanWorkout = false;

        public bool CanWorkoutbtn
        {
            get { return CanWorkout; }
            set { CanWorkout = value; NotifyOfPropertyChange(() => CanWorkoutbtn); }
        }
        public bool CanAddbtn
        {
            get { return canAdd; }
            set { canAdd = value; NotifyOfPropertyChange(() => CanAddbtn); }
        }



        public ShellViewModel(IWorkoutViewModel workoutView, IAddViewModel addView, IHistoryViewModel historyView)
        {
            _workoutView = workoutView;
            _addView = addView;
            _historyView = historyView;
            Wireup();
        }

        private void Wireup()
        {
            _addView._addEvent += _addView__addEvent;
            _workoutView._endOfWorkout += _workoutView__endOfWorkout;
        }
        private void _workoutView__endOfWorkout(object sender, WorkoutViewModel e)
        {
            Homebtn();
            CanAddbtn = true;
            CanWorkoutbtn = false;
        }
        private void _addView__addEvent(object sender, EventArgs e)
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
            
            ActivateItemAsync(_addView);
        }

       

        public void Historybtn()
        {
            
            ActivateItemAsync(_historyView);
            _historyView.OnInitilize();
        }

        public void Workoutbtn()
        {
           
            ActivateItemAsync(_workoutView);
            _workoutView.OnInitilize();
        }
    }
}
