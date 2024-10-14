using child13_AI.ViewModels;
using child13_AI.Views;
using System;
using System.Windows;

namespace child13_AI
{
    internal partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs inStartupEventArgs)
        {
            base.OnStartup(inStartupEventArgs);

            new MainWindow(new ViewModelOfMainWindow()).ShowDialog();
        }
    }
}