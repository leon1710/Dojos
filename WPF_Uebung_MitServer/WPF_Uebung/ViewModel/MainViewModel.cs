using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using System.Collections.ObjectModel;
using WPF_Uebung.ViewModels;
using System;
using System.Windows.Threading;
using System.Threading;

namespace WPF_Uebung.ViewModel
{
    /// <summary>
    /// This class contains properties that the main View can data bind to.
    /// <para>
    /// Use the <strong>mvvminpc</strong> snippet to add bindable properties to this ViewModel.
    /// </para>
    /// <para>
    /// You can also use Blend to data bind with the tool's support.
    /// </para>
    /// <para>
    /// See http://www.galasoft.ch/mvvm
    /// </para>
    /// </summary>
    public class MainViewModel : ViewModelBase
    {
        private ObservableCollection<TruckVM> waitingTrucks = new ObservableCollection<TruckVM>();
        private ObservableCollection<TruckVM> readyTrucks = new ObservableCollection<TruckVM>();

        private TruckVM selectedWaitingTruck;
        private TruckVM selectedReadyTruck;


        private RelayCommand deleteBtnClicked;
        private RelayCommand startGenerationBtnClicked;
        private RelayCommand stopGenerationBtnClicked;
        private RelayCommand shiftTruck;


        private Server server;


        public RelayCommand DeleteBtnClicked1
        {
            get
            {
                return deleteBtnClicked;
            }

            set
            {
                deleteBtnClicked = value;
            }
        }

        public ObservableCollection<TruckVM> WaitingTrucks
        {
            get
            {
                return waitingTrucks;
            }

            set
            {
                waitingTrucks = value; RaisePropertyChanged();
            }
        }

        public ObservableCollection<TruckVM> ReadyTrucks
        {
            get
            {
                return readyTrucks;
            }

            set
            {
                readyTrucks = value;
            }
        }

        public RelayCommand StopGenerationBtnClicked
        {
            get
            {
                return stopGenerationBtnClicked;
            }

            set
            {
                stopGenerationBtnClicked = value;
            }
        }

        public RelayCommand ShiftTruck
        {
            get
            {
                return shiftTruck;
            }

            set
            {
                shiftTruck = value;
            }
        }

        public TruckVM SelectedReadyTruck
        {
            get
            {
                return selectedReadyTruck;
            }

            set
            {
                selectedReadyTruck = value; RaisePropertyChanged();
            }
        }

        public RelayCommand StartGenerationBtnClicked
        {
            get
            {
                return startGenerationBtnClicked;
            }

            set
            {
                startGenerationBtnClicked = value;
            }
        }

        public TruckVM SelectedWaitingTruck
        {
            get
            {
                return selectedWaitingTruck;
            }

            set
            {
                selectedWaitingTruck = value;
            }
        }



        /// <summary>
        /// Initializes a new instance of the MainViewModel class.
        /// </summary>
        public MainViewModel()
        {
            StartGenerationBtnClicked = new RelayCommand(StartGeneration);
            stopGenerationBtnClicked = new RelayCommand(StopGeneration);
            shiftTruck = new RelayCommand(Shift);

            Data();

            ThreadPool.QueueUserWorkItem(new WaitCallback((object o) =>
            {
                int thread2;
                while (true)
                {
                    thread2 = Thread.CurrentThread.ManagedThreadId;
                    Data();
                    Thread.Sleep(2000);
                }
            }));

        }

        private void Shift()
        {
            readyTrucks.Add(selectedWaitingTruck);
            waitingTrucks.Remove(selectedWaitingTruck);
            selectedWaitingTruck = null;
        }

        private void StopGeneration()
        {
            throw new NotImplementedException();
        }

        private void StartGeneration()
        {
            DispatcherTimer dispatcherTimer = new DispatcherTimer();
            dispatcherTimer.Interval = new TimeSpan(0, 0, 3);
            
            Data();
        }

        private void ClearAllEntries()
        {
            waitingTrucks.Clear();
            readyTrucks.Clear();
        }

        private void Data()
        {
            int t = Thread.CurrentThread.ManagedThreadId;
            LoadVM loadtest = new LoadVM("test1", 2, 2);
            LoadVM loadtest2 = new LoadVM("test2", 3, 3);
            LoadVM loadtest3 = new LoadVM("test3", 4, 4);
            ObservableCollection<LoadVM> loadlist = new ObservableCollection<LoadVM>();
            loadlist.Add(loadtest);
            loadlist.Add(loadtest2);
            loadlist.Add(loadtest3);

            waitingTrucks.Add(new TruckVM("DemoEntry1", 1, loadlist));
            waitingTrucks.Add(new TruckVM("DemoEntry2", 3, loadlist));
            waitingTrucks.Add(new TruckVM("DemoEntry2", 5, loadlist));
        }
    }
}