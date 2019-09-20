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
        public MainForm()
        {
            InitializeComponent();
        }

        //================================================================================================================================================//
        // PROJECT NUMBER TEXTBOX                                                                                                                         //
        //================================================================================================================================================//
        private void ProjNum_Txt_TextChanged(object sender, EventArgs e)
        {
            dateNow = DateTime.Now.ToString("ddMMyyyy");
            filePath = @"C:\Project Clocker Logs\" + dateNow + ".txt";
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

            // Checks if the text box is empty
            if (!String.IsNullOrEmpty(projNum_Txt.Text))
            {
                btn_IN.Enabled = true;
                btn_IN.FlatAppearance.BorderColor = Color.Black;
            }

            if (curEntry != null)
            {
                if (curEntry.ProjCode == projNum_Txt.Text)
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
                curEntry = new Entry(projNum_Txt.Text);
                entries.Add(curEntry);
                dateNow = DateTime.Now.ToString("ddMMyyyy");
                filePath = @"C:\Project Clocker Logs\" + dateNow + ".txt";
                curEntry.InInfo = "IN  " + DateTime.Now.ToString("HH:mm") + " " + projNum_Txt.Text;
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
                if (strArr.Last().Equals(projNum_Txt.Text))
                {
                    curEntry = item;
                }
            }

            if (curEntry != null)
            {
                curEntry.OutInfo = "OUT " + DateTime.Now.ToString("HH:mm") + " " + projNum_Txt.Text;
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
                sb.WriteLine("OUT " + DateTime.Now.ToString("HH:mm") + " " + projNum_Txt.Text);
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
