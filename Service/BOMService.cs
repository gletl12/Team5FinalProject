using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VO;

namespace Service
{
    public class BOMService
    {
        public List<CodeVO> GetBOMCode()
        {
            DAC.BOMDAC dac = new DAC.BOMDAC();
            return dac.GetBOMCode();
        }
    }
}
