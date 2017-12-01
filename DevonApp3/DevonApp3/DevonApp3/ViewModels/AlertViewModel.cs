using System;
using Prism;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using DevonApp3.Infrastructure;

namespace DevonApp3.ViewModels
{
    public class AlertViewModel : AppMapViewModelBase
    {


        public AlertViewModel(INavigationService navigationService) : base (navigationService)
        {
        }
    }
}
