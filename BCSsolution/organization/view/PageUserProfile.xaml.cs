using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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
    /// Interaction logic for PageUserProfile.xaml
    /// </summary>
    public partial class PageUserProfile : Page
    {
        public PageUserProfile()
        {
            InitializeComponent();
            lblTitle.Content = Thread.CurrentPrincipal.Identity.Name + " Profile";
        }
    }
}
