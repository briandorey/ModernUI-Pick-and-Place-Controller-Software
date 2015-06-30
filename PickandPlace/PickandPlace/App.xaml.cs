using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace PickandPlace
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public usbDevice usbController;
        public kflop _kflop = new kflop();

        public bool _hasHomed = false;

        void App_Startup(object sender, StartupEventArgs e)
        {
            _hasHomed = false;
            _kflop.initdevice();
            usbController = new usbDevice(0x04D8, 0x0042);
            usbController.usbEvent += new usbDevice.usbEventsHandler(usbEvent_receiver);
            usbController.findTargetDevice();
            usbController.RunBoardInit(false, 250, 250);
            
           
        }
        public bool checkHome() {
            return _hasHomed;

        }
        public void setHomed(bool status)
        {
            _hasHomed = status;

        }
        public kflop GetKFlop()
        {
            
            return _kflop;
        }
        public usbDevice GetUSBDevice()
        {
           return usbController;
        }
        public DataComponentFeeders cf = new DataComponentFeeders();
        public Components comp = new Components();
      
        public PCBBuilder pcbBuilder = new PCBBuilder();
        private void usbEvent_receiver(object o, EventArgs e)
        {
            // Check the status of the USB device and update the form accordingly
            if (usbController.isDeviceAttached)
            {
                // Device is currently attached


            }
            else
            {
                // Device is currently unattached

                // Update the status label

            }
        }
    }
}
