﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PickandPlace
{
    public class DataComponentFeeders
    {
        public DataTable dtfeeder = new DataTable();


        public DataTable POPFeedersTable()
        {
    

            
            dtfeeder.Columns.Add("feederNumber", typeof(int));
            dtfeeder.Columns.Add("PosX", typeof(double));
            dtfeeder.Columns.Add("PosY", typeof(double));
            dtfeeder.Columns.Add("PosZ", typeof(double));
            dtfeeder.Columns.Add("FeederActivationCode", typeof(string));
            dtfeeder.Columns.Add("PickPlusChipHeight", typeof(bool));


            // tape feeders
            dtfeeder.Rows.Add(0, 30.6, 8.720, 3.2, "M90100", false); // empty
            dtfeeder.Rows.Add(1, 50.53, 8.745, 3.0, "M90101", false); // dual mosfet
            dtfeeder.Rows.Add(2, 70.6, 8.571, 3.2, "M90102", false); // 10uf
            dtfeeder.Rows.Add(3, 90.4, 8.9, 2.3, "M90103", false); // 100nf
            dtfeeder.Rows.Add(4, 110.35, 8.83, 2.8, "M90104", false); // 10K res
            dtfeeder.Rows.Add(5, 130.7, 8.758, 2.6, "M90105", false); // 6K8 res
            dtfeeder.Rows.Add(6, 150.33, 8.53, 2.6, "M90106", false); // 100R
            dtfeeder.Rows.Add(7, 170.0, 8.667, 3.2, "M90107", false); // 10Kx4
            dtfeeder.Rows.Add(8, 189.76, 8.47, 3.2, "M90108", false); // 2K2 x 4
            dtfeeder.Rows.Add(9, 209.75, 8.049, 3.2, "M90109", false); // 1K
            dtfeeder.Rows.Add(10, 229.63, 7.975, 3.2, "M90110", false); // signal diode
            dtfeeder.Rows.Add(11, 249.5, 8.00, 3.2, "M90111", false); // 220R x 4
            dtfeeder.Rows.Add(12, 269.39, 7.826, 3.2, "M90112", false);
            dtfeeder.Rows.Add(13, 289.17, 7.751, 3.2, "M90113", false);
            dtfeeder.Rows.Add(14, 309.17, 7.677, 3.2, "M90114", false);
            dtfeeder.Rows.Add(15, 328.77, 7.602, 3.2, "M90115", false);
            // chip feeders
            dtfeeder.Rows.Add(21, 16.77, 386.21, 7.7, "", true); // 
            dtfeeder.Rows.Add(22, 44.2, 385.99, 7.7, "", true); // SOIC28
            dtfeeder.Rows.Add(23, 72.7, 386.21, 8.1, "", true); // SOIC16
            dtfeeder.Rows.Add(24, 100.75, 386.21, 7.6, "", true); // SOIC14
            dtfeeder.Rows.Add(25, 128.035, 385.808, 7.9, "", true); // SOIC8
            dtfeeder.Rows.Add(26, 156.3, 385.85, 8.3, "", true); // SOIC8
            return dtfeeder;

        }
        public void CheckHasRows()
        {
            if (dtfeeder.Rows.Count == 0)
            {
                POPFeedersTable();
            }
        }

        public double GetfeederPosX(string fid)
        {
            CheckHasRows();
            DataView dv = new DataView(dtfeeder);
            dv.RowFilter = "feederNumber = " + fid;
            double returnval = 0.0;
            if (dv.Count > 0)
            {
                returnval = double.Parse(dv[0]["PosX"].ToString());
            }
            dv.Dispose();
            return returnval;
        }
        public double GetfeederPosY(string fid)
        {
            CheckHasRows();
            DataView dv = new DataView(dtfeeder);
            dv.RowFilter = "feederNumber = " + fid;
            double returnval = 0.0;
            if (dv.Count > 0)
            {
                returnval = double.Parse(dv[0]["PosY"].ToString());
            }
            dv.Dispose();
            return returnval;
        }
        public double GetfeederPosZ(string fid)
        {
            CheckHasRows();
            DataView dv = new DataView(dtfeeder);
            dv.RowFilter = "feederNumber = " + fid;
            double returnval = 0.0;
            if (dv.Count > 0)
            {
                returnval = double.Parse(dv[0]["PosZ"].ToString());
            }
            dv.Dispose();
            return returnval;
        }



        public string GetfeederActivationCode(string fid)
        {
            CheckHasRows();
            DataView dv = new DataView(dtfeeder);
            dv.RowFilter = "feederNumber = " + fid;
            string returnval = "";
            if (dv.Count > 0)
            {
                returnval = dv[0]["FeederActivationCode"].ToString();
            }
            dv.Dispose();
            return returnval;
        }

        public bool GetFeederPickPlusChipHeight(string fid)
        {
            CheckHasRows();
            DataView dv = new DataView(dtfeeder);
            dv.RowFilter = "feederNumber = " + fid;
            bool returnval = false;
            if (dv.Count > 0)
            {
                if (dv[0]["PickPlusChipHeight"].ToString().Equals("True"))
                {
                    returnval = true;
                }
                else
                {
                    returnval = false;
                }
            }
            dv.Dispose();
            return returnval;
        }
    }
}
