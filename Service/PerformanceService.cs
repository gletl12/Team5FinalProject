using DAC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VO;

namespace Service
{
    public class PerformanceService
    {
        public List<PerformanceVO> GetPerformanceList(DateTime from, DateTime to)
        {
            PerformanceDAC dac = new PerformanceDAC();
            return dac.GetPerformanceList(from, to);
        }

        public List<CodeVO> GetAllCodes()
        {
            PerformanceDAC dac = new PerformanceDAC();
            return dac.GetAllCodes();
        }

        public bool PerformanceCommit(List<int> selectedIDs,int empID)
        {
            PerformanceDAC dac = new PerformanceDAC();
            return dac.PerformanceCommit(selectedIDs,empID);
        }
    }
}
