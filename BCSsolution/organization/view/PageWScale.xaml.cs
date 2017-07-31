using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace BCSsolution.organization.view
{
    /// <summary>
    /// Interaction logic for PageWScale.xaml
    /// </summary>
    public partial class PageWScale : Page
    {
        private UdpClient udpClient;
        private IPEndPoint remoteIpEndPoint;

        public PageWScale()
        {
            InitializeComponent();
            try
            {
                udpClient = new UdpClient();
                remoteIpEndPoint = new IPEndPoint(IPAddress.Any, 21200);
                udpClient.Client.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.ReuseAddress, true);
                udpClient.Client.Bind(remoteIpEndPoint);
                UdpReceiveResult();

                
            }
            catch (Exception e)
            {
                ((MainWindow)Application.Current.MainWindow).AddExceptionTextMsg(e.ToString());
            }
        }
        private async void UdpReceiveResult()
        {
            int n = 0;
            try
            {
                //Task.Run(async () =>
                //{
                using (udpClient)
                {
                    while (true)
                    {
                        var recieveArgs = new SocketAsyncEventArgs();
                        var receivedResults = await udpClient.ReceiveAsync();
                        this.Dispatcher.Invoke(() =>
                        {
                            this.txtWeight.Content = Encoding.UTF8.GetString(receivedResults.Buffer);
                            if (n == 0) { ((MainWindow)Application.Current.MainWindow).AddTextMsg("Receive values from scale: " + receivedResults.RemoteEndPoint.Address.ToString()); n = 1; }
                        });

                        //if (recieveArgs.BytesTransferred == 0)
                        //{
                        //    this.Dispatcher.Invoke(() => {
                        //        this.txtWeight.Content = "0.00";
                        //    });
                        //}
                    }
                }
                //});
            }
            catch (Exception e)
            {
                ((MainWindow)Application.Current.MainWindow).AddExceptionTextMsg(e.ToString());
            }
        }
        private void Page_Unloaded(object sender, RoutedEventArgs e)
        {
            udpClient.Client.Close();
            udpClient.Client.Dispose();
            udpClient.Close();
        }
    }
}
