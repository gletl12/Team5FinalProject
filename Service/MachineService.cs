using DAC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VO;

namespace Service
{
   public class MachineService
    {
       
       public List<MachineVO> GetMachine()
       {
           MachineDAC dac = new MachineDAC();
           return dac.GetMachine();
       }
        public int MachineRun(string task_ID, string workUserName)
        {
            MachineDAC dac = new MachineDAC();
            return dac.MachineRun(task_ID, workUserName);
        }
        
        public bool MachineEnd(int runid, string workUserName)
        {
            MachineDAC dac = new MachineDAC();
            return dac.MachineEnd(runid, workUserName);
        }
    }
}
