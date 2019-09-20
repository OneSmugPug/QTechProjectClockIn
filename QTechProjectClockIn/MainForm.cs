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
        private string newLog;
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
                btn_OUT.Enabled = false;

            if (btn_IN.Enabled)
                btn_IN.Enabled = false;

            // Checks if the text box is empty
            if (!String.IsNullOrEmpty(projNum_Txt.Text))
            {
                btn_IN.Enabled = true;
            }

            // Checks if the current project has already been clocked IN
            string[] lines = File.ReadAllLines(filePath);
            string[] filteredLines = Array.FindAll(lines, l => l.Contains(projNum_Txt.Text));
            if (filteredLines.Length != 0 && filteredLines.Last().Contains("IN"))
            {
                btn_IN.Enabled = false;
                btn_OUT.Enabled = true;
            }
        }

        //================================================================================================================================================//
        // IN BUTTON                                                                                                                                      //
        //================================================================================================================================================//
        private void Btn_IN_Click(object sender, EventArgs e)
        {
            Entry newEntry = new Entry();
            entries.Add(newEntry);
            dateNow = DateTime.Now.ToString("ddMMyyyy");
            filePath = @"C:\Project Clocker Logs\" + dateNow + ".txt";
            newEntry.InInfo = "IN  " + DateTime.Now.ToString("HH:mm") + " " + projNum_Txt.Text;
            newEntry.IsOpen = true;
            StreamWriter sb = new StreamWriter(filePath, true);
            sb.WriteLine(newEntry.InInfo);
            sb.Close();
            btn_IN.Enabled = false;
            btn_OUT.Enabled = true;
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
                btn_IN.Enabled = true;
                entries.Remove(curEntry);
            }
            else
            {
                StreamWriter sb = new StreamWriter(filePath, true);
                sb.WriteLine("OUT " + DateTime.Now.ToString("HH:mm") + " " + projNum_Txt.Text);
                sb.Close();
                btn_OUT.Enabled = false;
                btn_IN.Enabled = true;
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
            //SortTextFile();
        }

        //================================================================================================================================================//
        // SORT TEXT FILE                                                                                                                                 //
        //================================================================================================================================================//
        private void SortTextFile()
        {
            
            dateNow = DateTime.Now.ToString("ddMMyyyy");
            filePath = @"C:\Project Clocker Logs\" + dateNow + ".txt";
            var contents = File.ReadAllLines(filePath);
            if (contents.Length != 0)
            {
                var contentList = new List<string>(contents);
                contentList.RemoveAt(0);
                contentList.RemoveAt(1);
                contentList.RemoveAt(2);
                contentList.Sort(projCompare);
                StreamWriter sb = new StreamWriter(filePath, true);
                foreach (var item in contentList)
                    sb.WriteLine(item);
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
                DialogResult dialog = MessageBox.Show("The following projects were not closed:" + sb.ToString() + "\nDo you wish to close them?", "Warning", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);
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
                else if (dialog == DialogResult.No)
                    e.Cancel = false;
                else if (dialog == DialogResult.Cancel)
                    e.Cancel = true;
            }
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
