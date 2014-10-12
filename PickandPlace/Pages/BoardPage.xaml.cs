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
using Microsoft.Win32;

namespace PickandPlace.Pages
{
    /// <summary>
    /// Interaction logic for BoardPage.xaml
    /// </summary>
    public partial class BoardPage : UserControl,  IContent
    {
        DataTable dtComponents = new DataTable();
        DataTable dtBoardInfo = new DataTable();
        public DataSet dsData = new DataSet();
        DataHelpers dh = new DataHelpers();
        private PCBBuilder builder = new PCBBuilder();
        public App MyApplication = ((App)Application.Current);
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
            usbController.setResetFeeder();
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
            if (MyApplication.checkHome())
            {
                builder.ActivateBuildProcess();
            }
            else
            {
                MessageBox.Show("Home Error");
            }
            MyApplication.setHomed(false);
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
            dh.SetupTextColumn(dg, "RefDes", "ComponentName", false);
            dh.SetupTextColumn(dg, "PosX", "PlacementX", false);
            dh.SetupTextColumn(dg, "PosY", "PlacementY", false);
            dh.SetupTextColumn(dg, "Rotate", "PlacementRotate", false);
            dh.SetupTextColumn(dg, "Nozzle", "PlacementNozzle", false);
            dh.SetupCheckBoxColumn(dg, "Pick", "Pick", false);
        }

        private void bt_Save_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Xml file (*.xml)|*.xml";
            if (saveFileDialog.ShowDialog() == true)
            {
                System.IO.StreamWriter xmlSW = new System.IO.StreamWriter(saveFileDialog.FileName);
                dsData.WriteXml(xmlSW, XmlWriteMode.WriteSchema);
                xmlSW.Close();
                MessageBox.Show("File Saved");
            }
        }

        public void SetlblActive(string val)
        {
            lblActive.Content = val;
        }

        private void bt_ViewPCB_Click(object sender, RoutedEventArgs e)
        {
            pcbvisualiser pcb = new pcbvisualiser();
            pcb.LoadDataSet(dsData);
            pcb.Show();
        }
    }
}
