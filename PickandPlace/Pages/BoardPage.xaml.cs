using FirstFloor.ModernUI.Windows;
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
using FirstFloor.ModernUI.Windows.Navigation;
using System.Windows.Shapes;
using System.Data;
using System.Threading;

namespace PickandPlace.Pages
{
    /// <summary>
    /// Interaction logic for BoardPage.xaml
    /// </summary>
    public partial class BoardPage : UserControl,  IContent
    {
        DataTable dtComponents = new DataTable();
        DataTable dtBoardInfo = new DataTable();
        DataSet dsData = new DataSet();
        DataHelpers dh = new DataHelpers();
        private PCBBuilder builder = new PCBBuilder();

        usbDevice usbController;
        kflop _kflop;
        
       

        public BoardPage()
        {
            InitializeComponent();
            SetupGridView(_dgComponents);
            
            
            App MyApplication = ((App)Application.Current);
            _kflop = MyApplication.GetKFlop();

            usbController = MyApplication.GetUSBDevice();
            
            builder.setupPCBBuilder(_kflop, usbController, dsData);
        }
       
       
        private void SetResultsLabelText(string text)
        {
           
        } 

        public void OnFragmentNavigation(FragmentNavigationEventArgs e)
        {
        }
        public void OnNavigatedFrom(NavigationEventArgs e)
        {
        }
        public void OnNavigatedTo(NavigationEventArgs e)
        {
            

        }
        public void OnNavigatingFrom(NavigatingCancelEventArgs e)
        {
        }

       

        private void bt_HomeAll_Click(object sender, RoutedEventArgs e)
        {
            _kflop.HomeAll();
        }

        private void bt_Load_Click(object sender, RoutedEventArgs e)
        {
           
            while (dsData.Tables.Count > 0)
            {
                DataTable table = dsData.Tables[0];
                if (dsData.Tables.CanRemove(table))
                {
                    dsData.Tables.Remove(table);
                }
            }

            // Configure open file dialog box
            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();
            dlg.FileName = ""; // Default file name
            dlg.DefaultExt = ".xml"; // Default file extension
            dlg.Filter = "Xml documents (.xml)|*.xml"; // Filter files by extension 

            // Show open file dialog box
            Nullable<bool> result = dlg.ShowDialog();

            // Process open file dialog box results 
            if (result == true)
            {
                // Open document 
                string filename = dlg.FileName;
                dsData.ReadXml(dlg.FileName);

                dtComponents = dsData.Tables["Components"];

                dtBoardInfo = dsData.Tables["BoardInfo"];


                ItemTitle.Text = dsData.Tables["BoardInfo"].Rows[0][0].ToString();
            }
            
            

            
            _dgComponents.ItemsSource = dtComponents.DefaultView;

        }

        private void bt_ChipFeeder_Click(object sender, RoutedEventArgs e)
        {
            usbController.RunVibrationMotor();
        }

        private void bt_CheckAll_Click(object sender, RoutedEventArgs e)
        {
            // toggle selection on datagrid checkboxes
            foreach (DataRow row in dsData.Tables["Components"].Rows)
            {
                
                    row["Pick"] = 1;
            }
            DataView dv = new DataView(dsData.Tables["Components"]);
            dv.RowFilter = "Pick = 1";
            lblInfo.Content = dv.Count.ToString() + " selected";
            dv.Dispose();
        }

        private void bt_UnCheckAll_Click(object sender, RoutedEventArgs e)
        {
            // toggle selection on datagrid checkboxes
            foreach (DataRow row in dsData.Tables["Components"].Rows)
            {
                
                    row["Pick"] = 0;
            }
            DataView dv = new DataView(dsData.Tables["Components"]);
            dv.RowFilter = "Pick = 1";
            lblInfo.Content = dv.Count.ToString() + " selected";
            dv.Dispose();
        }

        

        private void bt_eStop_Click(object sender, RoutedEventArgs e)
        {
            _kflop.EStop();
        }

        private void bt_Stop_Click(object sender, RoutedEventArgs e)
        {
            builder.CancelBuildProcess();
        }

        private void bt_Start_Click(object sender, RoutedEventArgs e)
        {
            builder.ActivateBuildProcess();
        }

        private void _dgComponents_SelectionChanged(object sender, SelectionChangedEventArgs e)

        {
            DataView dv = new DataView(dsData.Tables["Components"]);
            dv.RowFilter = "Pick = 1";
            lblInfo.Content = dv.Count.ToString() + " selected";
            dv.Dispose();
        }


        private void SetupGridView(DataGrid dg)
        {

            dg.AutoGenerateColumns = false;
            dh.SetupTextColumn(dg, "RefDes", "ComponentName", true);
            dh.SetupTextColumn(dg, "PosX", "PlacementX", true);
            dh.SetupTextColumn(dg, "PosY", "PlacementY", true);
            dh.SetupTextColumn(dg, "Rotate", "PlacementRotate", true);
            dh.SetupTextColumn(dg, "Nozzle", "PlacementNozzle", true);
            dh.SetupCheckBoxColumn(dg, "Pick", "Pick", false);
        }
      
    }
}
