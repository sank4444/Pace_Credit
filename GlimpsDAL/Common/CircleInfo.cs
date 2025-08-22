using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GlimpsDAL.Common
{
  public class CircleInfo
    {

        public string CircleCode { get; set; }
        public string CircleName { get; set; }
        public string RechargeValue { get; set; }
        public string Validity { get; set; }
        public string SumAsured { get; set; }
        public int UserID { get; set; }
        public bool IsActive { get; set; }
        public int CircleUID { get; set; }
    }
}
