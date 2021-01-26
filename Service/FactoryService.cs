using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VO;
using DAC;

namespace Service
{
    public class FactoryService
    {
        public List<FactoryVO> GetCommonCode()
        {
            FactoryDAC dac = new FactoryDAC();
            return dac.GetFactory();
        }

        //public List<CodeVO> GetAllCommonCode()
        //{
        //    CodeDAC dac = new CodeDAC();
        //    return dac.GetAllCommonCode();
        //}

        //public bool AddCommonCode(CodeVO codeVO)
        //{
        //    CodeDAC dac = new CodeDAC();
        //    return dac.AddCommonCode(codeVO);
        //}

        //public bool EditCommonCode(CodeVO codeVO)
        //{
        //    CodeDAC dac = new CodeDAC();
        //    return dac.EditCommonCode(codeVO);
        //}

        //public bool DeleteCommonCode(List<string> codeList)
        //{
        //    CodeDAC dac = new CodeDAC();
        //    return dac.DeleteCommonCode(codeList);
        //}
    }
}
