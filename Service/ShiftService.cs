using DAC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VO;

namespace Service
{
    public class ShiftService
    {
        public List<ShiftVO> GetShift()
        {
            ShiftDAC dac = new ShiftDAC();
            return dac.GetShift();
        }
    }
}
