using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace WpfApp1.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        
        public ObservableCollection<Process> processes { get; set; } = new ObservableCollection<Process>(Process.GetProcesses());



        private string Start;
        private Process slcprocess;



        public string start
        {
            get => Start;
            set
            {
                Start = value;
                RaisePropertyChanged();
            }
        }

        public Process Slcprocess
        {
            get => slcprocess; set
            {
                slcprocess = value;
                RaisePropertyChanged();
            }
        }


        public RelayCommand EndCommand
        {
            get => new RelayCommand
            (
                () =>
                {
                    try
                    {
                        if (Slcprocess != null)
                        {
                            foreach (var process in Process.GetProcesses())
                            {
                                if (process.Id == (Slcprocess as Process).Id) { process.Kill(); }
                            }
                            processes.Clear();
                            foreach (var process in Process.GetProcesses()) { processes.Add(process); }
                        }
                    }
                    catch (Exception ex) { MessageBox.Show(ex.Message); }
                }
            );
        }


        public RelayCommand StartCommand
        {
            get => new RelayCommand
            (
                () =>
                {
                    try
                    {
                        if (start != null)
                        {
                            Process.Start(start);
                            processes.Clear();
                            foreach (var process in Process.GetProcesses()) { processes.Add(process); }
                        }
                    }
                    catch (Exception ex) { MessageBox.Show(ex.Message); }
                }
            );
        }

       
    }
}
