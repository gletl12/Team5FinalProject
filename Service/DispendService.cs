using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VO;
using DAC;  
namespace Service
{
    public class DispendService
    {
        public List<CodeVO> GetMachineCodes()
        {
            DispendDAC dac = new DispendDAC();
            return dac.GetMachineCodes();
        }

        public List<DispendWOVO> GetWorkOrderList(DateTime from, DateTime to)
        {
            DispendDAC dac = new DispendDAC();
            return dac.GetWorkOrderList(from,to);
        }

        public bool GetDispendInfo(List<int> selectedRows)
        {
            throw new NotImplementedException();
        }
    }
}
