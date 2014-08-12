using PickandPlace.Pages;
using System;
using System.Collections.Generic;
using System.Data;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PickandPlace
{
    /// <summary>
    /// Interaction logic for pcbvisualiser.xaml
    /// </summary>
    public partial class pcbvisualiser : Window
    {
        DataSet dsData = new DataSet();
        public pcbvisualiser()
        {
            InitializeComponent();

           // BoardPage bp = new BoardPage();
           // dsData = bp.dsData;
            
        }

        public void LoadDataSet(DataSet ds) {
            dsData = ds;
        }

        public void MakePCB()
        {
           
            foreach (DataRow row in dsData.Tables["Components"].Rows)
            {
                Rectangle rect = new Rectangle();
                double placex = double.Parse(row["PlacementX"].ToString()) - 20;
                double placey = double.Parse(row["PlacementY"].ToString()) - 80;

                if (row["PlacementRotate"].ToString().Equals("0"))
                {
                    rect.Width = 4;
                    rect.Height = 8;
                }
                else
                {
                    rect.Width = 8;
                    rect.Height = 4;
                }
                if (row["PlacementNozzle"].ToString().Equals("2"))
                {
                    if (row["PlacementRotate"].ToString().Equals("0"))
                    {
                        rect.Width = 16;
                        rect.Height = 8;
                        placex = placex - 0.5;
                       placey = placey - 1;

                    }
                    else
                    {
                        rect.Width = 8;
                        rect.Height = 16;
                        placex = placex - 1;
                        placey = placey - 0.5;
                    }
                }

                

                    
                rect.Fill = new SolidColorBrush(Colors.Black);

                myCanvas.Children.Add(rect);
                Canvas.SetTop(rect, (placex * 7));
                Canvas.SetLeft(rect, (placey * 7));
                // = 1;
            }

        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
MakePCB();
        }
    }
}
