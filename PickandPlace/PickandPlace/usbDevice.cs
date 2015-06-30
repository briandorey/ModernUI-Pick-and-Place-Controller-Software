﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
    using usbGenericHidCommunications;
using System.Threading;
namespace PickandPlace
{
    

    /// <summary>
    /// This class performs several different tests against the 
    /// reference hardware/firmware to confirm that the USB
    /// communication library is functioning correctly.
    /// 
    /// It also serves as a demonstration of how to use the class
    /// library to perform different types of read and write
    /// operations.
    /// </summary>
    public class usbDevice : usbGenericHidCommunication
    {

        private int Vac1Suck = 0;
        private int Vac1Air = 2;
        private int Vac2Suck = 4;
        private int Vac2Air = 6;
        private int AirPulseLength = 20;
        private bool ChipMotorRunning = false;
        /// <summary>
        /// Class constructor - place any initialisation here
        /// </summary>
        /// <param name="vid"></param>
        /// <param name="pid"></param>
        public usbDevice(int vid, int pid)
            : base(vid, pid)
        {
        }


        public bool getDeviceStatus()
        {
            Byte[] outputBuffer = new Byte[65];

            outputBuffer[0] = 0;
            outputBuffer[1] = 0x01;
            outputBuffer[2] = 0x01;

            bool success;
            success = writeRawReportToDevice(outputBuffer);

            return success;
        }

        public bool getFeederReadyStatus()
        {
            Byte[] outputBuffer = new Byte[65];
            Byte[] inputBuffer = new Byte[65];

            outputBuffer[0] = 0;
            outputBuffer[1] = 0x02;
            outputBuffer[2] = 0x02;

            bool success;
            success = writeRawReportToDevice(outputBuffer);

            if (success)
            {
                // Perform the read
                success = readSingleReportFromDevice(ref inputBuffer);
                if (inputBuffer[1] == 0) return true;
                if (inputBuffer[1] == 1) return false;
            }

            return success;
        }

        public bool setGotoFeeder(byte inval)
        {
            Byte[] outputBuffer = new Byte[65];

            outputBuffer[0] = 0;
            outputBuffer[1] = 0x02;
            outputBuffer[2] = 0x03;
            outputBuffer[3] = inval;

            bool success;
            success = writeRawReportToDevice(outputBuffer);
            return success;
        }

        public bool setGotoFeederWithoutPick(byte inval)
        {
            Byte[] outputBuffer = new Byte[65];

            outputBuffer[0] = 0;
            outputBuffer[1] = 0x02;
            outputBuffer[2] = 0x08;
            outputBuffer[3] = inval;

            bool success;
            success = writeRawReportToDevice(outputBuffer);
            return success;
        }

        public bool setIOPort(Int16 inval)
        {
            byte b0 = (byte)inval,
                 b1 = (byte)(inval >> 8);

            Byte[] outputBuffer = new Byte[65];

            outputBuffer[0] = 0;
            outputBuffer[1] = 0x02;
            outputBuffer[2] = 0x07;
            outputBuffer[3] = b0;
            outputBuffer[4] = b1;

            bool success;
            success = writeRawReportToDevice(outputBuffer);
            return success;
        }



        public bool setPickerUp()
        {
            Byte[] outputBuffer = new Byte[65];

            outputBuffer[0] = 0;
            outputBuffer[1] = 0x02;
            outputBuffer[2] = 0x04;

            bool success;
            success = writeRawReportToDevice(outputBuffer);
            return success;
        }

        public bool setResetFeeder()
        {
            Byte[] outputBuffer = new Byte[65];

            outputBuffer[0] = 0;
            outputBuffer[1] = 0x02;
            outputBuffer[2] = 0x05;

            bool success;
            success = writeRawReportToDevice(outputBuffer);
            return success;
        }

        public bool setPickerDown()
        {
            Byte[] outputBuffer = new Byte[65];

            outputBuffer[0] = 0;
            outputBuffer[1] = 0x02;
            outputBuffer[2] = 0x06;

            bool success;
            success = writeRawReportToDevice(outputBuffer);
            return success;
        }
        Int16 aByte = 0;

        public void Set(int pos, bool value)
        {
            if (value)
            {
                //left-shift 1, then bitwise OR
                aByte = (Int16)(aByte | (1 << pos));
            }
            else
            {
                //left-shift 1, then take complement, then bitwise AND
                aByte = (Int16)(aByte & ~(1 << pos));
            }
        }

        public bool Get(int pos)
        {
            //left-shift 1, then bitwise AND, then check for non-zero
            return ((aByte & (1 << pos)) != 0);
        }
 
        public bool setVAC1(bool inval)
        {
            Set(Vac1Air, false);
            if (inval)
            {
                Set(Vac1Suck, true);
            }
            else
            {
                Set(Vac1Suck, false);
                Vac1AirPulse();
            }
            setIOPort(aByte);
           
            return true;
        }

        public bool setVAC2(bool inval)
        {
            Set(Vac2Air, false);
            if (inval)
            {
                Set(Vac2Suck, true);
            }
            else
            {
                Set(Vac2Suck, false);
                Vac2AirPulse();
            }
            
            setIOPort(aByte);

            return true;
        }
        public void Vac1AirPulse()
        {
            Thread th_motor = new Thread(Vac1AirPulseSub);
            th_motor.Start();
        }
        private void Vac1AirPulseSub()
        {
            Set(Vac1Air, true);
            setIOPort(aByte);
            int n = 1;
            while (n < AirPulseLength)
            {
                Thread.Sleep(10);
                n++;
            }

            Set(Vac1Air, false);
            setIOPort(aByte);
        }
        public void Vac2AirPulse()
        {
            Thread th_motor = new Thread(Vac2AirPulseSub);
            th_motor.Start();
        }
        private void Vac2AirPulseSub()
        {
            Set(Vac2Air, true);
            setIOPort(aByte);
            int n = 1;
            while (n < AirPulseLength)
            {
                Thread.Sleep(10);
                n++;
            }

            Set(Vac2Air, false);
            setIOPort(aByte);
        }

        public bool setVAC1Old(bool inval)
        {
            Byte[] outputBuffer = new Byte[65];

            outputBuffer[0] = 0;
            outputBuffer[1] = 0x03;
            outputBuffer[2] = 0x01;
            if (inval)
            {
                outputBuffer[3] = 0x01;
            }
            else
            {
                outputBuffer[3] = 0x00;
            }

            bool success;
            success = writeRawReportToDevice(outputBuffer);
            return success;
        }

        public bool setVAC2Old(bool inval)
        {
            Byte[] outputBuffer = new Byte[65];

            outputBuffer[0] = 0;
            outputBuffer[1] = 0x03;
            outputBuffer[2] = 0x02;
            if (inval)
            {
                outputBuffer[3] = 0x01;
            }
            else
            {
                outputBuffer[3] = 0x00;
            }

            bool success;
            success = writeRawReportToDevice(outputBuffer);
            return success;
        }
        public bool CheckChipMotorRunning()
        {
            return ChipMotorRunning;

        }
        private int MotorRunLoop = 20;
        public void RunVibrationMotor(int newrunloop)
        {
            MotorRunLoop = newrunloop;
            Thread th_motor = new Thread(RunVibrationMotorSub);
            th_motor.Start();
        }
        private void RunVibrationMotorSub()
        {
            setVibrationMotor(true);
            ChipMotorRunning = true;
            int n = 1;
            while (n < MotorRunLoop)
            {
                Thread.Sleep(100);
                n++;
            }

            
           
            setVibrationMotor(false);
            ChipMotorRunning = false;
        }
        public bool setVibrationMotor(bool inval)
        {
            Byte[] outputBuffer = new Byte[65];

            outputBuffer[0] = 0;
            outputBuffer[1] = 0x03;
            outputBuffer[2] = 0x03;
            if (inval)
            {
                outputBuffer[3] = 0x01;
            }
            else
            {
                outputBuffer[3] = 0x00;
            }

            bool success;
            success = writeRawReportToDevice(outputBuffer);
            return success;
        }

        public bool setVibrationMotorSpeed(byte inval)
        {
            /*
            Byte[] outputBuffer = new Byte[65];

            outputBuffer[0] = 0;
            outputBuffer[1] = 0x03;
            outputBuffer[2] = 0x07;
            outputBuffer[3] = inval;

            bool success;
            success = writeRawReportToDevice(outputBuffer);
             */ 
            return true;
        }

        public bool getVac1Status()
        {
            Byte[] outputBuffer = new Byte[65];
            Byte[] inputBuffer = new Byte[65];

            outputBuffer[0] = 0;
            outputBuffer[1] = 0x03;
            outputBuffer[2] = 0x04;

            bool success;
            success = writeRawReportToDevice(outputBuffer);

            if (success)
            {
                // Perform the read
                success = readSingleReportFromDevice(ref inputBuffer);
                if (inputBuffer[1] == 1) return true;
                if (inputBuffer[1] == 0) return false;
            }

            return success;
        }

        public bool getVac2Status()
        {
            Byte[] outputBuffer = new Byte[65];
            Byte[] inputBuffer = new Byte[65];

            outputBuffer[0] = 0;
            outputBuffer[1] = 0x03;
            outputBuffer[2] = 0x05;

            bool success;
            success = writeRawReportToDevice(outputBuffer);

            if (success)
            {
                // Perform the read
                success = readSingleReportFromDevice(ref inputBuffer);
                if (inputBuffer[1] == 1) return true;
                if (inputBuffer[1] == 0) return false;
            }

            return success;
        }

        public bool getVibrationStatus()
        {
            Byte[] outputBuffer = new Byte[65];
            Byte[] inputBuffer = new Byte[65];

            outputBuffer[0] = 0;
            outputBuffer[1] = 0x03;
            outputBuffer[2] = 0x06;

            bool success;
            success = writeRawReportToDevice(outputBuffer);

            if (success)
            {
                // Perform the read
                success = readSingleReportFromDevice(ref inputBuffer);
                if (inputBuffer[1] == 1) return true;
                if (inputBuffer[1] == 0) return false;
            }

            return success;
        }

        public bool setBaseCameraLED(bool inval)
        {
            Byte[] outputBuffer = new Byte[65];

            outputBuffer[0] = 0;
            outputBuffer[1] = 0x04;
            outputBuffer[2] = 0x01;
            if (inval)
            {
                outputBuffer[3] = 0x01;
            }
            else
            {
                outputBuffer[3] = 0x00;
            }

            bool success;
            success = writeRawReportToDevice(outputBuffer);
            return success;
        }

        public bool setHeadCameraLED(bool inval)
        {
            Byte[] outputBuffer = new Byte[65];

            outputBuffer[0] = 0;
            outputBuffer[1] = 0x04;
            outputBuffer[2] = 0x03;
            if (inval)
            {
                outputBuffer[3] = 0x01;
            }
            else
            {
                outputBuffer[3] = 0x00;
            }

            bool success;
            success = writeRawReportToDevice(outputBuffer);
            return success;
        }

        public bool setBaseCameraPWM(byte inval)
        {
            Byte[] outputBuffer = new Byte[65];

            outputBuffer[0] = 0;
            outputBuffer[1] = 0x04;
            outputBuffer[2] = 0x02;
            outputBuffer[3] = inval;

            bool success;
            success = writeRawReportToDevice(outputBuffer);
            return success;
        }

        public bool setHeadCameraPWM(byte inval)
        {
            Byte[] outputBuffer = new Byte[65];


            outputBuffer[0] = 0;
            outputBuffer[1] = 0x04;
            outputBuffer[2] = 0x04;
            outputBuffer[3] = inval;

            bool success;
            success = writeRawReportToDevice(outputBuffer);
            return success;
        }

        public bool getBaseCameraLEDStatus()
        {
            Byte[] outputBuffer = new Byte[65];
            Byte[] inputBuffer = new Byte[65];

            outputBuffer[0] = 0;
            outputBuffer[1] = 0x04;
            outputBuffer[2] = 0x05;

            bool success;
            success = writeRawReportToDevice(outputBuffer);

            if (success)
            {
                // Perform the read
                success = readSingleReportFromDevice(ref inputBuffer);
                if (inputBuffer[1] == 1) return true;
                if (inputBuffer[1] == 0) return false;
            }

            return success;
        }

        public bool getHeadCameraLEDStatus()
        {
            Byte[] outputBuffer = new Byte[65];
            Byte[] inputBuffer = new Byte[65];

            outputBuffer[0] = 0;
            outputBuffer[1] = 0x04;
            outputBuffer[2] = 0x06;

            bool success;
            success = writeRawReportToDevice(outputBuffer);

            if (success)
            {
                // Perform the read
                success = readSingleReportFromDevice(ref inputBuffer);
                if (inputBuffer[1] == 1) return true;
                if (inputBuffer[1] == 0) return false;
            }

            return success;
        }







        // Collect debug information from the device
        public String collectDebug()
        {
            // Collect debug information from USB device
            Debug.WriteLine("Reference Application -> Collecting debug information from device");

            // Declare our output buffer
            Byte[] outputBuffer = new Byte[65];

            // Declare our input buffer
            Byte[] inputBuffer = new Byte[65];

            // Byte 0 must be set to 0
            outputBuffer[0] = 0;

            // Byte 1 must be set to our command
            outputBuffer[1] = 0x10;

            // Send the collect debug command
            writeRawReportToDevice(outputBuffer);

            // Read the response from the device
            readSingleReportFromDevice(ref inputBuffer);

            // Byte 1 contains the number of characters transfered
            if (inputBuffer[1] == 0) return String.Empty;

            // Convert the Byte array into a string of the correct length
            string s = System.Text.ASCIIEncoding.ASCII.GetString(inputBuffer, 2, inputBuffer[1]);

            return s;
        }

        /// <summary>
        ///  RunBoardInit() run self test on control board and initalise all settings
        /// </summary>
        public void RunBoardInit(bool fulltest, byte BaseCameraPWM, byte HeadCameraPWM)
        {
            setBaseCameraPWM(BaseCameraPWM);
            setHeadCameraPWM(HeadCameraPWM);
            setVibrationMotorSpeed(250);
            //setVAC1(false);
            //setVAC2(false);
            setIOPort(0);
            if (fulltest)
            {
                setResetFeeder();


                Thread.Sleep(200);

                setVibrationMotor(true);
                Thread.Sleep(500);
                setVibrationMotor(false);
                setVibrationMotorSpeed(250);
                Thread.Sleep(100);
                setHeadCameraLED(true);
                Thread.Sleep(100);
                setHeadCameraLED(false);
                Thread.Sleep(100);
                setBaseCameraLED(true);
                Thread.Sleep(100);
                setBaseCameraLED(false);
                Thread.Sleep(100);
                //setVAC1(true);
                Thread.Sleep(100);
                //setVAC1(false);
                Thread.Sleep(100);
                //setVAC2(true);
                Thread.Sleep(100);
                //setVAC2(false);
            }

        }
    }
}