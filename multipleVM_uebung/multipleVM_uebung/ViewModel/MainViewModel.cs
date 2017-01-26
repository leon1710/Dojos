using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using GalaSoft.MvvmLight.Ioc;
using System.Windows.Navigation;

namespace multipleVM_uebung.ViewModel
{
    
    public class MainViewModel : ViewModelBase
    {
        private ViewModelBase currentDetailView;
        private NavigationService navService = SimpleIoc.Default.GetInstance<NavigationService>();

        public RelayCommand AddCmdClicked { get; set; }
        public RelayCommand SearchCmdClicked { get; set; }

        public ViewModelBase CurrentDetailView
        {
            get
            {
                return currentDetailView;
            }

            set
            {
                currentDetailView = value;
                RaisePropertyChanged();
            }
        }
        public MainViewModel()
        {
            AddCmdClicked = new RelayCommand(
                () => { CurrentDetailView = navService.NavigateTo("Add"); });
            SearchCmdClicked = new RelayCommand(
                () => { CurrentDetailView = navService.NavigateTo("Search"); });
        }
    }
}