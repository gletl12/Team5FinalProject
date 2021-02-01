using DAC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VO;

namespace Service
{
    public class EmployeeService
    {
        public (bool, EmployeeVO) GetLogin(string id, string pwd)
        {
            EmployeeDAC dac = new EmployeeDAC();
            return dac.GetLogin(id,pwd);
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
