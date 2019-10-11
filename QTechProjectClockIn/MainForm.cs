using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace QTechProjectClockIn
{
    public partial class MainForm : Form
    {
        private string originalFolderPath = @"C:\Project Clocker Logs";
        private string dateNow;
        private string filePath;
        private ProjCompare projCompare = new ProjCompare();
        private List<Entry> entries = new List<Entry>();
        private Entry curEntry;
        private DataTable dt;
        public MainForm()
        {
            InitializeComponent();
            PopulateDropDown();
            dateNow = DateTime.Now.ToString("ddMMyyyy");
            filePath = @"C:\Project Clocker Logs\" + dateNow + ".txt";
        }

        //================================================================================================================================================//
        // IN BUTTON                                                                                                                                      //
        //================================================================================================================================================//
        private void Btn_IN_Click(object sender, EventArgs e)
        {
            bool entryIsOpen = false;
            StringBuilder stringBuilder = new StringBuilder();
            foreach (Entry item in entries)
            {
                string[] tempStrArr = item.InInfo.Trim().Split(null);
                if (item.IsOpen)
                {
                    entryIsOpen = true;
                    stringBuilder.Append(" " + tempStrArr.Last());
                }
            }

            if (entryIsOpen)
            {
                DialogResult dialog = MessageBox.Show("The following project was not closed:" + stringBuilder.ToString() + "\nDo you wish to close it?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (dialog == DialogResult.Yes)
                {
                    foreach (Entry item in entries)
                    {
                        string[] tempStrArr = item.InInfo.Trim().Split(null);
                        if (item.IsOpen)
                        {
                            item.OutInfo = "OUT " + DateTime.Now.ToString("HH:mm") + " " + tempStrArr.Last();
                            item.IsOpen = false;
                            StreamWriter sw = new StreamWriter(filePath, true);
                            sw.WriteLine(item.OutInfo);
                            sw.Close();
                        }
                    }
                }
            }
            else
            {
                curEntry = new Entry(projNumDrp.SelectedItem.ToString());
                entries.Add(curEntry);
                dateNow = DateTime.Now.ToString("ddMMyyyy");
                filePath = @"C:\Project Clocker Logs\" + dateNow + ".txt";
                curEntry.InInfo = "IN  " + DateTime.Now.ToString("HH:mm") + " " + projNumDrp.SelectedItem.ToString();
                curEntry.IsOpen = true;
                StreamWriter sb = new StreamWriter(filePath, true);
                sb.WriteLine(curEntry.InInfo);
                sb.Close();
                btn_IN.Enabled = false;
                btn_IN.FlatAppearance.BorderColor = Color.LightGray;
                btn_OUT.Enabled = true;
                btn_OUT.FlatAppearance.BorderColor = Color.Black;
            }
            
        }

        //================================================================================================================================================//
        // OUT BUTTON                                                                                                                                     //
        //================================================================================================================================================//
        private void Btn_OUT_Click(object sender, EventArgs e)
        {
            dateNow = DateTime.Now.ToString("ddMMyyyy");
            filePath = @"C:\Project Clocker Logs\" + dateNow + ".txt";
            foreach (Entry item in entries)
            {
                string[] strArr = item.InInfo.Trim().Split(null);
                if (strArr.Last().Equals(projNumDrp.SelectedItem.ToString()))
                {
                    curEntry = item;
                }
            }

            if (curEntry != null)
            {
                curEntry.OutInfo = "OUT " + DateTime.Now.ToString("HH:mm") + " " + projNumDrp.SelectedItem.ToString();
                curEntry.IsOpen = false;
                StreamWriter sb = new StreamWriter(filePath, true);
                sb.WriteLine(curEntry.OutInfo);
                sb.Close();
                btn_OUT.Enabled = false;
                btn_OUT.FlatAppearance.BorderColor = Color.LightGray;
                btn_IN.Enabled = true;
                btn_IN.FlatAppearance.BorderColor = Color.Black;
                entries.Remove(curEntry);
            }
            else
            {
                StreamWriter sb = new StreamWriter(filePath, true);
                sb.WriteLine("OUT " + DateTime.Now.ToString("HH:mm") + " " + projNumDrp.SelectedItem.ToString());
                sb.Close();
                btn_OUT.Enabled = false;
                btn_OUT.FlatAppearance.BorderColor = Color.LightGray;
                btn_IN.Enabled = true;
                btn_IN.FlatAppearance.BorderColor = Color.Black;
            }
        }

        //================================================================================================================================================//
        // FORM LOAD                                                                                                                                      //
        //================================================================================================================================================//
        private void MainForm_Load(object sender, EventArgs e)
        {
            dateNow = DateTime.Now.ToString("ddMMyyyy");
            filePath = @"C:\Project Clocker Logs\" + dateNow + ".txt";
            if (!Directory.Exists(originalFolderPath))
            {
                Directory.CreateDirectory(originalFolderPath);
            }
            if (!File.Exists(filePath))
            {
                File.Create(filePath).Close();
                StreamWriter sb = new StreamWriter(filePath, true);
                sb.WriteLine("===============================================");
                sb.WriteLine(DateTime.Now.ToString("dddd, dd MMMM yyyy"));
                sb.WriteLine("===============================================");
                sb.Close();
            }
        }

        //================================================================================================================================================//
        // FORM CLOSING                                                                                                                                   //
        //================================================================================================================================================//
        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            bool entryIsOpen = false;
            dateNow = DateTime.Now.ToString("ddMMyyyy");
            filePath = @"C:\Project Clocker Logs\" + dateNow + ".txt";
            StringBuilder sb = new StringBuilder();
            foreach (Entry item in entries)
            {
                string[] tempStrArr = item.InInfo.Trim().Split(null);
                if (item.IsOpen)
                {
                    entryIsOpen = true;
                    sb.Append(" " + tempStrArr.Last());
                }
            }

            if (entryIsOpen)
            {
                DialogResult dialog = MessageBox.Show("The following project was not closed:" + sb.ToString() + "\nDo you wish to close it?", "Warning", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                if (dialog == DialogResult.OK)
                {
                    foreach (Entry item in entries)
                    {
                        string[] tempStrArr = item.InInfo.Trim().Split(null);
                        if (item.IsOpen)
                        {
                            item.OutInfo = "OUT " + DateTime.Now.ToString("HH:mm") + " " + tempStrArr.Last();
                            item.IsOpen = false;
                            StreamWriter sw = new StreamWriter(filePath, true);
                            sw.WriteLine(item.OutInfo);
                            sw.Close();
                        }
                    }
                }
                else if (dialog == DialogResult.Cancel)
                    e.Cancel = true;
            }
        }

        //================================================================================================================================================//
        // IN & OUT BUTTON COLOR CHANGE ON ENTER AND LEAVE                                                                                                //
        //================================================================================================================================================//
        private void Btn_IN_MouseEnter(object sender, EventArgs e)
        {
            btn_IN.ForeColor = Color.White;
        }

        private void Btn_IN_MouseLeave(object sender, EventArgs e)
        {
            btn_IN.ForeColor = Color.FromArgb(64, 64, 64);
        }

        private void Btn_OUT_MouseEnter(object sender, EventArgs e)
        {
            btn_OUT.ForeColor = Color.White;
        }

        private void Btn_OUT_MouseLeave(object sender, EventArgs e)
        {
            btn_OUT.ForeColor = Color.FromArgb(64, 64, 64);
        }

        //================================================================================================================================================//
        // DROPDOWN CODE                                                                                                                                  //
        //================================================================================================================================================//

        private void PopulateDropDown()
        {
            using (SqlConnection conn = DBUtils.GetDBConnection())
            {
                conn.Open();
                SqlDataAdapter da = new SqlDataAdapter("SELECT Timekeeping_Data FROM Projects", conn);
                dt = new DataTable();
                da.Fill(dt);
                foreach (DataRow row in dt.Rows)
                {
                    projNumDrp.Items.Add(row["Timekeeping_Data"].ToString());
                }
            }
        }

        private void ProjNumDrp_onItemSelected(object sender, EventArgs e)
        {
            if (btn_OUT.Enabled)
            {
                btn_OUT.Enabled = false;
                btn_OUT.FlatAppearance.BorderColor = Color.LightGray;
            }

            if (btn_IN.Enabled)
            {
                btn_IN.Enabled = false;
                btn_IN.FlatAppearance.BorderColor = Color.LightGray;
            }

            btn_IN.Enabled = true;
            btn_IN.FlatAppearance.BorderColor = Color.Black;

            if (curEntry != null)
            {
                if (curEntry.ProjCode == projNumDrp.SelectedItem.ToString())
                {
                    btn_IN.Enabled = false;
                    btn_IN.FlatAppearance.BorderColor = Color.LightGray;
                    btn_OUT.Enabled = true;
                    btn_OUT.FlatAppearance.BorderColor = Color.Black;
                }
                else
                {
                    btn_IN.Enabled = true;
                    btn_IN.FlatAppearance.BorderColor = Color.Black;
                    btn_OUT.Enabled = false;
                    btn_OUT.FlatAppearance.BorderColor = Color.LightGray;
                }
            }
        }

        private void ProjNumDrp_MouseEnter(object sender, EventArgs e)
        {
            projNumDrp.ForeColor = Color.White;
            projNumDrp.BackColor = Color.FromArgb(19, 118, 188);
        }

        private void ProjNumDrp_MouseLeave(object sender, EventArgs e)
        {
            projNumDrp.ForeColor = Color.Black;
            projNumDrp.BackColor = Color.White;
        }

        private void ProjNumDrp_KeyDown(object sender, KeyEventArgs e)
        {
            e.SuppressKeyPress = true;
        }

        private void ProjNumDrp_KeyUp(object sender, KeyEventArgs e)
        {
            e.SuppressKeyPress = false;
        }
    }

    //================================================================================================================================================//
    // PROJECT CODE COMPARER                                                                                                                          //
    //================================================================================================================================================//
    public class ProjCompare : IComparer<string>
    {
        public int Compare(string x, string y)
        {
            string[] xStrArr = x.Trim().Split(null);
            string[] yStrArr = y.Trim().Split(null);

            return xStrArr.Last().CompareTo(yStrArr.Last());
        }
    } 
}
