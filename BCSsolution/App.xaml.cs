using BCSsolution.onStart.viewmodel;
using BCSsolution.onStart.view;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Net.Sockets;
using System.Net;

namespace BCSsolution
{
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            IntroScreenUtil.Splash = new onStart.view.IntroScreen();
            IntroScreenUtil.ShowSplash();

            //Load your main windows but don't show it yet  
            //base.OnStartup(e);
            MainWindow mainWindow = new MainWindow();
            //set application main window;
            this.MainWindow = mainWindow;

            //Create a custom principal with an anonymous identity at startup
            UserPrincipal userPrincipal = new UserPrincipal();
            AppDomain.CurrentDomain.SetThreadPrincipal(userPrincipal);

            var startupTask = new Task(() =>
            {
                //Load plugins in non-UI thread - may be time consuming
                for (int i = 0; i < 2; i++)
                {
                    Thread.Sleep(1000);
                    //set custom message on screen
                    IntroScreenUtil.Splash.Dispatcher.BeginInvoke((Action)(() => IntroScreenUtil.Splash.setLblLoading(IntroScreenUtil.Splash.getLblLoading() + ".")));
                }
            });

            //when plugin loading finished, show login window
            startupTask.ContinueWith(t =>
            {
                LoginScreen loginWindow = new LoginScreen();

                //when login window is loaded close splash screen
                loginWindow.Loaded += (sender, args) => onStart.viewmodel.IntroScreenUtil.CloseSplash();

                //and finally show it
                loginWindow.Show();
            }, TaskScheduler.FromCurrentSynchronizationContext());

            startupTask.Start();

        }
    }
}
