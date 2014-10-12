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
using System.Data;
using Microsoft.Win32;
using System.IO;
using System.Threading;

namespace PickandPlace.Pages
{
    /// <summary>
    /// Interaction logic for BasicPage1.xaml
    /// </summary>
    public partial class ManualControl : UserControl
    {
    usbDevice usbController;
        kflop _kflop;
        DataSet dt = new DataSet();
      
        public ManualControl()
        {
    
       
            InitializeComponent();

            
           
            App MyApplication = ((App)Application.Current);
            _kflop = MyApplication.GetKFlop();

            usbController = MyApplication.GetUSBDevice();
           

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

        private void bt_MoveZMinus_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            ComboBoxItem typeItem = (ComboBoxItem)dd_distance.SelectedItem;
            string value = typeItem.Content.ToString();
            double jogspeed = double.Parse(typeItem.Content.ToString());
            _kflop.JogAxis("Z", -jogspeed);
        }


        private void bt_MoveZPlus_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            ComboBoxItem typeItem = (ComboBoxItem)dd_distance.SelectedItem;
            string value = typeItem.Content.ToString();
            double jogspeed = double.Parse(typeItem.Content.ToString());
            _kflop.JogAxis("Z", jogspeed);
        }

        private void bt_MoveAMinus_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            ComboBoxItem typeItem = (ComboBoxItem)dd_distance.SelectedItem;
            string value = typeItem.Content.ToString();
            double jogspeed = double.Parse(typeItem.Content.ToString());
            _kflop.JogAxis("A", -jogspeed);
        }


        private void bt_MoveAPlus_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            ComboBoxItem typeItem = (ComboBoxItem)dd_distance.SelectedItem;
            string value = typeItem.Content.ToString();
            double jogspeed = double.Parse(typeItem.Content.ToString());
            _kflop.JogAxis("A", jogspeed);
        }

        private void bt_MoveBMinus_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            ComboBoxItem typeItem = (ComboBoxItem)dd_distance.SelectedItem;
            string value = typeItem.Content.ToString();
            double jogspeed = double.Parse(typeItem.Content.ToString());
            _kflop.JogAxis("B", -jogspeed);
        }


        private void bt_MoveBPlus_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            ComboBoxItem typeItem = (ComboBoxItem)dd_distance.SelectedItem;
            string value = typeItem.Content.ToString();
            double jogspeed = double.Parse(typeItem.Content.ToString());
            _kflop.JogAxis("B", jogspeed);
        }

        private void bt_MoveCMinus_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            ComboBoxItem typeItem = (ComboBoxItem)dd_distance.SelectedItem;
            string value = typeItem.Content.ToString();
            double jogspeed = double.Parse(typeItem.Content.ToString());
            _kflop.JogAxis("C", -jogspeed);
        }


        private void bt_MoveCPlus_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            ComboBoxItem typeItem = (ComboBoxItem)dd_distance.SelectedItem;
            string value = typeItem.Content.ToString();
            double jogspeed = double.Parse(typeItem.Content.ToString());
            _kflop.JogAxis("C", jogspeed);
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
            txt_CameraZ.Text = _z.ToString();
            txt_CameraA.Text = _a.ToString();
            txt_CameraB.Text = _b.ToString();
            txt_CameraC.Text = _c.ToString();
        }

        private void bt_HomeAll_Click(object sender, RoutedEventArgs e)
        {
            _kflop.HomeAll();
            usbController.setResetFeeder();
        }

        private void bt_GetDRO_Click(object sender, RoutedEventArgs e)
        {
             UpdateDRO();
        }

          // head led controller
        private void chk_HeadLED_Checked(object sender, RoutedEventArgs e)
        {
            usbController.setBaseCameraLED(true);
        }

        private void chk_HeadLED_Unchecked(object sender, RoutedEventArgs e)
        {
            usbController.setBaseCameraLED(false);
        }
        // base led controller
        private void chk_BaseLED_Checked(object sender, RoutedEventArgs e)
        {
            usbController.setHeadCameraLED(true);
        }

        private void chk_BaseLED_Unchecked(object sender, RoutedEventArgs e)
        {
            usbController.setHeadCameraLED(false);
        }
        // vac 1
        private void chk_Vac1_Checked(object sender, RoutedEventArgs e)
        {
            usbController.setVAC1(true);
        }

        private void chk_Vac1_Unchecked(object sender, RoutedEventArgs e)
        {
            usbController.setVAC1(false);
        }
        // vac 2
        private void chk_Vac2_Checked(object sender, RoutedEventArgs e)
        {
            usbController.setVAC2(true);
        }

        private void chk_Vac2_Unchecked(object sender, RoutedEventArgs e)
        {
            usbController.setVAC2(false);
        }

        private void bt_getFeeder_Click_1(object sender, RoutedEventArgs e)
        {
            ComboBoxItem typeItem = (ComboBoxItem)dd_FeederSelect.SelectedItem;
            string value = typeItem.Content.ToString();
            byte feeder = byte.Parse(typeItem.Content.ToString());
            usbController.setGotoFeeder(feeder);
        }

        private void bt_eStop_Click(object sender, RoutedEventArgs e)
        {
            _kflop.EStop();
        }

        private void bt_ChipFeeder_Click(object sender, RoutedEventArgs e)
        {
            usbController.RunVibrationMotor();
        }

        private void bt_runto_Click(object sender, RoutedEventArgs e)
        {
            double newX = double.Parse(txt_goX.Text);
            double newY = double.Parse(txt_goY.Text);
            double newZ = double.Parse(txt_goZ.Text);
            double newA = double.Parse(txt_goA.Text);
            double newB = double.Parse(txt_goB.Text);
            double newC = double.Parse(txt_goC.Text);
            double newSpeed = double.Parse(txt_Speed.Text);


            ThreadStart starter = () => RunToPoint(newX, newY, newZ, newA, newB, newC, newSpeed);
            Thread runner = new Thread(starter);
            runner.Start();
        }

        private void RunToPoint(double newX, double newY, double newZ, double newA,double newB,double newC,double newSpeed)
        {
            _kflop.MoveSingleFeed(newSpeed, newX, newY, newZ, newA, newB, newC);
        }

        private void mainframe_PreviewMouseWheel(object sender, MouseWheelEventArgs e)
        {

            int currentitem = dd_distance.SelectedIndex;
            int maaxitems = dd_distance.Items.Count;
            if (e.Delta > 0)
            {
                if (currentitem > 0)
                {
                    dd_distance.SelectedIndex = currentitem - 1;
                }
                else
                {
                    dd_distance.SelectedIndex = 0;
                }
            }
            else
            {
                if (currentitem < maaxitems)
                {
                    dd_distance.SelectedIndex = currentitem + 1;
                }
            }

        }

      
    }

   
}