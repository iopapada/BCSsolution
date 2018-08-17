using BCSsolution.organization.model;
using BCSsolution.organization.model.collection;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Media;

namespace BCSsolution.organization.view
{
    /// <summary>
    /// Interaction logic for PageSuppliers.xaml
    /// </summary>
    public partial class PageSuppliers : Page
    {
        SupplierRepository supRepo;
        private EcObservableCollection<SupplierView> suppliers;

        public PageSuppliers(){
            InitializeComponent();
            supRepo = new SupplierRepository();

            suppliers = new EcObservableCollection<SupplierView>();
            foreach (Supplier c in supRepo.FindAll())
                suppliers.Add(new SupplierView(c));
            
            suppliers.CollectionChanged += new NotifyCollectionChangedEventHandler(suppliers_CollectionChanged);
            suppliers.ItemChanged += new EcObservableCollection<SupplierView>.EcObservableCollectionItemChangedEventHandler(suppliers_ItemChanged);

            dgSuppliers.ItemsSource = suppliers;
            dgSuppliers.ItemContainerGenerator.ItemsChanged += ItemContainerGenerator_ItemsChanged;
        }
        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {

        }
        private void btnDel_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                MessageBoxResult result = MessageBox.Show("Are you sure you want to delete this supplier ?");
                if (result == MessageBoxResult.OK)
                {
                    SupplierView delSupplier = dgSuppliers.SelectedItem as SupplierView;
                    suppliers.Remove(delSupplier);
                }
            }
            catch (Exception ex)
            {
                ((MainWindow)Application.Current.MainWindow).AddExceptionTextMsg(ex.ToString());
            }
        }
        private async void btnPrintLbl_Click(object sender, RoutedEventArgs e)
        {
            string IP = "192.168.1.4";
            int port = 9100;
            string fileName = "D:\\Downloads\\x.x";

            IPEndPoint printerIP = null;
            Socket socket = null;
            try
            {
                if (printerIP == null)
                {
                    /* IP is a string property for the printer's IP address. */
                    /* 9100 is the common port of all our Zebra printers. */
                    printerIP = new IPEndPoint(IPAddress.Parse(IP), port);
                }

                socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream,ProtocolType.Tcp);
                socket.Connect(printerIP);
                socket.SendFile(fileName);
            }
            catch (Exception ex)
            {
                ((MainWindow)Application.Current.MainWindow).AddExceptionTextMsg(ex.ToString());
            }
            finally
            {
                socket.Shutdown(SocketShutdown.Both);
                socket.Close();
            }
        }
        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                SupplierView supAdditionOb = new SupplierView { FirstName = textBoxFirstName.Text.ToString(), LastName = textBoxLastName.Text.ToString(), Grs = textBoxGRS.Text.ToString(), Ids = textBoxIDS.Text.ToString(), Email = textBoxEmail.Text.ToString(), Tel1 = textBoxTelephone.Text.ToString(), Mob1 = textBoxMobile.Text.ToString(), LblPrintText = textBoxLabelText.Text.ToString() };
                suppliers.Add(supAdditionOb);
                ((MainWindow)Application.Current.MainWindow).AddTextMsg("Supplier added succesful");
                btnClear_Click(null, null);
            }
            catch (Exception ex)
            {
                ((MainWindow)Application.Current.MainWindow).AddExceptionTextMsg(ex.ToString());
            }
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
            this.textBoxLabelText.Clear();
        }

        void suppliers_ItemChanged(object sender, EcObservableCollectionItemChangedEventArgs<SupplierView> args)
        {
            supRepo.SaveOrUpdate(args.Item.InnerSupplier);
        }

        void suppliers_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            switch (e.Action)
            {
                case NotifyCollectionChangedAction.Remove:
                    foreach (SupplierView c in e.OldItems)
                        supRepo.Delete(c.InnerSupplier);
                    break;
                case NotifyCollectionChangedAction.Add:
                    foreach (SupplierView c in e.NewItems)
                        supRepo.SaveOrUpdate(c.InnerSupplier);
                    break;
                default:
                    foreach (SupplierView c in e.OldItems)
                        supRepo.SaveOrUpdate(c.InnerSupplier);
                    break;
            }
        }
        void DataGrid_LoadingRow(object sender, DataGridRowEventArgs e)
        {
            e.Row.Header = (e.Row.GetIndex() + 1).ToString();
        }
        private void ItemContainerGenerator_ItemsChanged(object sender, ItemsChangedEventArgs e)
        {
            IEnumerable<DataGridRow> rows = FindVisualChildren<DataGridRow>(dgSuppliers as DependencyObject);
            foreach (DataGridRow row in rows)
            {
                row.Header = (row.GetIndex() + 1).ToString();
            }
        }
        private static IEnumerable<T> FindVisualChildren<T>(DependencyObject dependencyObject)where T : DependencyObject
        {
            if (dependencyObject != null)
            {
                for (int i = 0; i < VisualTreeHelper.GetChildrenCount(dependencyObject); i++)
                {
                    DependencyObject child = VisualTreeHelper.GetChild(dependencyObject, i);
                    if (child != null && child is T)
                    {
                        yield return (T)child;
                    }

                    foreach (T childOfChild in FindVisualChildren<T>(child))
                    {
                        yield return childOfChild;
                    }
                }
            }
        }
    }
}
