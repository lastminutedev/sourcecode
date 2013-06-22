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

namespace SecurityApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : MySecurityWindow
    {
        public MainWindow()
        {
            InitializeComponent();

            this.SecurityDataController.SecurityState = SecurityState.EditMode;
        }

        private void OnButtonSwitchSecurityModeClick(object sender, RoutedEventArgs e)
        {
            if (this.SecurityDataController == null)
            {
                return;
            }

            if (this.SecurityDataController.IsReadOnly == true)
            {
                this.SecurityDataController.TrySwitchToEditMode();
            }
            else
            {
                this.SecurityDataController.SwitchToReadOnlyMode();
            }
        }
    }
}
