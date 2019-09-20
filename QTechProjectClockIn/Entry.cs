using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QTechProjectClockIn
{
    class Entry
    {
        private string projCode;
        private string inInfo;
        private string outInfo;
        private bool isOpen = false;

        public Entry(string projCode)
        {
            this.projCode = projCode;
        }

        public string InInfo { get => inInfo; set => inInfo = value; }
        public string OutInfo { get => outInfo; set => outInfo = value; }
        public bool IsOpen { get => isOpen; set => isOpen = value; }
        public string ProjCode { get => projCode; set => projCode = value; }
    }
}
