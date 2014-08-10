using Emgu.CV;
using Emgu.CV.Structure;
using System;
using System.Collections.Generic;
using System.Drawing;
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

namespace PickandPlace
{
    /// <summary>
    /// Interaction logic for CameraWindow.xaml
    /// </summary>
    public partial class CameraWindow : Window
    {
        private Image<Bgr, Byte> frame;
        private Capture capture = null;
        private DispatcherTimer timer;
        private bool isrunning = false;
        private Byte[] buffer = new Byte[1];


        public CameraWindow()
        {
            InitializeComponent();

            InitializeCameras();

            timer = new DispatcherTimer();
            timer.Tick += new EventHandler(ProcessFrame);
            timer.Interval = new TimeSpan(0, 0, 0, 0, 40);

        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            if (!isrunning)
            {

                timer.Start();
                button1.Content = "Stop Camera";
                
                isrunning = true;
            }
            else
            {
                timer.Stop();
                button1.Content = "Start Camera";
                
                isrunning = false;
            }
        }


        private void InitializeCameras()
        {
            if (capture == null)
            {
                try
                {
                    capture = new Capture(1);
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.ToString());
                }
            }
        }

        private void ProcessFrame(object sender, EventArgs arg)
        {
            frame = capture.QueryFrame();


            if (frame != null)
            {

                // add cross hairs to image
                int totalwidth = frame.Width;
                int totalheight = frame.Height;
                PointF[] linepointshor = new PointF[] { 
                    new PointF(0, totalheight/2),
                    new PointF(totalwidth, totalheight/2)
                  
                };
                PointF[] linepointsver = new PointF[] { 
                    new PointF(totalwidth/2, 0),
                    new PointF(totalwidth/2, totalheight)
                  
                };

                frame.DrawPolyline(Array.ConvertAll<PointF, System.Drawing.Point>(linepointshor, System.Drawing.Point.Round), false, new Bgr(System.Drawing.Color.AntiqueWhite), 1);
                frame.DrawPolyline(Array.ConvertAll<PointF, System.Drawing.Point>(linepointsver, System.Drawing.Point.Round), false, new Bgr(System.Drawing.Color.AntiqueWhite), 1);




            }
            CapturedImageBox.Image = frame;

        }
    }
    public static class BitmapSourceConvert
    {
        /// <summary>
        /// Delete a GDI object
        /// </summary>
        /// <param name="o">The poniter to the GDI object to be deleted</param>
        /// <returns></returns>
        [DllImport("gdi32")]
        private static extern int DeleteObject(IntPtr o);

        /// <summary>
        /// Convert an IImage to a WPF BitmapSource. The result can be used in the Set Property of Image.Source
        /// </summary>
        /// <param name="image">The Emgu CV Image</param>
        /// <returns>The equivalent BitmapSource</returns>
        public static BitmapSource ToBitmapSource(IImage image)
        {
            using (System.Drawing.Bitmap source = image.Bitmap)
            {
                IntPtr ptr = source.GetHbitmap(); //obtain the Hbitmap

                BitmapSource bs = System.Windows.Interop.Imaging.CreateBitmapSourceFromHBitmap(
                    ptr,
                    IntPtr.Zero,
                    Int32Rect.Empty,
                    System.Windows.Media.Imaging.BitmapSizeOptions.FromEmptyOptions());

                DeleteObject(ptr); //release the HBitmap
                return bs;
            }
        }
    }
}
