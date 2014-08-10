ModernUI Pick and Place Controller Software
==================

This application is a Windows C# control application to run a DIY pick and place machine via A KFlop motion controller and Windows PC with a custom USB controller board to control feeders and other hardware interfaces. 

The software is built using C# and the ModernUI theme from http://http://mui.codeplex.com/ and uses Modern UI Icons from http://www.modernuiicons.com 

The camera vision uses Emgu CV from http://www.emgu.com/wiki/index.php/Main_Page which uses a basic usb microscope camera to look down on to the pcb to locate the parts. This is saved into a XML data file as a series of X & Y locations and the control software adds the correct offset depending on the selected picker nozzle.

The USB controller board prototype is on http://briandorey.com/post/pick-and-place-controller-v3-part-1.aspx

Photos and info for the completed driver board are on http://briandorey.com/post/pick-and-place-controller-v3-part-2.aspx

Full details of this project are on my blog at http://www.briandorey.com/

The project was built under Visual Studio 2013.

The project requires KMotion to be installed from

http://dynomotion.com/Software/Download.html
The build path on the project is currently set to: C:\KMotion432\KMotion\Release\ and this would need to be updated to build to the correct folder for different versions of the KMotion software.