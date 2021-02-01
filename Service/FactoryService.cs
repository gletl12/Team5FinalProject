using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VO;
using DAC;
using System.Data;

namespace Service
{
    public class FactoryService
    {
        public List<FactoryVO> GetFactory()
        {
            FactoryDAC dac = new FactoryDAC();
            return dac.GetFactory();
        }

        public bool AddFactory(FactoryVO vo)
        {
            FactoryDAC dac = new FactoryDAC();
            return dac.AddFactory(vo);
        }



        //public bool DeleteCommonCode(List<string> codeList)
        //{
        //    CodeDAC dac = new CodeDAC();
        //    return dac.DeleteCommonCode(codeList);
        //}
    }
}
