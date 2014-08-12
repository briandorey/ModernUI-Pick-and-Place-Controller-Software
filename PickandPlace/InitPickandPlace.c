#include "KMotionDef.h"

// Defines axis 0, 1, 2, 4, 5, 6 as simple step dir outputs
// enables them
// sets them as an xyzabc coordinate system for GCode

int main() 
{
	ch0->InputMode=ENCODER_MODE;
	ch0->OutputMode=STEP_DIR_MODE;
	ch0->Vel=40000.000000;
	ch0->Accel=400000.000000;
	ch0->Jerk=4000000.000000;
	ch0->P=0.000000;
	ch0->I=0.010000;
	ch0->D=0.000000;
	ch0->FFAccel=0.000000;
	ch0->FFVel=0.000000;
	ch0->MaxI=200.000000;
	ch0->MaxErr=1000000.000000;
	ch0->MaxOutput=200.000000;
	ch0->DeadBandGain=1.000000;
	ch0->DeadBandRange=0.000000;
	ch0->InputChan0=0;
	ch0->InputChan1=0;
	ch0->OutputChan0=0;
	ch0->OutputChan1=0;
	ch0->LimitSwitchOptions=0x0;
	ch0->InputGain0=1.000000;
	ch0->InputGain1=1.000000;
	ch0->InputOffset0=0.000000;
	ch0->InputOffset1=0.000000;
	ch0->invDistPerCycle=1.000000;
	ch0->Lead=0.000000;
	ch0->MaxFollowingError=1000000000.000000;
	ch0->StepperAmplitude=20.000000;

	ch0->iir[0].B0=1.000000;
	ch0->iir[0].B1=0.000000;
	ch0->iir[0].B2=0.000000;
	ch0->iir[0].A1=0.000000;
	ch0->iir[0].A2=0.000000;

	ch0->iir[1].B0=1.000000;
	ch0->iir[1].B1=0.000000;
	ch0->iir[1].B2=0.000000;
	ch0->iir[1].A1=0.000000;
	ch0->iir[1].A2=0.000000;

	ch0->iir[2].B0=0.000769;
	ch0->iir[2].B1=0.001538;
	ch0->iir[2].B2=0.000769;
	ch0->iir[2].A1=1.920810;
	ch0->iir[2].A2=-0.923885;
    EnableAxisDest(0,0);

	ch1->InputMode=ENCODER_MODE;
	ch1->OutputMode=STEP_DIR_MODE;
	ch1->Vel=40000.000000;
	ch1->Accel=400000.000000;
	ch1->Jerk=4000000.000000;
	ch1->P=0.000000;
	ch1->I=0.010000;
	ch1->D=0.000000;
	ch1->FFAccel=0.000000;
	ch1->FFVel=0.000000;
	ch1->MaxI=200.000000;
	ch1->MaxErr=1000000.000000;
	ch1->MaxOutput=200.000000;
	ch1->DeadBandGain=1.000000;
	ch1->DeadBandRange=0.000000;
	ch1->InputChan0=1;
	ch1->InputChan1=0;
	ch1->OutputChan0=1;
	ch1->OutputChan1=0;
	ch1->LimitSwitchOptions=0x0;
	ch1->InputGain0=1.000000;
	ch1->InputGain1=1.000000;
	ch1->InputOffset0=0.000000;
	ch1->InputOffset1=0.000000;
	ch1->invDistPerCycle=1.000000;
	ch1->Lead=0.000000;
	ch1->MaxFollowingError=1000000000.000000;
	ch1->StepperAmplitude=20.000000;

	ch1->iir[0].B0=1.000000;
	ch1->iir[0].B1=0.000000;
	ch1->iir[0].B2=0.000000;
	ch1->iir[0].A1=0.000000;
	ch1->iir[0].A2=0.000000;

	ch1->iir[1].B0=1.000000;
	ch1->iir[1].B1=0.000000;
	ch1->iir[1].B2=0.000000;
	ch1->iir[1].A1=0.000000;
	ch1->iir[1].A2=0.000000;

	ch1->iir[2].B0=0.000769;
	ch1->iir[2].B1=0.001538;
	ch1->iir[2].B2=0.000769;
	ch1->iir[2].A1=1.920810;
	ch1->iir[2].A2=-0.923885;
    EnableAxisDest(1,0);

	ch2->InputMode=ENCODER_MODE;
	ch2->OutputMode=STEP_DIR_MODE;
	ch2->Vel=40000.000000;
	ch2->Accel=400000.000000;
	ch2->Jerk=4000000.000000;
	ch2->P=0.000000;
	ch2->I=0.010000;
	ch2->D=0.000000;
	ch2->FFAccel=0.000000;
	ch2->FFVel=0.000000;
	ch2->MaxI=200.000000;
	ch2->MaxErr=1000000.000000;
	ch2->MaxOutput=200.000000;
	ch2->DeadBandGain=1.000000;
	ch2->DeadBandRange=0.000000;
	ch2->InputChan0=2;
	ch2->InputChan1=0;
	ch2->OutputChan0=2;
	ch2->OutputChan1=0;
	ch2->LimitSwitchOptions=0x0;
	ch2->InputGain0=1.000000;
	ch2->InputGain1=1.000000;
	ch2->InputOffset0=0.000000;
	ch2->InputOffset1=0.000000;
	ch2->invDistPerCycle=1.000000;
	ch2->Lead=0.000000;
	ch2->MaxFollowingError=1000000000.000000;
	ch2->StepperAmplitude=20.000000;

	ch2->iir[0].B0=1.000000;
	ch2->iir[0].B1=0.000000;
	ch2->iir[0].B2=0.000000;
	ch2->iir[0].A1=0.000000;
	ch2->iir[0].A2=0.000000;

	ch2->iir[1].B0=1.000000;
	ch2->iir[1].B1=0.000000;
	ch2->iir[1].B2=0.000000;
	ch2->iir[1].A1=0.000000;
	ch2->iir[1].A2=0.000000;

	ch2->iir[2].B0=0.000769;
	ch2->iir[2].B1=0.001538;
	ch2->iir[2].B2=0.000769;
	ch2->iir[2].A1=1.920810;
	ch2->iir[2].A2=-0.923885;
	EnableAxisDest(2,0);

	ch3->InputMode=ENCODER_MODE;
	ch3->OutputMode=STEP_DIR_MODE;
	ch3->Vel=40000.000000;
	ch3->Accel=400000.000000;
	ch3->Jerk=4000000.000000;
	ch3->P=0.000000;
	ch3->I=0.010000;
	ch3->D=0.000000;
	ch3->FFAccel=0.000000;
	ch3->FFVel=0.000000;
	ch3->MaxI=200.000000;
	ch3->MaxErr=1000000.000000;
	ch3->MaxOutput=200.000000;
	ch3->DeadBandGain=1.000000;
	ch3->DeadBandRange=0.000000;
	ch3->InputChan0=2;
	ch3->InputChan1=0;
	ch3->OutputChan0=2;
	ch3->OutputChan1=0;
	ch3->LimitSwitchOptions=0x0;
	ch3->InputGain0=1.000000;
	ch3->InputGain1=1.000000;
	ch3->InputOffset0=0.000000;
	ch3->InputOffset1=0.000000;
	ch3->invDistPerCycle=1.000000;
	ch3->Lead=0.000000;
	ch3->MaxFollowingError=1000000000.000000;
	ch3->StepperAmplitude=20.000000;

	ch3->iir[0].B0=1.000000;
	ch3->iir[0].B1=0.000000;
	ch3->iir[0].B2=0.000000;
	ch3->iir[0].A1=0.000000;
	ch3->iir[0].A2=0.000000;

	ch3->iir[1].B0=1.000000;
	ch3->iir[1].B1=0.000000;
	ch3->iir[1].B2=0.000000;
	ch3->iir[1].A1=0.000000;
	ch3->iir[1].A2=0.000000;

	ch3->iir[2].B0=0.000769;
	ch3->iir[2].B1=0.001538;
	ch3->iir[2].B2=0.000769;
	ch3->iir[2].A1=1.920810;
	ch3->iir[2].A2=-0.923885;
	EnableAxisDest(3,0);
	
	ch4->InputMode=ENCODER_MODE;
	ch4->OutputMode=STEP_DIR_MODE;
	ch4->Vel=40000.000000;
	ch4->Accel=400000.000000;
	ch4->Jerk=4000000.000000;
	ch4->P=0.000000;
	ch4->I=0.010000;
	ch4->D=0.000000;
	ch4->FFAccel=0.000000;
	ch4->FFVel=0.000000;
	ch4->MaxI=200.000000;
	ch4->MaxErr=1000000.000000;
	ch4->MaxOutput=200.000000;
	ch4->DeadBandGain=1.000000;
	ch4->DeadBandRange=0.000000;
	ch4->InputChan0=2;
	ch4->InputChan1=0;
	ch4->OutputChan0=2;
	ch4->OutputChan1=0;
	ch4->LimitSwitchOptions=0x0;
	ch4->InputGain0=1.000000;
	ch4->InputGain1=1.000000;
	ch4->InputOffset0=0.000000;
	ch4->InputOffset1=0.000000;
	ch4->invDistPerCycle=1.000000;
	ch4->Lead=0.000000;
	ch4->MaxFollowingError=1000000000.000000;
	ch4->StepperAmplitude=20.000000;

	ch4->iir[0].B0=1.000000;
	ch4->iir[0].B1=0.000000;
	ch4->iir[0].B2=0.000000;
	ch4->iir[0].A1=0.000000;
	ch4->iir[0].A2=0.000000;

	ch4->iir[1].B0=1.000000;
	ch4->iir[1].B1=0.000000;
	ch4->iir[1].B2=0.000000;
	ch4->iir[1].A1=0.000000;
	ch4->iir[1].A2=0.000000;

	ch4->iir[2].B0=0.000769;
	ch4->iir[2].B1=0.001538;
	ch4->iir[2].B2=0.000769;
	ch4->iir[2].A1=1.920810;
	ch4->iir[2].A2=-0.923885;
	EnableAxisDest(4,0);
	
		ch5->InputMode=ENCODER_MODE;
	ch5->OutputMode=STEP_DIR_MODE;
	ch5->Vel=40000.000000;
	ch5->Accel=400000.000000;
	ch5->Jerk=4000000.000000;
	ch5->P=0.000000;
	ch5->I=0.010000;
	ch5->D=0.000000;
	ch5->FFAccel=0.000000;
	ch5->FFVel=0.000000;
	ch5->MaxI=200.000000;
	ch5->MaxErr=1000000.000000;
	ch5->MaxOutput=200.000000;
	ch5->DeadBandGain=1.000000;
	ch5->DeadBandRange=0.000000;
	ch5->InputChan0=2;
	ch5->InputChan1=0;
	ch5->OutputChan0=2;
	ch5->OutputChan1=0;
	ch5->LimitSwitchOptions=0x0;
	ch5->InputGain0=1.000000;
	ch5->InputGain1=1.000000;
	ch5->InputOffset0=0.000000;
	ch5->InputOffset1=0.000000;
	ch5->invDistPerCycle=1.000000;
	ch5->Lead=0.000000;
	ch5->MaxFollowingError=1000000000.000000;
	ch5->StepperAmplitude=20.000000;

	ch5->iir[0].B0=1.000000;
	ch5->iir[0].B1=0.000000;
	ch5->iir[0].B2=0.000000;
	ch5->iir[0].A1=0.000000;
	ch5->iir[0].A2=0.000000;

	ch5->iir[1].B0=1.000000;
	ch5->iir[1].B1=0.000000;
	ch5->iir[1].B2=0.000000;
	ch5->iir[1].A1=0.000000;
	ch5->iir[1].A2=0.000000;

	ch5->iir[2].B0=0.000769;
	ch5->iir[2].B1=0.001538;
	ch5->iir[2].B2=0.000769;
	ch5->iir[2].A1=1.920810;
	ch5->iir[2].A2=-0.923885;
	EnableAxisDest(2,0);
	
	DefineCoordSystem6(0,1,2,3,4,5);

    return 0;
}
