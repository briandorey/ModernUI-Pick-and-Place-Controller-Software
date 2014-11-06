using Emgu.CV.Structure;
using Emgu.CV;
using Emgu.CV.CvEnum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
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
using System.Windows.Threading;
using System.Drawing;
using Microsoft.Win32;
using System.IO;
using System.Data;
using System.Threading;

namespace PickandPlace.Pages
{
    /// <summary>
    /// Interaction logic for BoardDesigner.xaml
    /// </summary>
    public partial class BoardDesigner : UserControl
    {
       
        usbDevice usbController;
        kflop _kflop;
        Components comp = new Components();
        DataSet dscomponents = new DataSet();
        DataHelpers dh = new DataHelpers();

       
        public BoardDesigner()
        {
            InitializeComponent();
         
            App MyApplication = ((App)Application.Current);
            _kflop = MyApplication.GetKFlop();

            usbController = MyApplication.GetUSBDevice();
           
            POPComponentsList();

            POPDataTable(dscomponents);
            SetupGridView(_dgBoard);

            _dgBoard.ItemsSource = dscomponents.Tables["Components"].DefaultView;
        }
        public DataSet POPDataTable(DataSet dt)
        {
            // define datatables
            DataTable dtPCBInfo = dt.Tables.Add("BoardInfo");
            DataTable dscomponents = dt.Tables.Add("Components");
            // setup components table
            dscomponents.Columns.Add("ComponentCode", typeof(Int32));
            dscomponents.Columns.Add("ComponentName", typeof(string));
            dscomponents.Columns.Add("PlacementX", typeof(double));
            dscomponents.Columns.Add("PlacementY", typeof(double));
            dscomponents.Columns.Add("PlacementRotate", typeof(int));
            dscomponents.Columns.Add("PlacementNozzle", typeof(int));
            dscomponents.Columns.Add("Pick", typeof(bool));
            // setup board info table
            dtPCBInfo.Columns.Add("BoardName", typeof(string));
            dtPCBInfo.Columns.Add("BoardHeight", typeof(double));
            dtPCBInfo.Columns.Add("MotorRunTime", typeof(int));

            return dt;
        }

        private void POPComponentsList()
        {
            DataSet dsComponents = new DataSet();
            dsComponents = comp.POPComponentsTable();
            dd_ComponentSelect.DisplayMemberPath = "ComponentValue";
            dd_ComponentSelect.SelectedValuePath = "ComponentCode";
            dd_ComponentSelect.ItemsSource = dsComponents.Tables[0].DefaultView;
            dd_ComponentSelect.SelectedIndex = 0;
        }

        public void SetText(TextBox control, string text)
        {
            control.Text = text;
        }

     

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            CameraWindow cam = new CameraWindow();
            cam.Show();
        }


        private void bt_MoveYMinus_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            ComboBoxItem typeItem = (ComboBoxItem)dd_distance.SelectedItem;
            string value = typeItem.Content.ToString();
            double jogspeed = double.Parse(typeItem.Content.ToString());
            _kflop.JogAxis("Y", -jogspeed);
        }


        private void bt_MoveYPlus_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            ComboBoxItem typeItem = (ComboBoxItem)dd_distance.SelectedItem;
            string value = typeItem.Content.ToString();
            double jogspeed = double.Parse(typeItem.Content.ToString());
            _kflop.JogAxis("Y", jogspeed);
        }
     

        private void bt_MoveXMinus_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            ComboBoxItem typeItem = (ComboBoxItem)dd_distance.SelectedItem;
            string value = typeItem.Content.ToString();
            double jogspeed = double.Parse(typeItem.Content.ToString());
            _kflop.JogAxis("X", -jogspeed);
        }

       
        private void bt_MoveXPlus_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            ComboBoxItem typeItem = (ComboBoxItem)dd_distance.SelectedItem;
            string value = typeItem.Content.ToString();
            double jogspeed = double.Parse(typeItem.Content.ToString());
            _kflop.JogAxis("X", jogspeed);
        }

     

        private void bt_MoveStop(object sender, MouseButtonEventArgs e)
        {
            _kflop.JogAxis("X", 0);
            _kflop.JogAxis("Y", 0);
            _kflop.JogAxis("Z", 0);
            _kflop.JogAxis("A", 0);
            _kflop.JogAxis("B", 0);
            _kflop.JogAxis("C", 0);
           
        }

        private void UpdateDRO()
        {
            double _x = 0;
            double _y = 0;
            double _z = 0;
            double _a = 0;
            double _b = 0;
            double _c = 0;

            _kflop.GetDRO(out _x, out _y, out _z, out _a, out _b, out _c);
            txt_CameraX.Text = _x.ToString() ;
            txt_CameraY.Text = _y.ToString();
         
        }

        private void bt_HomeAll_Click(object sender, RoutedEventArgs e)
        {
            usbController.setResetFeeder();
            _kflop.HomeAll();
            
        }

        private void bt_GetDRO_Click(object sender, RoutedEventArgs e)
        {
             UpdateDRO();
        }

       

        private void bt_SaveFle_Click(object sender, RoutedEventArgs e)
        {

            if (txt_BoardName.Text.Length > 0)
            {


                dscomponents.Tables["BoardInfo"].Rows.Add(txt_BoardName.Text, Double.Parse(txt_BoardHeight.Text), 20);



                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Filter = "Xml file (*.xml)|*.xml";
                if (saveFileDialog.ShowDialog() == true)
                {
                    System.IO.StreamWriter xmlSW = new System.IO.StreamWriter(saveFileDialog.FileName);
                    dscomponents.WriteXml(xmlSW, XmlWriteMode.WriteSchema);
                    xmlSW.Close();
                    MessageBox.Show("File Saved");
                }
            }
            else
            {
                MessageBox.Show("Please enter the PCB Board name");
            }
               
        }

        private void chk_HeadLED_Checked(object sender, RoutedEventArgs e)
        {
            usbController.setBaseCameraLED(true);
        }

        private void chk_HeadLED_Unchecked(object sender, RoutedEventArgs e)
        {
            usbController.setBaseCameraLED(false);
        }

        private void bt_addrow_Click(object sender, RoutedEventArgs e)
        {
            // check for valid data and add row to dataset table
            UpdateDRO();
            Thread.Sleep(100);
            if (txt_ComName.Text.Length > 0)
            {
                Int32 ComponentCode = Int32.Parse(dd_ComponentSelect.SelectedValue.ToString());
                string ComponentName = txt_ComName.Text + " - " + comp.GetComponentValue(dd_ComponentSelect.SelectedValue.ToString());
                double PlacementX = double.Parse(txt_CameraX.Text);
                double PlacementY = double.Parse(txt_CameraY.Text);
                int PlacementRotate = int.Parse(txt_Rotate.Text);
                int PlacementNozzle = 1;
             

                if (check_1.IsChecked.Value == true)
                {
                    PlacementNozzle = 1;
                }
                else
                {
                    PlacementNozzle = 2;
                }

                dscomponents.Tables["Components"].Rows.Add(ComponentCode, ComponentName, PlacementX, PlacementY, PlacementRotate, PlacementNozzle, true);


                lblInfo.Content = dscomponents.Tables["Components"].Rows.Count.ToString() + " components added";
            }
            else
            {
                MessageBox.Show("Please enter the component Ref ID");
            }
           
        }

        private void _dgBoard_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            lblInfo.Content = dscomponents.Tables["Components"].Rows.Count.ToString() + " components";
        }

        public void SetupGridView(DataGrid dg)
        {
            dg.AutoGenerateColumns = false;
            dh.SetupTextColumn(dg, "Component", "ComponentCode", false);
            dh.SetupTextColumn(dg, "Name", "ComponentName", false);
            dh.SetupTextColumn(dg, "X", "PlacementX", false);
            dh.SetupTextColumn(dg, "Y", "PlacementY", false);
            dh.SetupTextColumn(dg, "Rotate", "PlacementRotate", false);
            dh.SetupTextColumn(dg, "Nozzle", "PlacementNozzle", false);
            dh.SetupTextColumn(dg, "Feeder", "FeederLocation", false);
        }

        private void bt_eStop_Click(object sender, RoutedEventArgs e)
        {
            _kflop.EStop();
        }

        private void mainframe_PreviewMouseWheel(object sender, MouseWheelEventArgs e)
        {
           
            int currentitem = dd_distance.SelectedIndex;
            int maaxitems = dd_distance.Items.Count;
            if (e.Delta > 0) {
                if (currentitem > 0)
                {
                    dd_distance.SelectedIndex = currentitem - 1;
                }
                else
                {
                    dd_distance.SelectedIndex = 0;
                }
            } else {
                if (currentitem < maaxitems)
                {
                    dd_distance.SelectedIndex = currentitem + 1;
                }
            }
            
        }
      
    }

   
}