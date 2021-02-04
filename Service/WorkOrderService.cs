using DAC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VO;

namespace Service
{
    public class WorkOrderService
    {

        public List<WorkOrderVO> GetWorkOrder()
        {
            WorkOrderDAC dac = new WorkOrderDAC();
            return dac.GetWorkOrder();
        }
    }
}
