using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NameName.Model
{
    public class Sys_FormatSerialNo
    {
        //year,month,day,flag,value
        public virtual int FormatId { get; set; }
        public virtual string Flag { get; set; }
        public virtual string Year { get; set; }
        public virtual string Month { get; set; }
        public virtual string Day { get; set; }
        public virtual string Value { get; set; }
        public  override string ToString()
        {
            return Year + Month + Day + Flag + Value;
        }
    }
}
