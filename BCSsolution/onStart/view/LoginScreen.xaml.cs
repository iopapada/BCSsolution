using BCSsolution.onStart.model;
using BCSsolution.onStart.viewmodel;
using System;
using System.ComponentModel;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace BCSsolution.onStart.view
{
    public partial class LoginScreen : Window
    {
        //TODO:
        UserRepository _ur = new UserRepository(); 

        public LoginScreen()
        {
            InitializeComponent();
            this.lblVersioning.Content = MainWindow.version;
            FocusManager.SetFocusedElement(LoginWindow, textBoxUsername);
            LoadSettings();
        }

        private void LoadSettings()
        {
            if (Properties.Settings.Default.Lang.Equals("GR"))
                CBoxLang.SelectedItem = CBoxLang.Items[0] as ComboBoxItem;
            else
                CBoxLang.SelectedItem = CBoxLang.Items[1] as ComboBoxItem;
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            this.lblbWrongCredentialsMsg.Visibility = Visibility.Hidden;
            User currentUser = _ur.AuthenticateUser(textBoxUsername.Text, UserRepository.CalculateHash(textBoxPswd.Password, textBoxUsername.Text));
            if (currentUser!=null)
            {
                App.Current.MainWindow.Show();
                login_OnClosing(sender, null);
                //Create User Identity
                UserPrincipal userPrincipal = Thread.CurrentPrincipal as UserPrincipal;
                if (userPrincipal == null)
                    throw new ArgumentException("The application's default thread principal must be set to a UserPrincipal object on startup.");
                userPrincipal.Identity = new UserIdentity(currentUser.GetFullName(), currentUser.UserMail, new string[] { currentUser.UserRole.ToString() });
                //Show Identity info on MainWindow.
                ((MainWindow)Application.Current.MainWindow).lblName.Content = Thread.CurrentPrincipal.Identity.Name;
                ((MainWindow)Application.Current.MainWindow).lblRole.Content = '('+currentUser.UserRole.ToString()+')';
                //Welcome msg
                ((MainWindow)Application.Current.MainWindow).txtMessages.Text = "Welcome "+currentUser.UserName;
            }
            else
                this.lblbWrongCredentialsMsg.Visibility = Visibility.Visible;
        }

        public void login_OnClosing(object sender, CancelEventArgs e)
        {
            Button b = sender as Button;
            if (b != null && b.Content.Equals("Login"))
                this.Hide();
            else
                App.Current.Shutdown();
        }

        private void CBoxLang_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBoxItem temp1 = CBoxLang.SelectedItem as ComboBoxItem;
            var culture = new System.Globalization.CultureInfo("en-US");
            switch (temp1.Name)
            {
                case "GR":
                    culture = new System.Globalization.CultureInfo("el-GR");
                    break;
                default:
                    culture = new System.Globalization.CultureInfo("en-US");
                    break;

            }
            Properties.Settings.Default["Lang"] = temp1.Name;

            //ApplicationLanguages.PrimaryLanguageOverride = culture.Name;
            //Windows.ApplicationModel.Resources.Core.ResourceContext.GetForCurrentView().Reset();
            //Windows.ApplicationModel.Resources.Core.ResourceContext.GetForViewIndependentUse().Reset();
            //Reload frame
            this.UpdateLayout();
            //var _Frame = Window.Current.Content as Frame;
            //_Frame.Navigate(_Frame.Content.GetType());
            //_Frame.GoBack();
        }
    }
}
