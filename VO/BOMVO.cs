using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VO
{
    public class BOMVO
    {
        public int bom_id { get; set; }
        public string bom_parent_id { get; set; }
        public string item { get; set; }
        public int bom_use_qty { get; set; }
        public DateTime start_date { get; set; }
        public DateTime end_date { get; set; }
        public string bom_use { get; set; }
        public string plan_use { get; set; }
        public string auto_deduction { get; set; }
        public string bom_comment { get; set; }
        public int bom_level { get; set; }
        public DateTime ins_date { get; set; }
        public string ins_emp { get; set; }
        public DateTime up_date { get; set; }
        public string up_emp { get; set; }

    }
}
