using BCSsolution.organization.view;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Reflection;
using BCSsolution.onStart;
using BCSsolution.onStart.view;
using System.Threading;

namespace BCSsolution
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static string version = "Version: " + Assembly.GetExecutingAssembly().GetName().Version.ToString();
        public MainWindow()
        {
            InitializeComponent();
            this.WindowStartupLocation = WindowStartupLocation.CenterScreen;
        }
        //Help buttons
        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            if(mainFrame.NavigationService.CanGoBack)
           mainFrame.NavigationService.GoBack();
        }

        private void btnNext_Click(object sender, RoutedEventArgs e)
        {
            if (mainFrame.NavigationService.CanGoForward)
                mainFrame.NavigationService.GoForward();
        }

        private void btnRefresh_Click(object sender, RoutedEventArgs e)
        {
            
        }
        //Organize buttons
        private void btnSuppliers_Click(object sender, RoutedEventArgs e)
        {
            mainFrame.NavigationService.Navigate(new PageSuppliers());
        }
        private void btnMaterial_Click(object sender, RoutedEventArgs e)
        {
            mainFrame.NavigationService.Navigate(new PageMaterials());
        }
        private void btnCustomers_Click(object sender, RoutedEventArgs e)
        {
            mainFrame.NavigationService.Navigate(new PageCustomers());
        }

        private void btnReceipt_Click(object sender, RoutedEventArgs e)
        {
            mainFrame.NavigationService.Navigate(new PageReceipt());
        }

        private void btnTace_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnPlan_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnOrganizeSettings_Click(object sender, RoutedEventArgs e)
        {

        }
        //Automations buttons
        private void btnHome_Click(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void btnWeightMonitor_Click(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();
        }
        //Security buttons

        //MenuItems buttons
        private void btnLogOff_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            LoginScreen newLoginTry = new LoginScreen();
            newLoginTry.Show();
        }

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            App.Current.Shutdown();
        }

        //Static help functions
        #region
        public static void AddTextMsg(string text) {
                
        }
        public void AddWarningTextMsg(string text) {

        }
        public void AddExceptionTextMsg(string text) {

        }
        public void ClearTextBlock() {

        }
        #endregion
    }
}
