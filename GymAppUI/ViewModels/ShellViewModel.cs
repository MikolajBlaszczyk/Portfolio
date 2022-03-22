using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess;
using Serilog;

namespace GymAppUI.ViewModels
{
    public class ShellViewModel : Conductor<object>, IShellViewModel
    {
        //DI
        private readonly IWorkoutViewModel _workoutView;
        private readonly IAddViewModel _addView;
        private readonly IHistoryViewModel _historyView;
        private readonly IDateViewModel _dateView;
        //to view
        private bool canAdd = true;
        private bool CanWorkout = false;
        private bool canHistory = true;
        public bool CanHistorybtn
        {
            get { return canHistory; }
            set { canHistory = value; NotifyOfPropertyChange(() => CanHistorybtn); Log.Logger.Information("CanHistorybtn property changed"); }
        }
        public bool CanWorkoutbtn
        {
            get { return CanWorkout; }
            set { CanWorkout = value; NotifyOfPropertyChange(() => CanWorkoutbtn); Log.Logger.Information("CanWorkoutbtn property changed"); }
        }
        public bool CanAddbtn
        {
            get { return canAdd; }
            set { canAdd = value; NotifyOfPropertyChange(() => CanAddbtn); Log.Logger.Information("CanAddbtn property changed"); }
        }
        //ctor
        public ShellViewModel(IWorkoutViewModel workoutView, IAddViewModel addView, IHistoryViewModel historyView, IDateViewModel dateView, ILogger logger)
        {
            _workoutView = workoutView;
            _addView = addView;
            _historyView = historyView;
            _dateView = dateView;
            Wireup();
            Log.Logger.Information("Application started without interference");
        }
        //wire up events
        private void Wireup()
        {
            _addView._addEvent += _addView__addEvent;
            _addView._datePicker += _addView__datePicker;
            _dateView.datePickedEvent += _dateView_datePickedEvent;
            _workoutView._endOfWorkout += _workoutView__endOfWorkout;

        }
        private void _dateView_datePickedEvent(object sender, DateTime e)
        {
            _addView._SelectedDate = e;
            ActivateItemAsync(_addView);
            Log.Logger.Information("Date was Picked");
        }

        //events
        private void _addView__datePicker(object sender, EventArgs e)
        {
            ActivateItemAsync(_dateView);
            Log.Logger.Information("Date Picker Opened");
        }
        private void _addView__addEvent(object sender, string e)
        {
            CanAddbtn = false;
            CanWorkoutbtn = true;
            _historyView.Saved = e;
            Workoutbtn();
            Log.Logger.Information("Workout was added properly");
        }
        private void _workoutView__endOfWorkout(object sender, WorkoutViewModel e)
        {
            Homebtn();
            CanAddbtn = true;
            CanWorkoutbtn = false;
            _historyView.Saved = null;
            Log.Logger.Information("End of workout");
        }
        
        //buttons
        public void Homebtn()
        {
            CanHistorybtn = true;
            ActiveItem = null;
            Log.Logger.Information("Home");
        }
        public void Addbtn()
        {
            CanHistorybtn = true;
            ActivateItemAsync(_addView);
            Log.Logger.Information("Add button");
        }
        public void Historybtn()
        {
            CanHistorybtn = false;
            ActivateItemAsync(_historyView);
            _historyView.OnInitilize();
            Log.Logger.Information("History button");
        }
        public void Workoutbtn()
        {
            CanHistorybtn = true;
            ActivateItemAsync(_workoutView);
            _workoutView.OnInitilize();
            Log.Logger.Information("Workout button");
        }
    }
}
