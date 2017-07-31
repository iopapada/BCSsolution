using BCSsolution.organization.model;
using BCSsolution.organization.viewmodel;
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

namespace BCSsolution.organization.view
{
    /// <summary>
    /// Interaction logic for PageSuppliers.xaml
    /// </summary>
    public partial class PageSuppliers : Page
    {
        public PageSuppliers(){
            InitializeComponent();
            LoadSuppliers();
        }

        private void LoadSuppliers() {
            SupplierRepo supplierVM = new SupplierRepo();
            var suppliers = supplierVM.FindAll();
            dgSuppliers.ItemsSource = suppliers;
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnDel_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnPrintLbl_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            this.textBoxFirstName.Clear();
            this.textBoxLastName.Clear();
            this.textBoxGRS.Clear();
            this.textBoxIDS.Clear();
            this.textBoxEmail.Clear();
            this.textBoxTelephone.Clear();
            this.textBoxMobile.Clear();
        }
    }
}
