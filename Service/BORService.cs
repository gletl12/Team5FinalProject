using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VO;

namespace Service
{
    public class BORService
    {
        public List<CodeVO> GetBORCode()
        {
            DAC.BORDAC dac = new DAC.BORDAC();
            return dac.GetBORCode();
        }
    }
}
