using System;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;

namespace XF.MasterDetailPage.Prism.ViewModels
{
    public class ViewAViewModel : BindableBase
    {
        private string _title;

        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }

        private DelegateCommand _navigateCommand;
        private readonly INavigationService navigationService;

        public DelegateCommand NavigateCommand =>
            _navigateCommand ?? (_navigateCommand = new DelegateCommand(ExecuteNavigateCommand));

        public ViewAViewModel(INavigationService navigationService)
        {
            Title = "ViewA";
            this.navigationService = navigationService;
        }

        ~ViewAViewModel()
        {
            Console.WriteLine(this + " DESTRUCTOR");
        }

        async void ExecuteNavigateCommand()
        {
            await navigationService.NavigateAsync("ViewB");
        }
    }
}
