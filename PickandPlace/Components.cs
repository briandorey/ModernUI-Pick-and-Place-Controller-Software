using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace PickandPlace
{
    public class Components
    {
        private DataSet dscomponents = new DataSet();

        public DataSet POPComponentsTable()
        {
            dscomponents.EnforceConstraints = false;
            FileStream finschema = new FileStream(System.IO.Path.GetDirectoryName(Application.ExecutablePath) + "/datafiles/components.xsd", FileMode.Open, FileAccess.Read, FileShare.Read);
            dscomponents.ReadXmlSchema(finschema);
            finschema.Close();
            FileStream findata = new FileStream(System.IO.Path.GetDirectoryName(Application.ExecutablePath) +  "/datafiles/components.xml", FileMode.Open,
                                 FileAccess.Read, FileShare.ReadWrite);
            dscomponents.ReadXml(findata);
            findata.Close();
            return dscomponents;
        }

        public void SaveDataSet(DataSet ds)
        {
            System.IO.StreamWriter xmlSW = new System.IO.StreamWriter(System.IO.Path.GetDirectoryName(Application.ExecutablePath) + "/datafiles/components.xml");
            ds.WriteXml(xmlSW, XmlWriteMode.WriteSchema);
            xmlSW.Close();
        }
        public string GetComponentValue(string fid)
        {
            if (dscomponents.Tables.Count == 0)
            {
                POPComponentsTable();
            }
            DataView dv = new DataView(dscomponents.Tables[0]);
            dv.RowFilter = "ComponentCode = " + fid;
            string returnval = "";
            if (dv.Count > 0)
            {
                returnval = dv[0]["ComponentValue"].ToString();
            }
            dv.Dispose();
            return returnval;
        }
        public string GetComponentPackage(string fid)
        {
            if (dscomponents.Tables.Count == 0)
            {
                POPComponentsTable();
            }
            DataView dv = new DataView(dscomponents.Tables[0]);
            dv.RowFilter = "ComponentCode = " + fid;
            string returnval = "";
            if (dv.Count > 0)
            {
                returnval = dv[0]["Package"].ToString();
            }
            dv.Dispose();
            return returnval;
        }
        public double GetPlacementHeight(string fid)
        {
            if (dscomponents.Tables.Count == 0)
            {
                POPComponentsTable();
            }
            DataView dv = new DataView(dscomponents.Tables[0]);
            dv.RowFilter = "ComponentCode = " + fid;
            double returnval = 0.0;
            if (dv.Count > 0)
            {
                returnval = double.Parse(dv[0]["PlacementHeight"].ToString());
            }
            dv.Dispose();
            return returnval;
        }
        public double GetFeederHeight(string fid)
        {
            if (dscomponents.Tables.Count == 0)
            {
                POPComponentsTable();
            }
            DataView dv = new DataView(dscomponents.Tables[0]);
            dv.RowFilter = "ComponentCode = " + fid;
            double returnval = 0.0;
            if (dv.Count > 0)
            {
                returnval = double.Parse(dv[0]["FeederHeight"].ToString());
            }
            dv.Dispose();
            return returnval;
        }

        public double GetFeederX(string fid)
        {
            if (dscomponents.Tables.Count == 0)
            {
                POPComponentsTable();
            }
            DataView dv = new DataView(dscomponents.Tables[0]);
            dv.RowFilter = "ComponentCode = " + fid;
            double returnval = 0.0;
            if (dv.Count > 0)
            {
                returnval = double.Parse(dv[0]["FeederX"].ToString());
            }
            dv.Dispose();
            return returnval;
        }

        public double GetFeederY(string fid)
        {
            if (dscomponents.Tables.Count == 0)
            {
                POPComponentsTable();
            }
            DataView dv = new DataView(dscomponents.Tables[0]);
            dv.RowFilter = "ComponentCode = " + fid;
            double returnval = 0.0;
            if (dv.Count > 0)
            {
                returnval = double.Parse(dv[0]["FeederY"].ToString());
            }
            dv.Dispose();
            return returnval;
        }

        public int GetPickerNozzle(string fid)
        {
            if (dscomponents.Tables.Count == 0)
            {
                POPComponentsTable();
            }
            DataView dv = new DataView(dscomponents.Tables[0]);
            dv.RowFilter = "ComponentCode = " + fid;
            int returnval = 0;
            if (dv.Count > 0)
            {
                returnval = int.Parse(dv[0]["PickerNozzle"].ToString());
            }
            dv.Dispose();
            return returnval;
        }

        public int GetFeederID(string fid)
        {
            if (dscomponents.Tables.Count == 0)
            {
                POPComponentsTable();
            }
            DataView dv = new DataView(dscomponents.Tables[0]);
            dv.RowFilter = "ComponentCode = " + fid;
            int returnval = 0;
            if (dv.Count > 0)
            {
                returnval = int.Parse(dv[0]["FeederID"].ToString());
            }
            dv.Dispose();
            return returnval;
        }
        public bool GetComponentVerifywithCamera(string fid)
        {
            if (dscomponents.Tables.Count == 0)
            {
                POPComponentsTable();
            }
            DataView dv = new DataView(dscomponents.Tables[0]);
            dv.RowFilter = "ComponentCode = " + fid;
            bool returnval = false;
            if (dv.Count > 0)
            {
                if (dv[0]["VerifywithCamera"].ToString().Equals("True"))
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

        public bool GetComponentTapeFeeder(string fid)
        {
            if (dscomponents.Tables.Count == 0)
            {
                POPComponentsTable();
            }
            DataView dv = new DataView(dscomponents.Tables[0]);
            dv.RowFilter = "ComponentCode = " + fid;
            bool returnval = false;
            if (dv.Count > 0)
            {

                if (dv[0]["TapeFeeder"].ToString().Equals("True"))
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
