using System;
using System.Windows;

namespace BCSsolution.onStart.view
{

    public partial class IntroScreen : Window
    {
        public IntroScreen()
        {
            InitializeComponent();
            this.lblVersioning.Content = MainWindow.version;
            dbManager.NhibernateSessionManager.initDB();
        }

        public void setLblLoading(String temp) { this.lblLoading.Content = temp; }
        public String getLblLoading() { return this.lblLoading.Content.ToString(); }
    }
}
