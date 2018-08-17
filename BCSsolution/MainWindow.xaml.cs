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
using BCSsolution.automation.view;

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
            this.KeyDown += new KeyEventHandler(OnKeyDown);
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
            mainFrame.NavigationService.Navigate(new PageTrace());
        }
        private void btnPlan_Click(object sender, RoutedEventArgs e)
        {
            mainFrame.NavigationService.Navigate(new PagePlan());
        }
        private void btnOrganizeSettings_Click(object sender, RoutedEventArgs e)
        {
            mainFrame.NavigationService.Navigate(new PageSettings());
        }
        //Automations buttons
        private void btnHome_Click(object sender, RoutedEventArgs e)
        {
            mainFrame.NavigationService.Navigate(new PageHomeControl());
        }
        private void btnLockMonitor_Click(object sender, RoutedEventArgs e)
        {
            mainFrame.NavigationService.Navigate(new PageLockerControl());
        }
        private void btnWeightMonitor_Click(object sender, RoutedEventArgs e)
        {
            mainFrame.NavigationService.Navigate(new PageWScale());
        }
        private void btnTempMonitor_Click(object sender, RoutedEventArgs e)
        {
            mainFrame.NavigationService.Navigate(new PageTemperature());
        }
        private void btnAlerts_Click(object sender, RoutedEventArgs e)
        {
            mainFrame.NavigationService.Navigate(new PageAlerts());
        }
        private void btnAutomationSettings_Click(object sender, RoutedEventArgs e)
        {
            mainFrame.NavigationService.Navigate(new PageAutomationSettings());
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
        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            mainFrame.NavigationService.Navigate(new PageUserProfile());
        }
        //Static help messages functions
        #region
        public void AddTextMsg(string text) {
            ((MainWindow)Application.Current.MainWindow).txtMessages.Text += "\n" + text;
        }
        public void AddWarningTextMsg(string text) {

        }
        public void AddExceptionTextMsg(string text) {
            ((MainWindow)Application.Current.MainWindow).txtMessages.Text += "\n" + text;
        }
        public void ClearTextBlock() {

        }

        #endregion

        //Key event handlers
        private void OnKeyDown(object sender, KeyEventArgs e)
        {
            if ((Keyboard.IsKeyDown(Key.RightCtrl) || Keyboard.IsKeyDown(Key.RightCtrl)) && e.Key == Key.Back)
                btnBack_Click(sender, e);
            else if ((Keyboard.IsKeyDown(Key.RightCtrl) || Keyboard.IsKeyDown(Key.RightCtrl)) && e.Key == Key.Enter)
                btnNext_Click(sender, e);
            else if (e.Key == Key.F5)
                btnRefresh_Click(sender, e);
            //else if (e.Key == Key.Escape)
        }
    }
}
