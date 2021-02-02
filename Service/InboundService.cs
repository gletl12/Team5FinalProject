using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAC;
using VO;
namespace Service
{
    public class InboundService
    {
        public List<InboundVO> GetPurchasesList()
        {
            InboundDAC dac = new InboundDAC();
            return dac.GetPurchasesList();
        }

        public bool NewInbound(List<InboundVO> selectedRows)
        {
            InboundDAC dac = new InboundDAC();
            return dac.NewInbound(selectedRows);
        }
    }
}
