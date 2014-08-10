using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace PickandPlace
{
    public class DataHelpers
    {
        // helper functions for gridview setup

        public void SetupTextColumn(DataGrid dg, string header, string binding, bool ReadOnly)
        {
            Style s = new Style();
            s.Setters.Add(new Setter(TextBlock.TextAlignmentProperty, TextAlignment.Center));

            DataGridTextColumn dgvc = new DataGridTextColumn();
            dgvc.Header = header;
            dgvc.Binding = new Binding(binding);
            dgvc.IsReadOnly = ReadOnly;
            dgvc.Width = new DataGridLength(1, DataGridLengthUnitType.Star);
            dgvc.CellStyle = s;
            dg.Columns.Add(dgvc);
        }
        public void SetupCheckBoxColumn(DataGrid dg, string header, string binding, bool ReadOnly)
        {
            Style s = new Style();
            s.Setters.Add(new Setter(TextBlock.TextAlignmentProperty, TextAlignment.Center));

            DataGridCheckBoxColumn dgvc = new DataGridCheckBoxColumn();
            dgvc.Header = header;
            dgvc.Binding = new Binding(binding);
            dgvc.IsReadOnly = ReadOnly;
            dgvc.Width = new DataGridLength(1, DataGridLengthUnitType.Star);
            dgvc.CellStyle = s;
            dg.Columns.Add(dgvc);
        }

        // defaults for nozzle spacings to camera
        public double Nozzle1Xoffset = -20.57;
        public double Nozzle1Yoffset = 7.16;

        public double Nozzle2Xoffset = 11.74;
        public double Nozzle2Yoffset = 7.22;
    }
}
