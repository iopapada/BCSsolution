using BCSsolution.organization.model;
using System.Windows.Controls;

namespace BCSsolution.organization.view
{
    /// <summary>
    /// Interaction logic for PageMaterials.xaml
    /// </summary>
    public partial class PageMaterials : Page
    {
        public PageMaterials()
        {
            InitializeComponent();
            LoadMaterials();
        }

        private void LoadMaterials()
        {
            MaterialRepository materialVM = new MaterialRepository();
            var materials = materialVM.FindAll();
            dgMaterials.ItemsSource = materials;
        }
    }
}
