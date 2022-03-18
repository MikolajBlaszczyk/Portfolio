using Caliburn.Micro;
using DataAccess;
using GymAppUI.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace GymAppUI
{
    class Bootstrapper:BootstrapperBase
    {
        private SimpleContainer _container = new SimpleContainer();

        public Bootstrapper()
        {
            Initialize();
        }

        protected override void Configure()
        {
            _container.Instance(_container);

            _container
                .Singleton<IWindowManager, WindowManager>()
                .Singleton<IEventAggregator, EventAggregator>();

            _container.PerRequest<IDBProcessor, DataProcessor>();
            _container.PerRequest<ISqlDataAccess, SqlDataAccess>();
            _container.PerRequest<IShellViewModel, ShellViewModel>();
            _container.PerRequest<IAddViewModel, AddViewModel>();
            _container.PerRequest<IHistoryViewModel, HistoryViewModel>();
            _container.PerRequest<IWorkoutViewModel, WorkoutViewModel>();

            GetType().Assembly.GetTypes()
               .Where(type => type.IsClass)
               .Where(type => type.Name.EndsWith("ViewModel"))
               .ToList()
               .ForEach(viewModelType => _container.RegisterPerRequest(viewModelType, viewModelType.ToString(), viewModelType));
        }
        

        protected override void OnStartup(object sender, StartupEventArgs e)
        {
            DisplayRootViewFor <IShellViewModel>();
        }

        //Copy paste dependency Incjection
        protected override object GetInstance(Type service, string key)
        {
            return _container.GetInstance(service, key);
        }

        protected override IEnumerable<object> GetAllInstances(Type service)
        {
            return _container.GetAllInstances(service);
        }

        protected override void BuildUp(object instance)
        {
            _container.BuildUp(instance);
        }
    }
        

}
