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

namespace PickandPlace.Content
{
    /// <summary>
    /// Interaction logic for SettingsComponents.xaml
    /// </summary>
    public partial class SettingsComponents : UserControl
    {
        DataSet ds = new DataSet();
        Components comp = new Components();
        public SettingsComponents()
        {
            InitializeComponent();
            ds = comp.POPComponentsTable();
            dg_data.DataContext = ds.Tables[0].DefaultView;
           // MessageBox.Show(ds.Tables[0].Rows.Count.ToString());
            
        }

        private void bt_save_Click(object sender, RoutedEventArgs e)
        {
            comp.SaveDataSet(ds);
            MessageBox.Show("Saved Changes");
        }

        private void dg_data_RowEditEnding(object sender, DataGridRowEditEndingEventArgs e)
        {
            if (e.EditAction == DataGridEditAction.Commit)
            {

               // FormulaOneDriver driver = e.Row.DataContext as FormulaOneDriver;

               // driver.Save();

            }
        }
    }
}
