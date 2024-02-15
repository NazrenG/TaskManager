using System.Collections.Generic;
using System.Linq;
using System.Diagnostics;
using TaskManager.Services;
using System.Windows;
using System.Collections.ObjectModel;
using System.Windows.Input;
using TaskManager.Command;
using System.Threading;
using System.Windows.Threading;
using System;

namespace TaskManager
{
    public class MainWindoww:NotificationServices
    {
        private Process select;
        private string name;
        private List<string> processList;
        private static System.Timers.Timer aTimer;

        public ObservableCollection<Process> Processes { get; } = new ObservableCollection<Process>();
        public Process selectedItem { get => select; set { select = value; OnPropertyChanged(); } }
        public string Name { get => name; set { name = value; OnPropertyChanged(); } }
        public List<string> ProcessList { get => processList; set { processList = value; OnPropertyChanged(); } }

        public ICommand Create { get; set; }    
        public ICommand End { get; set; }
        public ICommand AddBlackList { get; set; }

        public List<string> BlackList;

        public MainWindoww()
        {

            Create = new RelayCommand(CreateProcess, CanCreateProcess);
            End = new RelayCommand(EndProcess, CanEndProcess);
            AddBlackList = new RelayCommand(AddList, CanAddList);

            BlackList = new List<string>();

            ProcessList = new List<string>()
            {
                new("mspaint"),
                new("Notepad"),
                new("C:\\Program Files\\Google\\Chrome\\Application\\chrome.exe"),
                new("C:\\WINDOWS\\system32\\cmd.exe"),
                new("C:\\Program Files (x86)\\Microsoft\\Edge\\Application\\msedge.exe"),
                new("C:\\Program Files\\Microsoft Visual Studio\\2022\\Community\\Common7\\IDE\\devenv.exe"),
            };

            DispatcherTimer timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(3);
            timer.Tick += CheckBlackList;
            timer.Start();


            var processes = Process.GetProcesses().OrderBy(p => p.ProcessName );
            foreach (var process in processes)
            {
                Processes.Add(process);
            }
            
        }

        private void CheckBlackList(object? sender, EventArgs e)
        {  
            Process processs = new Process();
           

            foreach (var process in BlackList)
            {

                var proc = Process.GetProcessesByName(process) ;
               foreach( var item in proc)
                {
                    item.Kill();
                }
            }
        }



        //Add BlackList
        private bool CanAddList(object? obj)
        {
            if (selectedItem == null) return false;
            return true;
        }

        private void AddList(object? obj)
        {
            bool check = true;
            if (BlackList != null)
            {
                foreach (var process in BlackList)
                {
                    if (process == selectedItem.ProcessName)
                    {
                        MessageBox.Show("This process was added in list!");
                        check = false;
                        break;
                    }
                }
                if (check)
                {
                    BlackList.Add(selectedItem.ProcessName);
                    MessageBox.Show("Process Add BlackList!");
                }
            }
        }
        //End Process
        private bool CanEndProcess(object? obj)
        {
            if (selectedItem == null) return false;
            return true;
        }

        private void EndProcess(object? obj)
        {
            var proc =Process.GetProcessById( selectedItem.Id);
            proc.Kill();
            
            MainWindow window = new MainWindow();
            window.ShowDialog();

        }
        //Create new Process
        private bool CanCreateProcess(object? obj)
        {
            return true;
        }

        private void CreateProcess(object? obj)
        {
           Process.Start(Name);


            MainWindow newWindow = new MainWindow();
            var windoww=obj as MainWindow;
            windoww.Close();    
            Application.Current.MainWindow = newWindow;
            newWindow.Show();
        }
    }
}
