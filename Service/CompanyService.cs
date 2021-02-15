using DAC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VO;

namespace Service
{
    public class CompanyService
    {
        public List<CompanyVO> GetCompany()
        {
            CompanyDAC dac = new CompanyDAC();
            return dac.GetCompany();
        }
    }
}
