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
using System.ComponentModel;
using FirstFloor.ModernUI.Presentation;
using System.Data;

namespace PickandPlace.Pages
{
    /// <summary>
    /// Interaction logic for Home.xaml
    /// </summary>
    public partial class Home : UserControl, IContent
    {
        DataSet dsBoards = new DataSet();
        public BackgroundWorker _backgroundWorker = new BackgroundWorker();
        public Home()
        {
            InitializeComponent();
        }
        private void ModernWindow_Initialized(object sender, EventArgs e)
        {
            
           // _backgroundWorker.DoWork += _backgroundWorker_DoWork;
            //_backgroundWorker.RunWorkerCompleted += _backgroundWorker_RunWorkerCompleted;
            // Run the Background Worker 
            //_backgroundWorker.RunWorkerAsync(5000);

        }

        // Worker Method void 
        void _backgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            // Do something 
        }

        // Completed Method 
        void _backgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Cancelled)
            {
                //statusText.Text = "Cancelled";
            }
            else if (e.Error != null)
            {
                //statusText.Text = "Exception Thrown";
            }
            else
            {
                //statusText.Text = "Completed";
            }
        }

        public void OnFragmentNavigation(FragmentNavigationEventArgs e)
        {
           


        }

        public void OnNavigatedFrom(NavigationEventArgs e)
        {
        }
        public void OnNavigatedTo(NavigationEventArgs e)
        {
            if (dsBoards.Tables.Count < 1)
            {
                // load dataset
                dsBoards.ReadXml("datafiles/settings.xml");


                foreach (DataRow row in dsBoards.Tables[1].Rows)
                {
                   
                    this._boardlist.Links.Add(new Link
                    {
                        DisplayName = row["boardname"].ToString(),
                        Source = new Uri("/Pages/BoardPage.xaml#" + row["boardimage"].ToString(), UriKind.Relative)
                    });

                }
            }
        }
        public void OnNavigatingFrom(NavigatingCancelEventArgs e)
        {
        }
      
    }
}
