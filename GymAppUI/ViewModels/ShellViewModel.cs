using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess;

namespace GymAppUI.ViewModels
{
    public class ShellViewModel : Conductor<object>, IShellViewModel
    {
        
        //DI
        private readonly IWorkoutViewModel _workoutView;
        private readonly IAddViewModel _addView;
        private readonly IHistoryViewModel _historyView;
        //to view
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
        //ctor
        public ShellViewModel(IWorkoutViewModel workoutView, IAddViewModel addView, IHistoryViewModel historyView)
        {
            _workoutView = workoutView;
            _addView = addView;
            _historyView = historyView;
            Wireup();
        }
        //wire up events
        private void Wireup()
        {
            _addView._addEvent += _addView__addEvent; 
            _workoutView._endOfWorkout += _workoutView__endOfWorkout;
        }

        private void _addView__addEvent(object sender, string e)
        {
            CanAddbtn = false;
            CanWorkoutbtn = true;
            _historyView.Saved = e;
            Workoutbtn();
        }

        //events
        private void _workoutView__endOfWorkout(object sender, WorkoutViewModel e)
        {
            Homebtn();
            CanAddbtn = true;
            CanWorkoutbtn = false;
            _historyView.Saved = null;
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
