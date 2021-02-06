using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VO
{
    public class DispendWOVO
    {
        public DateTime wo_sdate { get; set; }
        public int wo_id { get; set; }
        public string machine_id { get; set; }
        public string machine_name { get; set; }
        public string item_id { get; set; }
        public string item_name { get; set; }
        public int wo_qty { get; set; }
        public string unit { get; set; }
        public string wo_state { get; set; }
    }
    public  class DispendVO
    {
        
    }
}
