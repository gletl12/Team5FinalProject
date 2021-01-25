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
        public class ShiftService
        {
            public List<MachineVO> GetMachine()
            {
                MachineDAC dac = new MachineDAC();
                return dac.GetMachine();
            }
        }
    }
}
