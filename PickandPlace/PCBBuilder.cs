using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.ComponentModel;
using System.Threading;
using System.Windows;

namespace PickandPlace
{
    public class PCBBuilder
    {
        public DataSet dsData = new DataSet();

        private Components comp = new Components();
        private usbDevice usbController;
        private kflop kf;

        // manual picker selector
        public int currentfeeder = 0;
        // bed settings
        public double NeedleZHeight = 35.0;

        DataHelpers dh = new DataHelpers();
      
      
        public double dblPCBThickness = 1.6;
        public int FeedRate = 20000;

        public double ClearHeight = 15;

        // nozzle to camera offsets
        public double Nozzle1Xoffset = 0;
        public double Nozzle1Yoffset = 0;

        public double Nozzle2Xoffset = 0;
        public double Nozzle2Yoffset = 0;

        

        private readonly BackgroundWorker backgroundWorkerBuildPCB = new BackgroundWorker();

        public void setupPCBBuilder(kflop kflop, usbDevice usb, DataSet ds)
        {
            dsData = ds;
            kf = kflop;
            usbController = usb;
            // setup worker methods
            backgroundWorkerBuildPCB.DoWork += worker_DoWork;
            backgroundWorkerBuildPCB.RunWorkerCompleted += worker_RunWorkerCompleted;
            backgroundWorkerBuildPCB.WorkerSupportsCancellation = true;

            
        }
        

        private void worker_DoWork(object sender, DoWorkEventArgs e)
        {
           // run all background tasks here
            BackgroundWorker worker = sender as BackgroundWorker;
            DataTable dtComponents = dsData.Tables["Components"];
            DataView dv = new DataView(dtComponents);
            dv.RowFilter = "Pick = 1";
            int currentrow = 0;
            int totalrows = dv.Count;

            Nozzle1Xoffset = dh.Nozzle1Xoffset;
            Nozzle1Yoffset = dh.Nozzle1Yoffset;
            Nozzle2Xoffset = dh.Nozzle2Xoffset;
            Nozzle2Yoffset = dh.Nozzle2Yoffset;

            if (totalrows > 0)
            {

                /* Components table columns
                    ComponentCode
                    ComponentName
                    PlacementX
                    PlacementY
                    PlacementRotate
                    PlacementNozzle
                 
                 * component list
                 * ComponentCode
                 * ComponentValue
                 * Package
                 * 
                 * PlacementHeight
                 * FeederHeight
                 * FeederX
                 * FeederY
                 * VerifywithCamera
                 * TapeFeeder
               
                  
                 * */
                double pcbHeight = double.Parse(dsData.Tables["BoardInfo"].Rows[0][1].ToString());
               
                double feedrate = 20000;
                double feederPosX = 0;
                double feederPosY = 0;
                double feederPosZ = 0;
                double placePosX = 0;
                double placePosY = 0;
                //double placePosZ = 0;
               // double placePosA = 0;
               // double placePosRotateZ = 0;
               // double placePosRotateB = 0;
                double ComponentRotation = 0;
                double PlacementHeight = 0;
                int PlacementNozzle = 1;
                bool TapeFeeder = false;

                while (currentrow < totalrows)
                {

                    if (backgroundWorkerBuildPCB.CancellationPending)
                    {
                        e.Cancel = true;
                        dv.Dispose();
                        break;
                    }
                    PlacementNozzle = int.Parse(dv[currentrow]["PlacementNozzle"].ToString());


                    feederPosX = CalcXLocation(comp.GetFeederX(dv[currentrow]["ComponentCode"].ToString()),PlacementNozzle);
                    feederPosY = CalcYLocation(comp.GetFeederY(dv[currentrow]["ComponentCode"].ToString()),PlacementNozzle);

                    feederPosZ = comp.GetFeederHeight(dv[currentrow]["ComponentCode"].ToString());
                    PlacementHeight = comp.GetPlacementHeight(dv[currentrow]["ComponentCode"].ToString()) - pcbHeight;

                    TapeFeeder = comp.GetComponentTapeFeeder(dv[currentrow]["ComponentCode"].ToString()); 

                    placePosX = CalcXLocation(double.Parse(dv[currentrow]["PlacementX"].ToString()),PlacementNozzle);
                    placePosY = CalcYLocation(double.Parse(dv[currentrow]["PlacementY"].ToString()), PlacementNozzle);

                    ComponentRotation = double.Parse(dv[currentrow]["PlacementRotate"].ToString());


                    PlacementNozzle = int.Parse(dv[currentrow]["PlacementNozzle"].ToString());


                    if (currentrow == 0)
                    {
                        SetFeederOutputs(comp.GetFeederID(dv[currentrow]["ComponentCode"].ToString())); // send feeder to position
                    }
                   


                    kf.MoveSingleFeed(feedrate, feederPosX, feederPosY, ClearHeight, ClearHeight, 0, 0);


                    if (comp.GetComponentTapeFeeder(dv[currentrow]["ComponentCode"].ToString()))
                    {

                        while (!usbController.getFeederReadyStatus())
                        {
                            Thread.Sleep(10);
                        }
                        Thread.Sleep(50);
                        // use picker 1
                        kf.MoveSingleFeed(feedrate, feederPosX, feederPosY, feederPosZ, ClearHeight, 0, 0);
                        Thread.Sleep(50);
                        // go down and turn on suction
                        usbController.setVAC1(true);
                        Thread.Sleep(100);
                        kf.MoveSingleFeed(feedrate, feederPosX, feederPosY, ClearHeight, ClearHeight, 0, 0);

                    }
                    else
                    {
                        // use picker 2
                        kf.MoveSingleFeed(feedrate, feederPosX, feederPosY, ClearHeight, feederPosZ, 0, 0);
                        Thread.Sleep(50);
                        usbController.setVAC2(true);
                        
                        Thread.Sleep(200);
                        kf.MoveSingleFeed(feedrate, feederPosX, feederPosY, ClearHeight, ClearHeight, 0, 0);
                    }
                    // send picker to pick next item
                    if (currentrow >= 0 && (currentrow + 1) < totalrows)
                    {
                        Thread.Sleep(100);
                       
                        SetFeederOutputs(comp.GetFeederID(dv[currentrow + 1]["ComponentCode"].ToString())); // send feeder to position
                    }

                    // rotate head


                    //SetResultsLabelText("Placing Component");
                    if (comp.GetComponentTapeFeeder(dv[currentrow]["ComponentCode"].ToString()))
                    {

                        kf.MoveSingleFeed(feedrate, placePosX, placePosY, ClearHeight, ClearHeight, 0, ComponentRotation);

                       
                        kf.MoveSingleFeed(feedrate, placePosX, placePosY, PlacementHeight, ClearHeight, 0, ComponentRotation);
                        Thread.Sleep(300);
                        usbController.setVAC1(false);
                        Thread.Sleep(300);
                        kf.MoveSingleFeed(feedrate, placePosX, placePosY, ClearHeight, ClearHeight, 0, ComponentRotation);

                    }
                    else
                    {
                        // use picker 2  CalcXwithNeedleSpacing

                        kf.MoveSingleFeed(feedrate, placePosX, placePosY, ClearHeight, ClearHeight, ComponentRotation, 0);
                        Thread.Sleep(200);
                        kf.MoveSingleFeed(feedrate, placePosX, placePosY, ClearHeight, PlacementHeight, ComponentRotation, 0);
                        // go down and turn off suction
                        Thread.Sleep(300);
                        
                        usbController.setVAC2(false);
                        Thread.Sleep(300);
                        kf.MoveSingleFeed(feedrate, placePosX, placePosY, ClearHeight, ClearHeight, ComponentRotation, 0);

                    }

                    currentrow++;
                   
                }
                


            }
            else
            {
                MessageBox.Show("Board file not loaded");
            }
            backgroundWorkerBuildPCB.CancelAsync();

         
          
            dv.Dispose();
            dtComponents.Dispose();
        }

        private void worker_RunWorkerCompleted(object sender, 
                                               RunWorkerCompletedEventArgs e)
        {
          //update ui once worker complete his work
        }

        public double CalcXLocation(double val, int nozzle)
        {
            if (nozzle.Equals(1))
            {
                return val - Nozzle1Xoffset;
            }
            else
            {
                return val - Nozzle2Xoffset;
            }
        }
        public double CalcYLocation(double val, int nozzle)
        {
            if (nozzle.Equals(1))
            {
                return val - Nozzle1Yoffset;
            }
            else
            {
                return val - Nozzle2Yoffset;
            }
        }

   
       

       
        public void SetFeederOutputs(int feedercommand)
        {
            usbController.setGotoFeeder(Byte.Parse(feedercommand.ToString()));

            // check if on main feeder rack
            if (feedercommand == 98)
            {
                // command set, now toggle interupt pin
                usbController.setResetFeeder();
            }

            if (feedercommand > 20 && feedercommand < 30)
            {
                usbController.RunVibrationMotor();
            }
        }

       

        public void ActivateBuildProcess()
        {

            if (backgroundWorkerBuildPCB.IsBusy != true)
            {
                backgroundWorkerBuildPCB.RunWorkerAsync();
            }
        }
        public void CancelBuildProcess()
        {
            backgroundWorkerBuildPCB.CancelAsync();
            
        }

     
    }
}
