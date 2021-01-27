using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VO
{
    public class SalesOrderVO
    {
        public int so_id { get; set; }
        public DateTime plan_date { get; set; }
        public int company_id { get; set; }
        public int item_id { get; set; }
        public string order_id { get; set; }
        public DateTime due_date { get; set; }
        public int so_qty { get; set; }
        public string so_comment { get; set; }
        public int warehouse_id { get; set; }
        public int c_qty { get; set; }
        public string mkt { get; set; }
        public string currency { get; set; }
        public string so_state { get; set; }
        public DateTime ins_date { get; set; }
        public string ins_emp { get; set; }
        public DateTime up_date { get; set; }
        public string up_emp { get; set; }

    }
}
